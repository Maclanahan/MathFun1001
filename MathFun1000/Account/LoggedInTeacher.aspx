<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteLoggedIn.Master" CodeBehind="LoggedInTeacher.aspx.cs" Inherits="MathFun1000.Account.LoggedInTeacher" %>

<asp:Content runat="server" ID="LoggedInTeacher" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
                <br>
                    <asp:Label ID="labelUserNameTeacher" runat="server" Text="Label"></asp:Label>
                    <a runat="server" class="username" href="~/DisplayProblems" title="Add a Step">View Problems</a>
                <br />
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
</asp:Content>