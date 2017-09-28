<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Grade.aspx.cs" Inherits="Ex3_Grade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtInput" runat="server" Text=""></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="等级" OnClick="btnSubmit_Click" />
        <asp:Label ID="lblDisplay" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
