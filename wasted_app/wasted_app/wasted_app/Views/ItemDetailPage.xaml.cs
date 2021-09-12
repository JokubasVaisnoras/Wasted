using System.ComponentModel;
using wasted_app.ViewModels;
using Xamarin.Forms;

namespace wasted_app.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}