using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad0001
{
    public partial class Form1 : Form
    {
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
        {
            DialogResult result = FontDialog.ShowDialog();
            if (result == DialogResult.OK)
                TextBox1.Font = FontDialog.Font;
        }
        private void TextBoxModeChange()
        {
            TextBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
            TextBox1.ScrollBars = wordWrapToolStripMenuItem.Checked ? ScrollBars.Vertical : ScrollBars.Both;
            if (wordWrapToolStripMenuItem.Checked)
                TextBox1.ScrollBars = ScrollBars.Vertical;
            else
                TextBox1.ScrollBars = ScrollBars.Both;
        }
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBoxModeChange();
        }
        private void StatusBarChange()
        {
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
        private void StatusBarUpdate()
        {
            int statusBarLine = TextBox1.GetLineFromCharIndex(TextBox1.GetFirstCharIndexOfCurrentLine());
            int statusBarColumn = TextBox1.SelectionStart - TextBox1.GetFirstCharIndexOfCurrentLine();
            toolStripStatusLabel1.Text = "Ln " + statusBarLine.ToString() + ", Col " + statusBarColumn.ToString();
        }
        private void TextBox1_Changed(object sender, KeyPressEventArgs e)
        {
            StatusBarUpdate();
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
        {
            Find findForm = new Find();
            findForm.ShowDialog();
            Find(Functions.TextToFind, ref findForm);
        }
        private void Find(string textToFind, ref Find findForm)
        {
            if (TextBox1.Text.IndexOf(textToFind) == -1)
            {
                MessageBox.Show("Cannot find '" + textToFind + " '");
                findForm.ShowDialog();
            }
            else
            {
                TextBox1.SelectionStart = TextBox1.Text.IndexOf(Functions.TextToFind);
                TextBox1.SelectionLength = textToFind.Length;
            }
        }
        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find findForm = new Find();
            Find(Functions.TextToFind, ref findForm);
        }
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replace replaceForm = new Replace();
            replaceForm.ShowDialog();
            if (replaceForm.FindNextClicked)
            {
                Find findForm = new Find();
                Find(Functions.TextToFind, ref findForm);
            }
            if (replaceForm.FindNextClicked)
            {
                Find findForm = new Find();
                Find(Functions.TextToFind, ref findForm);
            }
            else if (replaceForm.ReplaceAllClicked)
                ReplaceAll(Functions.TextToFind, Functions.ReplacementText);
        }
        private void ReplaceAll(string textToReplace, string replacementText)
        {
            Regex regex = new Regex(textToReplace);
            string finishText = regex.Replace(TextBox1.Text, replacementText);
            if (TextBox1.Text == finishText)
                MessageBox.Show("Nothing was replaced, because there were no words to replace!");
            else
            {
                TextBox1.Text = finishText;
                MessageBox.Show("'" + textToReplace + "' was replaced by '" + replacementText + "'");
            }
        }
        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions.MaxNumberOfLines = TextBox1.Lines.Count();
            GoToLine goToForm = new GoToLine();
            goToForm.ShowDialog();
            if (goToForm.GoToClicked)
            {
                TextBox1.SelectionStart = TextBox1.GetFirstCharIndexFromLine(Functions.GoToLineNumber - 1);
                TextBox1.SelectionLength = 0;
            }
        }
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
                        //Write all of the text in txtBox to the specified file
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
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = printDocument1;
            DialogResult result = pageSetupDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
                printDocument1.PrinterSettings = pageSetupDialog1.PrinterSettings;
            }
        }
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            DialogResult result = printPreviewDialog1.ShowDialog();
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
        private void printDocument_PrintPage(Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(TextBox1.Text, TextBox1.Font, Brushes.Black, 0, 0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);

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
            StatusBarUpdate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();

        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void SaveChanges()
        {
            if (_oldFile != TextBox1.Text)
            {
                if (_filePath != null)
                {
                    DialogResult result = MessageBox.Show("Do you want to save the changes to " + _filePath, "Saving Changes",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        Save(_filePath);
                }

            }

        }

        private void Save(object filePath)
        {
           
            if (!string.IsNullOrWhiteSpace(fileToSave))
            {
                using (var myWriter = new StreamWriter(fileToSave))
                    myWriter.Write(TextBox1.Text);

            }

        }

        private void Open()
        {
            this.SaveChanges();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(openFileDialog1.FileName))
                {
                    _filePath = openFileDialog1.FileName;
                    using (var myReader = new StreamReader(_filePath))
                        TextBox1.Text = _oldFile = myReader.ReadToEnd();
                }

            }

        }
        
    }

}
