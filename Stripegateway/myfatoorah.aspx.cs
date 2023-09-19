using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Stripegateway
{
    public partial class myfatoorah : System.Web.UI.Page
    {
        // You can get the test token from MyFatoorah's website
        static string token = "rLtt6JWvbUHDDhsZnfpAhpYk4dxYDQkbcPTyGaKp2TYqQgG7FGZ5Th_WD53Oq8Ebz6A53njUoo1w3pjU1D4vs_ZMqFiz_j0urb_BH9Oq9VZoKFoJEDAbRZepGcQanImyYrry7Kt6MnMdgfG5jn4HngWoRdKduNNyP4kzcp3mRv7x00ahkm9LAK7ZRieg7k1PDAnBIOG3EyVSJ5kK4WLMvYr7sCwHbHcu4A5WwelxYK0GMJy37bNAarSJDFQsJ2ZvJjvMDmfWwDVFEVe_5tOomfVNt6bOg9mexbGjMrnHBnKnZR1vQbBtQieDlQepzTZMuQrSuKn-t5XZM7V6fCW7oP-uXGX-sMOajeX65JOf6XVpk29DP6ro8WTAflCDANC193yof8-f5_EYY-3hXhJj7RBXmizDpneEQDSaSz5sFk0sV5qPcARJ9zGG73vuGFyenjPPmtDtXtpx35A-BVcOSBYVIWe9kndG3nclfefjKEuZ3m4jL9Gg1h2JBvmXSMYiZtp9MR5I6pvbvylU_PP5xJFSjVTIz7IQSjcVGO41npnwIxRXNRxFOdIUHn0tjQ-7LwvEcTXyPsHXcMD8WtgBh-wxR8aKX7WPSsT1O8d8reb2aR7K3rkV3K82K_0OgawImEpwSvp9MNKynEAJQS6ZHe_J_l77652xwPNxMRTMASk1ZsJL";
        static string baseURL = "https://apitest.myfatoorah.com";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Your Page_Load logic, if needed
        }

        protected async void btnPay_Click(object sender, EventArgs e)
        {
            // Get the payment amount from the text field
            decimal paymentAmount;
            if (decimal.TryParse(txtAmount.Value, out paymentAmount))
            {
                // Call the InitiatePayment method with the payment amount
                var intiateResponse = await InitiatePayment(paymentAmount).ConfigureAwait(false);
                // Process the response as needed
                Response.Write("Initiate Payment Response:<br/>");
                Response.Write(intiateResponse);
            }
            else
            {
                // Handle invalid input amount
                Response.Write("Invalid payment amount.");
            }
        }

        public async Task<string> InitiatePayment(decimal amount)
        {
            var intiatePaymentRequest = new
            {
                InvoiceAmount = amount,
                CurrencyIso = "USD" // Set the currency to USD
            };

            var intitateRequestJSON = JsonConvert.SerializeObject(intiatePaymentRequest);
            return await PerformRequest(intitateRequestJSON, "InitiatePayment").ConfigureAwait(false);
        }

        // Add the ExecutePayment and PerformRequest methods, just like in your code
        // ...

        // Note: You may want to add error handling and additional validation
        // for user input in a production environment.

        public static async Task<string> PerformRequest(string requestJSON, string endPoint)
        {
            string url = baseURL + $"/v2/{endPoint}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var httpContent = new StringContent(requestJSON, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, httpContent).ConfigureAwait(false);
            string response = string.Empty;
            if (!responseMessage.IsSuccessStatusCode)
            {
                response = JsonConvert.SerializeObject(new
                {
                    IsSuccess = false,
                    Message = responseMessage.StatusCode.ToString()
                });
            }
            else
            {
                response = await responseMessage.Content.ReadAsStringAsync();
            }

            return response;
        }

    }


}