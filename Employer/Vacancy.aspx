<%@ Page Title="" Language="C#" MasterPageFile="~/Employer/Employer_MasterPage.master" AutoEventWireup="true" CodeFile="Vacancy.aspx.cs" Inherits="Employer_Vacancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <script>
        $(document).ready(function () {


            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liVacancy").addClass("active");


        });

    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contact" id="contact">
        <div class="container">
            <h5 style="text-align: center;">VACANCY</h5>

            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <div align="center">
                <div style="width: 100%" align="left">
                    <div class="col-md-12 contact-left">

                        <div class="col-md-4">
                            <h4>EXPERIENCE</h4>
                            <asp:TextBox ID="txtExperience" runat="server" TextMode="Number"></asp:TextBox>
                            <%--<asp:CustomValidator ID="idCustom" ValidationGroup="vg" ControlToValidate="txtExperience" ClientValidationFunction="NumberValidation" ValidateEmptyText="true" runat="server" ErrorMessage="Invalid" ></asp:CustomValidator>--%>
                        </div>
                        <div class="col-md-4">
                            <h4>STRAT DATE</h4>
                            <asp:TextBox ID="txtStartDate"  runat="server" TextMode="Date" AutoPostBack="True" OnTextChanged="txtStartDate_TextChanged"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>END DATE</h4>
                            <asp:TextBox ID="txtEndDate"  runat="server" TextMode="Date" AutoPostBack="True" OnTextChanged="txtEndDate_TextChanged"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>SKILL</h4>
                            <asp:TextBox ID="txtSkill"  runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>NUMBER OF POST</h4>
                            <asp:TextBox ID="txtNumberOfPost"  runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <h4>IS CLOSE</h4>
                            <%-- <asp:TextBox ID="txtClose" required runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="DDLIsClose" runat="server">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:DropDownList>
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
                <asp:GridView ID="GVVacancyInfo" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Vacancy_ID,Experience,StartDate,EndDate,Skill,NumberOfPost,IsClose">
                    <Columns>
                        <asp:BoundField DataField="Experience" HeaderText="EXPERIENCE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                        <asp:BoundField DataField="Skill" HeaderText="SKILL" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="NumberOfPost" HeaderText="NUMBER OF POST" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="IsClose1" HeaderText="IS CLOSE" HeaderStyle-HorizontalAlign="Center">
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


    </div>
</asp:Content>

