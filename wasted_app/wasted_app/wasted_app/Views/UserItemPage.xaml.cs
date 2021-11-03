using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wasted_app.ViewModels;//here is the change
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserItemPage : ContentPage
    {
        readonly ItemsViewModel _viewModel;
        public UserItemPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }


}