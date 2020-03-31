using System;
using System.Linq;

namespace Notepad0001
{
    partial class GoToLine
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
            this.GoToLineNumber = new System.Windows.Forms.Label();
            this.buttonGoTo = new System.Windows.Forms.Button();
            this.buttonCancelGo = new System.Windows.Forms.Button();
            this.lineTextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GoToLineNumber
            // 
            this.GoToLineNumber.AutoSize = true;
            this.GoToLineNumber.Location = new System.Drawing.Point(14, 13);
            this.GoToLineNumber.Name = "GoToLineNumber";
            this.GoToLineNumber.Size = new System.Drawing.Size(73, 13);
            this.GoToLineNumber.TabIndex = 0;
            this.GoToLineNumber.Text = "Line Number :";
            // 
            // buttonGoTo
            // 
            this.buttonGoTo.Location = new System.Drawing.Point(33, 84);
            this.buttonGoTo.Name = "buttonGoTo";
            this.buttonGoTo.Size = new System.Drawing.Size(75, 23);
            this.buttonGoTo.TabIndex = 2;
            this.buttonGoTo.Text = "Go To";
            this.buttonGoTo.UseVisualStyleBackColor = true;
            this.buttonGoTo.Click += new System.EventHandler(this.buttonGoTo_Click);
            // 
            // buttonCancelGo
            // 
            this.buttonCancelGo.Location = new System.Drawing.Point(146, 84);
            this.buttonCancelGo.Name = "buttonCancelGo";
            this.buttonCancelGo.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelGo.TabIndex = 3;
            this.buttonCancelGo.Text = "Cancel";
            this.buttonCancelGo.UseVisualStyleBackColor = true;
            this.buttonCancelGo.Click += new System.EventHandler(this.buttonCancelGo_Click);
            // 
            // lineTextBox1
            // 
            this.lineTextBox1.Location = new System.Drawing.Point(17, 48);
            this.lineTextBox1.Name = "lineTextBox1";
            this.lineTextBox1.Size = new System.Drawing.Size(211, 20);
            this.lineTextBox1.TabIndex = 4;
            this.lineTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lineTextBox1_KeyPress);
            // 
            // GoToLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 117);
            this.Controls.Add(this.lineTextBox1);
            this.Controls.Add(this.buttonCancelGo);
            this.Controls.Add(this.buttonGoTo);
            this.Controls.Add(this.GoToLineNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoToLine";
            this.ShowIcon = false;
            this.Text = "Go To Line ";
            this.Load += new System.EventHandler(this.GoToLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

  
        #endregion

        private System.Windows.Forms.Label GoToLineNumber;
        private System.Windows.Forms.Button buttonGoTo;
        private System.Windows.Forms.Button buttonCancelGo;
        private System.Windows.Forms.TextBox lineTextBox1;
    }
}