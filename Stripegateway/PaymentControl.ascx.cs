using Stripe.Checkout;
using Stripe;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace YourNamespace
{
    public partial class PaymentControl : System.Web.UI.UserControl
    {
        public string sessionId = "";
        public string chargeAmount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // You can optionally populate the currency dropdown here
                PopulateCurrencies();
            }
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
                //UnitAmount = 1000,  // Amount in cents (e.g., $10.00)
                UnitAmountDecimal=Convert.ToDecimal(chargeAmount)*100,
            },
            Quantity = 1,
        },
    },
                Mode = "payment",
                SuccessUrl = "https://localhost:44361/StripeSuccess.aspx",
                CancelUrl = "https://localhost:44361/Stripefailure.aspx",
            };

            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);
            sessionId = session.Id;
        }

        public void SetPaymentValues(decimal amount, string currency)
        {
            chargeAmount=amount.ToString();
            // Set the values in the controls
            txtAmount.Text = amount.ToString();
            ddlCurrency.SelectedValue = currency;

            // Enable the controls now that values are provided
            txtAmount.Enabled = false;
            ddlCurrency.Enabled = false;
           // ddlPaymentOption.Enabled = true;
           // btnSubmit.Enabled = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Handle the submit button click event
            // You can implement payment processing logic here
        }

        private void PopulateCurrencies()
        {
            // You can populate the currency dropdown with options here
            // Example:
             ddlCurrency.Items.Add(new ListItem("USD", "USD"));
             ddlCurrency.Items.Add(new ListItem("EUR", "EUR"));
            // ...
        }
    }
}
