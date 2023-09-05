using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stripegateway
{
    public partial class _Default : Page
    {
            public string sessionId = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            StripeConfiguration.ApiKey = "sk_test_51Nlv9PIRv7OhiATtVYuk8sF5sp3Vm7OXNxDQnKf9E3IYsoRCmTPXQOjFSmwBTNmVjVTG1U0EtuxUeep38SbrJ2oY00ekDiosMA";

            var options = new Stripe.Checkout.SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
            {
                "card",
            },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Your Product Name",
                        },
                        UnitAmount = 1000,  // Amount in cents (e.g., $10.00)
                    },
                    Quantity = 1,
                },
            },
                Mode = "payment",
                SuccessUrl = "https://localhost:44361/success",
                CancelUrl = "https://localhost:44361/cancel",
            };

            var service=new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);
            sessionId = session.Id;
        }

    }
}
