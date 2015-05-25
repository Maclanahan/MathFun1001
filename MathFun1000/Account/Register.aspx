<%@ Page  Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MathFun1000.Account.Register" MaintainScrollPositionOnPostback="true"%>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
            <div>
                <p>
                    <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                </p>
        
                <p>
                    <asp:TextBox ID="textboxUserName" runat="server" Height="24px" Width="302px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID ="usernameReq" runat="server" ErrorMessage="User Name is required!" SetFocusOnError="true" />--%>
                </p>
                <p>
                    <asp:Label ID="Label2" runat="server" Text="Email Address"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="textboxEmailAddress" runat="server" Height="24px" Width="300px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID ="emailReq" runat="server" ErrorMessage="Email Address is required!" SetFocusOnError="true" />--%>
                </p>
                <p>
                    <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="textboxPassword" TextMode="Password" runat="server" Height="24px" Width="300px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID ="passwordReq" runat="server" ErrorMessage="Password is required!" SetFocusOnError="true" />--%>
                </p>
                <p>
                    <asp:Label ID="Label4" runat="server" Text="Confirm Password"></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="textboxConfirmPassword" TextMode="Password" runat="server" Height="24px" Width="300px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID ="confirmPasswordReq" runat="server" ErrorMessage="Confirm Password is required!" SetFocusOnError="true" />--%>
                </p>
                <p>
                    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                </p>
                <%--http://www.java2s.com/Tutorial/ASP.NET/0160__Validation/UseCompareValidatortocheckpasswordfieldandconfirmpasswordfield.htm--%>
                </div>
                <p>
                    <asp:Label ID="lbl_Confirmation" runat="server"></asp:Label>
                </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
</asp:Content>

