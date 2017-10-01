<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Session.aspx.cs" Inherits="Session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            邮箱：<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            电话：<asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="确定" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
