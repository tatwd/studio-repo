<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchEmployee.aspx.cs" Inherits="SearchEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>断开模式查询指定部门的员工记录</h2>

        <h4>请输入部门：</h4>
        <div><asp:TextBox ID="DepartmentName" runat="server"></asp:TextBox></div>

        <p><asp:Button ID="QueryBtn" runat="server" Text="查询" OnClick="QueryInfo"/></p>

        <h4>查询结果：</h4>
        <div><asp:GridView ID="ResultView" runat="server"></asp:GridView></div>
    </div>
    </form>
</body>
</html>
