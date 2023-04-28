using System;
using System.IO;

namespace Notepad
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool newFile;
        private bool textModified;

        public Form()
        {
            InitializeComponent();
            textModified = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textModified)
            {
                DialogResult res = MessageBox.Show("Зберегти зміни в файлі?",
                    "Запитання", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    saveToolStripButton.PerformClick();
                    MessageBox.Show("Збережено!", "Повідомлення", MessageBoxButtons.OK);
                }
                else if (res == DialogResult.Cancel)
                {
                    return;
                }
            }

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Text = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    textBox.Text = reader.ReadToEnd();
                }
            }
            textModified = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine(textBox.Text);
                }
                this.Text = saveFileDialog.FileName;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem.PerformClick();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textModified)
            {
                DialogResult res = MessageBox.Show("Зберегти зміни в файлі?",
                    "Запитання", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    saveToolStripButton.PerformClick();
                    MessageBox.Show("Збережено!", "Повідомлення", MessageBoxButtons.OK);
                }
                else if (res == DialogResult.Cancel)
                {
                    return;
                }
            }
            textBox.Clear();
            this.Text = "New file";
            textModified = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textModified)
            {
                DialogResult result = MessageBox.Show("Зберегти зміни в файлі?",
                    "Запитання", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveToolStripButton.PerformClick();
                    MessageBox.Show("Збережено!", "Повідомлення", MessageBoxButtons.OK);
                    Close();
                }
                else if (result == DialogResult.No)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem.PerformClick();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.PerformClick();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripButton.PerformClick();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
            aboutBox.Dispose();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            aboutToolStripMenuItem.PerformClick();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!textModified)
            {
                textModified = true;
                this.Text = "*" + this.Text;
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textModified)
            {
                DialogResult result = MessageBox.Show("Зберегти зміни в файлі?",
                  "Запитання", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveToolStripButton.PerformClick();
                    MessageBox.Show("Збережено!", "Повідомлення", MessageBoxButtons.OK);
                    Close();
                }
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem.PerformClick();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem.PerformClick();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox.Text, new Font("Times New Romans", 14, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printToolStripMenuItem.PerformClick();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }
    }
}