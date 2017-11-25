<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleDetail.aspx.cs" Inherits="Web.ArticleDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Article Detail</title>
    <link href="style/main.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="logo">
            <a href="Home.aspx"><img src="assets/img/logo.png" alt="logo img"/></a>
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

        <div class="article-detail">
            <div class="container">
                <div class="title"><h2 runat="server" id="hTitle"></h2></div>
                <div class="author">
                    <h4 runat="server" id="hAuthor"></h4>
                </div>
                <div class="content">
                    <p runat="server" id="pContent"></p>
                </div>
            </div>
        </div>

        <div class="write-cmnt">
            <div class="container">
                <div class="rich-editor">
                    <asp:TextBox CssClass="edit-area" ID="CmntContent" runat="server" TextMode="MultiLine" placeholder="请输入文字（不得超过100个字）" disabled="true"></asp:TextBox>
                </div>
                <div class="submit-cmnt">
                    <asp:Button ID="SubmitCmnt" runat="server" Text="评论" OnClick="SubmitCmnt_Click" disabled="true"/>
                </div>
            </div>
        </div>

        <asp:ListView ID="ListCmnt" runat="server">
            <LayoutTemplate>
                <div class="comment">
                    <h3>热门评论</h3>
                    <div class="container">
                        <div runat="server" id="ItemPlaceHolder"></div>
                    </div>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class='<%# "comment-" + Eval("CommentId") %>'>
                    <div class="author"><h5><a href="#"><%# Eval("Username") %></a></h5></div>
                    <div class="content"><p><%# Eval("Contents") %></p></div>
                    <div class="meta"><span><%# Eval("CmntTime", "{0:yyyy-MM-dd HH:mm}") %></span></div>
                </div>
            </ItemTemplate>
        </asp:ListView>


        <div class="reply-container">
            <div class="container">
                <div class="tip-text">
                    <span runat="server" id="TipText">请先<a href="Sign.aspx">登录</a>，再回复！</span>
                    <span class="icon-cancel">X</span>
                </div>
                <div runat="server" id="ReplyMainBox" class="main-box">
                    <div class="header-box">
                        <span class="reply-who"></span>
                        <%--<span class="icon-cancel">x</span>--%>
                    </div>
                    <div class="rich-editor">
                        <asp:TextBox CssClass="edit-area" ID="ReplyContent" runat="server" TextMode="MultiLine" placeholder="请输入文字（不得超过100个字）"></asp:TextBox>
                    </div>
                    <div class="submit-reply">
                        <asp:Button ID="SubmitReply" runat="server" Text="回复"/>
                    </div>
                </div>
            </div>
        </div>

    </div>
    </form>
</body>
</html>
<script src="script/main.js"></script>
