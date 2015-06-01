<%@ Page  Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MathFun1000.Account.Register" MaintainScrollPositionOnPostback="true"%>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%--<asp:RequiredFieldValidator ID ="confirmPasswordReq" runat="server" ErrorMessage="Confirm Password is required!" SetFocusOnError="true" />--%></h1>
            </hgroup>
            <div>
                
                <p>
                    <asp:Label ID="Label1" runat="server" Text="User Name: "></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="textboxUserName" runat="server" Height="24px" Width="302px"></asp:TextBox>
                    <%--http://www.java2s.com/Tutorial/ASP.NET/0160__Validation/UseCompareValidatortocheckpasswordfieldandconfirmpasswordfield.htm--%>
                </p>
                <br /><br />
                <p>
                    <asp:Label ID="Label2" runat="server" Text="Email Address: "></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="textboxEmailAddress" runat="server" Height="24px" Width="300px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID ="confirmPasswordReq" runat="server" ErrorMessage="Confirm Password is required!" SetFocusOnError="true" />--%>
                </p>
                <br /><br />
                <p>
                    <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="textboxPassword" TextMode="Password" runat="server" Height="24px" Width="300px"></asp:TextBox>
                    <%--http://www.java2s.com/Tutorial/ASP.NET/0160__Validation/UseCompareValidatortocheckpasswordfieldandconfirmpasswordfield.htm--%>
                </p>
                <br /><br />
                <p>
                    <asp:Label ID="Label4" runat="server" Text="Confirm Password: "></asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="textboxConfirmPassword" TextMode="Password" runat="server" Height="24px" Width="300px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID ="confirmPasswordReq" runat="server" ErrorMessage="Confirm Password is required!" SetFocusOnError="true" />--%>
                </p>
                <br /><br />
                <p>
                    <asp:RadioButtonList ID="rbList_uType" runat="server" ForeColor="Black" Height="40px" Width="106px">
                        <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                        <asp:ListItem Text="Teacher" Value="Teacher"></asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <br /><br />
                <p>
                    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                </p>
                <%--http://www.java2s.com/Tutorial/ASP.NET/0160__Validation/UseCompareValidatortocheckpasswordfieldandconfirmpasswordfield.htm--%>
                <p>
                    <asp:Label ID="lbl_Confirmation" runat="server"></asp:Label>
                </p>
                </div>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
</asp:Content>

