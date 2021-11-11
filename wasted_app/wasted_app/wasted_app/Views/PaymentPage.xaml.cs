using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Stripe;

namespace wasted_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            InitializeComponent();
        }
        string mycustomer;
        string getchargedID;
        string refundID;

        public void NewEventHandler(Object sender, EventArgs e)
        {
            StripeConfiguration.SetApiKey("sk_test_51Js96bAopWd7zpBVyXzgmNQb5aqZFfei7wYFgsmni8rdMh5rS3Ddej3KlNoZlGWDO78Qd0FXJwXpAu4vL0pSJOHa00FTfRRirH");

            Stripe.CreditCardOptions stripcard = new Stripe.CreditCardOptions();
            stripcard.Number = "4000000000003055";
            stripcard.ExpYear = 2022;
            stripcard.ExpMonth = 08;
            stripcard.Cvc = "199";

            Stripe.TokenCreateOptions token = new Stripe.TokenCreateOptions();
            token.Card = stripcard;
            Stripe.TokenService serviceToken = new Stripe.TokenService();
            Stripe.Token newToken = serviceToken.Create(token);

            var options = new SourceCreateOptions
            {
                Type = SourceType.Card,
                Currency = "usd",
                Token = newToken.Id
            };

            var service = new SourceService();
            Source source = service.Create(options);

            Stripe.CustomerCreateOptions myCustomer = new Stripe.CustomerCreateOptions()
            {
                Name = "Vardenis Pavardenis",
                Email = "vardenispavardenis@gmail.com",
                Description = "test pavedimas",
            };

            var customerService = new Stripe.CustomerService();
            Stripe.Customer stripeCustomer = customerService.Create(myCustomer);

            mycustomer = stripeCustomer.Id; // Not needed

            var chargeoptions = new Stripe.ChargeCreateOptions
            {
                Amount = 1000,
                Currency = "EUR",
                ReceiptEmail = "tadassabestinas@gmail.com",
                Customer = stripeCustomer.Id,
                Source = source.Id

            };
            var service1 = new Stripe.ChargeService();
            Stripe.Charge charge = service1.Create(chargeoptions); // This will do the Payment

            getchargedID = charge.Id; // Not needed
        }
    }        
}
