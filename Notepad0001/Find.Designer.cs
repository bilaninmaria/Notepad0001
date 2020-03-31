namespace Notepad0001
{
    partial class Find
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
            this.buttonFindNext = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelFindWhat = new System.Windows.Forms.Label();
            this.controlUpRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.controlMatchCaseCheckbox = new System.Windows.Forms.CheckBox();
            this.controlDownRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFindNext
            // 
            this.buttonFindNext.Location = new System.Drawing.Point(258, 25);
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.Size = new System.Drawing.Size(75, 23);
            this.buttonFindNext.TabIndex = 0;
            this.buttonFindNext.Text = "Find Next";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(258, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelFindWhat
            // 
            this.labelFindWhat.AutoSize = true;
            this.labelFindWhat.Location = new System.Drawing.Point(5, 47);
            this.labelFindWhat.Name = "labelFindWhat";
            this.labelFindWhat.Size = new System.Drawing.Size(59, 13);
            this.labelFindWhat.TabIndex = 3;
            this.labelFindWhat.Text = "Find what :";
            // 
            // controlUpRadioButton
            // 
            this.controlUpRadioButton.AutoSize = true;
            this.controlUpRadioButton.Checked = true;
            this.controlUpRadioButton.Location = new System.Drawing.Point(151, 19);
            this.controlUpRadioButton.Name = "controlUpRadioButton";
            this.controlUpRadioButton.Size = new System.Drawing.Size(39, 17);
            this.controlUpRadioButton.TabIndex = 4;
            this.controlUpRadioButton.TabStop = true;
            this.controlUpRadioButton.Text = "Up";
            this.controlUpRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Direction:";
            // 
            // controlMatchCaseCheckbox
            // 
            this.controlMatchCaseCheckbox.AutoSize = true;
            this.controlMatchCaseCheckbox.Checked = true;
            this.controlMatchCaseCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.controlMatchCaseCheckbox.Location = new System.Drawing.Point(0, 13);
            this.controlMatchCaseCheckbox.Name = "controlMatchCaseCheckbox";
            this.controlMatchCaseCheckbox.Size = new System.Drawing.Size(80, 17);
            this.controlMatchCaseCheckbox.TabIndex = 7;
            this.controlMatchCaseCheckbox.Text = "MatchCase";
            this.controlMatchCaseCheckbox.UseVisualStyleBackColor = true;
            // 
            // controlDownRadioButton
            // 
            this.controlDownRadioButton.AutoSize = true;
            this.controlDownRadioButton.Location = new System.Drawing.Point(216, 19);
            this.controlDownRadioButton.Name = "controlDownRadioButton";
            this.controlDownRadioButton.Size = new System.Drawing.Size(53, 17);
            this.controlDownRadioButton.TabIndex = 8;
            this.controlDownRadioButton.Text = "Down";
            this.controlDownRadioButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.controlDownRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.controlMatchCaseCheckbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.controlDownRadioButton);
            this.groupBox1.Controls.Add(this.controlUpRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(0, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 36);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(339, 130);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelFindWhat);
            this.Controls.Add(this.buttonFindNext);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Find";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Text = "Find";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFindNext;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelFindWhat;
        private System.Windows.Forms.RadioButton controlUpRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox controlMatchCaseCheckbox;
        private System.Windows.Forms.RadioButton controlDownRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}