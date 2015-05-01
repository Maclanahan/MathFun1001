<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ERROR.aspx.cs" Inherits="MathFun1000.ERROR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>THERE HAS BEEN AN ERROR D:</h2>
    <p>We apologize for the inconvenience, hopefully it won't happen again.<p>

    <asp:LinkButton ID="GoHome" runat="server" OnClick="GoHome_Click">Return to Main Page</asp:LinkButton>
</asp:Content>
