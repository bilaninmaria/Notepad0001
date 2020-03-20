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
            this.controlDownRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.controlMatchCaseCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonFindNext
            // 
            this.buttonFindNext.Location = new System.Drawing.Point(263, 14);
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.Size = new System.Drawing.Size(75, 23);
            this.buttonFindNext.TabIndex = 0;
            this.buttonFindNext.Text = "Find Next";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(263, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 20);
            this.textBox1.TabIndex = 2;
            // 
            // labelFindWhat
            // 
            this.labelFindWhat.AutoSize = true;
            this.labelFindWhat.Location = new System.Drawing.Point(-1, 33);
            this.labelFindWhat.Name = "labelFindWhat";
            this.labelFindWhat.Size = new System.Drawing.Size(59, 13);
            this.labelFindWhat.TabIndex = 3;
            this.labelFindWhat.Text = "Find what :";
            // 
            // controlUpRadioButton
            // 
            this.controlUpRadioButton.AutoSize = true;
            this.controlUpRadioButton.Location = new System.Drawing.Point(133, 101);
            this.controlUpRadioButton.Name = "controlUpRadioButton";
            this.controlUpRadioButton.Size = new System.Drawing.Size(39, 17);
            this.controlUpRadioButton.TabIndex = 4;
            this.controlUpRadioButton.TabStop = true;
            this.controlUpRadioButton.Text = "Up";
            this.controlUpRadioButton.UseVisualStyleBackColor = true;
            // 
            // controlDownRadioButton
            // 
            this.controlDownRadioButton.AutoSize = true;
            this.controlDownRadioButton.Location = new System.Drawing.Point(193, 101);
            this.controlDownRadioButton.Name = "controlDownRadioButton";
            this.controlDownRadioButton.Size = new System.Drawing.Size(53, 17);
            this.controlDownRadioButton.TabIndex = 5;
            this.controlDownRadioButton.TabStop = true;
            this.controlDownRadioButton.Text = "Down";
            this.controlDownRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Direction:";
            // 
            // controlMatchCaseCheckbox
            // 
            this.controlMatchCaseCheckbox.AutoSize = true;
            this.controlMatchCaseCheckbox.Location = new System.Drawing.Point(2, 101);
            this.controlMatchCaseCheckbox.Name = "controlMatchCaseCheckbox";
            this.controlMatchCaseCheckbox.Size = new System.Drawing.Size(80, 17);
            this.controlMatchCaseCheckbox.TabIndex = 7;
            this.controlMatchCaseCheckbox.Text = "MatchCase";
            this.controlMatchCaseCheckbox.UseVisualStyleBackColor = true;
            // 
            // Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 130);
            this.Controls.Add(this.controlMatchCaseCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.controlDownRadioButton);
            this.Controls.Add(this.controlUpRadioButton);
            this.Controls.Add(this.labelFindWhat);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonFindNext);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Find";
            this.ShowIcon = false;
            this.Text = "Find";
            this.Load += new System.EventHandler(this.Find_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFindNext;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelFindWhat;
        private System.Windows.Forms.RadioButton controlUpRadioButton;
        private System.Windows.Forms.RadioButton controlDownRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox controlMatchCaseCheckbox;
    }
}