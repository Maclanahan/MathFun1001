<%@ Page Title="Math Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MathProgram.aspx.cs" Inherits="MathFun1000.MathProgram" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
 

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div _designerregion="0">
        <asp:Button ID="Tutorial" runat="server" Text="Tutorial" BackColor="#58ACFA" OnClick="Tutorial_Click"/>
        <asp:Button ID="FillInTheBlank" runat="server" Text="Fill In The Blank" BackColor="#58ACFA" OnClick="FillInTheBlank_Click"/>
        <asp:Button ID="AnswerOnly" runat="server" Text="Answer Only" BackColor="#58ACFA" OnClick="AnswerOnly_Click"/>
    </div>


    <div class="MainContainer" id="MainController" runat="server">
        <div class="innerMain" id="innerMain" runat="server">
            
            <div class="buttons" id="buttons" runat="server" >
                
            </div>
               
        </div>
    </div>

    <asp:HiddenField ID="stepCount" runat="server" value="0"/>
    <asp:HiddenField ID="problemNumber" runat="server" value="0"/>
    <asp:HiddenField ID="problemType" runat="server" value="FillIn" />
</asp:Content>
