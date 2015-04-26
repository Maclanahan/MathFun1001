<%@ Page Title="Graph Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="MathFun1000.Graph" MaintainScrollPositionOnPostback="true"%>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

    <style type="text/css">
        #rbList {
            margin-left: 28px;
            margin-right: 15px;
            margin-bottom: 28px;
            height: 264px;
            margin-top: 33px;
        }
    </style>
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="Instructions" id="instructions" runat="server">
        <p style="font-size:x-large; text-indent:300px; color:white">
        
            Pick the linear equation that made the following graph!

        </p>
    </div>    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">    

    <script type="text/javascript"
            src="https://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS_HTML">
     </script>

    <script type="text/x-mathjax-config">
           
         
            MathJax.Hub.Config({ 
                TeX: { 
                        extensions: ["autobold.js"],
                        //messageStyle: 'none', tex2jax: {preview: 'none'}
                    }
            
                
        });

        MathJax.Hub.Queue( function() 
        {
            $(".radioButtonList").css("visibility", "");
            //$(".MainContainer").slideDown(500);
        });
        </script>

    <link href="Content/MathProblemStyle.css" rel="stylesheet" />     
        <div class ="graph" id="graph" runat="server" style="border-style: groove; border-color: inherit; border-width: medium; float:left; width: 399px; height: 399px;">
            
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
        <div class ="radioButtonList" id="rbList" runat="server" style="float:right; width: 426px;">
                            
                <hr />
                <asp:RadioButton  ID="RadioButton1" runat="server"></asp:RadioButton>
                   <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="Large" ></asp:Label>                
                <hr />                
                <asp:RadioButton ID="RadioButton2" runat="server"></asp:RadioButton>
                   <asp:Label ID="Label2" runat="server" Text="Label" Font-Size="Large"></asp:Label>
                <hr />
                <asp:RadioButton ID="RadioButton3" runat="server"></asp:RadioButton>
                   <asp:Label ID="Label3" runat="server" Text="Label" Font-Size="Large"></asp:Label>
                <hr />
                <asp:RadioButton ID="RadioButton4" runat="server"></asp:RadioButton>
                   <asp:Label ID="Label4" runat="server" Text="Label" Font-Size="Large"></asp:Label>
                <hr />
                <asp:RadioButton ID="RadioButton5" runat="server"></asp:RadioButton>
                   <asp:Label ID="Label5" runat="server" Text="Label" Font-Size="Large"></asp:Label>
                <hr />
                
        </div>
    <div class="buttons" id="buttons" runat="server" style="margin-top:431px;">
        
        <asp:Button ID="CheckAnswer" runat="server" Text="Check" />
        <asp:Button ID="GoToNextProblem" runat="server" Text="Next Problem" OnClick="GoToNextProblem_Click" />
        
    </div>
</asp:Content>