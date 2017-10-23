<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sign In</title>
    <link href="css/sign-container.css" rel="stylesheet" />
</head>
<body>
    <form id="signForm" runat="server">
    <div>
        <h2>Hello Sign In Page!</h2>

        <div class="container">
            <div class="title-box">登录</div>
            
            <div class="input-box">
                
                <div class="name">
                    <asp:TextBox ID="nameBox" runat="server" placeholder="用户名"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="notNullName" CssClass="validator" runat="server" ControlToValidate="passwdBox" Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </div>
                
                <div class="passwd">
                    <asp:TextBox ID="passwdBox" runat="server" TextMode="Password" placeholder="密码（6~20位）"></asp:TextBox>
                    <!-- 密码验证 -->
                    <asp:RequiredFieldValidator ID="notNull" CssClass="validator" runat="server" ControlToValidate="passwdBox" Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="sign-btn">
                <asp:Button ID="signInBtn" runat="server" Text="提交" OnClick="signInBtn_Click"/>
            </div>
            <div class="tip">
                <a href="SignUp.aspx">还没注册？马上注册！</a>
            </div>
        </div>

        <div class="label">
             <asp:Label ID="tipLabel" runat="server"></asp:Label> 
        </div>
    </div>
    </form>
</body>
</html>
<script src="js/sign-validator.js"></script>
<script>
    (new FocusEvent('nameBox', 'validator')).addFocus(clicked);
    (new FocusEvent('emailBox', 'validator')).addFocus(clicked);
</script>
