<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TableLayout.aspx.cs" Inherits="Ex2_TableLayout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {}
        .auto-style2 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1" rowspan="2">
                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/logo.gif" />
            </td>
            <td class="auto-style1" style="text-align: center; background-color: #99ccff">
                <asp:LinkButton ID="lnkbtnDefault" runat="server">首页</asp:LinkButton>
            </td>
            <td class="auto-style1" style="text-align: center; background-color: #99ccff">
                <asp:LinkButton ID="lnkbtnReset" runat="server">个性设置</asp:LinkButton>
            </td>
            <td class="auto-style1" style="text-align: center; background-color: #99ccff">
                <asp:LinkButton ID="lnkbtnRegister" runat="server">注册</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="background-color: #ccffff">登录状态</td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="4" style="background-color: #33cccc">您的位置</td>
        </tr>
    </table>
    </form>
</body>
</html>
