using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourNamespace;

namespace Stripegateway
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Example values for amount and currency
                decimal amount = 1001.00M; // Replace with your amount
                string currency = "USD"; // Replace with your currency

                // Set the values in the PaymentControl
                PaymentControl1.SetPaymentValues(1001.00m, "USD");
            }
        }
       

    }
}