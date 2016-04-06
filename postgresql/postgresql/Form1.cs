using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marten;

namespace postgresql
{
    public partial class Form1 : Form
    {
        private DocumentStore _store;

        public Form1()
        {
            InitializeComponent();
            _store = DocumentStore.For("host=192.168.43.210;database=devtalks;password=devtalks;username=devtalks");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            using (var session = _store.LightweightSession())
            {

            }
        }
    }


}
