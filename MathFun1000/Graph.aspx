<%@ Page Title="Graph Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="MathFun1000.Graph" MaintainScrollPositionOnPostback="true"%>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server" >
    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">    
    <link href="Content/MathProblemStyle.css" rel="stylesheet" />
    <div class ="graph" id="graph" runat="server" style="float:left">
    <asp:Chart ID="LineGraph" runat="server" Width="400px" Height="400px" >
        <Series>
            <asp:Series ChartType="Line" Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    
    </div>
    <div class ="radioButtonList" id="rbList" runat="server" style="float:right;">

    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        
    </asp:RadioButtonList>

    </div>
    <div class="buttons" id="buttons" runat="server" style="margin-top:431px">
        <asp:Button ID="GoToNextProblem" runat="server" Text="Next Problem" OnClick="GoToNextProblem_Click" />
    </div>
</asp:Content>
