<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultipleChoice.aspx.cs" Inherits="MathFun1000.MultipleChoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Chapter: "></asp:Label>
        <asp:Literal ID="literal_ChapterNum" runat="server"></asp:Literal>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Problem: "></asp:Label>
        <asp:Literal ID="literal_ProblemNum" runat="server"></asp:Literal>
        <br />
        <asp:Literal ID="literal_Problem" runat="server"></asp:Literal>
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" />
        <br />
        <asp:CheckBox ID="CheckBox2" runat="server" />
        <br />
        <asp:CheckBox ID="CheckBox3" runat="server" />
        <br />
        <asp:CheckBox ID="CheckBox4" runat="server" />
        <br />
        <asp:CheckBox ID="CheckBox5" runat="server" />
        <br />
        <asp:GridView ID="GridView1" runat="server" ShowHeader="false">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>  
                    <asp:TemplateField>  
                        <ItemTemplate>  
                            <asp:CheckBox ID="chkDel" runat="server" />  
                        </ItemTemplate>  
                    </asp:TemplateField>  
<%--                    <asp:BoundField DataField="Step_ID" HeaderText="Step ID" ReadOnly="True" />--%>
<%--                    <asp:templatefield headertext="step id" >  
                        <edititemtemplate>
                            <asp:textbox id="textboxid" runat="server" text='<%# eval("step_id") %>'></asp:textbox>
                        </edititemtemplate>
                        <itemtemplate>
                            <asp:label id="lblid" runat="server" text='<%# eval("step_id") %>'></asp:label>
                        </itemtemplate>
                    </asp:templatefield>--%>
                    <asp:TemplateField HeaderText="option" >  
                        <EditItemTemplate>
                            <asp:TextBox ID="textboxInfo" runat="server" Text='<%# Eval("Info") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblInfo" runat="server" Text='<%# Eval("Info") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
 <%--                   <asp:TemplateField HeaderText="Example" >  
                        <EditItemTemplate>
                            <asp:TextBox ID="textboxExample" runat="server" Text='<%# Eval("Example") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblExample" runat="server" Text='<%# Eval("Example") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
<%--                    <asp:TemplateField HeaderText="Rules" >
                        <EditItemTemplate>
                            <asp:TextBox ID="textboxRules" runat="server" Text='<%# Eval("Rules") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblRules" runat="server" Text='<%# Eval("Rules") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
<%--                    <asp:TemplateField HeaderText="Difficulty" >  
                        <EditItemTemplate>
                            <asp:TextBox ID="textboxDifficulty" runat="server" Text='<%# Eval("Difficulty") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDifficulty" runat="server" Text='<%# Eval("Difficulty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Operations" ShowEditButton="True" ShowHeader="True"/>
                </Columns>  
        </asp:GridView>
    
        <asp:Button ID="btn_Submit" runat="server" OnClick="btnSubmit_Click" Text="Button" />
    
    </div>
    </form>
</body>
</html>
