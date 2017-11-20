<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign.aspx.cs" Inherits="Web.Home1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sign Page</title>
    <link href="style/main.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="logo"><a href="Home.aspx"><img src="assets/img/logo.png" alt="logo img"/></a></div>

        <div class="sign-container">
            <div>
                <h4>Username</h4>
                <div class="input"><asp:TextBox ID="UsernameTb" runat="server" autofocus="autofocus"></asp:TextBox></div>

                <h4>Password</h4>
                <div class="input"><asp:TextBox ID="PasswordTb" runat="server" TextMode="Password"></asp:TextBox></div>

                <div class="sign-btn">
                    <p class="sign-in"><asp:Button ID="SignInBtn" runat="server" Text="SIGN IN" OnClick="SignInBtn_Click"/></p>
                    <p class="sign-up"><asp:Button ID="SignUpBtn" runat="server" Text="SIGN UP" OnClick="SignUpBtn_Click"/></p>
                </div>

                <p runat="server" id="display"></p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
