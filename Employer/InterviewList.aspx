<%@ Page Title="" Language="C#" MasterPageFile="~/Employer/Employer_MasterPage.master" AutoEventWireup="true" CodeFile="InterviewList.aspx.cs" Inherits="Employer_InterviewList" %>

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
            <h5 style="text-align: center;">INTERVIEW INFORMATION</h5>

            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>

            <div align="center">
                <div style="width: 100%" align="left">
                    <div class="col-md-12 contact-left">
                        <asp:LinkButton ID="LinkBtnPending" runat="server" CssClass="btn btn-info" OnClick="LinkBtnPending_Click">Pending List</asp:LinkButton>
                        <asp:LinkButton ID="LinkBtnSelected" runat="server" CssClass="btn btn-info" OnClick="LinkBtnSelected_Click">Selected List</asp:LinkButton>
                        <asp:LinkButton ID="LinkBtnReject" runat="server" CssClass="btn btn-info" OnClick="LinkBtnReject_Click">Rejected List</asp:LinkButton>
                        <asp:LinkButton ID="LinkBtnNotCame" runat="server" CssClass="btn btn-info" OnClick="LinkBtnNotCame_Click">Not Came List</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <div class="col-md-12 table-responsive">

                <asp:GridView ID="GVInterviewInfoPending" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Name,InterviewDate,Skill">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="JOBSEEKER NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Skill" HeaderText="VACANY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="InterviewDate" HeaderText="INTERVIEW DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <h4 align="center">No Data to Display</h4>
                    </EmptyDataTemplate>
                </asp:GridView>

                <asp:GridView ID="GVInterviewInfoSelected" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Name,InterviewDate,Skill">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="JOBSEEKER NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Skill" HeaderText="VACANY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="InterviewDate" HeaderText="INTERVIEW DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="AppliedDate" HeaderText="APPLIED DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="STATUS" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                             <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
                    </Columns>
                    <EmptyDataTemplate>
                        <h4 align="center">No Data to Display</h4>
                    </EmptyDataTemplate>
                </asp:GridView>


                <asp:GridView ID="GVInterviewInfoRejected" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Name,InterviewDate,Skill">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="JOBSEEKER NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Skill" HeaderText="VACANY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="InterviewDate" HeaderText="INTERVIEW DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <h4 align="center">No Data to Display</h4>
                    </EmptyDataTemplate>
                </asp:GridView>


                <asp:GridView ID="GVInterviewInfoNotCame" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Name,InterviewDate,Skill">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="JOBSEEKER NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Skill" HeaderText="VACANY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="InterviewDate" HeaderText="INTERVIEW DATE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <h4 align="center">No Data to Display</h4>
                    </EmptyDataTemplate>
                </asp:GridView>


            </div>
        </div>
    </div>

</asp:Content>

