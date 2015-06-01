<%@ Page Title="Graph Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="MathFun1000.Graph" MaintainScrollPositionOnPostback="true"%>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

    <style type="text/css">
        #rbList {
            margin-left: 20px;
            margin-right: 15px;
            margin-bottom: 7px;
            height: 425px;
            margin-top: 0px;
        }
    </style>
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:Button ID="Books_Button" OnClick="Book_Click" Text="Books" runat="server" />
    <asp:Button ID="Chapters_Click" OnClick="Chapter_Click" Text="Chapters" runat="server" />
    <asp:Button ID="Problems_Click" OnClick="Problem_Click" Text="Problems" runat="server" />
    <div class="Instructions" id="instructions" runat="server">
        <p style="font-size:x-large; text-indent:300px; color:white">
        
            Pick the linear equation that made the following graph!

        </p>
    </div>    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server"> 
    
    <link href="Content/MathProblemStyle.css" rel="stylesheet" />     
        <div class ="graph" id="graph" runat="server" style="border-style: groove; border-color: inherit; border-width: medium; float:left; width: 399px; height: 399px; margin-left: 17px; margin-right: 26px; margin-top: 22px; margin-bottom: 14px;">
            
            <asp:Chart ID="LineGraph" runat="server" Width="400px" Height="400px" style="float:left; margin-right: 20px; margin-bottom: 23px;" >
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
    
    
    
    <div class ="radioButtonList" id="rbList" runat="server" style="width: 105px;">
                            
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="1" RepeatLayout="Table" >
                
                <asp:ListItem Value="0"></asp:ListItem>                
                <asp:ListItem Value="1"></asp:ListItem>
                <asp:ListItem Value="2"></asp:ListItem>
                <asp:ListItem Value="3"></asp:ListItem>
                <asp:ListItem Value="4"></asp:ListItem>

            </asp:RadioButtonList> 
    </div>
    <div>
            <label id="CorrectLabel" style="display: inline-block; font-size:xx-large; text-align:center; vertical-align: top;"></label><br />
    </div>
    <script>
        $(".graph").css("visibility", "hidden");
        $(".radioButtonList").css("visibility", "hidden");
        $(".radioButtonList").slideUp(0);
    </script>

    <script type="text/javascript"
            src="https://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS_HTML">
    </script>

    <script type="text/x-mathjax-config">
           
         
            MathJax.Hub.Config({ 
                TeX: { 
                        extensions: ["autobold.js"],
                        messageStyle: 'none', tex2jax: {preview: 'none'}
                    }
            
                
        });

        MathJax.Hub.Queue( function() 
        {            
            $(".radioButtonList").css("visibility", "");
            $(".radioButtonList").slideDown(500, scrollToBottomOfPage());
            setTimeout(function(){$(".graph").css("visibility", "");}, 750);
        });
        </script>

    
    <div class="buttons" id="buttons" runat="server" style="margin-top:66px;">

        <asp:Button ID="GoToPrevProblem" runat="server" Text="Prev Problem" OnClick="stepBack_Click" />
        <asp:Button ID="GoToNextProblem" runat="server" Text="Next Problem" OnClick="stepForward_Click" />
        
    </div>

    <script type="text/javascript" src="Scripts/Graphs.js"></script>
</asp:Content>