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

    


    <div class="MainContainer" id="MainController" runat="server">
    <input id="HidestepColumn" type="button" value="Hide steps" class="hideColumn" onclick="hideColumn('step')"/>
    <input id="HideruleColumn" type="button" value="Hide rules" class="StepForwardButton" onclick="hideColumn('rule')"/>

        <div class="innerMain" id="innerMain" runat="server">
            
            <div class="buttons" id="buttons" runat="server" >
                
            </div>
               
        </div>
        <input id="StepForward" type="button" value="Prev" class="StepBackwardButton" onclick="stepBack()"/>
        <input id="StepForward" type="button" value="Next" class="StepForwardButton" onclick="stepForward()"/>
    </div>
    <script type="text/javascript" src="Scripts/tutorial.js"></script>
    <asp:HiddenField ID="stepCount" runat="server" value="0"/>
    <asp:HiddenField ID="problemNumber" runat="server" value="0"/>
    <asp:HiddenField ID="problemType" runat="server" value="FillIn" />
</asp:Content>
