using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simple.Data;

namespace SQLServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.Open().SaveRead(int.Parse(this.textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            foreach (var row in Database.Open().ReadCounts.All())
            {
                richTextBox1.AppendText(string.Format("{0} {1} {2}", row.ArticleId, row.ReadCount, Environment.NewLine));
            }
        }
    }
}
