<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeeker/JobSeekerMaster.master" AutoEventWireup="true" CodeFile="Vacancy.aspx.cs" Inherits="JobSeeker_Vacancy" %>

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
                    <asp:Button ID="btnSkillSearch" ValidationGroup="vg" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnSkillSearch_Click" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnSkillReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnSkillReset_Click" />
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
                <asp:GridView ID="GVVacancyInfo" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Vacancy_ID,CompanyName,Experience,StartDate,EndDate,Skill,NumberOfPost,IsClose">
                    <Columns>
                        <asp:BoundField DataField="CompanyName" HeaderText="COMPANY NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Experience" HeaderText="EXPERIENCE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="StartDate" HeaderText="START DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="EndDate" HeaderText="END DATE" HeaderStyle-HorizontalAlign="Center">
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
                        <asp:BoundField DataField="IsClose" HeaderText="IS CLOSE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnApply" runat="server" CssClass="btn btn-default" Text="Apply" OnClick="btnApply_Click" />
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

