using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AUTO.BLL;
using AUTO.Model;

namespace AUTO.youth_manage
{
    public partial class youth_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindRole();
            }
        }

        protected void bindRole()
        {
            AUTO.BLL.YouthRoleBLL role_bll = new BLL.YouthRoleBLL();
            DataSet ds = role_bll.GetList("");
            this.ddlRole.DataTextField = "role_name";
            this.ddlRole.DataValueField = "role_id";
            this.ddlRole.DataSource = ds;
            this.ddlRole.DataBind();
            this.ddlRole.Items.Insert(0, new ListItem("", ""));
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string user_name = txbAdminName.Text.Trim().ToString();
            string pwd = txbPassword.Text.Trim().ToString();
            //int Role_id = Convert.ToInt32(ddlRole.SelectedValue);
            int Role_id = Convert.ToInt32(ddlRole.SelectedItem.Value);
            string check_code = txbCheck.Text.ToString().ToLower();
            
              if (!check_code.Equals(Session[Constant.CheckCode].ToString()))
            {
                lblTip.Text = "验证码错误";
                lblTip.Visible = true;
                txbCheck.Text = "";
                return;
            }
            
            AUTO.BLL.YouthUsersBLL user_bll = new BLL.YouthUsersBLL();
            bool i = user_bll.check_user(user_name, pwd, Role_id);
            if (i)
            //if(true)//测试专用
            {
                //登录成功
                //得到登录成功用户的id和角色id
                int user_id = user_bll.GetUserIdByName(user_name, pwd);

                YouthUsers model = new YouthUsers();
                model = user_bll.GetUserById(user_id);


                Session[Constant.adminID] = user_id;
                //Session[Constant.adminID] = "7";
                Session[Constant.roleID] = Role_id;
                Session[Constant.adminName] = user_name;
                //Session[Constant.adminName] = "测试开发专用";
                Session[Constant.AcademicID] = model.User_academic_id;
                //Session[Constant.AcademicID] = "测试专用";
                //根据Role_id跳转到不同页面
                switch (Role_id)
                {
                    case 1://站长
                        Response.Redirect("../youth_admin/Menu_StationMaster.aspx");
                        break;
                    case 2://超级管理员
                        Response.Redirect("../youth_admin/Menu_Super.aspx");
                        break;
                    case 3://高级管理员、内部编辑
                        Response.Redirect("../youth_admin/Menu_Editor.aspx");
                        break;
                    case  4://高级管理员、内部编辑
                        Response.Redirect("../youth_admin/Menu_Editor.aspx");
                        break;
                    case 5://学院账号
                        Response.Redirect("../youth_admin/Menu_Academic.aspx");
                        break;
                    case 6://团委书记
                        Response.Redirect("../youth_admin/Menu_Shuji.aspx");
                        break;
                }
                Response.Write("<script>alert('成功！')</script>");
            }
            else
            {
                //登录失败
                Response.Write("<script>alert('账户密码错误或账户已被冻结，请联系管理员！');window.location='youth_login.aspx'</script>");
            }
        }
    }
}