using System;
using System.Windows.Forms;

namespace Notepad0001
{
    public partial class Replace : Form
    {//I need to make two auto-properties to see if the user has clicked FindNext or ReplaceAll
        public bool FindNextClicked { get; private set; }
        public bool ReplaceAllClicked { get; private set; }
        public Replace()
        {
            InitializeComponent();
        }
        private void Replace_Load(object sender, EventArgs e)
        {//If there is some text in the functionality TextToFind or ReplacementText properties set the textBox's text to the properties
            if (Functions.TextToFind != null)
                findTextBox.Text = Functions.TextToFind;
            if (Functions.ReplacementText != null)
                replaceTextBox.Text = Functions.ReplacementText;
        }
        private void button1_Click(object sender, EventArgs e)
        {/*When the user clicks FindNext the program should, if the user has entered some text in the text box, set the FindNextClicked to true 
            and ReplaceAllClicked to false, and pass the text entered to the functions class*/
            if (findTextBox.Text != null)
            {
                FindNextClicked = true;
                ReplaceAllClicked = false;
                Functions.TextToFind = findTextBox.Text;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {/* When the user clicks the replace all button the program should check if there is any text in both textBoxes and then set the FindNextClicked 
            to false and ReplaceAllClicked to true! Also set the Function.TextToFind property to the entered text and Function.ReplacementText to the 
            entered text!*/
            if (findTextBox.Text != null && replaceTextBox.Text != null)
            {
                ReplaceAllClicked = true;
                FindNextClicked = false;
                Functions.TextToFind = findTextBox.Text;
                Functions.ReplacementText = replaceTextBox.Text;
                Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
