using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["cart"] == null | Session["cart"].ToString() == "")
            {
                lblMsg.Text      = "没有选购任何宠物！";
                btnClear.Enabled = false;
            }
            else
            {
                // 用数组列表存储每个宠物名

                #region 法一：利用IndexOf()和Substring()方法

                string petStr = Session["cart"].ToString();

                // 创建数组列表对象
                System.Collections.ArrayList pets = new System.Collections.ArrayList();

                int index = petStr.IndexOf(",");

                while (index != -1)
                {
                    string pet = petStr.Substring(0, index); // 取出一个宠物名

                    if (pet != "")
                    {
                        pets.Add(pet);

                        petStr = petStr.Substring(index + 1);

                        index = petStr.IndexOf(",");
                    }
                }

                #endregion

                #region 法二：利用Substring()和Split()方法

                //string petStr = Session["cart"].ToString();

                //// 创建数组列表对象
                //System.Collections.ArrayList pets = new System.Collections.ArrayList();

                //petStr = petStr.Substring(0, petStr.Length - 1); // 去除最后一个逗号

                //string[] arrPets = petStr.Split(','); // 按逗号分割字符串

                //foreach (var item in arrPets)
                //{
                //    // Response.Write(item + "==");
                //    pets.Add(item);
                //}

                #endregion



                lblMsg.Text = "购物车中现有宠物：";

                chklsPet.DataSource = pets; // 设置数据源

                chklsPet.DataBind(); // 显示数据
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["cart"]  = ""; // 清空cart
        lblMsg.Text      = "没有选购任何宠物！";
        chklsPet.Visible = false;
        btnClear.Enabled = false;
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx"); // 重定向会Default.aspx
    }
}