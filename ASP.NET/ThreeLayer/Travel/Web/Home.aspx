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

        <!-- @Evan You(http://evanyou.me/) -->
        <canvas width="1366" height="675" style="position:absolute;top:0;z-index:-1;"></canvas>
        <script>
            document.addEventListener('touchmove', function (e) {
                e.preventDefault()
            })
            var c = document.getElementsByTagName('canvas')[0],
                x = c.getContext('2d'),
                pr = window.devicePixelRatio || 1,
                w = window.innerWidth,
                h = window.innerHeight,
                f = 90,
                q,
                m = Math,
                r = 0,
                u = m.PI*2,
                v = m.cos,
                z = m.random
            c.width = w*pr
            c.height = h*pr
            x.scale(pr, pr)
            x.globalAlpha = 0.6
            function i(){
                x.clearRect(0,0,w,h)
                q=[{x:0,y:h*.7+f},{x:0,y:h*.7-f}]
                while(q[1].x<w+f) d(q[0], q[1])
            }
            function d(i,j){   
                x.beginPath()
                x.moveTo(i.x, i.y)
                x.lineTo(j.x, j.y)
                var k = j.x + (z()*2-0.25)*f,
                    n = y(j.y)
                x.lineTo(k, n)
                x.closePath()
                r-=u/-50
                x.fillStyle = '#'+(v(r)*127+128<<16 | v(r+u/3)*127+128<<8 | v(r+u/3*2)*127+128).toString(16)
                x.fill()
                q[0] = q[1]
                q[1] = {x:k,y:n}
            }
            function y(p){
                var t = p + (z()*2-1.1)*f
                return (t>h||t<0) ? y(p) : t
            }
            document.onclick = i
            document.ontouchstart = i
            i()
        </script>

    </div>
    </form>
</body>
</html>
<script src="script/main.js"></script>
