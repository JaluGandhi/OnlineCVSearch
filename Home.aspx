<%@ Page Title="" Language="C#" MasterPageFile="~/OuterMaster1.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <script>
        $(document).ready(function () {


            $("#menu1").children().removeClass("active");
            $("#menu1").children("#liHome").addClass("active");


        });

    </script>


</asp:Content>

