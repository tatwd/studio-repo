<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditEmployee.aspx.cs" Inherits="EditEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>连接模式修改指定编号的员工记录</h2>

        <h4>请输入员工编号：</h4>
        <p><asp:TextBox ID="EmpID" runat="server"></asp:TextBox></p>

        <h4>修改项：</h4>
        <div><asp:DropDownList ID="UpdateItem" runat="server"></asp:DropDownList></div>
        
        <p><asp:TextBox ID="UpdateData" runat="server"></asp:TextBox></p>

        <div><asp:Button ID="UpdateBtn" runat="server" OnClick="UpdateInfo" Text="修改"/></div>
    </div>
    </form>
</body>
</html>
