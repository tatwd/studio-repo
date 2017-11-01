<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FuzzyQuery.aspx.cs" Inherits="FuzzyQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- 模糊查询 -->
        <p>
            <span>分类名：</span>
            <span><asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></span>
            <span><asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click"/></span>
            <span><asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click"/></span>
        </p>

        <p><asp:GridView ID="gvCategory" runat="server"></asp:GridView></p>

        <p><asp:Label ID="lbMsg" runat="server" ></asp:Label></p>
    </div>
    </form>
</body>
</html>
