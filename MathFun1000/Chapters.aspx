<%@ Page Title="Math Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chapters.aspx.cs" Inherits="MathFun1000.Chapters" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
<h1 runat="server" id="BookTitle" class="pageTitle"></h1>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="PrevButton" runat="server" Text="<< Previous Book" class="progressButton" OnClick="PrevButton_Click"/>
    <asp:PlaceHolder ID="ChapterHolder" runat="server"></asp:PlaceHolder>
    <asp:Button ID="NextButton" runat="server" Text="Next Book >>" class="progressButton" OnClick="NextButton_Click"/>
</asp:Content>
