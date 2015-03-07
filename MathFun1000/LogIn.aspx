<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="MathFun1000.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Log In</title>
</head>
<body>
    <form id="form1" runat="server">
    <p>This is the Log In Page.</p>
    <div>
        
        <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
        
    </div>
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
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
