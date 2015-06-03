<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddContent.aspx.cs" Inherits="MathFun1000.AddContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/ContentManager.js"></script>
    <script src="Scripts/wysiwyg.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <div id="book" style="visibility: hidden" class="editBox">
        Book: <select id="bookSelection" onchange="getChapters()">
            <option value="-1">Select Book</option>
        </select>
        <input type="button" value="Edit" onclick="openEdit('#bookSelection','#editBook', '#editBookName')"/>
        <input type="button" value="+" onclick="$('#addBook').slideDown(500); $('#editBook').slideUp(500)"/>
        <div id="addBook">
            Title: <input type="text" id="bookName"/><br/>
            <input type="button" value="Cancel" onclick="closeDiv('#addBook')">
            <input type="button" value="Add" onclick="addNewBook()">
        </div>

        <div id="editBook">
            Title: <input type="text" id="editBookName"/><br/>
            <input type="button" value="Cancel" onclick="closeDiv('#editBook')">
            <input type="button" value="Save" onclick="updateBook()">
        </div>
    </div>

    <div id="chapter" style="visibility:hidden" class="editBox">
        Chapter: <select id="chapterSelection" onchange="getProblems()">
            <option value="-1">Select Chapter</option>
        </select>
        <input type="button" value="Edit" onclick="openChapterEdit('#chapterSelection', '#editChapter')"/>
        <input type="button" value="+" onclick="$('#addChapter').slideDown(500); $('#editChapter').slideUp(500)"/>
        <div id="addChapter">
            Chapter Title: <input type="text" id="chapterName"/><br/>
            Chapter Description: <textarea id="chapterDesc" cols="5" rows="5"></textarea><br/>
            <input type="button" value="Cancel" onclick="closeDiv('#addChapter')">
            <input type="button" value="Add" onclick="addNewChapter()">
        </div>

        <div id="editChapter">
            Chapter Title: <input type="text" id="editChapterName"/><br/>
            Chapter Description: <textarea id="editChapterDesc" cols="5" rows="5"></textarea><br/>
            <input type="button" value="Cancel" onclick="closeDiv('#editChapter')">
            <input type="button" value="Save" onclick="updateChapter()">
        </div>
        
    </div>
    <div id="problem" style="visibility:hidden" class="editBox">
        Problem: <select id="problemSelection" onchange="getSteps()">
            <option value="-1">Select Problem</option>
        </select>
        <input type="button" value="Edit" onclick="makeEditable();"/>
        <input type="button" value="+"/>

        <div id="editProblem">
            <input type="button" value="Cancel" onclick="$('#editProblem').slideUp(500); makeUnEditable()">
            <input type="button" value="Save" onclick="updateProblem()">
        </div>
    </div>

    <div id="step" style="visibility:hidden" class="editBox">
       

        
    </div>


    
</asp:Content>
