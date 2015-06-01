<%@ Page Title="Multi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Multi.aspx.cs" Inherits="MathFun1000.Multi" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:Button ID="Books_Button" OnClick="Book_Click" Text="Books" runat="server" />
    <asp:Button ID="Chapters_Click" OnClick="Chapter_Click" Text="Chapters" runat="server" />
    <asp:Button ID="Problems_Click" OnClick="Problem_Click" Text="Problems" runat="server" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   

    <div id="arrayData" runat="server">

    </div>

    <div class="MainContainer" id="MainController" runat="server">
<%--        <input id="StepBackward" type="button" value="ERROR" class="StepBackwardButton" onclick="stepBack()"/>--%>
        <input id="StepForward" type="button" value="Show Answers" class="StepForwardButton" onclick="stepForward()"/>
        
         <script>
             // $(document).ready(function () { $(".MainContainer").slideDown(500); });
             $(".MainContainer").css("visibility", "hidden");
             $(".MainContainer").slideUp(0);

        </script>

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
                $(".MainContainer").css("visibility", "");
                $(".MainContainer").slideDown(500);
            });
        </script> 

       
        <asp:HiddenField ID="stepCount" runat="server" value="0"/>

        <div class="innerMain" id="innerMain" runat="server">
            
            <div class="buttons" id="buttons" runat="server" >
                
            </div>
               
        </div>

        
    </div>
    <script type="text/javascript" src="Scripts/Multi.js"></script>

    <div class="MainContainer" id="MainController0" runat="server">
<%--        <input id="StepBackward" type="button" value="ERROR" class="StepBackwardButton" onclick="stepBack()"/>--%>
        <input id="Confirmbtn" type="button" value="Confirm" class="Confirmcl" onclick="Confirm()"/>
        
         <script>
             // $(document).ready(function () { $(".MainContainer").slideDown(500); });
             $(".MainContainer").css("visibility", "hidden");
             $(".MainContainer").slideUp(0);

        </script>

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
                $(".MainContainer").css("visibility", "");
                $(".MainContainer").slideDown(500);
            });
        </script> 

       
        <asp:HiddenField ID="stepCount0" runat="server" value="0"/>

        <div class="innerMain" id="innerMain0" runat="server">
            
            <div class="buttons" id="buttons0" runat="server" >
                
            </div>
               
        </div>

        
    </div>
    </asp:Content>
