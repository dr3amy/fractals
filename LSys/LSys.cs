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

namespace lab05
{
    public partial class LSys : Form
    {
        Grammar currentGrammar = null;
        Pen drawingPen = new Pen(Color.Black);

        public LSys()
        {
            InitializeComponent();
        }

        class Grammar
        {
            public string atom;
            public double angle;
            public Dictionary<char, string> rules = new Dictionary<char, string>();
        }

        private void loadGrammar(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                string[] firstLineItems = lines[0].Split(' ');
                Grammar grammar = new Grammar();
                grammar.atom = firstLineItems[0];
                grammar.angle = double.Parse(firstLineItems[1].Replace('.', ','));

                foreach (var line in lines.Skip(1))
                {
                    string[] lineItems = line.Split(' ');
                    grammar.rules.Add(lineItems[0][0], lineItems[2]);
                }

                currentGrammar = grammar;
            }
            catch (Exception)
            {
                currentGrammar = null;
                MessageBox.Show("invalid file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.CurrentDirectory.Replace("bin\\Debug", "") + "LSys\\examples";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = dialog.FileName;
                fileNameLabel.Text = Path.GetFileName(selectedFile);
                iterationsCountBox.Value = 1;
                loadGrammar(selectedFile);
                
            }
        }
    }
}
