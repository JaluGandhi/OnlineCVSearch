<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="JobSeekerFullDetail.aspx.cs" Inherits="Admin_JobSeekerFullDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        $(document).ready(function () {


            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liJbDetail").addClass("active");


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contact" id="contact">
        <div class="container">
            <h5 style="text-align: center;">JOBSEEKER DETAIL</h5>

            <%--<h3>Registration</h3>
            <label class="line"></label>--%>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>

        </div>
    </div>
    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <div class="form-group col-md-12" align="right">
                <asp:Button ID="btnActive"  runat="server" Text="Active"  CssClass="btn btn-success" OnClick="btnActive_Click"  />
                <asp:Button ID="btnBlock" runat="server" Text="Block" CssClass="btn btn-danger" OnClick="btnBlock_Click"  />

            </div>
        </div>
    </div>

    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <h5 style="text-align: left;">JOBSEEKER PROFILE</h5>
            <br />
            <div class="col-md-12 table-responsive">
                <asp:GridView ID="GVJbProfile" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Name,MobileNumber,Email,Address,Pincode">
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
                        <asp:BoundField DataField="Address" HeaderText="ADDRESS" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Pincode" HeaderText="PINCODE" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnFullDetail" runat="server" CssClass="btn btn-default" Text="Full Detail" OnClick="btnFullDetail_Click" />
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
        <br />
    </div>


    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <h5 style="text-align: left;">JOBSEEKER PERSONAL</h5>
            <br />
            <div class="col-md-12 table-responsive">
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
                        </Columns>
                        <EmptyDataTemplate>
                            <h4 align="center">No Data to Display</h4>
                        </EmptyDataTemplate>
                    </asp:GridView>


                </div>


            </div>

        </div>
        <br />
    </div>




    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <h5 style="text-align: left;">JOBSEEKER EDUCATIONAL</h5>
            <br />
            <div class="col-md-12 table-responsive">
                <div class="col-md-12 table-responsive">
                    <asp:GridView ID="GVEducationalInfo" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Board,University,Result,Percentage,Educational_ID">
                        <Columns>
                            <asp:BoundField DataField="Board" HeaderText="BOARD" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="University" HeaderText="UNIVERSITY" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Result" HeaderText="RESULT" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Percentage" HeaderText="PERCENTEAGE" HeaderStyle-HorizontalAlign="Center">
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
        <br />
    </div>




    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <h5 style="text-align: left;">JOBSEEKER EXPERIENCE</h5>
            <br />

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

                    </Columns>
                    <EmptyDataTemplate>
                        <h4 align="center">No Data to Display</h4>
                    </EmptyDataTemplate>
                </asp:GridView>


            </div>
        </div>
        <br />
    </div>




    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <h5 style="text-align: left;">JOBSEEKER SKILL</h5>
            <br />

            <div class="col-md-12 table-responsive">
                <asp:GridView ID="GVSkillInfo" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Skill_ID,SkillName,Discription">
                    <Columns>
                        <asp:BoundField DataField="SkillName" HeaderText="SKILL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Discription" HeaderText="DISCRIPTION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
        <br />
    </div>



    <div style="background: rgb(245, 245, 245); width: 100%;">
        <div class="container">
            <h5 style="text-align: left;">JOBSEEKER HOBBY</h5>
            <br />

            <div class="col-md-12 table-responsive">
                <asp:GridView ID="GVHobbyInfo" Style="background-color: white;" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Hobby_ID,HobbyName">
                    <Columns>
                        <asp:BoundField DataField="HobbyName" HeaderText="HOBBY NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
        <br />
    </div>
</asp:Content>

