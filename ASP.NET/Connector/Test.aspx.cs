using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DbKitX;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // ConnecterFactory cf = new ConnecterFactory();

        Connector connector = ConnecterFactory.GetConnector("MSSQL");

        try
        {
            connector.Connect("TestDB");

            Response.Write("OK");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

        
    }
}