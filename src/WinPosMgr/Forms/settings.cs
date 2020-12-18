/*!

\author         Oliver Blaser

\date           17.12.2020

\copyright      GNU GPLv3 - Copyright (c) 2020 Oliver Blaser

\brief          

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPosMgr.Forms
{
    public partial class settings : Form
    {
        private Application.Settings setts;

        public settings(Application.Settings settings)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon;

            this.tabControl1.TabPages["tabPage_general"].Text = Properties.Strings.settings_tab_general;

            this.button_cancel.Text = Properties.Strings.gCancel;
            this.button_cancel.DialogResult = DialogResult.Cancel;

            this.button_ok.Text = Properties.Strings.gOK;
            this.button_ok.DialogResult = DialogResult.OK;

            this.label_general_defaultOpMode.Text = Properties.Strings.settings_general_defaultOpMode;
            this.label_general_opModeRunErrRep.Text = Properties.Strings.settings_general_opModeRunErrRep;
            this.label_general_jobsFile.Text = Properties.Strings.settings_general_jobsFile;

            this.comboBox_general_defaultOpMode.Items.AddRange(Enum.GetNames(typeof(Application.Settings.OpMode)));
            this.comboBox_general_opModeRunErrRep.Items.AddRange(Enum.GetNames(typeof(Application.Settings.ErrorReporting)));

            this.SetSettings(settings);
        }

        private void settings_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Escape)
            {
                e.Handled = true;
                this.button_cancel.PerformClick();
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                this.button_ok.PerformClick();
            }
        }

        private void button_general_jobsFile_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = this.textBox_general_jobsFile.Text;
            ofd.Filter = Middleware.AppFiles.File.FileDialogFilter.Ini + Middleware.AppFiles.File.FileDialogFilter.Join + Middleware.AppFiles.File.FileDialogFilter.AllFiles;

            if(ofd.ShowDialog()== DialogResult.OK)
            {
                this.textBox_general_jobsFile.Text = ofd.FileName;
            }
        }

        public Application.Settings GetSettings()
        {
            this.setts.General_DefaultOpMode = Middleware.Util.Misc.ParseEnum<Application.Settings.OpMode>(this.comboBox_general_defaultOpMode.Text);
            this.setts.General_OpModeRunErrorReporting = Middleware.Util.Misc.ParseEnum<Application.Settings.ErrorReporting>(this.comboBox_general_opModeRunErrRep.Text);
            this.setts.General_JobsFile = this.textBox_general_jobsFile.Text;

            return this.setts;
        }

        public void SetSettings(Application.Settings settings)
        {
            this.setts = settings;

            this.comboBox_general_defaultOpMode.Text = settings.General_DefaultOpMode.ToString();
            this.comboBox_general_opModeRunErrRep.Text = settings.General_OpModeRunErrorReporting.ToString();
            this.textBox_general_jobsFile.Text = settings.General_JobsFile;
        }
    }
}
