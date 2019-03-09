<%@ Page Title="" Language="C#" MasterPageFile="~/OuterMaster.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script>
        $(document).ready(function () {


            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liAbout").addClass("active");


        });

    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">




    <div class="contact" id="contact">
        <div class="about-agile" id="about">
            <div class="container">
                <h3>About Us</h3>
                <label class="line"></label>
                <h6>About our system,The system will provide the online facility to Jobseeker(user) for the job and Employer(Company) to provide the vacancy  for Jobseeker.
                    .It provides proper GUI and proper functionality.Online recruitment classifieds, www.Online CV Search.com, a clear market leader in the Indian e-recruitment space,a job site focused at the Middle East market, offline executive search and a fresher hiring site. Additionally, Info Edge provides jobseekers value added services (Naukri Fast Forward) such as resume writing.
                </h6>

            </div>
        </div>
    </div>






</asp:Content>

