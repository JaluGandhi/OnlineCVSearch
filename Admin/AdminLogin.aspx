<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Admin_AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <title>Admin Login</title>
    <link rel="shortcut icon" type="image/x-icon"  href="../images/CV_Logo_ICON.ico" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css">

    <link rel='stylesheet prefetch' href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900'>
    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>

    <!--<link rel="sktylesheet" href="css/style.css">-->
   
    <link href="Admin_Style_JS/Admin_CSS/Admin_Style.css" rel="stylesheet" />
</head>

<body>

    <!-- Form Mixin-->
    <!-- Input Mixin-->
    <!-- Button Mixin-->
    <!-- Pen Title-->
    <div class="pen-title">
        <h1>Admin Login</h1>
    </div>
    <!-- Form Module-->
    <div class="module form-module">
        <div class="toggle">
            <!--<i class="fa fa-times fa-pencil"></i>
            <!--<div class="tooltip">Click Me</div>-->
        </div>

        <div class="form" runat="server">
            <h2>Login here</h2>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text=""></asp:Label>
            <form runat="server">
                <asp:TextBox ID="txtUsername" runat="server" TextMode="Email" required style="border-radius:6px;" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required style="border-radius:6px;" placeholder="Password" ></asp:TextBox><br />
                <%--<button id="btnLgn" runat="server">Login</button>--%>
                <asp:Button ID="btnLogin" OnClick="btnLogin_Click" style="background:rgb(46,204,113);width: 100%;border: 0;padding: 10px 15px;color: #ffffff;-webkit-transition: 0.3s ease; transition: 0.3s ease;" runat="server" Text="Login" />
                
            </form>
        </div>
     
    </div>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
   <%-- <script src='https://codepen.io/andytran/pen/vLmRVp.js'></script>--%>

    <!--<script  src="js/index.js"></script>-->
    <script src="Admin_Style_JS/Admin_JS/Admin_Index.js"></script>
</body>
</html>
