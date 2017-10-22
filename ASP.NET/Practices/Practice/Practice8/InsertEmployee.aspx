<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertEmployee.aspx.cs" Inherits="InsertEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>连接模式录入新员工</h2>
        
        <h4>EmpID:</h4>
        <div><asp:TextBox ID="EmpID" runat="server"></asp:TextBox></div>
        
        <h4>EmpName:</h4>
        <div><asp:TextBox ID="EmpName" runat="server"></asp:TextBox></div>

        <h4>EmpAge:</h4>
        <div><asp:TextBox ID="EmpAge" runat="server"></asp:TextBox></div>

        <h4>EmpDepartment:</h4>
        <div><asp:TextBox ID="EmpDepartment" runat="server"></asp:TextBox></div>

        <p><asp:Button ID="Submit" runat="server" Text="提交" OnClick="SubmitInfo"/></p>
    </div>
    </form>
</body>
</html>
