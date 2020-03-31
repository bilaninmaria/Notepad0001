using System;
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
            lineTextBox1.Text = Functions.GoToLineNumber.ToString();
        }

        private void buttonCancelGo_Click(object sender, EventArgs e)
        {
            GoToClicked = false;
            Close();
        }
        ///I need to set the functions go to line number to the parsed int value of the lineTextBox
        private void buttonGoTo_Click(object sender, EventArgs e)
        {/*If the GoToLineNumber is greater than the MaxNumberOfLines them show a message to the user,
            else pass that value to the GoToLineNumber, set the GoTo indicator to true property and close the form*/
            if (int.Parse(lineTextBox1.Text) > Functions.MaxNumberOfLines)
               MessageBox.Show("The line number is beyond the total number of lines");
           else
           {
              GoToClicked = true;
              Functions.GoToLineNumber = int.Parse(lineTextBox1.Text);
              Close();
           }
        }
        private void lineTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Limit the user to entering only numbers:
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
