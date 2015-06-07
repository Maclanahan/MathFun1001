<%@ Page  Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MathFun1000.Account.Register" MaintainScrollPositionOnPostback="true"%>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <fieldset class="content-wrapper">
            <ol> 
                <li>
                    <asp:Label ID="Label1" runat="server" Text="User Name: " ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="textboxUserName" runat="server" Height="24px" Width="302px"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label2" runat="server" Text="Email Address: " ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="textboxEmailAddress" runat="server" Height="24px" Width="300px"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label3" runat="server" Text="Password: " ForeColor="Black"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="textboxPassword" TextMode="Password" runat="server" Height="24px" Width="300px"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label4" runat="server" Text="Confirm Password: " ForeColor="Black"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="textboxConfirmPassword" TextMode="Password" runat="server" Height="24px" Width="300px"></asp:TextBox>
                    <asp:RadioButtonList ID="rbList_uType" runat="server" ForeColor="Black" Height="16px" Width="117px" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                        <asp:ListItem Text="Teacher" Value="Teacher"></asp:ListItem>
                    </asp:RadioButtonList>
                </li>
                <li>
                    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                </li>
                <li>
                    <asp:Label ID="lbl_Confirmation" runat="server"></asp:Label>
                </li>
            </ol>
        </fieldset>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
</asp:Content>

