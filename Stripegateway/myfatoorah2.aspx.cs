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

namespace Stripegateway
{
    public partial class myfatoorah2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set your MyFatoorah API token
            string token = "rLtt6JWvbUHDDhsZnfpAhpYk4dxYDQkbcPTyGaKp2TYqQgG7FGZ5Th_WD53Oq8Ebz6A53njUoo1w3pjU1D4vs_ZMqFiz_j0urb_BH9Oq9VZoKFoJEDAbRZepGcQanImyYrry7Kt6MnMdgfG5jn4HngWoRdKduNNyP4kzcp3mRv7x00ahkm9LAK7ZRieg7k1PDAnBIOG3EyVSJ5kK4WLMvYr7sCwHbHcu4A5WwelxYK0GMJy37bNAarSJDFQsJ2ZvJjvMDmfWwDVFEVe_5tOomfVNt6bOg9mexbGjMrnHBnKnZR1vQbBtQieDlQepzTZMuQrSuKn-t5XZM7V6fCW7oP-uXGX-sMOajeX65JOf6XVpk29DP6ro8WTAflCDANC193yof8-f5_EYY-3hXhJj7RBXmizDpneEQDSaSz5sFk0sV5qPcARJ9zGG73vuGFyenjPPmtDtXtpx35A-BVcOSBYVIWe9kndG3nclfefjKEuZ3m4jL9Gg1h2JBvmXSMYiZtp9MR5I6pvbvylU_PP5xJFSjVTIz7IQSjcVGO41npnwIxRXNRxFOdIUHn0tjQ-7LwvEcTXyPsHXcMD8WtgBh-wxR8aKX7WPSsT1O8d8reb2aR7K3rkV3K82K_0OgawImEpwSvp9MNKynEAJQS6ZHe_J_l77652xwPNxMRTMASk1ZsJL";

            // Construct the payment initiation request
            var initiatePaymentRequest = new
            {
                InvoiceAmount = 100,  // Set your desired payment amount
                CurrencyIso = "KWD"  // Set your desired currency
            };

            var intitateRequestJSON = JsonConvert.SerializeObject(initiatePaymentRequest);
            string response = PerformRequest(intitateRequestJSON, "InitiatePayment", token).Result;

            // Deserialize the response
            var responseData = JsonConvert.DeserializeObject<dynamic>(response);

            if (responseData.IsSuccess)
            {
                // Redirect the user to the MyFatoorah payment page
                string paymentUrl = responseData.Data.PaymentMethods[0].PaymentURL; // Adjust the index as needed
                Response.Redirect(paymentUrl);
            }
            else
            {
                // Handle the case where payment initiation failed
                string errorMessage = responseData.Message;
                // Display an error message to the user or take appropriate action.
            }
        }

        private async Task<string> PerformRequest(string requestJSON, string endPoint, string token)
        {
            string baseURL = "https://apitest.myfatoorah.com";
            string url = baseURL + $"/v2/{endPoint}";

       Console.WriteLine(url);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var httpContent = new StringContent(requestJSON, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, httpContent);

            return await responseMessage.Content.ReadAsStringAsync();
        }
    }
}