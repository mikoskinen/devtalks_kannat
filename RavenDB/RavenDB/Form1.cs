using System;
using System.Linq;
using System.Windows.Forms;
using Raven.Client.Bundles.Versioning;
using Raven.Client.Document;

namespace RavenDB
{
    public partial class Form1 : Form
    {
        private string personId;

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, System.EventArgs e)
        {
            using (var store = new DocumentStore { Url = "http://devtalks:8080/", DefaultDatabase = "devtalks" })
            {
                store.Initialize();

       
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            using (var store = new DocumentStore { Url = "http://devtalks:8080/", DefaultDatabase = "devtalks" })
            {
                store.Initialize();

            }
        }
    }
}
