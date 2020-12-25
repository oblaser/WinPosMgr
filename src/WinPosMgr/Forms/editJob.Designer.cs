
namespace WinPosMgr.Forms
{
    partial class editJob
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
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.listBox_procSearchResult = new System.Windows.Forms.ListBox();
            this.textBox_procSearchString = new System.Windows.Forms.TextBox();
            this.groupBox_searchProc = new System.Windows.Forms.GroupBox();
            this.button_setProcName = new System.Windows.Forms.Button();
            this.textBox_procName = new System.Windows.Forms.TextBox();
            this.button_test = new System.Windows.Forms.Button();
            this.groupBox_position = new System.Windows.Forms.GroupBox();
            this.numericUpDown_position_y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_position_x = new System.Windows.Forms.NumericUpDown();
            this.groupBox_size = new System.Windows.Forms.GroupBox();
            this.numericUpDown_size_y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_size_x = new System.Windows.Forms.NumericUpDown();
            this.groupBox_flags = new System.Windows.Forms.GroupBox();
            this.checkBox_flags_noZOrder = new System.Windows.Forms.CheckBox();
            this.checkBox_flags_noMove = new System.Windows.Forms.CheckBox();
            this.checkBox_flags_noSize = new System.Windows.Forms.CheckBox();
            this.checkBox_flags_enabled = new System.Windows.Forms.CheckBox();
            this.comboBox_zOrder = new System.Windows.Forms.ComboBox();
            this.button_getRect = new System.Windows.Forms.Button();
            this.groupBox_searchProc.SuspendLayout();
            this.groupBox_position.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_position_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_position_x)).BeginInit();
            this.groupBox_size.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size_x)).BeginInit();
            this.groupBox_flags.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_ok.Location = new System.Drawing.Point(336, 291);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 3;
            this.button_ok.Text = "_ok_";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(417, 291);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "_cancel_";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // listBox_procSearchResult
            // 
            this.listBox_procSearchResult.FormattingEnabled = true;
            this.listBox_procSearchResult.Location = new System.Drawing.Point(6, 45);
            this.listBox_procSearchResult.Name = "listBox_procSearchResult";
            this.listBox_procSearchResult.Size = new System.Drawing.Size(193, 251);
            this.listBox_procSearchResult.TabIndex = 1;
            this.listBox_procSearchResult.DoubleClick += new System.EventHandler(this.listBox_procSearchResult_DoubleClick);
            // 
            // textBox_procSearchString
            // 
            this.textBox_procSearchString.Location = new System.Drawing.Point(6, 19);
            this.textBox_procSearchString.Name = "textBox_procSearchString";
            this.textBox_procSearchString.Size = new System.Drawing.Size(193, 20);
            this.textBox_procSearchString.TabIndex = 0;
            this.textBox_procSearchString.TextChanged += new System.EventHandler(this.textBox_procSearchString_TextChanged);
            // 
            // groupBox_searchProc
            // 
            this.groupBox_searchProc.Controls.Add(this.textBox_procSearchString);
            this.groupBox_searchProc.Controls.Add(this.listBox_procSearchResult);
            this.groupBox_searchProc.Location = new System.Drawing.Point(12, 12);
            this.groupBox_searchProc.Name = "groupBox_searchProc";
            this.groupBox_searchProc.Size = new System.Drawing.Size(205, 303);
            this.groupBox_searchProc.TabIndex = 0;
            this.groupBox_searchProc.TabStop = false;
            this.groupBox_searchProc.Text = "groupBox1";
            // 
            // button_setProcName
            // 
            this.button_setProcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_setProcName.Location = new System.Drawing.Point(223, 29);
            this.button_setProcName.Name = "button_setProcName";
            this.button_setProcName.Size = new System.Drawing.Size(35, 23);
            this.button_setProcName.TabIndex = 5;
            this.button_setProcName.Text = ">>";
            this.button_setProcName.UseVisualStyleBackColor = true;
            this.button_setProcName.Click += new System.EventHandler(this.button_setProcName_Click);
            // 
            // textBox_procName
            // 
            this.textBox_procName.Location = new System.Drawing.Point(264, 31);
            this.textBox_procName.Name = "textBox_procName";
            this.textBox_procName.Size = new System.Drawing.Size(228, 20);
            this.textBox_procName.TabIndex = 6;
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(255, 291);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 2;
            this.button_test.Text = "_test_";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // groupBox_position
            // 
            this.groupBox_position.Controls.Add(this.numericUpDown_position_y);
            this.groupBox_position.Controls.Add(this.numericUpDown_position_x);
            this.groupBox_position.Location = new System.Drawing.Point(231, 72);
            this.groupBox_position.Name = "groupBox_position";
            this.groupBox_position.Size = new System.Drawing.Size(139, 47);
            this.groupBox_position.TabIndex = 8;
            this.groupBox_position.TabStop = false;
            this.groupBox_position.Text = "groupBox1";
            // 
            // numericUpDown_position_y
            // 
            this.numericUpDown_position_y.Location = new System.Drawing.Point(72, 19);
            this.numericUpDown_position_y.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.numericUpDown_position_y.Minimum = new decimal(new int[] {
            2000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_position_y.Name = "numericUpDown_position_y";
            this.numericUpDown_position_y.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_position_y.TabIndex = 1;
            // 
            // numericUpDown_position_x
            // 
            this.numericUpDown_position_x.Location = new System.Drawing.Point(6, 19);
            this.numericUpDown_position_x.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.numericUpDown_position_x.Minimum = new decimal(new int[] {
            2000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_position_x.Name = "numericUpDown_position_x";
            this.numericUpDown_position_x.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_position_x.TabIndex = 0;
            // 
            // groupBox_size
            // 
            this.groupBox_size.Controls.Add(this.numericUpDown_size_y);
            this.groupBox_size.Controls.Add(this.numericUpDown_size_x);
            this.groupBox_size.Location = new System.Drawing.Point(231, 154);
            this.groupBox_size.Name = "groupBox_size";
            this.groupBox_size.Size = new System.Drawing.Size(139, 47);
            this.groupBox_size.TabIndex = 9;
            this.groupBox_size.TabStop = false;
            this.groupBox_size.Text = "groupBox1";
            // 
            // numericUpDown_size_y
            // 
            this.numericUpDown_size_y.Location = new System.Drawing.Point(72, 19);
            this.numericUpDown_size_y.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.numericUpDown_size_y.Minimum = new decimal(new int[] {
            2000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_size_y.Name = "numericUpDown_size_y";
            this.numericUpDown_size_y.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_size_y.TabIndex = 1;
            // 
            // numericUpDown_size_x
            // 
            this.numericUpDown_size_x.Location = new System.Drawing.Point(6, 19);
            this.numericUpDown_size_x.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.numericUpDown_size_x.Minimum = new decimal(new int[] {
            2000000,
            0,
            0,
            -2147483648});
            this.numericUpDown_size_x.Name = "numericUpDown_size_x";
            this.numericUpDown_size_x.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_size_x.TabIndex = 0;
            // 
            // groupBox_flags
            // 
            this.groupBox_flags.Controls.Add(this.checkBox_flags_noZOrder);
            this.groupBox_flags.Controls.Add(this.checkBox_flags_noMove);
            this.groupBox_flags.Controls.Add(this.checkBox_flags_noSize);
            this.groupBox_flags.Controls.Add(this.checkBox_flags_enabled);
            this.groupBox_flags.Location = new System.Drawing.Point(376, 72);
            this.groupBox_flags.Name = "groupBox_flags";
            this.groupBox_flags.Size = new System.Drawing.Size(116, 129);
            this.groupBox_flags.TabIndex = 10;
            this.groupBox_flags.TabStop = false;
            this.groupBox_flags.Text = "groupBox1";
            // 
            // checkBox_flags_noZOrder
            // 
            this.checkBox_flags_noZOrder.AutoSize = true;
            this.checkBox_flags_noZOrder.Location = new System.Drawing.Point(6, 89);
            this.checkBox_flags_noZOrder.Name = "checkBox_flags_noZOrder";
            this.checkBox_flags_noZOrder.Size = new System.Drawing.Size(80, 17);
            this.checkBox_flags_noZOrder.TabIndex = 3;
            this.checkBox_flags_noZOrder.Text = "checkBox4";
            this.checkBox_flags_noZOrder.UseVisualStyleBackColor = true;
            // 
            // checkBox_flags_noMove
            // 
            this.checkBox_flags_noMove.AutoSize = true;
            this.checkBox_flags_noMove.Location = new System.Drawing.Point(6, 66);
            this.checkBox_flags_noMove.Name = "checkBox_flags_noMove";
            this.checkBox_flags_noMove.Size = new System.Drawing.Size(80, 17);
            this.checkBox_flags_noMove.TabIndex = 2;
            this.checkBox_flags_noMove.Text = "checkBox3";
            this.checkBox_flags_noMove.UseVisualStyleBackColor = true;
            // 
            // checkBox_flags_noSize
            // 
            this.checkBox_flags_noSize.AutoSize = true;
            this.checkBox_flags_noSize.Location = new System.Drawing.Point(6, 43);
            this.checkBox_flags_noSize.Name = "checkBox_flags_noSize";
            this.checkBox_flags_noSize.Size = new System.Drawing.Size(80, 17);
            this.checkBox_flags_noSize.TabIndex = 1;
            this.checkBox_flags_noSize.Text = "checkBox2";
            this.checkBox_flags_noSize.UseVisualStyleBackColor = true;
            // 
            // checkBox_flags_enabled
            // 
            this.checkBox_flags_enabled.AutoSize = true;
            this.checkBox_flags_enabled.Location = new System.Drawing.Point(6, 20);
            this.checkBox_flags_enabled.Name = "checkBox_flags_enabled";
            this.checkBox_flags_enabled.Size = new System.Drawing.Size(80, 17);
            this.checkBox_flags_enabled.TabIndex = 0;
            this.checkBox_flags_enabled.Text = "checkBox1";
            this.checkBox_flags_enabled.UseVisualStyleBackColor = true;
            // 
            // comboBox_zOrder
            // 
            this.comboBox_zOrder.FormattingEnabled = true;
            this.comboBox_zOrder.Location = new System.Drawing.Point(231, 216);
            this.comboBox_zOrder.Name = "comboBox_zOrder";
            this.comboBox_zOrder.Size = new System.Drawing.Size(139, 21);
            this.comboBox_zOrder.TabIndex = 11;
            // 
            // button_getRect
            // 
            this.button_getRect.Location = new System.Drawing.Point(237, 125);
            this.button_getRect.Name = "button_getRect";
            this.button_getRect.Size = new System.Drawing.Size(126, 23);
            this.button_getRect.TabIndex = 12;
            this.button_getRect.Text = "_get_";
            this.button_getRect.UseVisualStyleBackColor = true;
            this.button_getRect.Click += new System.EventHandler(this.button_getRect_Click);
            // 
            // editJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 326);
            this.Controls.Add(this.button_getRect);
            this.Controls.Add(this.comboBox_zOrder);
            this.Controls.Add(this.groupBox_flags);
            this.Controls.Add(this.groupBox_size);
            this.Controls.Add(this.groupBox_position);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.textBox_procName);
            this.Controls.Add(this.button_setProcName);
            this.Controls.Add(this.groupBox_searchProc);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "editJob";
            this.Load += new System.EventHandler(this.editJob_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.editJob_KeyUp);
            this.groupBox_searchProc.ResumeLayout(false);
            this.groupBox_searchProc.PerformLayout();
            this.groupBox_position.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_position_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_position_x)).EndInit();
            this.groupBox_size.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size_x)).EndInit();
            this.groupBox_flags.ResumeLayout(false);
            this.groupBox_flags.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ListBox listBox_procSearchResult;
        private System.Windows.Forms.TextBox textBox_procSearchString;
        private System.Windows.Forms.GroupBox groupBox_searchProc;
        private System.Windows.Forms.Button button_setProcName;
        private System.Windows.Forms.TextBox textBox_procName;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.GroupBox groupBox_position;
        private System.Windows.Forms.NumericUpDown numericUpDown_position_y;
        private System.Windows.Forms.NumericUpDown numericUpDown_position_x;
        private System.Windows.Forms.GroupBox groupBox_size;
        private System.Windows.Forms.NumericUpDown numericUpDown_size_y;
        private System.Windows.Forms.NumericUpDown numericUpDown_size_x;
        private System.Windows.Forms.GroupBox groupBox_flags;
        private System.Windows.Forms.CheckBox checkBox_flags_noZOrder;
        private System.Windows.Forms.CheckBox checkBox_flags_noMove;
        private System.Windows.Forms.CheckBox checkBox_flags_noSize;
        private System.Windows.Forms.CheckBox checkBox_flags_enabled;
        private System.Windows.Forms.ComboBox comboBox_zOrder;
        private System.Windows.Forms.Button button_getRect;
    }
}