using System;
using System.Windows.Forms;

namespace Notepad0001
{
    public partial class Find: Form
    {
        private string _LastSearchText;
        private bool _LastMatchCase;
        private object _LastSearchDown;
        public int SelectionLength { get; private set; }
        public string Content { get; set; }
        public int SelectionStart { get; private set; }
        public object SelectionEnd { get; private set; }

        public Find()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonFindNext_Click(object sender, EventArgs e)
        {// I set the TextToFind property of the Functions class to the text I entered in the text box and the close the form!
            Functions.TextToFind = textBox1.Text;
            Hide();
            //In the Load event of this form I set the text box text to the last search if there is one 
            if (Functions.TextToFind != "")
                textBox1.Text = Functions.TextToFind;
            var SearchText = textBox1.Text;
            var MatchCase = controlMatchCaseCheckbox.Checked;
            var bSearchDown = controlDownRadioButton.Checked;

           
        }
        private void Find_Load(object sender, EventArgs e)
        {
            
        }

        private void FindAndSelect()
        {
            throw new NotImplementedException();
        }

        private bool FindAndSelect(string searchText, bool matchCase, bool bSearchDown)
        {
            throw new NotImplementedException();
        }

        public void Triggered()
        {
            textBox1.Focus();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var Sender = (TextBox)sender;
            Sender.SelectAll();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

    }
}
