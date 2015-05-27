<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggedInTeacher.aspx.cs" Inherits="MathFun1000.Account.LoggedInTeacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formTeacher" runat="server">

    <div>
    
        <asp:Label ID="labelUserNameTeacher" runat="server" Text="Label"></asp:Label>
    
    </div>
        <a href="AddProblem.aspx">Add Problems</a>
        <a href="AddStep.aspx">Add Steps</a>
        <a href="DisplayProblems.aspx">Display Problems</a>
        <asp:Button ID="btnTeacherLogOut" runat="server" OnClick="btnTeacherLogOut_Click" Text="Log Out" />
    </form>
</body>
</html>
