<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStep.aspx.cs" Inherits="MathFun1000.AddTutorial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Step </title>
</head>
<body>
    <a href="DisplayProblems.aspx">Display Problems</a>
    <p>This Page Adds Individual Tutorial Step for Each Problem</p>

    <form id="form1" runat="server">
    <div>
           <p>Enter Information:</p>
           <asp:TextBox ID="Info_TextBox" Text="" runat="server" Height="130px" Width="400px" />
           
           <p>Enter Example:</p>
           <asp:TextBox ID="Example_TextBox" Text="" runat="server" Height="130px" Width="400px" />

           <p>Enter Rules:</p>
           <asp:TextBox ID="Rules_TextBox" Text="" runat="server" Height="130px" Width="400px" />

           <p>Enter Difficulty:</p>
           <p>1: Easy, 2: Medium, 3: Hard</p>
           <asp:TextBox ID="Diff_TextBox" Text="" runat="server" />
           <br />
    </div>

           <asp:Button ID="Btn_AddStep" Text ="Add Step" runat="server" OnClick="addStep_Click" />

    
    </form>
</body>
</html>
