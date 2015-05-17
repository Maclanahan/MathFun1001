<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rules.aspx.cs" Inherits="MathFun1000.Rules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <nav class="navMenu">
        <ul id="linkList" runat="server">
            <%--<li>
                <a href="#MainContent_distributive">Distributive Property</a>
            </li>
            <li>
                <a href="#MainContent_associative">Associative Property</a>
            </li>
            <li>
                <a href="#MainContent_communative">Communative Property</a>
            </li>
            <li>
                <a href="#MainContent_identity">Identity Property</a>
            </li>
            <li>
                <a href="#MainContent_zeroProduct">Zero Product Property</a>
            </li>--%>
        </ul>
    </nav>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ruleHolder" runat="server">

    </div>

    <%--<h2 id="distributive">Distributive Property</h2>
    <div class="ruleDescBox" >
        <p>It's where you pass things outside the parenthesis.</p><br/>
        <p>3x – 6 = 3(x – 2)</p>
        <br/><br/><br/><br/><br/>
    </div>

    <h2 id="associative">Associative Property</h2>
    <div class="ruleDescBox" >
        <p>You can change the order and it still works.</p><br/>
        <p>2(3x) = (2 * 3)x</p>
        <br/><br/><br/><br/><br/>
    </div>

    <h2 id="communative">Communative Property</h2>
    <div class="ruleDescBox" >
        <p>You can change the order and it still works.</p><br/>
        <p>2 * 4 * 3 = 3 * 2 * 4</p>
        <br/><br/><br/><br/><br/>
    </div>

    <h2 id="identity">Identity Property</h2>
    <div class="ruleDescBox" >
        <p>A number stays the same after an operation.</p><br/>
        <p>6 + 0 = 6</p>
        <br/><br/><br/><br/><br/>
    </div>

    <h2 id="zeroProduct">Zero Product Property</h2>
    <div class="ruleDescBox" >
        <p>You multply it by zero, it becomes zero.</p><br/>
        <p>5 * 0 = 0</p>
        <br/><br/><br/><br/><br/>
    </div>--%>

</asp:Content>
