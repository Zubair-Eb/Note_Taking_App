using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Note_Taking_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string file = "";

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Text Files | *.txt";
            if (dr == DialogResult.OK) 
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
               
                file = openFileDialog1.FileName;
                Task<string> text = sr.ReadToEndAsync();
                richTextBox1.Text = text.Result;

            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            saveFileDialog1.Filter = "Text Files | *.txt";
            if (dr == DialogResult.OK)
            {
                StreamWriter sWriter = new StreamWriter(saveFileDialog1.FileName);
                sWriter.Write(richTextBox1.Text);
                sWriter.Close();

            }
    }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
