<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridDelete.aspx.cs" Inherits="GridDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        function isDelete() {
            return confirm('确定删除？');
        }



    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="StuDbSrc" runat="server" ConnectionString="<%$ ConnectionStrings:StudentDb %>" 
            SelectCommand="SELECT * FROM [StuInfo]" 
            DeleteCommand="DELETE FROM [StuInfo] WHERE [StuNo] = @StuNo" 
            InsertCommand="INSERT INTO [StuInfo] ([StuNo], [Name], [Sex], [Birth], [MajorId]) VALUES (@StuNo, @Name, @Sex, @Birth, @MajorId)" 
            UpdateCommand="UPDATE [StuInfo] SET [Name] = @Name, [Sex] = @Sex, [Birth] = @Birth, [MajorId] = @MajorId WHERE [StuNo] = @StuNo">
            
            <DeleteParameters>
                <asp:Parameter Name="StuNo" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="StuNo" Type="String" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Sex" Type="String" />
                <asp:Parameter Name="Birth" Type="DateTime" />
                <asp:Parameter Name="MajorId" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Sex" Type="String" />
                <asp:Parameter Name="Birth" Type="DateTime" />
                <asp:Parameter Name="MajorId" Type="Int32" />
                <asp:Parameter Name="StuNo" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:GridView ID="ViewData" runat="server" AutoGenerateColumns="False" DataSourceID="StuDbSrc" DataKeyNames="StuNo" OnRowCreated="ViewData_RowCreated">
            <Columns>
                <asp:BoundField DataField="StuNo" HeaderText="StuNo" ReadOnly="True" SortExpression="StuNo"/>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex"/>
                <asp:BoundField DataField="Birth" HeaderText="Birth" SortExpression="Birth"/>
                <asp:BoundField DataField="MajorId" HeaderText="MajorId" SortExpression="MajorId"/>
                
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" ShowHeader="True"/>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ShowHeader="True"/>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
