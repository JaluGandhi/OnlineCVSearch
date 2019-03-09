<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeeker/JobSeekerMaster.master" AutoEventWireup="true" CodeFile="JobSeekerExperienceDeail.aspx.cs" Inherits="JobSeeker_JobSeekerExperienceDeail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        $(document).ready(function () {


            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liProfile").addClass("active");


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contact" id="contact">
        <div class="container">

            <div class="col-md-12 contact-left">


                <div class="col-md-8" align="center">
                    <h5 style="text-align: center;">JOBSEEKER EXPERIENCE DEATAIL</h5>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="VacErrMsg" runat="server" Style="font-family: Garamond; letter-spacing: 2px; font-size: 23px" Visible="false"></asp:Label>
                </div>

            </div>



            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>

            <div align="center">
                <div style="width: 100%" align="left">
                    <div class="col-md-12 contact-left">

                        <div class="col-md-3">
                            <h4>COMPANNY NAME</h4>
                            <asp:TextBox ID="txtCompanyName" placeholder="ComapanyName if not than put (-)" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DetailFieldValidator1" runat="server" ErrorMessage="Please Fill Company name" ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtCompanyName" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <h4>START DATE</h4>
                            <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" OnTextChanged="txtStartDate_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DetailFieldValidator2" runat="server" ErrorMessage="Please Fill Start date" ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtStartDate" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <h4>END DATE</h4>
                            <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" AutoPostBack="True" OnTextChanged="txtEndDate_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DetailFieldValidator3" runat="server" ErrorMessage="Please Fill End date" ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtEndDate" Display="Dynamic"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-3">
                            <h4>NUMBER OF YEAR</h4>
                            <asp:TextBox ID="txtNumberOfYear" runat="server" Enabled="False"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="DetailFieldValidator4" runat="server" ErrorMessage="Please Fill Number of year" ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtNumberOfYear" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-3">
                            <h4>IS CONTINUE</h4>
                            <asp:RadioButton ID="RBIsContinueYes" Text="Yes" Checked="true" runat="server" GroupName="rb" />
                            <asp:RadioButton ID="RBIsContinueNo" Text="No" runat="server" GroupName="rb" />
                            <%--<asp:TextBox ID="txtIsContinue" required runat="server"></asp:TextBox>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <div class="form-group col-md-12" align="right">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" ValidationGroup="vg" OnClick="btnSave_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" />
            </div>

            <div class="col-md-12 table-responsive">
                <asp:GridView ID="GVExperienceInfo" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Experience_ID,CompanyName,StartDate,EndDate,NumberOfYear,ISContinue,ISContinue1">
                    <Columns>
                        <asp:BoundField DataField="CompanyName" HeaderText="COMAPNY NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="StartDate1" HeaderText="START DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="EndDate1" HeaderText="END DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="NumberOfYear" HeaderText="NUMBER OF YEAR" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ISContinue1" HeaderText="IS CONTINUE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-info" Text="Edit" OnClick="btnEdit_Click" />
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" OnClientClick="return confirm('Are you sure?');" OnClick="btnDelete_Click" />
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <h4 align="center">No Data to Display</h4>
                    </EmptyDataTemplate>
                </asp:GridView>


            </div>
        </div>
    </div>

    <div class="contact" style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
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
</asp:Content>

