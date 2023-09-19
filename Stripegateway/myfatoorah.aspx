<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myfatoorah.aspx.cs" Async="true" Inherits="Stripegateway.myfatoorah" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MyFatoorah Payment</title>
</head>
<body>
    <form id="paymentForm" runat="server">
        <div>
            <label for="txtAmount">Payment Amount (USD):</label>
            <input type="text" id="txtAmount" runat="server" />
            <asp:Button ID="btnPay" runat="server" Text="Pay with MyFatoorah" OnClick="btnPay_Click" />
        </div>
    </form>
</body>
</html>
