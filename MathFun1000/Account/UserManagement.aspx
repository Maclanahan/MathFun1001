<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLoggedIn.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="MathFun1000.WebForm1" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%--                </ChangePasswordTemplate>
            </asp:ChangePassword>--%></h1>
    </hgroup>

    <section id="passwordForm">
        <%--        </asp:PlaceHolder>--%><%--<asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" RenderOuterTable="false" SuccessPageUrl="Manage?m=ChangePwdSuccess">
                <ChangePasswordTemplate>--%>
                <h3>Change password</h3>
            <%--                </ChangePasswordTemplate>
            </asp:ChangePassword>--%>
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                    <fieldset class="changePassword">
                        <legend>Change password details</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword">Current password</asp:Label>
                                <asp:TextBox runat="server" ID="CurrentPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="field-validation-error" ErrorMessage="The current password field is required."
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">New password</asp:Label>
                                <asp:TextBox runat="server" ID="NewPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                    CssClass="field-validation-error" ErrorMessage="The new password is required."
                                    ValidationGroup="ChangePassword" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword">Confirm new password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                    ValidationGroup="ChangePassword" />
                            </li>
                        </ol>
                        <asp:Button ID="btnChangePassword" runat="server" CommandName="ChangePassword" Text="Change password" OnClick="btnChangePassword_Click" ValidationGroup="ChangePassword" />
                    </fieldset>
<%--        </asp:PlaceHolder>--%><%--<asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" RenderOuterTable="false" SuccessPageUrl="Manage?m=ChangePwdSuccess">
                <ChangePasswordTemplate>--%>
    </section>

    <section id="deleteForm">
        <%--                </ChangePasswordTemplate>
            </asp:ChangePassword>--%><%--        </asp:PlaceHolder>--%>
                <h4>Delete Account</h4>
            <%--<asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" RenderOuterTable="false" SuccessPageUrl="Manage?m=ChangePwdSuccess">
                <ChangePasswordTemplate>--%>
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="DeleteText" />
                    </p>
                    <fieldset class="DeleteAccount">
                        <legend>Delete This Account</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" ID="dLabel2" AssociatedControlID="tb_delCurrentPassword">Current Password</asp:Label>
                                <asp:TextBox runat="server" ID="tb_delCurrentPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tb_delCurrentPassword"
                                    CssClass="field-validation-error" ErrorMessage="The current password is required."
                                    ValidationGroup="DeleteAccount" />
                            </li>
                            <li>
                                <asp:Label runat="server" ID="dLabel3" AssociatedControlID="tb_delConfirmPassword">Confirm password</asp:Label>
                                <asp:TextBox runat="server" ID="tb_delConfirmPassword" CssClass="passwordEntry" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="tb_delConfirmPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password is required."
                                    ValidationGroup="DeleteAccount" />
                                <asp:CompareValidator runat="server" ControlToCompare="tb_delCurrentPassword" ControlToValidate="tb_delConfirmPassword"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                    ValidationGroup="DeleteAccount" />
                            </li>
                        </ol>
                        <asp:Button ID="btnDeleteAccount" runat="server" CommandName="DeleteAccount" Text="Delete Account" OnClick="btnDeleteAccount_Click" ValidationGroup="DeleteAccount" />
                    </fieldset>
<%--                </ChangePasswordTemplate>
            </asp:ChangePassword>--%>
<%--        </asp:PlaceHolder>--%>
    </section>
</asp:Content>
