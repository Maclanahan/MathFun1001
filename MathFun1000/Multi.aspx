<%@ Page Title="Multi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Multi.aspx.cs" Inherits="MathFun1000.Multi" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
 

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   

    <div id="arrayData" runat="server">

    </div>

    <div class="MainContainer" id="MainController" runat="server">
        <input id="StepBackward" type="button" value="Prev" class="StepBackwardButton" onclick="stepBack()"/>
        <input id="StepForward" type="button" value="Next" class="StepForwardButton" onclick="stepForward()"/>
        
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
</asp:Content>
