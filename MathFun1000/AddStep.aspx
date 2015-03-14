<%@ Page Title="Add Step" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStep.aspx.cs" Inherits="MathFun1000.AddTutorial" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
 

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <a href="DisplayProblems.aspx">Display Problems</a>
    <p>This Page Adds Individual Tutorial Step for Each Problem</p>

    
    <div>
           <p>Enter Information:</p><br/>
           <asp:TextBox ID="Info_TextBox" Text="" runat="server" Height="90px" Width="600px" TextMode="MultiLine" /><br/>
           
           <p>Enter Example:</p><br/>
           <asp:TextBox ID="Example_TextBox" Text="" runat="server" Height="90px" Width="600px" TextMode="MultiLine" /><br/>

           <p>Enter Rules:</p><br/>
           <asp:TextBox ID="Rules_TextBox" Text="" runat="server" Height="90px" Width="600px" TextMode="MultiLine" /><br/>

           <p>Enter Difficulty:</p><br/>
           <p>1: Easy, 2: Medium, 3: Hard</p><br/>
           <asp:TextBox ID="Diff_TextBox" Text="" runat="server" /><br/>
           <br />
    </div>

           <asp:Button ID="Btn_AddStep" Text ="Add Step" runat="server" OnClick="addStep_Click" />

    
    
</asp:Content>
