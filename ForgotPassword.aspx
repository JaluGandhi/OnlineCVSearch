<%@ Page Title="" Language="C#" MasterPageFile="~/OuterMaster.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="contact" id="contact">
		<div class="container">	
            <br />
			<h3>FORGOT PASSWORD</h3>
			<label class="line"></label>
            <div align="center">
                <div style="width:400px" align="left">
                    <div class="col-md-12 contact-left">
				
					    <div class="col-md-12">
                            <asp:Label ID="labMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
					    <h4>EMAIL</h4>
                            <asp:TextBox ID="txtEmail" TextMode="Email" required runat="server"></asp:TextBox>
					    </div>
					    
                        <asp:Button ID="btnRecover" runat="server" Text="RECOVER" OnClick="btnRecover_Click" />
				
			        </div>
                </div>
            </div>
            <div class="clearfix"></div>
			
		</div>
	</div>




</asp:Content>

