<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            登录时间：<asp:Label ID="lblLoginTime" runat="server"></asp:Label>
            <br />
            IP地址：<asp:Label ID="lblIPAddress" runat="server"></asp:Label>
            <br />
            在线人数：<asp:Label ID="lblOnline" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
