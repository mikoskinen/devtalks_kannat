using System;
using System.Windows;
using RethinkDb.Driver;
using RethinkDb.Driver.Net;

namespace RethinkDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static RethinkDb.Driver.RethinkDB db;
        private static Connection conn;

        public MainWindow()
        {
            InitializeComponent();
            db = new RethinkDb.Driver.RethinkDB();
            conn = db.Connection()
                .Hostname("localhost")
                .Db("devtalks")
                .Port(RethinkDBConstants.DefaultPort)
                .Timeout(60)
                .Connect();
        }


        private void Add_OnClick(object sender, RoutedEventArgs e)
        {

        }


        private void Update_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private async void Listen_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }

}
