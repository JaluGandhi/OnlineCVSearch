<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="IndustryType.aspx.cs" Inherits="Admin_IndustryType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <script>
        $(document).ready(function () {

           
            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liHome").addClass("active");


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contact" id="contact">
        <div class="container">
            <h3>INDUSTRY TYPE</h3>
            <label class="line"></label>
        </div>
    </div>

    <div id="Div1" style="background: rgb(245, 245, 245)">
        <div class="container">

            <div class="col-md-12">

                <div class="form-group col-md-4">
                    <label class="control-label">Industry Type</label>
                    <asp:TextBox ID="txtIndustryName" CssClass="form-control"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill This" Display="Dynamic" ForeColor="Red" ValidationGroup="vg" ControlToValidate="txtIndustryName"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group col-md-12 ">
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group col-md-12">
                    <asp:Button ID="btnSave" ValidationGroup="vg" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" />

                </div>
            </div>
            <div class="col-md-12 table-responsive" >
                <asp:GridView ID="GVIndustryInfo" style="background-color:white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVIndustryInfo_SelectedIndexChanged" DataKeyNames="IndustryType_ID,IndustryName">
                    <Columns>
                        <asp:BoundField DataField="IndustryName" HeaderText="Industry Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-info" Text="Edit" OnClick="btnEdit_Click" />
                            </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure?');" />
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

