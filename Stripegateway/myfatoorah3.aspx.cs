using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;

namespace Stripegateway
{
    public partial class myfatoorah3 : System.Web.UI.Page
    {
        // Replace with your MyFatoorah API token
        private const string MyFatoorahToken = "rLtt6JWvbUHDDhsZnfpAhpYk4dxYDQkbcPTyGaKp2TYqQgG7FGZ5Th_WD53Oq8Ebz6A53njUoo1w3pjU1D4vs_ZMqFiz_j0urb_BH9Oq9VZoKFoJEDAbRZepGcQanImyYrry7Kt6MnMdgfG5jn4HngWoRdKduNNyP4kzcp3mRv7x00ahkm9LAK7ZRieg7k1PDAnBIOG3EyVSJ5kK4WLMvYr7sCwHbHcu4A5WwelxYK0GMJy37bNAarSJDFQsJ2ZvJjvMDmfWwDVFEVe_5tOomfVNt6bOg9mexbGjMrnHBnKnZR1vQbBtQieDlQepzTZMuQrSuKn-t5XZM7V6fCW7oP-uXGX-sMOajeX65JOf6XVpk29DP6ro8WTAflCDANC193yof8-f5_EYY-3hXhJj7RBXmizDpneEQDSaSz5sFk0sV5qPcARJ9zGG73vuGFyenjPPmtDtXtpx35A-BVcOSBYVIWe9kndG3nclfefjKEuZ3m4jL9Gg1h2JBvmXSMYiZtp9MR5I6pvbvylU_PP5xJFSjVTIz7IQSjcVGO41npnwIxRXNRxFOdIUHn0tjQ-7LwvEcTXyPsHXcMD8WtgBh-wxR8aKX7WPSsT1O8d8reb2aR7K3rkV3K82K_0OgawImEpwSvp9MNKynEAJQS6ZHe_J_l77652xwPNxMRTMASk1ZsJL";

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Generate and open the invoice link
                await GenerateAndOpenInvoiceLink();
            }
        }
        public class CustomerAddress
        {
            public string Block { get; set; }
            public string Street { get; set; }
            public string HouseBuildingNo { get; set; }
            public string Address { get; set; }
            public string AddressInstructions { get; set; }
        }

        public class InvoiceItem
        {
            public string ItemName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }

        public class InvoiceRequest
        {
            public string CustomerName { get; set; }
            public string NotificationOption { get; set; }
            public string MobileCountryCode { get; set; }
            public string CustomerMobile { get; set; }
            public string CustomerEmail { get; set; }
            public decimal InvoiceValue { get; set; }
            public string DisplayCurrencyIso { get; set; }
            public string CallBackUrl { get; set; }
            public string ErrorUrl { get; set; }
            public string Language { get; set; }
            public string CustomerReference { get; set; }
            public CustomerAddress CustomerAddress { get; set; }
            public List<InvoiceItem> InvoiceItems { get; set; }
        }
        private async Task GenerateAndOpenInvoiceLink()
        {
            try
            {
                // Create an HttpClient to send requests to MyFatoorah API
                using (var client = new HttpClient())
                {
                    // Set the base URL for MyFatoorah API
                    client.BaseAddress = new Uri("https://apitest.myfatoorah.com");

                    // Set the authorization header with your API token
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", MyFatoorahToken);

                    // Create the invoice request
                    var invoiceRequest = new InvoiceRequest
                    {
                        CustomerName = "name",
                        NotificationOption = "ALL",
                        MobileCountryCode = "965",
                        CustomerMobile = "12345678",
                        CustomerEmail = "mail@company.com",
                        InvoiceValue = 100,
                        DisplayCurrencyIso = "kwd",
                        CallBackUrl = "https://yoursite.com/success",
                        ErrorUrl = "https://yoursite.com/error",
                        Language = "en",
                        CustomerReference = "noshipping-nosupplier",
                        CustomerAddress = new CustomerAddress
                        {
                            Block = "string",
                            Street = "string",
                            HouseBuildingNo = "string",
                            Address = "address",
                            AddressInstructions = "string"
                        },
                        InvoiceItems = new List<InvoiceItem>
    {
        new InvoiceItem
        {
            ItemName = "string",
            Quantity = 20,
            UnitPrice = 5
        }
    }
                    };


                    // Serialize the invoice request to JSON
                    var jsonRequest = JsonConvert.SerializeObject(invoiceRequest);

                    // Send a POST request to generate the invoice
                    var response = await client.PostAsync("/v2/SendPayment",
                        new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        // Successful response
                        var jsonResponse = await response.Content.ReadAsStringAsync();

                        //Response.Write(jsonResponse);
                        var responseData = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                        Response.Write(responseData);



                        // Extract the invoice link from the response
                        string invoiceLink = responseData.Data.InvoiceURL;

                        // Open the invoice link in a new browser tab using JavaScript
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenInvoiceLink",
                            $"<script>window.open('{invoiceLink}', '_blank');</script>");
                    }
                    else
                    {
                        // Handle API request failure
                        Response.Write("Failed to generate invoice.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Response.Write($"An error occurred: {ex.Message}");
            }
        }
    }
}