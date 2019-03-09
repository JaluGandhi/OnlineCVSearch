<%@ Page Title="" Language="C#" MasterPageFile="~/OuterMaster.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="contact" id="contact">
        <div class="container">
            <h5 style="text-align:center;">JOBSEEKER</h5>
            <h4 style="text-align:right;color:#2ECC71;"><a href="EmployerRegistration.aspx">HR | Company Registration</a></h4>
           
            <h3>Registration</h3>
            <label class="line"></label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please fill all details" ForeColor="Red" ValidationGroup="vg" ControlToValidate="txtpassword" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not matched" ControlToValidate="txtpassword" ControlToCompare="ConfirmPassword" Display="Dynamic" ValidationGroup="vg" ForeColor="Red"></asp:CompareValidator>

            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <div align="center">
                <div style="width:100%" align="left">
                    <div class="col-md-12 contact-left">

                        <div class="col-md-4">
                            <h4>FIRST NAME</h4>
                            <asp:TextBox ID="txtFirstName" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>MIDDLE NAME</h4>
                            <asp:TextBox ID="txtMiddleName" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>LAST NAME</h4>
                            <asp:TextBox ID="txtLastName" required runat="server"></asp:TextBox>
                        </div>
                       <div class="col-md-4">
                            <h4>EMAIL ID</h4>
                            <asp:TextBox ID="txtEmail" TextMode="Email" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>PASSWORD</h4>
                            <asp:TextBox ID="txtpassword" TextMode="Password" required runat="server" ControlToValidate="txtpassword"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>CONFIRM PASSWORD</h4>
                            <asp:TextBox ID="ConfirmPassword" TextMode="Password" required runat="server"></asp:TextBox>

                        </div>
                        <div class="col-md-4">
                            <h4>MOBILE NUMBER</h4>
                            <asp:TextBox ID="txtContactNumber" required runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>ADDRESS</h4>
                            <asp:TextBox ID="txtAddress" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>PINCODE</h4>
                            <asp:TextBox ID="txtPincode" required runat="server" TextMode="Number"></asp:TextBox>
                        </div>

                        <asp:Button ID="btnRegister" runat="server" Text="REGISTER NOW" OnClick="btnRegister_Click" ValidationGroup="vg" />

                        
                        
                    </div>
                </div>

            </div>
        </div>
    </div>
    

    </div>
	</div>


</asp:Content>

