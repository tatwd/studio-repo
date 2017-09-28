<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Timer.aspx.cs" Inherits="Ex2_Timer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Scripts/jquery-3.2.1.min.js"></script>
    <script>
        function refresh() {
            var date = new Date();

            // 全部信息 toString() toLocaleString()

            // $('#date').text(date.toString());     

            // 日期信息 toDateString() toLocaleDateString()

            // $('#date').text(date.toDateString());

            // 时间信息 toTimeString() toLocaleTimeString()

            $('#date').text(date.toTimeString());

            setTimeout('refresh()', 1000); // 让 refresh() 自身再次调用 setTimeout()
        }
    </script>
</head>
<body onload="refresh()">
    <form id="form1" runat="server">
    <div id="date">
    
    </div>
    </form>
</body>
</html>
