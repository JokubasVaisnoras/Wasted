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
using Microsoft.EntityFrameworkCore;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        public delegate Regex validator(string regex);

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            validator pattern = delegate (string regex)
            {
                string x = regex;

                return new Regex(x, RegexOptions.IgnoreCase);
            };

            //for Contacts
            Regex Valid_Contact = pattern("^(?=.{6,12}$)[0-9]*$");

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
            Regex Valid_Username = pattern("^(?=.{6,12}$)(?![_.])(?!.*[_.]{2})[a-z0-9._]+(?<![_.])$");

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
            Regex Valid_Password = pattern("(?!^[0-9]*$)(?!^[a-z]*$)^([a-z0-9]{8,15})$");

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
            Regex Valid_Email = pattern(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");

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

            int y = 0;
            if (Check1.IsChecked || Check2.IsChecked)
                y = 1;


            var item = new RegUserTable()
            {
                Username = EntryUsername.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                PhoneNumber = EntryUserPhoneNumber.Text,
                Newsletter = y
            };

            var dbUser = new UserContext();
            dbUser.Add(item);
            await dbUser.SaveChangesAsync();

            var myquery = await dbUser.Users.FirstOrDefaultAsync(u => u.Username.Equals(EntryUsername.Text) && u.Password.Equals(EntryUserPassword.Text));

            if (Check1.IsChecked)
            {
                using (var db = new NewsletterContext())
                {
                    var newNewsletter = new Newsletter
                    {
                        UserId = myquery.UserId,
                        Name = "Software update blog"
                    };
                    db.Add(newNewsletter);
                    await db.SaveChangesAsync();
                }
            }

            if (Check2.IsChecked)
            {
                using (var db = new NewsletterContext())
                {
                    var newNewsletter = new Newsletter
                    {
                        UserId = myquery.UserId,
                        Name = "News about produce"
                    };
                    db.Add(newNewsletter);
                    await db.SaveChangesAsync();
                }
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
