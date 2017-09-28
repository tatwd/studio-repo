<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calculator.aspx.cs" Inherits="Ex4_Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        简易计算器<br />
        <asp:TextBox ID="txtDisplay" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnOne" runat="server" Text="1" Width="40px" OnClick="btnOne_Click" />
        <asp:Button ID="btnTwo" runat="server" Text="2" Width="40px" OnClick="btnTwo_Click" />
        <asp:Button ID="btnThree" runat="server" Text="3" Width="40px" OnClick="btnThree_Click" />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="+" Width="40px" OnClick="btnAdd_Click" />
        <asp:Button ID="btnSubtract" runat="server" Text="-" Width="40px" OnClick="btnSubtract_Click" />
        <asp:Button ID="btnEqual" runat="server" Text="=" Width="40px" OnClick="btnEqual_Click" />
    
    </div>
    </form>
</body>
</html>
