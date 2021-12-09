using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wasted_app.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsletterPage : ContentPage
    {
        public class NameAndNews
        {
            public string Username { get; set; }
            public string News { get; set; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public NewsletterPage()
        {
            InitializeComponent();

            var db1 = new UserContext();
            var userList = db1.Users.ToList();

            var db2 = new NewsletterContext();
            var newsletterList = db2.Newsletters.ToList();

            var innerJoin = userList.Join(newsletterList, user => user.UserId, news => news.UserId, (user, news) => new { Username = user.Username, Email = news.Name });
            IList<NameAndNews> joinedList = new List<NameAndNews>();

            foreach (var nameAndnews in innerJoin)
                joinedList.Add(new NameAndNews() { Username = nameAndnews.Username, News = nameAndnews.Email });

            //joinListView.ItemsSource = joinedList;

            var grouped = joinedList.GroupBy(li => li.News);
            IList<NameAndNews> groupedList1 = new List<NameAndNews>();
            IList<NameAndNews> groupedList2 = new List<NameAndNews>();

            foreach (var group in grouped)
            {
                foreach (var user in group)
                {
                    if (group.Key == "Software update blog")
                        groupedList1.Add(new NameAndNews() { Username = user.Username, News = group.Key });
                    if (group.Key == "News about produce")
                        groupedList2.Add(new NameAndNews() { Username = user.Username, News = group.Key });
                }
            }

            groupedList1View.ItemsSource = groupedList1;
            groupedList2View.ItemsSource = groupedList2;

            int firstuser = 0;
            int iterate = -1;
            while (firstuser < 1)
            {
                iterate++;

                if (userList[iterate].Newsletter == 1)
                    firstuser++;
            }

            var userr = userList.Skip(iterate).Take(1);

            foreach (var x in userr)
            {
                id.Text = x.UserId.ToString();
                username.Text = x.Username;
            }

            var sum = userList.Select(e => e.Newsletter).Aggregate((a, b) => a + b);
            sumUser.Text = sum.ToString();

        }
    }
}