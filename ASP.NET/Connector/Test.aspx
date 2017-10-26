<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3 id="prompt" runat="server"></h3>

        <h4>Username:</h4>
        <div><asp:TextBox ID="Username" runat="server"></asp:TextBox></div>

        <h4>Password:</h4>
        <div><asp:TextBox ID="Password" runat="server"></asp:TextBox></div>

        <p><asp:Button ID="SignInBtn" runat="server" Text="登录" OnClick="SignInBtn_Click"/></p>

        <p><asp:Button ID="SignUpBtn" runat="server" Text="注册" OnClick="SignUpBtn_Click"/></p>

        <asp:GridView ID="ViewData1" runat="server"></asp:GridView>
        <asp:GridView ID="ViewData2" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
