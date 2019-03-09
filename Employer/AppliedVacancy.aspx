<%@ Page Title="" Language="C#" MasterPageFile="~/Employer/Employer_MasterPage.master" AutoEventWireup="true" CodeFile="AppliedVacancy.aspx.cs" Inherits="Employer_AppliedVacancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script>
           $(document).ready(function () {


               $("#menu1").children().removeClass("active");
               $("#menu1").children("#liAppliedVacancy").addClass("active");


           });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="contact" id="contact">
        <div class="container">
            <h5 style="text-align: center;">APPLIED VACANCY</h5>

            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>

            <div align="center">
                <div style="width: 100%" align="left">
                    <div class="col-md-12 contact-left">

                        <%--<div class="col-md-3">
                            <h4>HOBBY</h4>
                            <asp:TextBox ID="txtHobby"  runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DataFieldValidator1" runat="server" ErrorMessage="Please fill the hobby" Display="Dynamic"  ValidationGroup="vg" ForeColor="Red" ControlToValidate="txtHobby"></asp:RequiredFieldValidator>
                        </div>--%>
                         <%--<h4 style="text-align:left;color:#2ECC71;"><a href="#">Aprovel List</a></h4><br />--%>
                         <asp:LinkButton ID="LinkBtnPending" runat="server" CssClass="btn btn-info"  OnClick="LinkBtnPending_Click"  >Pending List</asp:LinkButton>
                        <asp:LinkButton ID="LinkBtnAprovel" runat="server" CssClass="btn btn-info"  OnClick="LinkBtnAprovel_Click">Aprovel List</asp:LinkButton>
                        <asp:LinkButton ID="LinkBtnReject" runat="server" CssClass="btn btn-info"  OnClick="LinkBtnReject_Click" >Rejected List</asp:LinkButton>
                       
                        <%--<asp:LinkButton ID="LinkButton2" runat="server" style="text-align:left;color:#2ECC71;" >Aprovel List</asp:LinkButton>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <%--<div class="form-group col-md-12" align="right">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" ValidationGroup="vg" OnClick="btnSave_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" />
            </div>--%>

            <div class="col-md-12 table-responsive">
                <asp:GridView ID="GVAppliedVacancyInfoPending" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="AppliedVacancy_ID,Name,MobileNumber,Email,AppliedDate,Status">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="JOBSEEKER NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                        <asp:BoundField DataField="AppliedDate" HeaderText="APPLIED DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="STATUS" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="" HeaderText="" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="" HeaderText="" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnApply" runat="server" CssClass="btn btn-default" Text="Aprove" OnClick="btnApply_Click" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-info" Text="Edit" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>--%>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnReject" runat="server" CssClass="btn btn-danger" Text="Reject" OnClientClick="return confirm('Are you sure?');" OnClick="btnReject_Click" />
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <h4 align="center">No Data to Display</h4>
                    </EmptyDataTemplate>
                </asp:GridView>




                <asp:GridView ID="GVAppliedVacancyInfoAproval" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Vacancy_ID,JobSeeker_ID,AppliedVacancy_ID,Name,MobileNumber,Email,AppliedDate,Status">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="JOBSEEKER NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                        <asp:BoundField DataField="AppliedDate" HeaderText="APPLIED DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="STATUS" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="" HeaderText="" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="" HeaderText="" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnInterview" runat="server" CssClass="btn btn-default" Text="Interview Process" OnClick="btnInterview_Click" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                       
                        <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnReject" runat="server" CssClass="btn btn-danger" Text="Reject" OnClientClick="return confirm('Are you sure?');" OnClick="btnReject_Click" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataTemplate>
                        <h4 align="center">No Data to Display</h4>
                    </EmptyDataTemplate>
                </asp:GridView>


                <asp:GridView ID="GVAppliedVacancyInfoReject" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="AppliedVacancy_ID,Name,MobileNumber,Email,AppliedDate,Status">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="JOBSEEKER NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                        <asp:BoundField DataField="AppliedDate" HeaderText="APPLIED DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="STATUS" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="" HeaderText="" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="" HeaderText="" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
                       <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnInterview" runat="server" CssClass="btn btn-default" Text="Interview Process" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>--%>
                       
                        <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnReject" runat="server" CssClass="btn btn-danger" Text="Reject" OnClientClick="return confirm('Are you sure?');" OnClick="btnReject_Click" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataTemplate>
                        <h4 align="center">No Data to Display</h4>
                    </EmptyDataTemplate>
                </asp:GridView>


            </div>
        </div>
    </div>


</asp:Content>

