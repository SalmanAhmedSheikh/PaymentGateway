<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stripefailure.aspx.cs" Inherits="Stripegateway.Stripefailure" %>


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
        .continue-button {
    margin-top: 20px;
}

/* Button Styles */
.continue-button a {
    display: inline-block;
    padding: 10px 20px;
    background-color: #007BFF; /* Button color */
    color: #fff;
    text-decoration: none;
    border-radius: 5px;
    transition: background-color 0.3s;
}

.continue-button a:hover {
    background-color: #0056b3; /* Hover color */
}
    </style>
</head>
<body>
    <div class="container">
        <div class="failure-message">
            <h1>Payment Failed</h1>
            <p>Sorry, your payment could not be processed. Please try again later.</p>
                        <!-- Continue Shopping Button -->
            <div class="continue-button">
                <a href="https://localhost:44361/validusdemo">Continue Shopping</a>
            </div>
        </div>
    </div>
</body>
</html>
