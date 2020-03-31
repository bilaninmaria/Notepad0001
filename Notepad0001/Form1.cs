
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Notepad0001
{
    public partial class Form1 : Form
    {/*I'll need a global variable that holds the current file path and a variable to hold the previous file 
        (So that I may compare them when I need to detect if changes were made)*/
        private string path;
        private string _oldFile;
        private string _filePath;
        public string fileToSave { get; private set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (TextBox1.SelectionLength != 0)
                TextBox1.Copy();
        }
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {//Catch the result and check if the user clicked OK so we will do it like this
            DialogResult result = FontDialog.ShowDialog();
            if (result == DialogResult.OK)
                TextBox1.Font = FontDialog.Font;
        }
        //I need to make the text box wrap the words in it and display the horizontal scroll bar in accordance to the feature state
        //I created a method for this since it will be called from two places (later in the Form1_Load event and here)
        private void TextBoxModeChange()
        {//I also need to make changes to the TextBox1 scroll bars (if word wrap is off show the horizontal, and vertical scroll bar if it's off then just the vertical scroll bar)
            TextBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
            TextBox1.ScrollBars = wordWrapToolStripMenuItem.Checked ? ScrollBars.Vertical : ScrollBars.Both;
            if (wordWrapToolStripMenuItem.Checked)
                TextBox1.ScrollBars = ScrollBars.Vertical;
            else
                TextBox1.ScrollBars = ScrollBars.Both;
        }
        // Now I add the call to that method from the :
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBoxModeChange();
        }
        private void StatusBarChange()
        {//Well if the status bar is visible the hide it and uncheck the menu item, else show it and check the menu item
           // I make a method that returns void and it's private
            if (statusStrip.Visible)
            {
                statusBarToolStripMenuItem.Checked = false;
                statusStrip.Visible = false;
            }
            else
            {
                statusBarToolStripMenuItem.Checked = true;
                statusStrip.Visible = true;
            }
        }
        /*Let's now tackle the problem of showing the correct text in the status bar,
           create a new method to do this*/
        private void StatusBarUpdate()
        {/*The text box provides the following methods (amongst others):
           .GetFirstCharIndexOfCurrentLine();
           .GetLineFromCharIndex();*/
            int statusBarLine = TextBox1.GetLineFromCharIndex(TextBox1.GetFirstCharIndexOfCurrentLine());
            int statusBarColumn = TextBox1.SelectionStart - TextBox1.GetFirstCharIndexOfCurrentLine();
            toolStripStatusLabel1.Text = "Ln " + statusBarLine.ToString() + ", Col " + statusBarColumn.ToString();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                TextBox1.Undo();
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox1.Cut();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox1.Paste();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox1.SelectAll();
        }
        private void timeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox1.Text += DateTime.Now;
        }
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {// I declare and initialize a new find form and show it...
            Find findForm = new Find ();
            findForm.ShowDialog();
            Find(Functions.TextToFind, ref findForm);
        }
        //I make the method private and the parameters should be the text to find and a referenced find form:
        private void Find(string textToFind, ref Find findForm)
        {/*The body of the method should check if there is in the TextBox1 the text we passed as a parameter, 
           and show a message box that tells the user that there hasn't been a match. Then show the referenced find form*/
            // .IndexOf() method can help to do this
            if (TextBox1.Text.IndexOf(textToFind) == -1)
            {
                MessageBox.Show("Cannot find '" + textToFind + " '");
                findForm.ShowDialog();
            }
            else
            {/*To select the text I need to set the selection start to the index of the searched word,
                then set the selection length to the length of the word that I want to find*/
                TextBox1.SelectionStart = TextBox1.Text.IndexOf(Functions.TextToFind);
                TextBox1.SelectionLength = textToFind.Length;
            }
        }
        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {/*I need to declare and initialize a new form that will be referenced in the find method and then call that method passing the text in the 
            Functions.TextToFind property as the textToFind parameter */
            Find findForm = new Find();
            Find(Functions.TextToFind, ref findForm);
        }
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {//Declare and initialize a new replace form and then show it as a dialog:
            Replace replaceForm = new Replace();
            replaceForm.ShowDialog();
            /*If the user has clicked find next, declare and initialize a new find form and call the Find method, passing the
             Function.TextToFind and the findForm as the parameters:*/
            if (replaceForm.FindNextClicked)
            {
                Find findForm = new Find();
                Find(Functions.TextToFind, ref findForm);
            }
            else if (replaceForm.ReplaceAllClicked)
                ReplaceAll(Functions.TextToFind, Functions.ReplacementText);
        }
        //I make it private and the parameters should be the text to replace and the replacement text
        private void ReplaceAll(string textToReplace, string replacementText)
        {//Was need to add a using statement at the start of the project
            Regex regex = new Regex(textToReplace);//A string that will hold the original text of the text box and a regex to change the words
            string finishText = regex.Replace(TextBox1.Text, replacementText);//Then I call the .Replace() method of the regex to replace the words.
            /*If the replaced text is the same as the original text, then tell the user that there was nothing replaced because there 
            were no words to replace, else tell the user*/
            if (TextBox1.Text == finishText)
                MessageBox.Show("Nothing was replaced, because there were no words to replace!");
            else
            {
                TextBox1.Text = finishText;
                MessageBox.Show("'" + textToReplace + "' was replaced by '" + replacementText + "'");
            }
        }
        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {//I set it to the TextBox1.Lines.Count();
            Functions.MaxNumberOfLines = TextBox1.Lines.Count();
            //Declare a new goToForm and show it
            GoToLine goToForm = new GoToLine();
            goToForm.ShowDialog();
            //If the user clicked 'Go To' then go to the line specified
            if (goToForm.GoToClicked)
            {
                TextBox1.SelectionStart = TextBox1.GetFirstCharIndexFromLine(Functions.GoToLineNumber - 1);
                TextBox1.SelectionLength = 0;
            }
        }
        /*So if the mainTextBox can't undo then the undo button should be disabled, also if there isn't anything in the clipboard the paste 
        button should be disabled, and if nothing is selected, then neither copy nor paste should be enabled*/
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem.Enabled =
               toolStripMenuItem3.Enabled =
                deleteToolStripMenuItem.Enabled = (TextBox1.SelectionLength > 0);

            findToolStripMenuItem.Enabled =
                findNextToolStripMenuItem.Enabled = (TextBox1.TextLength > 0);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (TextBox1.Modified == true)
            {
                DialogResult dr = MessageBox.Show("Do you want to save the file before exiting", "Unsaved file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string filename = sfd.FileName;
                    String filter = "Text Files|*.txt|All Files|*.*";
                    sfd.Filter = filter;
                    sfd.Title = "Save";

                    if (sfd.ShowDialog(this) == DialogResult.OK)
                    {
                        //Write all of the text in TextBox to the specified file
                        System.IO.File.WriteAllText(filename, TextBox1.Text);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    TextBox1.Modified = false;
                    Close();
                }
            }
        }
        public string Content
        {
            get { return TextBox1.Text; }
            set { TextBox1.Text = value; }
        }

        public int SelectionEnd { get; private set; }
        public int SelectionStart { get; private set; }
        public int SelectionLength { get; private set; }

        private string _LastSearchText;
        private bool _LastMatchCase;
        private bool _LastSearchDown;
        public bool FindAndSelect(string SearchText, bool MatchCase, bool SearchDown)
        {
            int Index;

            var eStringComparison = MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

            if (SearchDown)
            {
                Index = Content.IndexOf(SearchText, SelectionEnd, eStringComparison);
            }
            else
            {
                Index = Content.LastIndexOf(SearchText, SelectionStart, SelectionStart, eStringComparison);
            }

            if (Index == -1) return false;

            _LastSearchText = SearchText;
            _LastMatchCase = MatchCase;
            _LastSearchDown = SearchDown;

            SelectionStart = Index;
            SelectionLength = SearchText.Length;

            return true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = printDocument1;//Set the .Document property of our page setup dialog to our print document
            DialogResult result = pageSetupDialog1.ShowDialog();//Open the dialog and 'catch' the result
            //Set the document settings to the user selected if the user clicked 'OK'
            if (result == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
                printDocument1.PrinterSettings = pageSetupDialog1.PrinterSettings;
            }
        }
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;//Set the .Document property of the print preview dialog to our print document
            DialogResult result = printPreviewDialog1.ShowDialog();//Show the dialog and 'catch' the result
            //If the user clicked 'OK' then print the document
            if (result == DialogResult.OK)
                printDocument1.Print();
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
                printDocument1.Print();
        }
        private void Form1_Load(object sender, EventArgs e)
        { //What this does is creates an event that triggers when you print the page
             this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
        }
        private void printDocument_PrintPage(Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;//Graphic to draw something
            g.DrawString(TextBox1.Text, TextBox1.Font, Brushes.Black, 0, 0);//Draw the text with the font in black:
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = string.Empty;
            TextBox1.Clear();
        }
        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents |*", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            path = sfd.FileName;
                            using (StreamWriter sw = new StreamWriter(sfd.FileName))/*Using StreamWrite it's designed for character output in a particular encoding 
                              becauseclasses derived from Stream*/
                            {
                                await sw.WriteLineAsync(TextBox1.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        await sw.WriteLineAsync(TextBox1.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents |*", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            await sw.WriteLineAsync(TextBox1.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox1.Clear();
        }
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatusBarChange();
            StatusBarUpdate();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }
        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }
        //Create a new method 
        //So the method should check if the old file is not equal to the text box text:
        private void SaveChanges()
        {
            if (_oldFile != TextBox1.Text)
            {
                if (_filePath != null)//And then if the file path is null
                {//let's show a message to the user and catch the input
                    DialogResult result = MessageBox.Show("Do you want to save the changes to " + _filePath, "Saving Changes",MessageBoxButtons.YesNo);
                    //And if the user clicked yes save the file
                    if (result == DialogResult.Yes)
                        Save(_filePath);
                }
            }
        }
        //It should accept a string indicating the file to save as a parameter:
        private void Save(object filePath)
        {// check if the parameter inputed isn't empty
            if (!string.IsNullOrWhiteSpace(fileToSave))
            {//And then save the file to the file path specified
                using (var myWriter = new StreamWriter(fileToSave))
                    myWriter.Write(TextBox1.Text);
            }
        }
        private void Open()
        {
            SaveChanges();
            DialogResult result = openFileDialog1.ShowDialog();//Show the dialog and 'catch' the input:
            if (result == DialogResult.OK)//And if the user clicked ok:
            {
                if (!string.IsNullOrWhiteSpace(openFileDialog1.FileName))//Check if the user selected a valid file
                {
                    _filePath = openFileDialog1.FileName;//Set the file path to the one selected
                    using (var myReader = new StreamReader(_filePath))//I need to set the text box text the _oldFile (the string that holds the original document) to the full text of the file
                        TextBox1.Text = _oldFile = myReader.ReadToEnd();
                }
            }
        }
        // I create a custom event handler called TextBox1_TextChanged, and call the previously created method
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            this.StatusBarUpdate();
        }
    }

}
