<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <h2 align="center">分页显示所有新闻列表</h2>

    <div class="news-container">
        <div class="title">
            <h3>新闻公告</h3>
            <h3>当前位置：首页/<a href="News.aspx">新闻公告</a></h3>
        </div>
        <div class="list news-list">
            <!-- 新闻数据源 -->
            <asp:SqlDataSource ID="NewsData" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolDb %>" SelectCommand="SELECT [title], [ntime] FROM [news] ORDER BY [ntime] DESC"></asp:SqlDataSource>

            <!-- 显示前五条新闻 -->
            <asp:ListView ID="ListNews" runat="server" DataSourceID="NewsData">
                <LayoutTemplate>

                    <div ID="ItemPlaceholder" runat="server"></div>

                    <asp:DataPager ID="NewsDataPager" runat="server" PageSize="8">
                        <Fields>
                            <%--<asp:NextPreviousPagerField FirstPageText="首页" LastPageText="尾页" ShowFirstPageButton="true" ShowLastPageButton="true" RenderNonBreakingSpacesBetweenControls="true"/>--%>
                            <asp:NumericPagerField ButtonCount="3" ButtonType="Link" PreviousPageText="上一页" NextPageText="下一页"/>
                            <%--<asp:TemplatePagerField>
                                <PagerTemplate>
                                    <div>1</div>
                                </PagerTemplate>
                            </asp:TemplatePagerField>--%>

                        </Fields>
                    </asp:DataPager>

                </LayoutTemplate>

                <ItemTemplate>
                    <div class="news-item">
                        <asp:LinkButton ID="NewsTitle" runat="server" Text='<%# Eval("title") %>'></asp:LinkButton>
                        <asp:Label ID="NewsTime" runat="server" Text='<%# Eval("ntime") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>

