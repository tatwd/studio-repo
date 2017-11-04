<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridTemplate.aspx.cs" Inherits="GirdTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="StuDbSrc" runat="server" ConnectionString="<%$ ConnectionStrings:StudentDb %>" 
            SelectCommand="SELECT * FROM [Major]" 
            DeleteCommand="DELETE FROM [Major] WHERE [MajorId] = @MajorId" 
            InsertCommand="INSERT INTO [Major] ([MajorId], [MajorName]) VALUES (@MajorId, @MajorName)" 
            UpdateCommand="UPDATE [Major] SET [MajorName] = @MajorName WHERE [MajorId] = @MajorId">

            <DeleteParameters>
                <asp:Parameter Name="MajorId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="MajorId" Type="Int32" />
                <asp:Parameter Name="MajorName" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="MajorName" Type="String" />
                <asp:Parameter Name="MajorId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:GridView ID="ViewData" runat="server" DataSourceID="StuDbSrc" AutoGenerateColumns="False" DataKeyNames="MajorId">
            <Columns>

                <asp:TemplateField>
                    <headertemplate>
                        <asp:checkbox ID="HeaderCkBox" runat="server" text="全选" OnCheckedChanged="HeaderCkBox_CheckedChanged" AutoPostBack="true"/>
                    </headertemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="ItemCkBox" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="MajorId" HeaderText="MajorId" ReadOnly="True" SortExpression="MajorId" />
                <asp:BoundField DataField="MajorName" HeaderText="MajorName" SortExpression="MajorName" />
                
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" ShowHeader="True" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>

        <asp:LinkButton ID="DeleteMajor" runat="server" OnClick="DeleteMajor_Click">批量删除</asp:LinkButton>
    </div>
    </form>
</body>
</html>
