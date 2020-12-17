/*!

\author         Oliver Blaser

\date           17.12.2020

\copyright      GNU GPLv3 - Copyright (c) 2020 Oliver Blaser

\brief          

*/

using System;

namespace WinPosMgr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
#if (DEBUG)
            // testing the parseing of default values
            try { Application.Job testJob = new Application.Job(); }
            catch { throw new Exception("TEST - Job constructor - FAILED"); }
#endif

            Middleware.AppFiles.Directory.CreateInexistents();
            Middleware.AppFiles.File.CreateInexistents();

            Application.Settings settings = Application.Settings.Get();
            Application.Settings.OpMode opMode = Application.Settings.OpMode.gui;

            try
            {
                if (args.Length == 0)
                {
                    opMode = settings.General_DefaultOpMode;
                }
                else if (args.Length == 1)
                {
                    opMode = Middleware.Util.Misc.ParseEnum<Application.Settings.OpMode>(args[0], true);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Forms.MessageBox.Error(Properties.Strings.cliArg_error_invalidArg);
                opMode = Application.Settings.OpMode.gui;
            }

            switch (opMode)
            {
                case Application.Settings.OpMode.run:

                    try
                    {
                        var tmpSettings = Application.Settings.Get();

                        Application.JobsFile tmpJF = new Application.JobsFile(tmpSettings.General_JobsFile);

                        Application.Job.Run(
                            tmpJF.Get(opMode, tmpSettings.General_OpModeRunErrorReporting),
                            opMode,
                            tmpSettings.General_OpModeRunErrorReporting);
                    }
                    catch (Exception ex)
                    {
                        Forms.MessageBox.Error(Properties.Strings.gFatalError + "\n" + ex.Message);
                    }

                    break;

                case Application.Settings.OpMode.gui:
                default:
                    Forms.MessageBox.SetTitles(Properties.Strings.gError, String.Empty, Properties.Strings.gWarning);
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    System.Windows.Forms.Application.Run(new mainForm());
                    break;
            }
        }
    }
}
