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
    public partial class GoToLine : Form
    {
        public bool GoToClicked { get; private set; }

        public GoToLine()
        {
            InitializeComponent();
        }

        private void GoToLine_Load(object sender, EventArgs e)
        {
            lineTextBox.Text = Functions.GoToLineNumber.ToString();

        }

        private void buttonCancelGo_Click(object sender, EventArgs e)
        {
            GoToClicked = false;
            Close();

        }

        private void textBox1_TextChanged(object sender,KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);

        }

        private void buttonGoTo_Click(object sender, EventArgs e)
        {
            if (int.Parse(lineTextBox.Text) > Functions.MaxNumberOfLines)
               MessageBox.Show("The line number is beyond the total number of lines");
           else
           {
              GoToClicked = true;
              Functions.GoToLineNumber = int.Parse(lineTextBox.Text);
              Close();
           }
        }
    }
}
