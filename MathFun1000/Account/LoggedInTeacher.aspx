<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteLoggedIn.Master" CodeBehind="LoggedInTeacher.aspx.cs" Inherits="MathFun1000.Account.LoggedInTeacher" %>

<asp:Content runat="server" ID="LoggedInTeacher" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
                <br>
                    <asp:Label ID="labelUserNameTeacher" runat="server" Text="Label"></asp:Label>
                    <a href="AddProblem.aspx">Add Problems</a>
                    <a href="AddStep.aspx">Add Steps</a>
                    <a href="DisplayProblems.aspx">Display Problems</a>
                    <asp:Button ID="Button1" runat="server" OnClick="btnTeacherLogOut_Click" Text="Log Out" />
                <br />
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
</asp:Content>