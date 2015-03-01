<%@ Page Title="Graph Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="MathFun1000.Graph" MaintainScrollPositionOnPostback="true"%>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
 

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Chart ID="LineGraph" runat="server" Width="500" Height="600">
    <series>
        <asp:Series Name="Series1" ChartType="Line" ChartArea="MainChartArea">
    </asp:Series>
    </series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
            
        </asp:ChartArea>
    </chartareas>
</asp:Chart>

</asp:Content>
