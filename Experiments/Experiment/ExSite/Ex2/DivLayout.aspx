<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DivLayout.aspx.cs" Inherits="Ex2_DivLayout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="top">
        <div id="logo_navi_stat">
            <div id="logo" style="float: left; width: 30%;">
                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/logo.gif" />
            </div>
            <div id="navigation" style="background-color: #99ccff; height: 30px;">
                <asp:LinkButton ID="lnkbtnDefault" runat="server">首页</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;|&nbsp;
                <asp:LinkButton ID="lnkbtnReset" runat="server">个性设置</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;|&nbsp;
                <asp:LinkButton ID="lnkbtnRegister" runat="server">注册</asp:LinkButton>
            </div>
            <div id="status" style="background-color: #ccffff; height: 30px;">登录状态</div>
        </div>

        <div id="position" style="background-color: #33cccc">你的位置</div>
    </div>
    </form>
</body>
</html>
