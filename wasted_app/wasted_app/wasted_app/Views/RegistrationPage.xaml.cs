using System;
using wasted_app.ViewModels;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using wasted_app.Tables;
using wasted_app.Database;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        static Regex Valid_Username = StringNumber();
        static Regex Valid_Contact = NumbersOnly();
        static Regex Valid_Password = ValidPassword();
        static Regex Valid_Email = Email_Address();

        private static Regex StringNumber()
        {
            string StringAndNumber_Pattern = "^(?=.{6,12}$)(?![_.])(?!.*[_.]{2})[a-z0-9._]+(?<![_.])$";

            return new Regex(StringAndNumber_Pattern, RegexOptions.IgnoreCase);
        }

        private static Regex Email_Address()
        {
            string Email_Pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(Email_Pattern);
        }

        private static Regex NumbersOnly()
        {
            string StringAndNumber_Pattern = "^(?=.{6,12}$)[0-9]*$";

            return new Regex(StringAndNumber_Pattern);
        }

        private static Regex ValidPassword()
        {
            string Password_Pattern = "(?!^[0-9]*$)(?!^[a-z]*$)^([a-z0-9]{8,15})$";

            return new Regex(Password_Pattern, RegexOptions.IgnoreCase);
        }


        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            //for Contacts
            if (EntryUserPhoneNumber.Text == null)
            {
                var result = DisplayAlert("Invalid", "Phone number field cannot be empty!", "Yes", "Cancel");
                return;
            }
            else if (Valid_Contact.IsMatch(EntryUserPhoneNumber.Text) != true)
            {
                var result = DisplayAlert("Invalid", "Enter a valid phone number.", "Yes", "Cancel");
                return;
            }

            //for username
            if (EntryUsername.Text == null)
            {
                var result = DisplayAlert("Invalid", "Username cannot be empty!", "Yes", "Cancel");
                return;
            }
            else if (Valid_Username.IsMatch(EntryUsername.Text) != true)
            {
                var result = DisplayAlert("Invalid", "Username length is between 6 to 12", "Yes", "Cancel");
                return;
            }

            //for password
            if (EntryUserPassword.Text == null)
            {
                var result = DisplayAlert("Invalid", "Password cannot be empty!", "Yes", "Cancel");
                return;
            }
            else if (Valid_Password.IsMatch(EntryUserPassword.Text) != true)
            {
                var result = DisplayAlert("Password must be atleast 8 to 15 characters.", "It must contain letters and numbers.", "Yes", "Cancel");
                return;
            }

            //for Email Address
            if (EntryUserEmail.Text == null)
            {
                var result = DisplayAlert("Invalid", "Email cannot be empty!", "Yes", "Cancel");
                return;
            }
            else if (Valid_Email.IsMatch(EntryUserEmail.Text) != true)
            {
                var result = DisplayAlert("Invalid Email Address!", "Invalid", "Yes", "Cancel");
                return;
            }

            var item = new RegUserTable()
            {
                Username = EntryUsername.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                PhoneNumber = EntryUserPhoneNumber.Text
            };

            using (var db = new DatabaseContext())
            {
                db.Add(item);
                await db.SaveChangesAsync();
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulations!", "User is registered", "Yes", "Cancel");

                if (result)
                    await Navigation.PushAsync(new LoginPage());
            });
        }
    }
}
