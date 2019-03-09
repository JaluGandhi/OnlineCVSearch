<%@ Page Title="" Language="C#" MasterPageFile="~/OuterMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script>
        $(document).ready(function () {
            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liLogin").addClass("active");
        });

    </script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="contact" id="contact">
        <div class="container">
            <h3>Login</h3>
            <label class="line"></label>
            <div align="center">
                <div style="width: 400px" align="left">
                    <div class="col-md-12 contact-left">

                        <div class="col-md-12">
                            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <h4>EMAIL</h4>
                            <asp:TextBox ID="txtEmail" TextMode="Email" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-12">
                            <h4>PASSWORD</h4>
                            <asp:TextBox ID="txtPassword" TextMode="Password" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" />
                        </div>

                        <div align="left">ForgotPassword?<a href="ForgotPassword.aspx">Click here</a></div>
                        <div align="left">Not register yet?<a href="Registration.aspx">Click here</a></div>

                    </div>
                </div>
            </div>
            <div class="clearfix"></div>

        </div>
    </div>



</asp:Content>

