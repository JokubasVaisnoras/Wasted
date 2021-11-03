using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using wasted_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserItemDetailPage : ContentPage
    {
        public UserItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();//
        }
    }
}