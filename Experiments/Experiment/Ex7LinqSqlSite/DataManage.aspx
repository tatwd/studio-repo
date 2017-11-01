<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataManage.aspx.cs" Inherits="DataManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- 数据管理导航页 -->

        <p>
            <span>分类ID：</span>
            <asp:TextBox ID="txtCategoryId" runat="server" Text="输入分类Id，只用于“修改”和“删除”" Width="220px"></asp:TextBox>
        </p>
        
        <p>
            <span><asp:Button ID="btnQueryAll" runat="server" Text="显示全部" OnClick="btnQueryAll_Click"/></span>
            <span><asp:Button ID="btnFuzzy" runat="server" Text="模糊查找" OnClick="btnFuzzy_Click"/></span>
            <span><asp:Button ID="btnInsert" runat="server" Text="插入" OnClick="btnInsert_Click"/></span>
            <span><asp:Button ID="btnUpdate" runat="server" Text="修改" OnClick="btnUpdate_Click"/></span>
            <span><asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/></span>
        </p>

        <p><asp:GridView ID="gvCategory" runat="server"></asp:GridView></p>
    </div>
    </form>
</body>
</html>
