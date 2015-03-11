<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayProblems.aspx.cs" Inherits="MathFun1000.DisplayProblems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Problems</title>
</head>
<body>
    <p>Display Problem Page</p>

    <form id="form1" runat="server">
    <a href="AddStep.aspx">Add Step</a>
        <asp:Button ID="btnAllSteps" runat="server" OnClick="btnAllHelp_Click" Text="Show All"/>
        <asp:Button ID="btnMediumHelp" runat="server" OnClick="btnMedium_Click" Text="Medium Help"/>
        <asp:Button ID="btnNoHelp" runat="server" OnClick="btnNoHelp_Click" Text="No Help"/>   
        <div>  
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" Height="429px" Width="911px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ForeColor="#333333" GridLines="None" DataKeyNames="Step_ID">  
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>  
                    <asp:TemplateField>  
                        <ItemTemplate>  
                            <asp:CheckBox ID="chkDel" runat="server" />  
                        </ItemTemplate>  
                    </asp:TemplateField>  
                    <asp:BoundField DataField="Step_ID" HeaderText="Step ID" ReadOnly="True" />
<%--                    <asp:templatefield headertext="step id" >  
                        <edititemtemplate>
                            <asp:textbox id="textboxid" runat="server" text='<%# eval("step_id") %>'></asp:textbox>
                        </edititemtemplate>
                        <itemtemplate>
                            <asp:label id="lblid" runat="server" text='<%# eval("step_id") %>'></asp:label>
                        </itemtemplate>
                    </asp:templatefield>--%>
                    <asp:TemplateField HeaderText="Info" >  
                        <EditItemTemplate>
                            <asp:TextBox ID="textboxInfo" runat="server" Text='<%# Eval("Info") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblInfo" runat="server" Text='<%# Eval("Info") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Example" >  
                        <EditItemTemplate>
                            <asp:TextBox ID="textboxExample" runat="server" Text='<%# Eval("Example") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblExample" runat="server" Text='<%# Eval("Example") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rules" >
                        <EditItemTemplate>
                            <asp:TextBox ID="textboxRules" runat="server" Text='<%# Eval("Rules") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblRules" runat="server" Text='<%# Eval("Rules") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Difficulty" >  
                        <EditItemTemplate>
                            <asp:TextBox ID="textboxDifficulty" runat="server" Text='<%# Eval("Difficulty") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDifficulty" runat="server" Text='<%# Eval("Difficulty") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" HeaderText="Operations" ShowEditButton="True" ShowHeader="True"/>
                </Columns>  
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" ForeColor="#ffffff" Font-Bold="True" />  
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />  
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>  
            <asp:Button ID="btnDeleteRecord" runat="server" Height="32px" OnClick="btnDeleteRecord_Click" Text="Delete" Width="64px" />  
            <br />  
        </div>  
    </form>
</body>
</html>
