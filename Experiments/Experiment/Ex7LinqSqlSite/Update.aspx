<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        td:first-child {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- 修改数据 -->
        <table>
            <tr>
                <td>分类ID：</td>
                <td><asp:TextBox ID="txtCategoryId" runat="server" Width="160px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>分类名：</td>
                <td><asp:TextBox ID="txtName" runat="server" Width="160px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>描述：</td>
                <td><asp:TextBox ID="txtDescn" runat="server" TextMode="MultiLine" Columns="20"></asp:TextBox></td>
            </tr>
        </table>
        <p>
            <span><asp:Button ID="btnUpdate" runat="server" Text="修改" OnClick="btnUpdate_Click"/></span>
            <span><asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click"/></span>
        </p>
    </div>
    </form>
</body>
</html>
