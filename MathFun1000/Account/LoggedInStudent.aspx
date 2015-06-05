<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteLoggedIn.Master" CodeBehind="LoggedInStudent.aspx.cs" Inherits="MathFun1000.LoggedInStudent" %>

<asp:Content runat="server" ID="LoggedInStudent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
                <br>
                    <asp:Label ID="labelUserNameStudent" runat="server" Text="Label"></asp:Label>
                    <asp:Button ID="btnStudentLogOut" runat="server" OnClick="btnStudentLogOut_Click" Text="Log Out" />
                <br />
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
</asp:Content>
