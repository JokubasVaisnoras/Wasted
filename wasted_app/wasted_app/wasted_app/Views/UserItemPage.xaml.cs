using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;//
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wasted_app.Models;//
using wasted_app.ViewModels;//here is the change
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserItemPage : ContentPage
    {
        // buvo readonly itemsviewmodel
        readonly ItemsViewModel _viewModel = new ItemsViewModel();
      

        public UserItemPage()
        {
            InitializeComponent();
            BindingContext = _viewModel;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            var searchTerm = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = string.Empty;
            }
            searchTerm = searchTerm.ToLowerInvariant();
            //var sourceItems = _viewModel.Items;
            var editedsourceItems = _viewModel.Items.ToList();
            var filteredItems = _viewModel.Items.Where(value => 
            value.Name.ToLowerInvariant().Contains(searchTerm)).ToList();

            /*if (string.IsNullOrWhiteSpace(searchTerm))
            {
                filteredItems = _viewModel.Items.ToList();
            }*/
                foreach(var value in editedsourceItems)
                {
                    if(!filteredItems.Contains(value))
                    {
                        _viewModel.Items.Remove(value);
                    }
                    else if (!_viewModel.Items.Contains(value))
                    {
                        _viewModel.Items.Add(value);
                    }
                }
            
        }
    }


}