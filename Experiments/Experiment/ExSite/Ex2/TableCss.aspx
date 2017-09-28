<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TableCss.aspx.cs" Inherits="Ex2_TableCss" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Styles/TableDiv.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td rowspan="2">
                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/logo.gif" />
            </td>
            <td class="navigation">
                <asp:LinkButton ID="lnkbtnDefault" runat="server">首页</asp:LinkButton>
            </td>
            <td class="navigation">
                <asp:LinkButton ID="lnkbtnReset" runat="server">个性设置</asp:LinkButton>
            </td>
            <td class="navigation">
                <asp:LinkButton ID="lnkbtnRegister" runat="server">注册</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="status">登录状态</td>
        </tr>
        <tr>
            <td class="position" colspan="4">您的位置</td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
