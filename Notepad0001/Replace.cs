using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Notepad0001
{
    public partial class Replace : Form
    {
        public bool FindNextClicked { get; private set; }
        public bool ReplaceAllClicked { get; private set; }
        public Replace()
        {
            InitializeComponent();
        }
        private void Replace_Load(object sender, EventArgs e)
        {
            if (Functions.TextToFind != null)
                findTextBox.Text = Functions.TextToFind;
            if (Functions.ReplacementText != null)
                replaceTextBox.Text = Functions.ReplacementText;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (findTextBox.Text != null)
            {
                FindNextClicked = true;
                ReplaceAllClicked = false;
                Functions.TextToFind = findTextBox.Text;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (findTextBox.Text != null && replaceTextBox.Text != null)
            {
                ReplaceAllClicked = true;
                FindNextClicked = false;
                Functions.TextToFind = findTextBox.Text;
                Functions.ReplacementText = replaceTextBox.Text;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
