<%@ Page Title="Math Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MathProgramJavascript.aspx.cs" Inherits="MathFun1000.MathProgramJavascript" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%--<asp:PlaceHolder ID="MenuHolder" runat="server" >
        <div id="menuContainer" class="menuContainer" runat="server">

        </div>
    </asp:PlaceHolder>--%>
    <asp:Button ID="Books_Button" OnClick="Book_Click" Text="Books" runat="server" />
    <asp:Button ID="Chapters_Click" OnClick="Chapter_Click" Text="Chapters" runat="server" />
    <asp:Button ID="Problems_Click" OnClick="Problem_Click" Text="Problems" runat="server" />


</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <%--<script src="Scripts/greensock/TweenLite.min.js"></script>
    <script src="Scripts/greensock/jquery.gsap.min.js"></script>
    <script src="Scripts/greensock/TimelineLite.min.js"></script>--%>
    
    

    <div id="arrayData" runat="server">

    </div>

    
    <br/>
    <br/>
    <div class="ControllButtons">
        <input id="tutorial" type="button" value="Tutorial" onclick="tutorialParser()"/>
        <input id="fillIn" type="button" value="Fill In" onclick="fillInParser()"/>
        <input id="unguided" type="button" value="Answer Only" onclick="unguidedParser()"/>
    </div>
    <div class="MainContainer" id="MainController" runat="server">
    <input id="HidestepColumn" type="button" value="Hide steps" class="hideColumn" onclick="hideColumn('step')"/>
    <input id="HideruleColumn" type="button" value="Hide rules" class="StepForwardButton" onclick="hideColumn('rule')"/>

        <div class="innerMain" id="innerMain" runat="server">
            
            
               
        </div>

        <script>
            // $(document).ready(function () { $(".MainContainer").slideDown(500); });
            $(".MainContainer").css("visibility", "hidden");
            //$(".MainContainer").slideUp(333);

        </script>

        

        <div id="answerArea" >
            <%--<input id="answerField" type="text" />--%>
            <p style="float: left; margin-right: 5px;">Answer:   </p>
            <input class="answerBox" id="AnswerBox" type="text" value="" autoComplete="off"/>
            <input type="button" value="&#10003" onclick="checkAnswer()"/>
            <label id="answerLabel" style="display: inline-block; vertical-align: top;"></label>
        </div>

        <div id="unguidedAnswerArea" >
            <%--<input id="answerField" type="text" />--%>
            <p style="float: left; margin-right: 5px;">Answer:   </p>
            <input class="answerBox" id="unguidedAnswerBox" type="text" value="" autoComplete="off"/>
            <input type="button" value="&#10003" onclick="checkUnguidedAnswer()"/>
            <label id="unguidedAnswerLabel" style="display: inline-block; vertical-align: top;"></label>
        </div>
        <input id="StepForward" type="button" value="Next" class="StepForwardButton" onclick="stepForward()"/>
        <input id="StepBackward" type="button" value="Prev" class="StepBackwardButton" onclick="stepBack()"/>
        
        
    </div>
    <div class="buttons" id="buttons" runat="server" >
                
    </div>
    

    

    

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
            $(".MainContainer").slideDown(1500);
            $(".MainContainer").css("visibility", "");
            $(".MainContainer").css("opacity", "0");
            $(".MainContainer").animate({opacity: 1}, 1500)
        });
    </script> 

    <script type="text/javascript" src="Scripts/tutorial.js"></script>

    <asp:HiddenField ID="stepCount" runat="server" value="0"/>
    <asp:HiddenField ID="problemNumber" runat="server" value="0"/>
    <asp:HiddenField ID="problemType" runat="server" value="FillIn" />
</asp:Content>
