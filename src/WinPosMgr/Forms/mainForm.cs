/*!

\author         Oliver Blaser

\date           15.12.2020

\copyright      GNU GPLv3 - Copyright (c) 2020 Oliver Blaser

\brief          Main form

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPosMgr
{
    public partial class mainForm : Form
    {
        private Application.Settings settings;
        private Application.JobsFile jobsFile;

        public mainForm()
        {
            InitializeComponent();
            this.InitializeManualComponents();

            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(this.mainForm_KeyUp);

            this.settings = Application.Settings.Get();
            this.loadConfig();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.reloadJobs();
        }
        private void mainForm_Shown(object sender, EventArgs e)
        {
            //if(Middleware.IniFileWrapper.Config.General.FirstStart.Get() == true)
            //{
            //    Middleware.IniFileWrapper.Config.General.FirstStart.Set(false, true); // will be saved to file on app close
            //}

            this.tmrInit();
        }
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.saveConfig();
        }
        private void mainForm_Move(object sender, EventArgs e)
        {
            this.tmrSys_setCntSaveConfig(200);
        }
        private void mainForm_Resize(object sender, EventArgs e)
        {
            this.tmrSys_setCntSaveConfig(200);
        }
        private void mainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                e.Handled = true;

                this.toolStripButton_job_add.PerformClick();
            }

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract)
            {
                e.Handled = true;

                this.toolStripButton_job_remove.PerformClick();
            }

            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;

                this.toolStripButton_job_reload.PerformClick();
            }

            if (e.KeyCode == Keys.F9)
            {
                e.Handled = true;

                this.toolStripButton_job_run.PerformClick();
            }
        }

        private void listBox_jobs_DoubleClick(object sender, EventArgs e)
        {
            this.toolStripButton_job_edit.PerformClick();
        }


        // ==============================================================================================================================================================
        // more controls
        //

        #region moreControls
        private ToolStripMenuItem toolStripMenuItem_file;
        private ToolStripMenuItem toolStripMenuItem_file_exit;
        private ToolStripMenuItem toolStripMenuItem_help;
        private ToolStripMenuItem toolStripMenuItem_help_gitHubPage;
        private ToolStripMenuItem toolStripMenuItem_help_about;

        private ToolStrip toolStrip_job;
        private ToolStripButton toolStripButton_job_add;
        private ToolStripButton toolStripButton_job_edit;
        private ToolStripButton toolStripButton_job_reload;
        private ToolStripButton toolStripButton_job_remove;
        private ToolStripButton toolStripButton_job_run;
        private ToolStripSeparator toolStripSeparator_job1;

        private void InitializeManualComponents()
        {

            //
            // menustrip
            //
            this.toolStripMenuItem_file = new ToolStripMenuItem();
            this.toolStripMenuItem_file.Text = Properties.Strings.mainForm_toolStripMenuItem_file_Text;

            this.toolStripMenuItem_file_exit = new ToolStripMenuItem();
            this.toolStripMenuItem_file_exit.Click += new EventHandler(this.toolStripMenuItem_file_exit_Click);
            this.toolStripMenuItem_file_exit.Text = Properties.Strings.mainForm_toolStripMenuItem_file_exit_Text;

            this.toolStripMenuItem_help = new ToolStripMenuItem();
            this.toolStripMenuItem_help.Text = Properties.Strings.mainForm_toolStripMenuItem_help_Text;

            this.toolStripMenuItem_help_gitHubPage = new ToolStripMenuItem();
            this.toolStripMenuItem_help_gitHubPage.Click += new EventHandler(this.toolStripMenuItem_help_gitHubPage_Click);
            this.toolStripMenuItem_help_gitHubPage.Text = Properties.Strings.mainForm_toolStripMenuItem_help_gitHubPage_Text;

            this.toolStripMenuItem_help_about = new ToolStripMenuItem();
            this.toolStripMenuItem_help_about.Click += new EventHandler(this.toolStripMenuItem_help_about_Click);
            this.toolStripMenuItem_help_about.Text = Properties.Strings.mainForm_toolStripMenuItem_help_about_Text;

            this.toolStripMenuItem_file.DropDownItems.Add(this.toolStripMenuItem_file_exit);
            this.toolStripMenuItem_help.DropDownItems.Add(this.toolStripMenuItem_help_gitHubPage);
            this.toolStripMenuItem_help.DropDownItems.Add(this.toolStripMenuItem_help_about);
            this.menuStrip1.Items.Add(this.toolStripMenuItem_file);
            this.menuStrip1.Items.Add(this.toolStripMenuItem_help);

            //
            // toolstrip jobs
            //
            this.toolStrip_job = new ToolStrip();

            this.toolStripButton_job_add = new ToolStripButton();
            this.toolStripButton_job_add.Click += new EventHandler(this.toolStripButton_job_add_Click);
            this.toolStripButton_job_add.Image = Properties.Resources.Add_16x;
            this.toolStripButton_job_add.ToolTipText = Properties.Strings.mainForm_toolStripButton_job_add_Text;

            this.toolStripButton_job_edit = new ToolStripButton();
            this.toolStripButton_job_edit.Click += new EventHandler(this.toolStripButton_job_edit_Click);
            this.toolStripButton_job_edit.Image = Properties.Resources.Edit_16x;
            this.toolStripButton_job_edit.ToolTipText = Properties.Strings.mainForm_toolStripButton_job_edit_Text;

            this.toolStripButton_job_reload = new ToolStripButton();
            this.toolStripButton_job_reload.Click += new EventHandler(this.toolStripButton_job_reload_Click);
            this.toolStripButton_job_reload.Image = Properties.Resources.Refresh_16x;
            this.toolStripButton_job_reload.ToolTipText = Properties.Strings.mainForm_toolStripButton_job_reload_Text;

            this.toolStripButton_job_remove = new ToolStripButton();
            this.toolStripButton_job_remove.Click += new EventHandler(this.toolStripButton_job_remove_Click);
            this.toolStripButton_job_remove.Image = Properties.Resources.Remove_color_16x;
            this.toolStripButton_job_remove.ToolTipText = Properties.Strings.mainForm_toolStripButton_job_remove_Text;

            this.toolStripButton_job_run = new ToolStripButton();
            this.toolStripButton_job_run.Click += new EventHandler(this.toolStripButton_job_run_Click);
            this.toolStripButton_job_run.Image = Properties.Resources.Run_16x;
            this.toolStripButton_job_run.Text = Properties.Strings.mainForm_toolStripButton_job_run_Text;
            this.toolStripButton_job_run.ToolTipText = Properties.Strings.mainForm_toolStripButton_job_run_Text;

            this.toolStripSeparator_job1 = new ToolStripSeparator();

            this.toolStrip_job.Items.Add(this.toolStripButton_job_add);
            this.toolStrip_job.Items.Add(this.toolStripButton_job_remove);
            this.toolStrip_job.Items.Add(this.toolStripButton_job_edit);
            this.toolStrip_job.Items.Add(this.toolStripButton_job_reload);
            this.toolStrip_job.Items.Add(this.toolStripSeparator_job1);
            this.toolStrip_job.Items.Add(this.toolStripButton_job_run);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip_job);

            //
            // misc
            //
            this.Icon = Properties.Resources.icon;
            this.Text = Properties.Strings.gAppName;
            this.menuStrip1.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            this.toolStripContainer1.TopToolStripPanel.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
#if (DEBUG)
            this.Text += " - DEBUG";
#endif
        }

        private void toolStripMenuItem_file_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripMenuItem_help_gitHubPage_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/oblaser/WinPosMgr");
            }
            catch (Exception ex) { Forms.MessageBox.Warning(ex.Message); }
        }
        private void toolStripMenuItem_help_about_Click(object sender, EventArgs e)
        {
            Forms.About af = new Forms.About();
            af.ShowDialog(this);
        }
        private void toolStripButton_job_add_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Job newJob = new Application.Job();
                newJob.Enabled = true;
                newJob.ZPosition = Application.Job.WindowZPosition.NoTopMost;
                newJob.NoSize = false;
                newJob.NoMove = false;
                newJob.NoZOrder = true;

                Forms.editJob ejd = new Forms.editJob(Properties.Strings.editJob_title_new, newJob);

                if (ejd.ShowDialog(this) == DialogResult.OK)
                {
                    this.jobsFile.Add(ejd.GetJob());
                    this.refreshJobsDisplay();
                }
            }
            catch (Exception ex) { Forms.MessageBox.Error(ex.Message); }
        }
        private void toolStripButton_job_edit_Click(object sender, EventArgs e)
        {
            if (this.listBox_jobs.SelectedIndex < 0) return;

            try
            {
                int id = this.getSelectedJobId();

                Forms.editJob ejd = new Forms.editJob(Properties.Strings.editJob_title_edit, this.jobsFile.Get(id));

                if (ejd.ShowDialog(this) == DialogResult.OK)
                {
                    this.jobsFile.Set(id, ejd.GetJob());
                    this.refreshJobsDisplay();
                }
            }
            catch (Exception ex) { Forms.MessageBox.Error(ex.Message); }
        }
        private void toolStripButton_job_reload_Click(object sender, EventArgs e)
        {
            try { this.reloadJobs(); }
            catch (Exception ex) { Forms.MessageBox.Error(ex.Message); }
        }
        private void toolStripButton_job_remove_Click(object sender, EventArgs e)
        {
            if (this.listBox_jobs.SelectedIndex < 0) return;

            try
            {
                if (MessageBox.Show(Properties.Strings.mainForm_deleteJobDialog + "\n\n" + this.listBox_jobs.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.jobsFile.Remove(this.getSelectedJobId());
                    this.refreshJobsDisplay();
                }
            }
            catch (Exception ex) { Forms.MessageBox.Error(ex.Message); }
        }
        private void toolStripButton_job_run_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Job[] jobs = this.jobsFile.Get();

                Application.Job.Run(jobs, this.Handle);
            }
            catch (Exception ex) { Forms.MessageBox.Error(ex.Message); }
        }
        #endregion


        // ==============================================================================================================================================================
        // timer
        //

        private void tmrInit()
        {
            this.tmrSysInit();
        }

        // tmrSys
        private System.Timers.Timer tmrSys;
        private readonly int tmrSysInterval = 250;
        private int tmrSys_cntSaveConfig = -1;
        private void tmrSysInit()
        {
            this.tmrSys = new System.Timers.Timer();
            this.tmrSys.Interval = this.tmrSysInterval;
            this.tmrSys.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrSys_elapsed);
            this.tmrSys.AutoReset = true;
            this.tmrSys.Enabled = true;
        }
        private void tmrSys_elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (this.tmrSys_cntSaveConfig > 0) --this.tmrSys_cntSaveConfig;
                else if (this.tmrSys_cntSaveConfig == 0)
                {
                    this.tmrSys_cntSaveConfig = -1;

                    this.saveConfig(true); // will be saved to file on app close
                }
            }));
        }
        private void tmrSys_setCntSaveConfig(int t_ms)
        {
            this.tmrSys_cntSaveConfig = (t_ms >= 0 ? Convert.ToInt32(Math.Round(((decimal)t_ms / this.tmrSysInterval), MidpointRounding.AwayFromZero)) : -1);
            if (this.tmrSys_cntSaveConfig == 0 && t_ms > 0) this.tmrSys_cntSaveConfig = 1;
        }


        // ==============================================================================================================================================================
        // config
        //

        private void loadConfig()
        {
            try
            {
                this.WindowState = (Middleware.IniFileWrapper.Config.UI.WindowMaximized.Get() ? FormWindowState.Maximized : FormWindowState.Normal);
                this.Location = Middleware.IniFileWrapper.Config.UI.WindowLocation.Get();
                this.Size = Middleware.IniFileWrapper.Config.UI.WindowSize.Get();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                try { msg += "\n\n" + ex.InnerException.Message; } catch { }
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        private void saveConfig() { this.saveConfig(false); }
        private void saveConfig(bool preventWriteFile)
        {
            try
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    Middleware.IniFileWrapper.Config.UI.WindowMaximized.Set(true, preventWriteFile);
                }
                //else if (this.WindowState == FormWindowState.Minimized)
                //{
                //}
                else if (this.WindowState == FormWindowState.Normal)
                {
                    Middleware.IniFileWrapper.Config.UI.WindowMaximized.Set(false, true);
                    Middleware.IniFileWrapper.Config.UI.WindowLocation.Set(this.Location, true);
                    Middleware.IniFileWrapper.Config.UI.WindowSize.Set(this.Size, true);
                    if (!preventWriteFile) Middleware.IniFileWrapper.Config.SaveFile();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                try { msg += "\n\n" + ex.InnerException.Message; } catch { }
                Forms.MessageBox.Error(msg);
            }
        }


        // ==============================================================================================================================================================
        // misc
        //

        private int getSelectedJobId()
        {
            string[] tmp = this.listBox_jobs.Text.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

            return Convert.ToInt32(tmp[0]);
        }
        private void reloadJobs()
        {
            try
            {
                this.jobsFile = new Application.JobsFile(this.settings.General_JobsFile);
                this.refreshJobsDisplay();
            }
            catch (Exception ex) { Forms.MessageBox.Error(ex.Message); }
        }
        private void refreshJobsDisplay()
        {
            try
            {
                this.listBox_jobs.Items.Clear();

                var tmpJobs = this.jobsFile.Get();

                foreach (var job in tmpJobs)
                {
                    this.listBox_jobs.Items.Add("[" + job.ID.ToString() + "] " + job.ToString());
                }
            }
            catch (Exception ex) { Forms.MessageBox.Error(ex.Message); }
        }


        // ==============================================================================================================================================================
        // tmp
        //

#if(DEBUG)
        private bool tmpDEBUG; // the automatically generated event functions are placed after this line (the last in this class) by Visual Studio
#endif
    }
}
