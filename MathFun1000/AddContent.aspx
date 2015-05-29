<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddContent.aspx.cs" Inherits="MathFun1000.AddContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.8.2.min.js"></script>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:ScriptManager ID="ConentManager" runat="server">
        <%--<Services>
            <asp:ServiceReference Path="ContentManager.asmx" />
        </Services>--%>
    <%--</asp:ScriptManager>--%>
    <input id="Button1" type="button" value="Hello?" onclick="helloWorld()" />
    <div id="book">
        <select id="bookSelection">
            <option></option>
            <script>
                
            </script>
        </select>
    </div>
    <div id="chapter">
        <select id="chapterSelection">
            <option></option>

        </select>
    </div>
    <div id="problem">
        <select id="problemSelection">
            <option></option>

        </select>
    </div>
    <div id="step">
        <select id="stepSelection">
            <option></option>

        </select>
    </div>
</asp:Content>
