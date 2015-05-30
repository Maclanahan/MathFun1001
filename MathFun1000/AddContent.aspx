<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddContent.aspx.cs" Inherits="MathFun1000.AddContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/ContentManager.js"></script>
    <script type="text/javascript">
        function helloWorld() {
            $.ajax({
                type: "POST",
                url: "ContentManager.asmx/HelloWorld",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                },
                error: function (data) {
                    //console.log(data);
                }
            });
        }

    </script>
    <script type="text/javascript"
            src="https://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS_HTML">
     </script>

    <script type="text/x-mathjax-config">
        function loadJax()
        {  
            MathJax.Hub.Config({ 
                TeX: { 
                        extensions: ["autobold.js"],
                        //messageStyle: 'none', tex2jax: {preview: 'none'}
                     }
            });
        }
     </script>
    <script src="Scripts/wysiwyg.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:ScriptManager ID="ConentManager" runat="server">
        <%--<Services>
            <asp:ServiceReference Path="ContentManager.asmx" />
        </Services>--%>
    <%--</asp:ScriptManager>--%>
    <%--<input id="Button1" type="button" value="Hello?" onclick="getBooks()" />--%>

    <div id="book" >
        Book: <select id="bookSelection" onchange="getChapters()">
            <option value="-1">Select Book</option>
            
            <%--<div>
                <input type="button" value="B" onclick="iBold()">
                <input type="button" value="&#920;" onclick="iSymbol()">
                <input type="button" >
                <input type="button" >
            </div>
            <textarea contenteditable style="display:none" class="wysiwyg" cols="5" rows="5"></textarea>
            <%--<iframe id="richTextField" style="border: #000000 1px solid; height:300px; background-color: #ffffff"></iframe>--%>
            <%--<div contenteditable style="width:200px; height: 200px; background-color: #ffffff">
                This is all editable?
            </div>--%>
            
        </select>
    </div>

    <div id="chapter" style="visibility:hidden">
        Chapter: <select id="chapterSelection" onchange="getProblems()">
            <option value="-1">Select Chapter</option>

        </select>
    </div>
    <div id="problem" style="visibility:hidden">
        Problem: <select id="problemSelection" onchange="getSteps()">
            <option value="-1">Select Problem</option>

        </select>
    </div>

    <div id="step" style="visibility:hidden">
        Step: <select id="stepSelection" style="visibility:hidden">
            <option value="-1">Select Step</option>

        </select>
    </div>


    
</asp:Content>
