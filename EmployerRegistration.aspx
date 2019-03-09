<%@ Page Title="" Language="C#" MasterPageFile="~/OuterMaster.master" AutoEventWireup="true" CodeFile="EmployerRegistration.aspx.cs" Inherits="EmployerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="contact" id="contact">
        <div class="container">
            <h5 style="text-align:center;">EMPLOYER REGISTRATION</h5>
            
           
            <h3>Registration</h3>
            <label class="line"></label>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <div align="center">
                <div style="width:100%" align="left">
                    <div class="col-md-12 contact-left">
                            <div <%--class="col-md-12"--%>>
                            <h4>INDUSTRY TYPE</h4>
                            <asp:DropDownList ID="DDLIndustryType" required runat="server"></asp:DropDownList>
                        </div>
                    <div class="col-md-12 contact-left">

                        
                        </div>
                        <div class="col-md-3">
                            <h4>NAME</h4>
                            <asp:TextBox ID="txtName" required runat="server" ></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>EMAIL ID</h4>
                            <asp:TextBox ID="txtEmailId" required runat="server" TextMode="Email"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>PASSWORD</h4>
                            <asp:TextBox ID="txtPassword" required runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        
                        <div class="col-md-3">
                            <h4>COMAPANY NAME</h4>
                            <asp:TextBox ID="txtCompanyName" required runat="server"></asp:TextBox>
                        </div>
                        

                        <div class="col-md-3">
                            <h4>CONATCT PERSON'S NAME</h4>
                            <asp:TextBox ID="txtContactPersonasName"  required runat="server"></asp:TextBox>
                        </div>
                        
                        <div class="col-md-3">
                            <h4>OFFICE ADDRESS</h4>
                            <asp:TextBox ID="txtOfficeAddress"  required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>CITY</h4>
                            <asp:TextBox ID="txtCity"  required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>STATE</h4>
                            <asp:TextBox ID="txtState"  required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>COUNTRY</h4>
                            <asp:TextBox ID="txtCountry"  required runat="server"></asp:TextBox>   
                        </div>
                        <div class="col-md-3">
                            <h4>PIN CODE</h4>
                            <asp:TextBox ID="txtPinCode"  required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>MOBILE NUMBER</h4>
                            <asp:TextBox ID="txtMobileNumber"  required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>OWNER NAME</h4>
                            <asp:TextBox ID="txtOwanerName"  required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>START DATE</h4>
                            <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
                        </div>

                        <asp:Button ID="btnRegister" runat="server" Text="REGISTER NOW" OnClick="btnRegister_Click" />
                       

                        
                        
                    </div>
                </div>

            </div>
        </div>
    </div>
    

    </div>
	</div>


</asp:Content>

