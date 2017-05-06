using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUTO.youth_admin
{
    public partial class Menu_Academic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Constant.adminID] == null || Session[Constant.adminID].ToString() == "")
                {
                    Response.Redirect("../youth_manage/youth_login.aspx");
                }
                int user_id = Convert.ToInt32(Session[Constant.adminID].ToString());
                int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
                lblRealName.Text = Session[Constant.adminName].ToString();
                lblRole.Text = new AUTO.BLL.YouthRoleBLL().GetModel(role_id).Role_name;
                lblLoginName.Text = Session[Constant.adminName].ToString();
                lblLoginTime.Text = DateTime.Now.ToShortDateString();
                lblLoginIP.Text = HttpContext.Current.Request.UserHostAddress;
            }
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session[Constant.adminID].ToString()))
            {
                Session.Contents.Clear();
            }

            Response.Redirect("../youth_manage/youth_login.aspx");
        }
    }
}