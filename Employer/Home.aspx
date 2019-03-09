<%@ Page Title="" Language="C#" MasterPageFile="~/Employer/Employer_MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Employer_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script>
           $(document).ready(function () {


               $("#menu1").children().removeClass("active");
               $("#menu1").children("#liHome").addClass("active");


           });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <div class="contact" id="contact">
        <div class="container">
            <h5 style="text-align: center;">JOBSEEKER SEARCH</h5>
            
            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>








    <div id="Div1" style="background: rgb(245, 245, 245)">
        <div class="container">
            <div class="col-md-12">


                <div class="col-md-1" style="margin-right:15px;">
                    <h4 style="color: #000; font-size: 16px; font-weight: 700; text-align: left;">SKILL KEYWORD</h4>
                    
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtSkillSearch" Style="border-radius: 5px; border: none; border-top: 1px solid #000; background: rgba(215, 211, 212, 0.59); outline: none; padding: 10px; margin-bottom: 35px; width: 100%; font-size: 14px;" runat="server" placeholder="eg. Progaming,DataBase"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill This" Display="Dynamic" ForeColor="Red" ValidationGroup="vg" ControlToValidate="txtSkillSearch"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnSkillSearch" ValidationGroup="vg" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnSkillSearch_Click"  />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnSkillReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnSkillReset_Click"  />
                </div>
               <%-- <div class="form-group col-md-12 ">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>--%>
                
            </div>
        </div>
    </div>






    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">


            <div class="col-md-12 table-responsive">
                <asp:GridView ID="GVVacancyInfo" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="JobSeeker_ID,Name,MobileNumber,Email,SkillName">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                        <%--<asp:BoundField DataField="NumberOfYear" HeaderText="EXPERIENCE IN YEAR" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="SkillName" HeaderText="SKILL" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                       <%-- <asp:BoundField DataField="NumberOfPost" HeaderText="NUMBER OF POST" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="IsClose" HeaderText="IS CLOSE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" runat="server" CssClass="btn btn-default" Text="Save" OnClick="btnSelect_Click"  />
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

