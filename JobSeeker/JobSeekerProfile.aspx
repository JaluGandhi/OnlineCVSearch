<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeeker/JobSeekerMaster.master" AutoEventWireup="true" CodeFile="JobSeekerProfile.aspx.cs" Inherits="JobSeeker_JobSeekerProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        $(document).ready(function () {


            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liProfile").addClass("active");


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlPopUp" runat="server" Visible="false" Style="border-radius: 10px; border: 1px solid #F00; position: fixed; width: 300px; height: 100px; top: 0; right: 0; background-color: white; color: #000; padding: 10px; text-align: center;">
        <div>
            <asp:Button ID="btnPopUpClose" runat="server" Text="Close" Style="width: 60px; margin: 5px; border-style: none; border-radius: 10px; position: absolute; right: 0; top: 0; color: #fff; background-color: #F00; padding: 3px;" />
        </div>
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>
    </asp:Panel>
    <div class="contact" id="contact">
        <div class="container">
            <div class="col-md-12 contact-left">


                <div class="col-md-8" align="center">
                    <h5 style="text-align: center;">YOUR PROFILE</h5>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="VacErrMsg" runat="server" Style="font-family: Garamond; letter-spacing: 2px; font-size: 23px" Visible="false"></asp:Label>
                </div>
                <div>
                    <asp:LinkButton ID="lnkPDFCreate" runat="server" OnClick="lnkPDFCreate_Click">Create PDF Resume</asp:LinkButton>
                </div>
            </div>


            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <div align="center">
                <div style="width: 100%" align="left">
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
                            <asp:TextBox ID="txtEmail" TextMode="Email" required runat="server" Enabled="False"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>MOBILE NUMBER</h4>
                            <asp:TextBox ID="txtContactNumber" TextMode="Number" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>ADDRESS</h4>
                            <asp:TextBox ID="txtAddress" required runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>PINCODE</h4>
                            <asp:TextBox ID="txtPincode" TextMode="Number" required runat="server"></asp:TextBox>
                        </div>

                        <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />




                    </div>
                </div>

            </div>
            <br />
            <h4 style="text-align: left; color: #2ECC71;"><a href="JobSeekerPersonal.aspx">View Personal Detail</a></h4>
            <br />
            <h4 style="text-align: left; color: #2ECC71;"><a href="JobSeekerEducationalDetail.aspx">View Educational Detail</a></h4>
            <br />
            <h4 style="text-align: left; color: #2ECC71;"><a href="JobSeekerExperienceDeail.aspx">View Exeperience Detail</a></h4>
            <br />
            <h4 style="text-align: left; color: #2ECC71;"><a href="JobSeekerSkillDetail.aspx">View Skill Detail</a></h4>
            <br />
            <h4 style="text-align: left; color: #2ECC71;"><a href="JobSeekerHobbyDetail.aspx">View Hobby Detail</a></h4>
            <br />
        </div>
    </div>


    </div>
    </div>
</asp:Content>

