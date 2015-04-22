<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MathFun1000.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <section id="loginForm">
        <h2>Use a local account to log in.</h2>
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
         <p>
        <asp:TextBox ID="textboxUserName" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="label2" runat="server" Text="Password:"></asp:Label>
        </p>
        <p>
        <asp:TextBox ID="textboxPassword" TextMode="Password"  runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnLogIn" runat="server" OnClick="btnLogIn_Click" Text="Log In" />
        </p>
        <p>
            <asp:Label ID="lbl_Confirmation" runat="server"></asp:Label>
        </p>
    </section>

    <section id="socialLoginForm">
        <h2>Use another service to log in.</h2>
        <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />

    </section>
</asp:Content>
