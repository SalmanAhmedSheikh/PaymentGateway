<%@ Page Title="Payment Failed" Language="C#" AutoEventWireup="true" CodeBehind="Failure.aspx.cs" Inherits="Failure" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Failed</title>
    <style>
        body {
            background-color: #7D27CE;
            color: white;
            font-family: Arial, sans-serif;
            text-align: center;
        }

        .container {
            margin: 0 auto;
            padding: 20px;
            max-width: 600px;
        }

        .failure-message {
            background-color: #FF5722;
            padding: 20px;
            border-radius: 5px;
        }

        h1 {
            font-size: 24px;
        }

        p {
            font-size: 18px;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="failure-message">
            <h1>Payment Failed</h1>
            <p>Sorry, your payment could not be processed. Please try again later.</p>
        </div>
    </div>
</body>
</html>
