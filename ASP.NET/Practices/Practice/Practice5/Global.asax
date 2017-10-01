<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // 在应用程序启动时运行的代码

        Application["online"] = 0; // 初始化在线人数为0
    }

    void Application_End(object sender, EventArgs e)
    {
        //  在应用程序关闭时运行的代码

    }

    void Application_Error(object sender, EventArgs e)
    {
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e)
    {
        // 在新会话启动时运行的代码

        Session["loginTime"] = DateTime.Now.ToString(); // 登录时间
        Session["ipAddress"] = Request.ServerVariables["REMOTE_ADDR"]; // IP地址

        Application.Lock();
        Application["online"] = (int)Application["online"] + 1;  // 统计在线人数
        Application.UnLock();
    }

    void Session_End(object sender, EventArgs e)
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
        // 或 SQLServer，则不引发该事件。

        Application["online"] = (int)Application["online"] - 1;
    }

</script>
