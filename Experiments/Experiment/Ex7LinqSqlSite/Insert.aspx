<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Insert.aspx.cs" Inherits="Insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- 插入数据 -->
        <table>
            <tr>
                <td align="right">分类名：</td>
                <td><asp:TextBox ID="txtName" runat="server" Width="160px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">描述：</td>
                <td><asp:TextBox ID="txtDescn" runat="server" TextMode="MultiLine" Rows="2" Columns="20"></asp:TextBox></td>
            </tr>
        </table>
        <p>
            <span><asp:Button ID="btnInsert" runat="server" Text="插入" OnClick="btnInsert_Click"/></span>
            <span><asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click"/></span>
        </p>
    </div>
    </form>
</body>
</html>
