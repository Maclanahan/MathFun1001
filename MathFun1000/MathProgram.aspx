<%@ Page Title="Math Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MathProgram.aspx.cs" Inherits="MathFun1000.MathProgram" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
 

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/MathProblemStyle.css" rel="stylesheet" />

    <div class="MainContainer" id="MainController" runat="server">
        <div class="innerMain" id="innerMain" runat="server">
            
            <div class="buttons" id="buttons" runat="server" >
            
            </div>   
        </div>
         
        
    </div>

    
           
    

    <asp:HiddenField ID="stepCount" runat="server" value="0"/>
    <asp:HiddenField ID="problemNumber" runat="server" value="0"/>
</asp:Content>
