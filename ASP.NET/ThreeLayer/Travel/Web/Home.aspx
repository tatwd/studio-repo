<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web.Home2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Home</title>
    <link href="style/main.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="logo">
            <a href="#"><img src="assets/img/logo.png" alt="logo img"/></a>
            <div class="nav">
                <a href="Home.aspx">首页</a>
                <div class="user-sign">
                    <a class="user-avatar" href="#"><img src="assets/img/avatar.svg" alt="avatar"/></a>
                    <div class="sign-box">
                        <i class="icon-triangle"></i>
                        <ul>
                            <li><a href="Sign.aspx" runat="server" id="SignInLb">登录</a></li>
                            <li><a href="Sign.aspx" runat="server" id="SignUpLb">注册</a></li>
                            <li><asp:LinkButton runat="server" ID="SignOutLb" OnClick="SignOutLb_Click">注销</asp:LinkButton></li>
                        </ul>
                    </div>
                </div>
                <a href="#">文章</a>
            </div>
        </div>

        <asp:ListView ID="ListArticle" runat="server">
            <LayoutTemplate>
                <div class="article-list">
                    <div class="container">
                        <div runat="server" id="ItemPlaceHolder"></div>
                    </div>
                </div>
            </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div runat="server" class='<%# "article-" + Eval("ArticleId") %>'>
                    <div class="author">
                        <h4>
                            <a href="#"><%# Eval("Username") %></a>
                        </h4>
                    </div>
                    <div class="title">
                        <h4>
                            <a href='<%# "ArticleDetail.aspx?articleId=" + Eval("ArticleId") %>'><%# Eval("Title") %></a>
                        </h4>
                    </div>
                    <div class="date">
                        <h4><%# Eval("CreateTime", "{0:yyyy-MM-dd}") %></h4>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
<script src="script/main.js"></script>
