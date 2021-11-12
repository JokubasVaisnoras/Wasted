using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using wasted_app.Tables;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusinessPage : ContentPage
    {
        public BusinessPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BusinessDatabase.db");
            
            using (var db = new SQLiteConnection(dbpath))
            {
                db.CreateTable<RegUserTable>();
                var business = db.Table<RegUserTable>().ToList();

                businessListView.ItemsSource = business;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BusinessDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();

            /*
             var lazyItem = new Lazy<RegUserTable>(() =>
             new RegUserTable
             {
                 Email = EntryUserEmail.Text,
                 Username = EntryUsername.Text,
                 Password = EntryUserPassword.Text,
                 PhoneNumber = EntryUserPhoneNumber.Text
             });
             var item = lazyItem.Value;
            */

            Lazy<RegUserTable> lazyItem = new Lazy<RegUserTable>();
            lazyItem.Value.Email = EntryUserEmail.Text;
            lazyItem.Value.Password = EntryUserPassword.Text;
            lazyItem.Value.PhoneNumber = EntryUserPhoneNumber.Text;
            lazyItem.Value.Username = EntryUsername.Text;
            var item = lazyItem.Value;

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulations!", "Welcome to the family", "OK", " ");

            });
        }
    }
}
