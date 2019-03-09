<%@ Page Title="" Language="C#" MasterPageFile="~/Employer/Employer_MasterPage.master" AutoEventWireup="true" CodeFile="InterviewProcess.aspx.cs" Inherits="Employer_InterviewProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        $(document).ready(function () {


            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liInterviewList").addClass("active");


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="contact" id="contact">
        <div class="container">
            <h5 style="text-align: center;">INTERVIEW PROCESS</h5>

            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>

            <div align="center">
                <div style="width: 100%" align="left">
                    <div class="col-md-12 contact-left">
                        <h5 style="text-align: left;">JOBSEEKER DETAILS</h5>
                        <div class="col-md-3">
                            <h4>NAME</h4>
                            <asp:TextBox ID="txtName" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="DataFieldValidator1" runat="server" ErrorMessage="Please fill the hobby" Display="Dynamic"  ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtHobby"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-3">
                            <h4>MOBILE NO</h4>
                            <asp:TextBox ID="txtMobileNumber" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please fill the hobby" Display="Dynamic"  ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtHobby"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-3">
                            <h4>EMAIL</h4>
                            <asp:TextBox ID="txtEmail" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please fill the hobby" Display="Dynamic"  ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtHobby"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-3">
                            <h4>ADDRESS</h4>
                            <asp:TextBox ID="txtAddress" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please fill the hobby" Display="Dynamic"  ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtHobby"></asp:RequiredFieldValidator>--%>
                        </div>

                    </div>
                </div>
            </div>

            <div align="center">
                <div style="width: 100%" align="left">
                    <div class="col-md-12 contact-left">
                        <h5 style="text-align: left;">VANCANCY DETAILS</h5>
                        <div class="col-md-3">
                            <h4>SKILL</h4>
                            <asp:TextBox ID="txtSkill" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please fill the hobby" Display="Dynamic"  ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtHobby"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-3">
                            <h4>FROM DATE</h4>
                            <asp:TextBox ID="txtFromDate" TextMode="Date" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please fill the hobby" Display="Dynamic"  ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtHobby"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-3">
                            <h4>END DATE</h4>
                            <asp:TextBox ID="txtEndDate" TextMode="Date" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please fill the hobby" Display="Dynamic"  ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtHobby"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-3">
                            <h4>NUMBER OF POST</h4>
                            <asp:TextBox ID="txtNumberOfPost" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please fill the hobby" Display="Dynamic"  ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtHobby"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-3">
                            <h4>EXPERIENCE</h4>
                            <asp:TextBox ID="txtExperience" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please fill the hobby" Display="Dynamic"  ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtHobby"></asp:RequiredFieldValidator>--%>
                        </div>

                        <%--<asp:LinkButton ID="LinkButton2" runat="server" style="text-align:left;color:#2ECC71;" >Aprovel List</asp:LinkButton>--%>
                    </div>
                </div>
            </div>


            <div align="center">
                <div style="width: 100%" align="left">
                    <div class="col-md-12 contact-left">
                        <h5 style="text-align: left;">INTREVIEW PROCESS</h5>
                        <div align="center">
                            <asp:Label ID="lblMsgInterview" runat="server" Text=""></asp:Label>
                        </div>
                        <br />
                        <div class="col-md-3">
                            <h4>TIME</h4>
                            <asp:TextBox ID="txtTime" TextMode="Time" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DataFieldValidator1" runat="server" ErrorMessage="Please fill the time" Display="Dynamic" ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <h4>DATE</h4>
                            <asp:TextBox ID="txtInterviewProcessDate" TextMode="Date" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DataFieldValidator2" runat="server" ErrorMessage="Please fill the date" Display="Dynamic" ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtInterviewProcessDate"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <h4>CONTACT PERSON NAME</h4>
                            <asp:TextBox ID="txtContactPersonName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DataFieldValidator3" runat="server" ErrorMessage="Please fill the contact person name" Display="Dynamic" ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtContactPersonName"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <h4>ADDRESS</h4>
                            <asp:TextBox ID="txtInterviewAdress" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DataFieldValidator4" runat="server" ErrorMessage="Please fill the address" Display="Dynamic" ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtInterviewAdress"></asp:RequiredFieldValidator>
                        </div>


                    </div>
                    <asp:RadioButtonList ID="RadioButtonListForJob" Visible="false" runat="server">
                        <asp:ListItem Value="1">Select for this job</asp:ListItem>
                        <asp:ListItem Value="2">Rejected in interview</asp:ListItem>
                        <asp:ListItem Value="3">Not Came</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>


        </div>
    </div>
    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <div class="form-group col-md-12" align="right">
                <asp:Button ID="btnSave" runat="server" Text="Set Interview" CssClass="btn btn-success" OnClick="btnSave_Click" ValidationGroup="vg" />

            </div>
        </div>
    </div>

</asp:Content>

