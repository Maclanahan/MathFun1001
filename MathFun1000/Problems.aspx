<%@ Page Title="Math Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Problems.aspx.cs" Inherits="MathFun1000.Problems" MaintainScrollPositionOnPostback="true"%>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
 

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Button ID="Button1" runat="server" Text="Problem 1" OnClick="Button1_Click" />
    <br/>
    <asp:Button ID="Button2" runat="server" Text="Problem 2" OnClick="Button2_Click" />
    <br/>
    <asp:Button ID="Button3" runat="server" OnClick="Problem 3" Text="Button3_Click" />
    
</asp:Content>
