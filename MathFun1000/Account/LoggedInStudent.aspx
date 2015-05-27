<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggedInStudent.aspx.cs" Inherits="MathFun1000.LoggedInStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="labelUserNameStudent" runat="server" Text="Label"></asp:Label>
    
    </div>
        <asp:Button ID="btnStudentLogOut" runat="server" OnClick="btnStudentLogOut_Click" Text="Log Out" />
    </form>
</body>
</html>
