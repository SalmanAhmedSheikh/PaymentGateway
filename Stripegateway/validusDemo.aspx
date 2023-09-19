<%--<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Stripegateway.About" %>--%>
<%--<%@ Register Src="~/PaymentControl.ascx" TagName="PaymentControl" TagPrefix="uc" %>--%>

<%@ Page Title="About" Language="C#" AutoEventWireup="true" Async="true" CodeBehind="validusDemo.aspx.cs" Inherits="Stripegateway.About" %>

<%@ Register Src="~/PaymentControl.ascx" TagName="PaymentControl" TagPrefix="uc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form id="form1" runat="server">--%>
        <div>
            <!-- Include the PaymentControl user control on the page -->
            <uc:PaymentControl ID="PaymentControl1" runat="server" />
        </div>
    <%--</form>--%>
  
</body>
</html>

