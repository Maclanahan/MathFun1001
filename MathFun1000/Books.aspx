<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="MathFun1000.Books" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
 

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder ID="ButtonHolder" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Books"></asp:Label><br/>

    </asp:PlaceHolder>
    
</asp:Content>