<%@ Page Title="" Language="C#" MasterPageFile="~/OuterMaster.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script>
        $(document).ready(function () {


            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liContact").addClass("active");


        });

    </script>

</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <!-- contact -->
    <div class="contact" id="contact">
        <div class="container">
            <h3>CONTACT US</h3>
            <label class="line"></label>
            <h6 id="lblMsg" runat="server" style="color:lightgreen"></h6>
            <%--<asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>--%>
            <div class="col-md-6 contact-left">
                <form action="#" method="post">

                    <div class="col-md-6">
                        <h4>YOUR NAME</h4>
                        <asp:TextBox ID="txtYourName" required runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <h4>YOUR EMAIL</h4>

                        <asp:TextBox ID="txtEmail" TextMode="Email" required runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-md-12">
                        <h4>MESSAGE</h4>
                        <textarea id="txtMsg" runat="server" required=""></textarea>
                    </div>
                    <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />


                </form>
            </div>
            <div class="col-md-6 contact-right">
                <h5>To contact us please use the contact form visible</h5>
                <h5>phone:<span class="dark">+91 9033344995,+91 9727633800</span></h5>
                <h5>Email:<span class="dark"><%--<a href="#">--%>jaygandhi933@gmail.com<%--</a>--%></span></h5>
                <%--<ul>
					<li><a class="linkedin" href="#"></a></li>
					<li><a class="google" href="#"></a></li>
					<li><a class="twitter" href="#"></a></li>
					<li><a class="facebook" href="#"></a></li>
				</ul>--%>
            </div>
            <div class="clearfix"></div>

        </div>
    </div>
    <!-- //contact -->




</asp:Content>

