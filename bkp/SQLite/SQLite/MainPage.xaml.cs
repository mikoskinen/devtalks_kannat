using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLite
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        static MobileServiceClient client = new MobileServiceClient("https://devtalks.azurewebsites.net");
        private IMobileServiceSyncTable<Category> categoryTable = client.GetSyncTable<Category>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await InitLocalStoreAsync(); 
        }

        private async Task InitLocalStoreAsync()
        {
            if (!client.SyncContext.IsInitialized)
            {
                var store = new MobileServiceSQLiteStore("localstore.db");
                store.DefineTable<Category>();
                await client.SyncContext.InitializeAsync(store);
            }

            await SyncAsync();
        }

        private async Task SyncAsync()
        {
            await client.SyncContext.PushAsync();
            await categoryTable.PullAsync(null, categoryTable.CreateQuery());

            var allItems = await categoryTable.CreateQuery().ToListAsync();
            this.Items.ItemsSource = allItems;
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            categoryTable.InsertAsync(new Category() {Name = this.CategoryName.Text});
        }

        private async void Sync_OnClick(object sender, RoutedEventArgs e)
        {
            await SyncAsync();
        }
    }
}
