<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupValidation.aspx.cs" Inherits="Ex5_GroupValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 289px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td style="text-align: right">用户名：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="请输入用户名！" SetFocusOnError="True" ValidationGroup="groupSubmit">*</asp:RequiredFieldValidator>
                    <asp:Button ID="btnValidateName" runat="server" OnClick="btnValidateName_Click" Text="用户名是否可用" ValidationGroup="groupName" />
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">密码：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="请输入密码！" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">确认密码：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPasswordAgain" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPasswordAgain" runat="server" ControlToValidate="txtPasswordAgain" Display="Dynamic" ErrorMessage="请输入确认密码！" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPasswordAgain" Display="Dynamic" ErrorMessage="密码不一致！" SetFocusOnError="True"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">生日：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtBirthday" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvBirthday" runat="server" ControlToValidate="txtBirthday" Display="Dynamic" ErrorMessage="请输入生日！" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvBirthday" runat="server" ControlToValidate="txtBirthday" Display="Dynamic" ErrorMessage="日期应在1900-1-1到2020-1-1之间！" MaximumValue="2020-1-1" MinimumValue="1900-1-1" SetFocusOnError="True" Type="Date"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">电话号码：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvTelephone" runat="server" ControlToValidate="txtTelephone" Display="Dynamic" ErrorMessage="请输入电话号码！" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTelephone" runat="server" ControlToValidate="txtTelephone" Display="Dynamic" ErrorMessage="电话格式应在021-66798304！" SetFocusOnError="True" ValidationExpression="\d{3}-\d{8}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">身份证号：</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtIdentity" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvIdentity" runat="server" ControlToValidate="txtIdentity" Display="Dynamic" ErrorMessage="请输入身份证号！" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="csvIdentity" runat="server" ControlToValidate="txtIdentity" Display="Dynamic" ErrorMessage="身份证号错误！" OnServerValidate="csvIdentity_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="确定" />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <asp:ValidationSummary ID="vsSubmit" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" />
    
        <asp:ValidationSummary ID="vsName" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="groupName" />
    
    </div>
    </form>
</body>
</html>
