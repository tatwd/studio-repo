<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryString_Hello.aspx.cs" Inherits="QueryString_Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            姓名：<asp:Label ID="lblName" runat="server"></asp:Label>
            <br />
            邮箱：<asp:Label ID="lblEmail" runat="server"></asp:Label>
            <br />
            电话：<asp:Label ID="lblTelephone" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
