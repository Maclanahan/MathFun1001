<%@ Page Title="Math Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MathProgram.aspx.cs" Inherits="MathFun1000.MathProgram" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/MathProblemStyle.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
 

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="MainContainer" id="MainController" runat="server">
        <div id="innerMain" runat="server">

        </div>
        <asp:Button ID="StepForwardButton" runat="server" Text="Next" OnClick="StepForwardButton_Click" />
    </div>

    <asp:HiddenField ID="stepCount" runat="server" value="0"/>
</asp:Content>
