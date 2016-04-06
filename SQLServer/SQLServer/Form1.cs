using System;
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
            var id = int.Parse(this.textBox1.Text);
            Database.Open().SaveRead(id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            foreach (var row in Database.Open().ReadCounts.All())
            {
                var articleId = row.ArticleId;
                var readCount = row.ReadCount;

                richTextBox1.AppendText(string.Format("{0} {1} {2}", articleId, readCount, Environment.NewLine));
            }
        }
    }
}
