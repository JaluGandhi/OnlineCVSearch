<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="EmployerDetail.aspx.cs" Inherits="Admin_EmployerDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        $(document).ready(function () {


            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liEmpDetail").addClass("active");


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contact" id="contact">
        <div class="container">
            <h5 style="text-align: center;">EMPLOYER LIST</h5>
        </div>
    </div>
    <div id="Div1" style="background: rgb(245, 245, 245)">
        <div class="container">
            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            
            <div class="col-md-12">
                <div class="form-group col-md-4">
                     <label class="control-label">Industry Type</label>
                    <%--<h4 cssclass="form-control">INDUSTRY TYPE</h4>--%>
                    <asp:DropDownList ID="DDLIndustryType" CssClass="form-control" required runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLIndustryType_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
        </div>
        <br /><br />
    </div>



    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <div class="col-md-12 table-responsive">
                <asp:GridView ID="GVEmpInfo" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Employer_ID,OwanerName,MobileNumber,Email,IndustryName">
                    <Columns>
                         <asp:BoundField DataField="IndustryName" HeaderText="INDUSTRY TYPE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="OwanerName" HeaderText="OWNER NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CompanyName" HeaderText="COMPANY NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MobileNumber" HeaderText="MOBILE NUMBER" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Email" HeaderText="EMAIL" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                       
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnFullDetail" runat="server" CssClass="btn btn-default" Text="Full Detail" OnClick="btnFullDetail_Click" />
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

