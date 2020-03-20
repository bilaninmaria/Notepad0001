using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad0001
{
    public partial class Find : Form
    {
        public Find()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            Functions.TextToFind = textBox1.Text;
                Close();
            if (Functions.TextToFind != "")
                textBox1.Text = Functions.TextToFind;
            var SearchText = textBox1.Text;
            var MatchCase = controlMatchCaseCheckbox.Checked;
            var bSearchDown = controlDownRadioButton.Checked;

  
        }

        private void Find_Load(object sender, EventArgs e)
        {
            if (Functions.TextToFind != "")
                textBox1.Text = Functions.TextToFind;
        }
    }
}
