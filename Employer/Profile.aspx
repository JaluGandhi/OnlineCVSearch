<%@ Page Title="" Language="C#" MasterPageFile="~/Employer/Employer_MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Employer_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        $(document).ready(function () {


            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liProfile").addClass("active");


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



   <div class="contact" id="contact">
        <div class="container">
            <h5 style="text-align:center;">YOUR PROFILE</h5>
           
            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <div align="center">
                <div style="width:100%" align="left">
                    <div class="col-md-12 contact-left">
                        <div class="col-md-12">
                            <h4>INDUSTRY NAME</h4>
                            <asp:DropDownList runat="server" ID="DDLIndustryType">
                                
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <h4>NAME</h4>
                            <asp:TextBox ID="txtName" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>EMAIL</h4>
                            <asp:TextBox ID="txtEmail" TextMode="Email" Enabled="false" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>COMPANY NAME</h4>
                            <asp:TextBox ID="txtComapnyName" required runat="server"></asp:TextBox>
                        </div>
                       
                        <div class="col-md-3">
                            <h4>CONTACT PERSON NAME</h4>
                            <asp:TextBox ID="txtContactPersonName" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>ADDRESS</h4>
                            <asp:TextBox ID="txtAddress" required runat="server"></asp:TextBox>
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
                            <asp:TextBox ID="txtPinCode" TextMode="Number"  required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>MOBILE NUMBER</h4>
                            <asp:TextBox ID="txtMobileNumber" TextMode="Number"  required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>OWNER NAME</h4>
                            <asp:TextBox ID="txtOwanerName"  required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <h4>START DATE</h4>
                            <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
                        </div>

                        <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click"   />

                         

                        
                    </div>
                </div>

            </div>
             <br /><h4 style="text-align:left;color:#2ECC71;"><a href="ContactDetail.aspx">Contact Person Detail</a></h4><br />
            <%--<h4 style="text-align:left;color:#2ECC71;"><a href="JobSeekerExperienceDeail.aspx">View Exeperience Detail</a></h4><br />
            <h4 style="text-align:left;color:#2ECC71;"><a href="JobSeekerHobbyDetail.aspx">View Hobby Detail</a></h4><br />
            <h4 style="text-align:left;color:#2ECC71;"><a href="JobSeekerSkillDetail.aspx">View Skill Detail</a></h4><br />
            <h4 style="text-align:left;color:#2ECC71;"><a href="JobSeekerPersonal.aspx">View Personal Detail</a></h4><br />--%>
        </div>
    </div>



    
</asp:Content>

