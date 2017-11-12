<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <div class="news-container">
        <div class="title">
            <h3>新闻公告</h3>
            <h3>当前位置：<a href="Default.aspx">首页</a>/<a href="News.aspx">新闻公告</a></h3>
        </div>
        <div class="list news-list">
            <!-- 新闻数据源 -->
            <asp:SqlDataSource ID="NewsData" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolDb %>" SelectCommand="SELECT [title], convert(varchar(20), [ntime], 120) AS [date] FROM [news] ORDER BY [ntime] DESC"></asp:SqlDataSource>

            <!-- 显示前五条新闻 -->
            <asp:ListView ID="ListNews" runat="server" DataSourceID="NewsData">
                <LayoutTemplate>

                    <div ID="ItemPlaceholder" runat="server"></div>

                    <div class="news-pager">
                        <asp:DataPager ID="NewsDataPager" runat="server" PageSize="8">
                            <Fields>
                                <asp:NextPreviousPagerField FirstPageText="首页" ShowFirstPageButton="true" ShowPreviousPageButton="false"/>
                                <asp:NumericPagerField ButtonCount="3" CurrentPageLabelCssClass="active-num" NumericButtonCssClass="num-btn"/>
                                <asp:NextPreviousPagerField LastPageText="尾页" ShowLastPageButton="true" ShowPreviousPageButton="false"/>
                            </Fields>
                        </asp:DataPager>
                    </div>

                </LayoutTemplate>

                <ItemTemplate>
                    <div class="news-item">
                        <asp:LinkButton ID="NewsTitle" runat="server" Text='<%# Eval("title") %>'></asp:LinkButton>
                        <asp:Label ID="NewsTime" runat="server" Text='<%# Eval("date") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>

