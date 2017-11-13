 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <div class="row-container">
        <div class="left">
            <div class="title">
                <h3>学生信息</h3>
                <h3><a href="#">更多...</a></h3>
            </div>
            <div class="list info-list">
                <!-- 学生信息数据源 -->
                <asp:SqlDataSource ID="StuInfoData" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolDb %>" SelectCommand="SELECT TOP 6 * FROM [student]"></asp:SqlDataSource>

                <!-- 分组显示数据 -->
                <asp:ListView ID="GroupList" runat="server" DataSourceID="StuInfoData" GroupItemCount="3">
                    <LayoutTemplate>
                        <div class="row">
                            <asp:PlaceHolder ID="GroupPlaceHolder" runat="server"></asp:PlaceHolder>
                        </div>
                    </LayoutTemplate>

                    <GroupTemplate>
                        <div class="group">
                            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </div>
                    </GroupTemplate>

                    <ItemTemplate>
                        <div class="item">
                            <div class="avatar">
                                <asp:Image ID="StuImg" runat="server" ImageUrl='<%# Eval("photo") %>'/>
                            </div>
                            <div class="author">
                                <p class="no">
                                    学号：<asp:Label ID="StuNo" runat="server" Text='<%# Eval("sno") %>'></asp:Label>
                                </p>
                                <p class="name">
                                    姓名：<asp:Label ID="StuName" runat="server" Text='<%# Eval("sname") %>'></asp:Label>
                                </p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
        <div class="right">
            <div class="title">
                <h3>新闻公告</h3>
                <h3><a href="News.aspx">更多...</a></h3>
            </div>
            <div class="list news-list">
                <!-- 新闻数据源 -->
                <asp:SqlDataSource ID="NewsData" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolDb %>" SelectCommand="SELECT TOP 5 [title], CONVERT(varchar(20), [ntime], 23) AS [date] FROM [news] ORDER BY [date] DESC"></asp:SqlDataSource>

                <!-- 显示前五条新闻 -->
                <asp:ListView ID="ListNews" runat="server" DataSourceID="NewsData">
                    
                    <ItemTemplate>
                        <div class="news-item">
                            <asp:LinkButton ID="NewsTitle" runat="server" Text='<%# Eval("title") %>'></asp:LinkButton>
                            <asp:Label ID="NewsTime" runat="server" Text='<%# Eval("date") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>

</asp:Content>

