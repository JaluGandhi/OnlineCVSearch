<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeeker/JobSeekerMaster.master" AutoEventWireup="true" CodeFile="JobSeekerPersonal.aspx.cs" Inherits="JobSeeker_JobSeekerPersonal" %>

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
                    <h5 style="text-align: center;">JOBSEEKER PERSONAL DEATAIL</h5>
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
                            <h4>CITY</h4>
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DataFieldValidator1" runat="server" ValidationGroup="vg" ErrorMessage="Please fill City" ControlToValidate="txtCity" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <h4>STATE</h4>
                            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DataFieldValidator2" runat="server" ValidationGroup="vg" ErrorMessage="Please fill State" ControlToValidate="txtState" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <h4>COUNTRY</h4>
                            <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DataFieldValidator3" runat="server" ValidationGroup="vg" ErrorMessage="Please fill Country" ControlToValidate="txtCountry" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-3">
                            <h4>DATE OF BIRTH</h4>
                            <asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="DataFieldValidator5" runat="server" ValidationGroup="vg" ErrorMessage="Please fill DateOfBirth" ControlToValidate="txtDOB" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <h4>GENDER</h4>
                            <br />
                            <asp:RadioButton ID="RadioButtonMale" runat="server" Checked="true" Text="Male" GroupName="rb" Font-Size="Medium" />&nbsp
                            <asp:RadioButton ID="RadioButtonFemale" runat="server" Text="Female" GroupName="rb" Font-Size="Medium" />
                            <%--<asp:RequiredFieldValidator ID="DataFieldValidator4" runat="server" ValidationGroup="vg" ErrorMessage="Please fill Gender" ControlToValidate="txtGender" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-3">
                            <h4>MERITIAL STATUS</h4>
                            <%--<asp:TextBox ID="txtMeritialStatus" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="DDLMeritialStatus" runat="server">
                                <asp:ListItem>Married</asp:ListItem>
                                <asp:ListItem>Unmarried</asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="DataFieldValidator6" runat="server" ValidationGroup="vg" ErrorMessage="Please fill Merital Status" ControlToValidate="txtMeritialStatus" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-3">
                            <h4>PASSPORT</h4>
                            <asp:TextBox ID="txtPassport" MaxLength="15" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DataFieldValidator7" runat="server" ValidationGroup="vg" ErrorMessage="Please fill Passport" ControlToValidate="txtPassport" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <h4>RESUME</h4>
                            <asp:FileUpload ID="FLUResume" runat="server" Height="50px" Width="200px" />
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
                <asp:GridView ID="GVPersonalInfo" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Personal_ID,City,State,Country,Gender,DateOfBirth,MariatailStatus,Passport,ResumeFile">
                    <Columns>
                        <asp:BoundField DataField="City" HeaderText="CITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="State" HeaderText="STATE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Country" HeaderText="COUNTRY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Gender" HeaderText="GENDER" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="DateOfBirth1" HeaderText="DATE OF BIRTH" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MariatailStatus" HeaderText="MARIATAIL STATUS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Passport" HeaderText="PASSPORT" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="City" HeaderText="CITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
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

