<%@ Page Title="Math Problem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MathProgramJavascript.aspx.cs" Inherits="MathFun1000.MathProgramJavascript" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <%--<script src="Scripts/greensock/TweenLite.min.js"></script>
    <script src="Scripts/greensock/jquery.gsap.min.js"></script>
    <script src="Scripts/greensock/TimelineLite.min.js"></script>--%>

    <div id="arrayData" runat="server">

    </div>

    

    <div class="ControllButtons">
        <input id="tutorial" type="button" value="Tutorial" onclick="tutorialParser()"/>
        <input id="fillIn" type="button" value="Fill In" onclick="fillInParser()"/>
        <input id="unguided" type="button" value="Answer Only" onclick="unguidedParser()"/>
    </div>
    <div class="MainContainer" id="MainController" runat="server">
    <input id="HidestepColumn" type="button" value="Hide steps" class="hideColumn" onclick="hideColumn('step')"/>
    <input id="HideruleColumn" type="button" value="Hide rules" class="StepForwardButton" onclick="hideColumn('rule')"/>

        <div class="innerMain" id="innerMain" runat="server">
            
            <div class="buttons" id="buttons" runat="server" >
                
            </div>
               
        </div>

        

        

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

        <input id="StepBackward" type="button" value="Prev" class="StepBackwardButton" onclick="stepBack()"/>
        <input id="StepForward" type="button" value="Next" class="StepForwardButton" onclick="stepForward()"/>
        
    </div>

    <script>
        // $(document).ready(function () { $(".MainContainer").slideDown(500); });
        $(".MainContainer").css("visibility", "hidden");
        //$(".MainContainer").slideUp(0);

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
            $(".MainContainer").css("visibility", "");
            //$(".MainContainer").slideDown(500);
        });
        </script> 

    <script type="text/javascript" src="Scripts/tutorial.js"></script>
    <asp:HiddenField ID="stepCount" runat="server" value="0"/>
    <asp:HiddenField ID="problemNumber" runat="server" value="0"/>
    <asp:HiddenField ID="problemType" runat="server" value="FillIn" />
</asp:Content>
