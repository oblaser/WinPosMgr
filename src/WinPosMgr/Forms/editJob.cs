/*!

\author         Oliver Blaser

\date           16.12.2020

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
    public partial class editJob : Form
    {
        private Application.Job job;

        public editJob(string title, Application.Job job)
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;
            this.Text = title;

            this.button_cancel.Text = Properties.Strings.gCancel;
            this.button_ok.Text = Properties.Strings.gOK;
            this.button_test.Text = Properties.Strings.editJob_button_test;

            this.checkBox_flags_enabled.Text = Properties.Strings.editJob_checkBox_enabled;
            this.checkBox_flags_noSize.Text = Properties.Strings.editJob_checkBox_noSize;
            this.checkBox_flags_noMove.Text = Properties.Strings.editJob_checkBox_noMove;
            this.checkBox_flags_noZOrder.Text = Properties.Strings.editJob_checkBox_noZOrder;

            this.comboBox_zOrder.Items.Clear();
            this.comboBox_zOrder.Items.Add(Application.Job.WindowZPosition.Top.ToString());
            this.comboBox_zOrder.Items.Add(Application.Job.WindowZPosition.Bottom.ToString());
            this.comboBox_zOrder.Items.Add(Application.Job.WindowZPosition.TopMost.ToString());
            this.comboBox_zOrder.Items.Add(Application.Job.WindowZPosition.NoTopMost.ToString());

            this.groupBox_searchProc.Text = Properties.Strings.editJob_groupBox_searchProc;
            this.groupBox_position.Text = Properties.Strings.editJob_groupBox_position;
            this.groupBox_size.Text = Properties.Strings.editJob_groupBox_size;
            this.groupBox_flags.Text = Properties.Strings.editJob_groupBox_flags;

            this.listBox_procSearchResult.Items.Clear();
            this.listBox_procSearchResult.Items.AddRange(this.filteredProcList(String.Empty));

            this.textBox_procName.Text = String.Empty;
            this.textBox_procSearchString.Text = String.Empty;

            this.job = job;
            this.textBox_procName.Text = job.ProcessName;
            this.numericUpDown_position_x.Value = job.Position.X;
            this.numericUpDown_position_y.Value = job.Position.Y;
            this.numericUpDown_size_x.Value = job.Size.Width;
            this.numericUpDown_size_y.Value = job.Size.Height;
            this.comboBox_zOrder.Text = job.ZPosition.ToString();
            this.checkBox_flags_enabled.Checked = job.Enabled;
            this.checkBox_flags_noSize.Checked = job.NoSize;
            this.checkBox_flags_noMove.Checked = job.NoMove;
            this.checkBox_flags_noZOrder.Checked = job.NoZOrder;
        }

        private void editJob_Load(object sender, EventArgs e)
        {

        }
        private void editJob_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
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

        private void button_setProcName_Click(object sender, EventArgs e)
        {
            this.textBox_procName.Text = this.listBox_procSearchResult.Text;
        }
        private void textBox_procSearchString_TextChanged(object sender, EventArgs e)
        {
            this.listBox_procSearchResult.Items.Clear();
            this.listBox_procSearchResult.Items.AddRange(this.filteredProcList(this.textBox_procSearchString.Text));
        }
        private void listBox_procSearchResult_DoubleClick(object sender, EventArgs e)
        {
            this.button_setProcName.PerformClick();
        }
        private void button_test_Click(object sender, EventArgs e)
        {
            Application.Job.Run(new Application.Job[] { this.GetJob() }, this.Handle);
        }


        // ==============================================================================================================================================================
        // misc
        //

        private string[] filteredProcList(string searchString)
        {
            string[] p = Application.Job.GetProcNames();

            if (String.IsNullOrEmpty(searchString)) return p;

            List<string> result = new List<string>(0);

            foreach (string s in p)
            {
                if (s.ToLower().Contains(searchString.ToLower())) result.Add(s);
            }

            return result.ToArray();
        }

        public Application.Job GetJob()
        {
            this.job.ProcessName = this.textBox_procName.Text;
            try { this.job.Position = new Point(Convert.ToInt32(this.numericUpDown_position_x.Value), Convert.ToInt32(this.numericUpDown_position_y.Value)); }
            catch { Forms.MessageBox.Warning(Properties.Strings.editJob_warning_invalidPosition); }
            try { this.job.Size = new Size(Convert.ToInt32(this.numericUpDown_size_x.Value), Convert.ToInt32(this.numericUpDown_size_y.Value)); }
            catch { Forms.MessageBox.Warning(Properties.Strings.editJob_warning_invalidSize); }
            try { this.job.ZPosition = Middleware.Util.Misc.ParseEnum<Application.Job.WindowZPosition>(this.comboBox_zOrder.Text); }
            catch { Forms.MessageBox.Warning(Properties.Strings.editJob_warning_invalidZPosition); }
            this.job.Enabled = this.checkBox_flags_enabled.Checked;
            this.job.NoSize = this.checkBox_flags_noSize.Checked;
            this.job.NoMove = this.checkBox_flags_noMove.Checked;
            this.job.NoZOrder = this.checkBox_flags_noZOrder.Checked;

            return this.job;
        }


        // ==============================================================================================================================================================
        // tmp
        //

#if(DEBUG)
        private bool tmpDEBUG; // the automatically generated event functions are placed after this line (the last in this class) by Visual Studio
#endif
    }
}
