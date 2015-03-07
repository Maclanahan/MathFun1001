<%@ Page Title="Graph Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="MathFun1000.Graph" MaintainScrollPositionOnPostback="true"%>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
 

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/MathProblemStyle.css" rel="stylesheet" />

    <asp:Chart ID="LineGraph" runat="server" Width="400" Height="400">
        <Series>
            <asp:Series ChartType="Line" Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

    <br />
    <br />

    <div class="MainContainer" id="MainController" runat="server">
        <div class="innerMain" id="innerMain" runat="server">
            
            <div class="buttons" id="buttons" runat="server" >
                
            </div>
               
        </div>
    </div>

    <asp:Button ID="GoToNextProblem" runat="server" Text="Next Problem" OnClick="GoToNextProblem_Click" />

</asp:Content>
