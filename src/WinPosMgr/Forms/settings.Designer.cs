
namespace WinPosMgr.Forms
{
    partial class settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_general = new System.Windows.Forms.TabPage();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_general_defaultOpMode = new System.Windows.Forms.Label();
            this.comboBox_general_defaultOpMode = new System.Windows.Forms.ComboBox();
            this.label_general_opModeRunErrRep = new System.Windows.Forms.Label();
            this.comboBox_general_opModeRunErrRep = new System.Windows.Forms.ComboBox();
            this.label_general_jobsFile = new System.Windows.Forms.Label();
            this.textBox_general_jobsFile = new System.Windows.Forms.TextBox();
            this.button_general_jobsFile_browse = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_general.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_general);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(380, 278);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_general
            // 
            this.tabPage_general.Controls.Add(this.button_general_jobsFile_browse);
            this.tabPage_general.Controls.Add(this.textBox_general_jobsFile);
            this.tabPage_general.Controls.Add(this.label_general_jobsFile);
            this.tabPage_general.Controls.Add(this.comboBox_general_opModeRunErrRep);
            this.tabPage_general.Controls.Add(this.label_general_opModeRunErrRep);
            this.tabPage_general.Controls.Add(this.comboBox_general_defaultOpMode);
            this.tabPage_general.Controls.Add(this.label_general_defaultOpMode);
            this.tabPage_general.Location = new System.Drawing.Point(4, 22);
            this.tabPage_general.Name = "tabPage_general";
            this.tabPage_general.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_general.Size = new System.Drawing.Size(372, 252);
            this.tabPage_general.TabIndex = 0;
            this.tabPage_general.Text = "tabPage_general";
            this.tabPage_general.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(236, 296);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "_OK_";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(317, 296);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "_Cancel_";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // label_general_defaultOpMode
            // 
            this.label_general_defaultOpMode.AutoSize = true;
            this.label_general_defaultOpMode.Location = new System.Drawing.Point(6, 9);
            this.label_general_defaultOpMode.Name = "label_general_defaultOpMode";
            this.label_general_defaultOpMode.Size = new System.Drawing.Size(35, 13);
            this.label_general_defaultOpMode.TabIndex = 0;
            this.label_general_defaultOpMode.Text = "label1";
            // 
            // comboBox_general_defaultOpMode
            // 
            this.comboBox_general_defaultOpMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_general_defaultOpMode.FormattingEnabled = true;
            this.comboBox_general_defaultOpMode.Location = new System.Drawing.Point(149, 6);
            this.comboBox_general_defaultOpMode.Name = "comboBox_general_defaultOpMode";
            this.comboBox_general_defaultOpMode.Size = new System.Drawing.Size(85, 21);
            this.comboBox_general_defaultOpMode.TabIndex = 1;
            // 
            // label_general_opModeRunErrRep
            // 
            this.label_general_opModeRunErrRep.AutoSize = true;
            this.label_general_opModeRunErrRep.Location = new System.Drawing.Point(6, 36);
            this.label_general_opModeRunErrRep.Name = "label_general_opModeRunErrRep";
            this.label_general_opModeRunErrRep.Size = new System.Drawing.Size(35, 13);
            this.label_general_opModeRunErrRep.TabIndex = 2;
            this.label_general_opModeRunErrRep.Text = "label2";
            // 
            // comboBox_general_opModeRunErrRep
            // 
            this.comboBox_general_opModeRunErrRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_general_opModeRunErrRep.FormattingEnabled = true;
            this.comboBox_general_opModeRunErrRep.Location = new System.Drawing.Point(149, 33);
            this.comboBox_general_opModeRunErrRep.Name = "comboBox_general_opModeRunErrRep";
            this.comboBox_general_opModeRunErrRep.Size = new System.Drawing.Size(85, 21);
            this.comboBox_general_opModeRunErrRep.TabIndex = 3;
            // 
            // label_general_jobsFile
            // 
            this.label_general_jobsFile.AutoSize = true;
            this.label_general_jobsFile.Location = new System.Drawing.Point(6, 66);
            this.label_general_jobsFile.Name = "label_general_jobsFile";
            this.label_general_jobsFile.Size = new System.Drawing.Size(35, 13);
            this.label_general_jobsFile.TabIndex = 4;
            this.label_general_jobsFile.Text = "label3";
            // 
            // textBox_general_jobsFile
            // 
            this.textBox_general_jobsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_general_jobsFile.Location = new System.Drawing.Point(149, 63);
            this.textBox_general_jobsFile.Name = "textBox_general_jobsFile";
            this.textBox_general_jobsFile.Size = new System.Drawing.Size(191, 20);
            this.textBox_general_jobsFile.TabIndex = 5;
            // 
            // button_general_jobsFile_browse
            // 
            this.button_general_jobsFile_browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_general_jobsFile_browse.Location = new System.Drawing.Point(346, 63);
            this.button_general_jobsFile_browse.Name = "button_general_jobsFile_browse";
            this.button_general_jobsFile_browse.Size = new System.Drawing.Size(20, 20);
            this.button_general_jobsFile_browse.TabIndex = 6;
            this.button_general_jobsFile_browse.UseVisualStyleBackColor = true;
            this.button_general_jobsFile_browse.Click += new System.EventHandler(this.button_general_jobsFile_browse_Click);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 331);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 370);
            this.Name = "settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "settings";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.settings_KeyUp);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_general.ResumeLayout(false);
            this.tabPage_general.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_general;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_general_jobsFile_browse;
        private System.Windows.Forms.TextBox textBox_general_jobsFile;
        private System.Windows.Forms.Label label_general_jobsFile;
        private System.Windows.Forms.ComboBox comboBox_general_opModeRunErrRep;
        private System.Windows.Forms.Label label_general_opModeRunErrRep;
        private System.Windows.Forms.ComboBox comboBox_general_defaultOpMode;
        private System.Windows.Forms.Label label_general_defaultOpMode;
    }
}