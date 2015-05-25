<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MathFun1000.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="Login1" ContentPlaceHolderID="FeaturedContent" onAuthenticate="Login1_Authenticate">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
                <br><p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" BackColor="#DE8642" ViewStateMode="Disabled">Register</asp:HyperLink>
                    if you don't have an account.
                </p><br />
                <p>
                    <asp:Label ID="label1" runat="server" Text="UserName:"></asp:Label>
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
                <br><p>
                    <asp:Label ID="lbl_Confirmation" runat="server"></asp:Label>
                </p><br />

        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
</asp:Content>
