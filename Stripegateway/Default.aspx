<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Default.aspx.cs" Inherits="Stripegateway._Default" %>


<main>


    <div class="row">
        <form id="form1">
            <button type="submit">Checkout</button>

        </form>

            <script src="https://js.stripe.com/v3/"></script>
        <script>
          var publicKey = 'pk_test_51Nlv9PIRv7OhiATt4w9Ztl56zlcN80tVD8bWW6IhsLrd1rH0SBuBmLRMvsupZsFAZ7uduSCPwaOJWvK1VfNEhtH100ZiofyEEZ';

        var stripe = Stripe(publicKey);
                var form=document.getElementById("form1");
            form.addEventListener('submit',function(e) {
            e.preventDefault();
           
            stripe.redirectToCheckout({
            sessionId: "<%= sessionId %>"
            });
            });
        </script>

    </div>
</main>

