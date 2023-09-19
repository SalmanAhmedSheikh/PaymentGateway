<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentControl.ascx.cs" Inherits="YourNamespace.PaymentControl"  %>

<style>
    /* Custom CSS for an Amazon-like indigo theme */
    body {
        background-color: #232f3e; /* Darker indigo background color */
        color: #333; /* Dark text color */
        font-family: Arial, sans-serif; /* Amazon-like font */
    }

    .container {
        margin: 0 auto;
        max-width: 400px;
        height:650px;
        padding: 20px;
        background-color: #fff; /* White container background color */
        border-radius: 4px;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); /* Amazon-like box shadow */
    }

    .form-group {
        margin-bottom: 20px;
    }

    .form-label {
        font-weight: bold;
        color: #232f3e; /* Darker indigo label color */
    }

    .form-control {
        width: 100%;
        padding: 10px;
        border: 1px solid #ccc; /* Light gray border */
        border-radius: 4px;
    }

    .btn-primary {
        background-color: #ff9900; /* Amazon orange */
        color: #fff;
        border: none;
        border-radius: 4px;
        padding: 10px 20px;
        font-weight: bold;
        cursor: pointer;
    }

    /* Validus specific styling */
    .validus-heading {
        color: rgba(136, 48, 218, 0.9); /* Validus purple with high opacity */
        font-size: 24px;
        text-align: center;
        margin-bottom: 20px;
    }

    .validus-label {
        color: rgba(136, 48, 218, 0.6); /* Validus purple with low opacity */
        font-weight: bold;
    }
</style>
    <div class="container">

<form id="form1" runat="server">
    <%--<div class="container">--%>
        <!-- Validus Heading -->
        <div class="validus-heading">
            Validus Payment
        </div>

        <div class="form-group">
            <label class="form-label validus-label" for="txtAmount">Amount:</label>
            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="form-group">
            <label class="form-label validus-label" for="ddlCurrency">Currency:</label>
            <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="form-control" Enabled="false">
            </asp:DropDownList>
        </div>
       <div class="form-group">
      <div class="validus-heading" style="color: #ff9900;text-align:left">
    Payment Option
</div>
           </div>
<div class="radio-button-list">
    <label class="radio-button-label">
        <input type="radio" name="paymentOption" value="card" />
        <img src="images/payByCard.jpg" style="margin-left:20px; height:40px;width:200px;" alt="Debit / Credit Card" />
       
    </label>

     <label class="radio-button-label">
     <input type="radio" name="paymentOption" value="virtualPay" disabled />
     <img src="images/VirtualPay.png" style="margin-left:20px;" alt="Virtual Pay" />
    
 </label>
        <label class="radio-button-label">
    <input type="radio" name="paymentOption" value="wire" disabled />
    <img src="images/WireTransfer.png" style="margin-left:20px; height:40px;width:120px;" alt="Debit / Credit Card" />
    
</label>
            <label class="radio-button-label">
    <input type="radio" name="paymentOption" value="loyaltycard" disabled />
    <img src="images/LOYALTY.png" style="margin-left:20px; height:60px;width:80px;" alt="Loyalty Card" />
    
</label>
        <label class="radio-button-label">
        <input type="radio" name="paymentOption" value="crypto" />
        <img src="images/CryptoIcon.png" style="margin-left:20px;height:40px;width:40px" alt="Crypto Currencies" />        
        Crypto Currencies
    </label>
</div>

<style>
    .radio-button-list {
        display: flex;
        flex-direction: column; /* Align vertically like a list */
        align-items: flex-start; /* Align items to the left */
    }

    .radio-button-label {
        display: flex;
        align-items: center;
        margin-bottom: 10px;
        margin-top:10px;
    }

    .radio-button-label img {
        margin-right: 10px;
        width: 100px; /* Adjust the width as needed */
        height: auto;
    }
</style>
 


        <%--<div class="form-group">--%>

            <%--<asp:Button ID="btnTest"  runat="server" Text="Checkout" CssClass="btn btn-primary" OnClick="btnTest_Click"  />--%>

    <asp:ImageButton ID="btnSubmit" runat="server" style="width:200px;height:70px;margin-top:14px;margin-left:20px;display: none;" ImageUrl="~/images/myFatoorah.png" OnClick="btnTest_Click" />

           <%-- <input type="image" src="images/Stripe.png" ID="btnSubmit"    alt="Pay by Card" style="width:200px;height:60px;margin-top:14px; display: none;">--%>

            <%--</div>--%>
</form>

        <form action="https://www.coinpayments.net/index.php" method="post" target="_top">
	<input type="hidden" name="cmd" value="_pay">
	<input type="hidden" name="reset" value="1">
	<input type="hidden" name="want_shipping" value="0">
	<input type="hidden" name="merchant" value="4c4943b7aad5069c9626479e847c3b0e">

            
            

	<input type="hidden" name="currency" value="LTC">

            	<input type="hidden" name="amountf" value="<%= chargeAmount %>"">
	<input type="hidden" name="item_name" value="Test Item">		
	<input type="hidden" name="allow_extra" value="1">	
	<input type="hidden" name="success_url" value="https://localhost:44361/StripeSuccess.aspx">	
	<input type="hidden" name="cancel_url" value="https://localhost:44361/Stripefailure.aspx">	
	<input type="image" src="images/CoinPayment.png" alt="Buy Now with CoinPayments.net" id="cryptoInput" style="display: none;height:90px;">
            <%--<input type="submit" alt="Buy Now with CoinPayments.net" title="Pay via Coin Payment" id="cryptoInput" style="display: none;">--%>

</form>

        </div>
   <script>
       //To Enable Payment Via Crypto Button
       var cryptoRadioButton = document.querySelector('input[value="crypto"]');
       var cryptoInput = document.getElementById('cryptoInput');

       cryptoRadioButton.addEventListener('change', function () {
           if (cryptoRadioButton.checked) {
               cryptoInput.style.display = 'inline-block'; // Show the input
               Input.style.display = 'none';
           } else {
               cryptoInput.style.display = 'none'; // Hide the input
           }
       });

       //To Enable Payment Via Card button
       var cardRadioButton = document.querySelector('input[value="card"]');
       var buttonID = '<%= btnSubmit.ClientID %>';

       // Get a reference to the ImageButton control using its ClientID
       var Input = document.getElementById(buttonID);
      // var Input = document.getElementById('btnSubmit');

       cardRadioButton.addEventListener('change', function () {
           if (cardRadioButton.checked) {
               Input.style.display = 'inline-block'; // Show the input
               cryptoInput.style.display = 'none'; // hide the crypto
           } else {
               Input.style.display = 'none'; // Hide the input
           }
       });


       btnSubmit

   </script>





<script src="https://js.stripe.com/v3/"></script>
<%--<script>
    var publicKey = 'pk_test_51Nlv9PIRv7OhiATt4w9Ztl56zlcN80tVD8bWW6IhsLrd1rH0SBuBmLRMvsupZsFAZ7uduSCPwaOJWvK1VfNEhtH100ZiofyEEZ';

    var stripe = Stripe(publicKey);
    var form = document.getElementById("form1");
    form.addEventListener('submit', function (e) {
        e.preventDefault();

        stripe.redirectToCheckout({
            sessionId: "<%= sessionId %>"
        });
    });
</script>--%>
