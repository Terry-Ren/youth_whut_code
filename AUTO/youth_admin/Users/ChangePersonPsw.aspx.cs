using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;
using AUTO.Utility;

namespace AUTO.youth_admin.Users
{
    public partial class ChangePersonPsw : System.Web.UI.Page
    {
        YouthUsers user_model = new YouthUsers();
        YouthUsersBLL user_bll = new YouthUsersBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            int user_id = Convert.ToInt32(Session[Constant.adminID].ToString());
            int roleID = Convert.ToInt32(Session[Constant.roleID].ToString());
            user_model = user_bll.GetUserById(user_id);
            if (MyUtil.MD5(txtOldPsw.Text) != user_model.User_pwd)
            {
                lblInfo.Text = "原密码错误";
                lblInfo.Visible = true;
                return;
            }
            if (txtNewPsw.Text.Trim() != txtNewPsw2.Text.Trim())
            {
                lblInfo.Text = "两次密码不一致！";
                lblInfo.Visible = true;
                return;
            }

            string new_user_pwd = MyUtil.MD5(txtNewPsw.Text.Trim());
            user_model.User_pwd = new_user_pwd;
            user_model.User_id = user_id;
            if (user_bll.ResetPwd(user_model))
            {
                //修改密码成功
                MyUtil.ShowMessage(this.Page, "成功修改登录密码");
            }
        }
    }
}