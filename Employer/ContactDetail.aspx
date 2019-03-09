<%@ Page Title="" Language="C#" MasterPageFile="~/Employer/Employer_MasterPage.master" AutoEventWireup="true" CodeFile="ContactDetail.aspx.cs" Inherits="Employer_ContactDetail" %>

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
            <h5 style="text-align: center;">EMPLOYER CANTACT PERSON DETAIL</h5>

            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <div align="center">
                <div style="width: 100%" align="left">
                    <div class="col-md-12 contact-left">

                        <div class="col-md-4">
                            <h4>CONTACT PERSON NAME</h4>
                            <asp:TextBox ID="txtContactPersonName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DetailFieldValidator1" runat="server" ErrorMessage="Please Fill Company name" ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtContactPersonName" Display="Dynamic"></asp:RequiredFieldValidator>
                            <%--<asp:CustomValidator ID="idCustom" ValidationGroup="vg" ControlToValidate="txtExperience" ClientValidationFunction="NumberValidation" ValidateEmptyText="true" runat="server" ErrorMessage="Invalid" ></asp:CustomValidator>--%>
                        </div>
                        <div class="col-md-4">
                            <h4>CONTACT NUMBER</h4>
                            <asp:TextBox ID="txtContactNumber" TextMode="Number" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill Company name" ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtContactNumber" Display="Dynamic"></asp:RequiredFieldValidator>
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
                <asp:GridView ID="GVContactInfo" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Contact_ID,ContactPersonName,ContactNumber">
                    <Columns>
                        <asp:BoundField DataField="ContactPersonName" HeaderText="CONTACT PERSON NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ContactNumber" HeaderText="CONTACT NUBER" HeaderStyle-HorizontalAlign="Center">
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





</asp:Content>

