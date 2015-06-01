<%@ Page Title="Problems" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Problems.aspx.cs" Inherits="MathFun1000.Problems" MaintainScrollPositionOnPostback="true"%>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:PlaceHolder ID="MenuHolder" runat="server"></asp:PlaceHolder>
    
    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section class="featured">
        
        <div class="content-wrapper">
        
            <p ID="ChapterTitle" runat="server" style="font-size: 30px;"></p><br/>

            <p ID="Intro" runat="server"></p>
        </div>
    </section>

    <asp:Button ID="PrevChapter" runat="server" class="progressButton" OnClick="PrevChapter_Click" Text="<< Prev Chapter" />
    
    <asp:PlaceHolder ID="ButtonHolder" runat="server"></asp:PlaceHolder>
    <%--<asp:Button ID="Button1" runat="server" Text="Problem 1" OnClick="Button1_Click" Width="210px" />
    <br/>
    <asp:Button ID="Button2" runat="server" Text="Problem 2" OnClick="Button2_Click" Width="210px" />
    <br/>
    <asp:Button ID="Button3" runat="server" Text="Graph" OnClick="Button3_Click" Width="210px" />
    <br/>
    <asp:Button ID="Button4" runat="server" Text="Multiple Choice" OnClick="Button4_Click" Width="210px" />--%>

    <asp:Button ID="NextChapter" runat="server" class="progressButton" OnClick="NextChapter_Click" Text="Next Chapter >>" />

</asp:Content>
