<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestDbKitS.aspx.cs" Inherits="TestDbKitS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Username:</h3>
        <p><asp:TextBox ID="Username" runat="server"></asp:TextBox></p>

        <h3>Password:</h3>
        <p><asp:TextBox ID="Password" runat="server"></asp:TextBox></p>

        <div>
            <asp:Button ID="BtnExecute" runat="server" Text="Execute" OnClick="BtnExecute_Click"/>
            <asp:Button ID="BtnExecuteBySp" runat="server" Text="Execute by stored procdure" OnClick="BtnExecuteBySp_Click"/>
            <asp:Button ID="BtnExecuteDisc" runat="server" Text="GetData" OnClick="BtnExecuteDisc_Click"/>
        </div>

        <div>
            <p runat="server" id="display"></p>
            
            <asp:GridView ID="ViewData" runat="server"></asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
