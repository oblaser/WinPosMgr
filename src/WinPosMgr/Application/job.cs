/*!

\author         Oliver Blaser

\date           16.12.2020

\copyright      GNU GPLv3 - Copyright (c) 2020 Oliver Blaser

\brief          

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinPosMgr.Application
{
    public class Job
    {
        public const int IDstart = 100;

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order.
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowpos
        /// </summary>
        /// <param name="hWnd">A handle to the window</param>
        /// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order. This parameter must be a window handle or one of the following values (see online reference).</param>
        /// <param name="x">The new position of the left side of the window, in client coordinates</param>
        /// <param name="y">The new position of the top of the window, in client coordinates.</param>
        /// <param name="cx">The new width of the window, in pixels.</param>
        /// <param name="cy">The new height of the window, in pixels.</param>
        /// <param name="uFlags">The window sizing and positioning flags (see online reference).</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);
        private const int HWND_BOTTOM = 1;
        private const int HWND_NOTOPMOST = -2;
        private const int HWND_TOP = 0;
        private const int HWND_TOPMOST = -1;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;

        private static void error(string msg, Application.Settings.OpMode opMode, Application.Settings.ErrorReporting opModeRunErrorReporting)
        {
            if ((opMode == Settings.OpMode.gui) || (opModeRunErrorReporting == Settings.ErrorReporting.MsgBox))
            {
                Forms.MessageBox.Error(msg);
            }
        }
        private static void warning(string msg, Application.Settings.OpMode opMode, Application.Settings.ErrorReporting opModeRunErrorReporting)
        {
            if ((opMode == Settings.OpMode.gui) || (opModeRunErrorReporting == Settings.ErrorReporting.MsgBox))
            {
                Forms.MessageBox.Warning(msg);
            }
        }

        public static string[] GetProcNames()
        {
            System.Diagnostics.Process[] procList = System.Diagnostics.Process.GetProcesses();
            string[] result = new string[procList.Length];

            for (int i = 0; i < procList.Length; ++i)
            {
                result[i] = procList[i].ProcessName;
            }

            return result;
        }

        public static void Run(Job[] jobs)
        {
            Run(jobs, IntPtr.Zero);
        }
        public static void Run(Job[] jobs, IntPtr thisAppHwnd)
        {
            Run(jobs, Application.Settings.OpMode.gui, Application.Settings.ErrorReporting.MsgBox, thisAppHwnd);
        }
        public static void Run(Job[] jobs, Application.Settings.OpMode opMode, Application.Settings.ErrorReporting opModeRunErrorReporting)
        {
            Run(jobs, opMode, opModeRunErrorReporting, IntPtr.Zero);
        }
        public static void Run(Job[] jobs, Application.Settings.OpMode opMode, Application.Settings.ErrorReporting opModeRunErrorReporting, IntPtr thisAppHwnd)
        {
            try
            {
                System.Diagnostics.Process[] procList = System.Diagnostics.Process.GetProcesses();
                List<string> notFoundProcesses = new List<string>(0);

                for (int i = 0; i < jobs.Length; ++i)
                {
                    if (jobs[i].Enabled && (jobs[i].ID >= 0))
                    {
                        int procIndex = -1;

                        for (int pi = 0; pi < procList.Length; ++pi)
                        {
                            if (jobs[i].ProcessName == procList[pi].ProcessName)
                            {
                                procIndex = pi;
                                pi = procList.Length;
                            }
                        }

                        if (procIndex == -1)
                        {
                            notFoundProcesses.Add(jobs[i].ProcessName);
                        }
                        else
                        {
                            int insertAfter;
                            int flags = 0;

                            switch (jobs[i].ZPosition)
                            {
                                case WindowZPosition.TopMost:
                                    insertAfter = HWND_TOPMOST;
                                    break;

                                case WindowZPosition.Top:
                                    insertAfter = HWND_TOP;
                                    break;

                                case WindowZPosition.Bottom:
                                    insertAfter = HWND_BOTTOM;
                                    break;

                                case WindowZPosition.NoTopMost:
                                default:
                                    insertAfter = HWND_NOTOPMOST;
                                    break;
                            }

                            if (jobs[i].NoSize) flags |= SWP_NOSIZE;
                            if (jobs[i].NoMove) flags |= SWP_NOMOVE;
                            if (jobs[i].NoZOrder) flags |= SWP_NOZORDER;

                            SetWindowPos(
                                procList[procIndex].MainWindowHandle,
                                insertAfter,
                                jobs[i].Position.X,
                                jobs[i].Position.Y,
                                jobs[i].Size.Width,
                                jobs[i].Size.Height,
                                flags);
                        }
                    }
                }

                if (notFoundProcesses.Count > 0)
                {
                    string tmpStr = String.Empty;
                    for (int i = 0; i < notFoundProcesses.Count; ++i) tmpStr += "\n" + notFoundProcesses[i];
                    warning(Properties.Strings.nsApplication_Job_Run_Warning_ProcNotFound + tmpStr, opMode, opModeRunErrorReporting);
                }

                if ((opMode == Settings.OpMode.gui) && (thisAppHwnd != IntPtr.Zero)) SetWindowPos(thisAppHwnd, HWND_TOP, -1, -1, -1, -1, SWP_NOSIZE | SWP_NOMOVE);
            }
            catch (Exception ex)
            {
                Forms.MessageBox.Error(Properties.Strings.gFatalError + "\n" + ex.Message);
            }
        }

        //
        // defined job IDs:
        //
        //     -1               invalid job
        //      0               newly generated job
        // IDstart ... x        listed/stored jobs
        //
        public int ID;

        public string ProcessName;
        public bool Enabled;
        public System.Drawing.Point Position;
        public System.Drawing.Size Size;
        public WindowZPosition ZPosition;
        public bool NoSize;
        public bool NoMove;
        public bool NoZOrder;

        public Job()
        {
            string[] tmp;

            this.ID = JobsFile.Default_ID;
            this.ProcessName = JobsFile.Default_ProcessName;
            this.Enabled = Convert.ToBoolean(JobsFile.Default_Enabled);

            tmp = JobsFile.Default_Position.Split(';');
            this.Position = new System.Drawing.Point(System.Convert.ToInt32(tmp[0]), System.Convert.ToInt32(tmp[1]));

            tmp = JobsFile.Default_Size.Split(';');
            this.Size = new System.Drawing.Size(System.Convert.ToInt32(tmp[0]), System.Convert.ToInt32(tmp[1]));

            this.ZPosition = Middleware.Util.Misc.ParseEnum<Job.WindowZPosition>(JobsFile.Default_WindowZPosition);
            this.NoSize = Convert.ToBoolean(JobsFile.Default_NoSize);
            this.NoMove = Convert.ToBoolean(JobsFile.Default_NoMove);
            this.NoZOrder = Convert.ToBoolean(JobsFile.Default_NoZOrder);
        }

        public override string ToString()
        {
            string result = this.ProcessName + " [" + (this.Enabled ? "enabled" : "disabled") + "]" +
                " (" + this.Position.X.ToString() + ", " + this.Position.Y.ToString() + ") (" +
                this.Size.Width.ToString() + ", " + this.Size.Height.ToString() + ")" +
                " [" + this.ZPosition.ToString() + "]";

            string tmpStr = String.Empty;
            if (this.NoSize) tmpStr += (String.IsNullOrEmpty(tmpStr) ? "" : " ") + "NoSize";
            if (this.NoMove) tmpStr += (String.IsNullOrEmpty(tmpStr) ? "" : " ") + "NoMove";
            if (this.NoZOrder) tmpStr += (String.IsNullOrEmpty(tmpStr) ? "" : " ") + "NoZOrder";
            if (!String.IsNullOrEmpty(tmpStr)) result += " [" + tmpStr + "]";

            return result;
        }

        public enum WindowZPosition
        {
            Top,
            Bottom,
            TopMost,
            NoTopMost
        }
    }

    public class JobsFile
    {
        private const string Key_ProcessName = "ProcessName";
        private const string Key_Enabled = "Enabled";
        private const string Key_Position = "Position";
        private const string Key_Size = "Size";
        private const string Key_WindowZPosition = "WindowZPosition";
        private const string Key_NoSize = "NoSize";
        private const string Key_NoMove = "NoMove";
        private const string Key_NoZOrder = "NoZOrder";

        public const int Default_ID = 0;
        public const string Default_ProcessName = "defaultProcessName";
        public const string Default_Enabled = "false";
        public const string Default_Position = "20;20";
        public const string Default_Size = "750;600";
        public const string Default_WindowZPosition = "Top";
        public const string Default_NoSize = "true";
        public const string Default_NoMove = "true";
        public const string Default_NoZOrder = "true";

        private Middleware.Util.IniFile.IniFile iniFile;

        private void error(string msg, Application.Settings.OpMode opMode, Application.Settings.ErrorReporting opModeRunErrorReporting)
        {
            if ((opMode == Settings.OpMode.gui) || (opModeRunErrorReporting == Settings.ErrorReporting.MsgBox))
            {
                Forms.MessageBox.Error(msg);
            }
        }

        public JobsFile(string filename)
        {
            this.iniFile = new Middleware.Util.IniFile.IniFile(filename, Encoding.UTF8, true);
        }

        public string[] GetSectionNames()
        {
            var tmpSections = iniFile.GetSections().ToArray();
            string[] sections = new string[tmpSections.Length];
            for (int i = 0; i < tmpSections.Length; ++i) { sections[i] = tmpSections[i].Name; }

            return sections;
        }

        public int[] GetSectionNamesInt()
        {
            var tmpSections = iniFile.GetSections().ToArray();
            int[] sections = new int[tmpSections.Length];
            for (int i = 0; i < tmpSections.Length; ++i)
            {
                try { sections[i] = Convert.ToInt32(tmpSections[i].Name); }
                catch { sections[i] = -1; }
            }

            return sections;
        }

        public Job Get(int id)
        {
            return this.Get(id, Application.Settings.OpMode.gui, Application.Settings.ErrorReporting.MsgBox);
        }
        public Job Get(int id, Application.Settings.OpMode opMode, Application.Settings.ErrorReporting opModeRunErrorReporting)
        {
            Job[] jobs = Get(opMode, opModeRunErrorReporting);

            foreach (Job j in jobs)
            {
                if (j.ID == id) return j;
            }

#warning TODO multi language or better a custm exception and text in the form
            throw new Exception("Job not found");
        }
        public Job[] Get()
        {
            return this.Get(Application.Settings.OpMode.gui, Application.Settings.ErrorReporting.MsgBox);
        }
        public Job[] Get(Application.Settings.OpMode opMode, Application.Settings.ErrorReporting opModeRunErrorReporting)
        {
            string[] sectionNames = this.GetSectionNames();
            int[] sectionNamesInt = this.GetSectionNamesInt();

            List<Job> jobs = new List<Job>(0);

            for (int i = 0; i < sectionNamesInt.Length; ++i)
            {
                if (sectionNamesInt[i] < Job.IDstart) this.error(Properties.Strings.nsApplication_JobsFile_Get_ErrorInvalidSection + " \"" + sectionNames[i] + "\"", opMode, opModeRunErrorReporting);
                else
                {
                    try
                    {
                        Job job = new Job();
                        job.ID = sectionNamesInt[i];

                        string[] tmp;

                        job.ProcessName = iniFile.Get(sectionNames[i], Key_ProcessName, true, Default_ProcessName);
                        job.Enabled = Convert.ToBoolean(iniFile.Get(sectionNames[i], Key_Enabled, true, Default_Enabled));

                        tmp = iniFile.Get(sectionNames[i], Key_Position, true, Default_Position).Split(';');
                        job.Position = new System.Drawing.Point(System.Convert.ToInt32(tmp[0]), System.Convert.ToInt32(tmp[1]));

                        tmp = iniFile.Get(sectionNames[i], Key_Size, true, Default_Size).Split(';');
                        job.Size = new System.Drawing.Size(System.Convert.ToInt32(tmp[0]), System.Convert.ToInt32(tmp[1]));

                        job.ZPosition = Middleware.Util.Misc.ParseEnum<Job.WindowZPosition>(iniFile.Get(sectionNames[i], Key_WindowZPosition, true, Default_WindowZPosition));
                        job.NoSize = Convert.ToBoolean(iniFile.Get(sectionNames[i], Key_NoSize, true, Default_NoSize));
                        job.NoMove = Convert.ToBoolean(iniFile.Get(sectionNames[i], Key_NoMove, true, Default_NoMove));
                        job.NoZOrder = Convert.ToBoolean(iniFile.Get(sectionNames[i], Key_NoZOrder, true, Default_NoZOrder));

                        jobs.Add(job);
                    }
                    catch
                    {
                        this.error(Properties.Strings.nsApplication_JobsFile_Get_ErrorParse + " \"" + sectionNames[i] + "\"", opMode, opModeRunErrorReporting);
                    }
                }
            }

            return jobs.ToArray();
        }

        public void Remove(int sectionNameInt)
        {
            string sectionName = sectionNameInt.ToString();
            this.Remove(sectionName);
        }
        public void Remove(string sectionName)
        {
            this.iniFile.RemoveSection(sectionName);
        }

        public void Set(int sectionNameInt, Job job)
        {
            string sectionName = sectionNameInt.ToString();
            this.Set(sectionName, job);
        }
        public void Set(string sectionName, Job job)
        {
            iniFile.Set(sectionName, Key_ProcessName, job.ProcessName, true, true);
            iniFile.Set(sectionName, Key_Enabled, job.Enabled.ToString(), true, true);
            iniFile.Set(sectionName, Key_Position, (job.Position.X.ToString() + ";" + job.Position.Y.ToString()), true, true);
            iniFile.Set(sectionName, Key_Size, (job.Size.Width.ToString() + ";" + job.Size.Height.ToString()), true, true);
            iniFile.Set(sectionName, Key_WindowZPosition, job.ZPosition.ToString(), true, true);
            iniFile.Set(sectionName, Key_NoSize, job.NoSize.ToString(), true, true);
            iniFile.Set(sectionName, Key_NoMove, job.NoMove.ToString(), true, true);
            iniFile.Set(sectionName, Key_NoZOrder, job.NoZOrder.ToString(), true, true);
            iniFile.SaveToFile();
        }

        public int Add(Job job)
        {
            int[] sections = this.GetSectionNamesInt();
            int newSection = Job.IDstart;
            int cntZeroTransitions = 0;

            while (sections.Contains(newSection) || (newSection <= 0))
            {
                if (newSection < Job.IDstart)
                {
                    newSection = Job.IDstart;

                    if (cntZeroTransitions > 2) throw new Exception("Unable to find unused job ID");
                    else ++cntZeroTransitions;
                }
                else ++newSection;
            }

            this.Set(newSection, job);

            return newSection;
        }
    }
}
