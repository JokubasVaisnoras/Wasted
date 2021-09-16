using System;
using System.Collections.Generic;
using System.Text;
using wasted_app.Views;
using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;

namespace wasted_app.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged //BaseViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { set; get; }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
           // LoginCommand = new Command(OnLoginClicked);
            SubmitCommand = new Command(OnSubmit);
        }

        public async void OnSubmit(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            if (email != "admin" || password != "admin")
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {

                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
        }
    }
}
