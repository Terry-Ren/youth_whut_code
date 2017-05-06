using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AUTO.BLL;
using AUTO.Model;
using AUTO.Utility;

namespace AUTO.youth_admin.Users
{
    public partial class youth_UserAdd : System.Web.UI.Page
    {
        YouthUsers user_model = new YouthUsers();
        YouthUsersBLL user_bll = new YouthUsersBLL();
        YouthRoleBLL role_bll = new YouthRoleBLL();
        YouthDepBLL dep_bll = new YouthDepBLL();
        YouthAcademicBLL aca_bll = new YouthAcademicBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(youth_UserAdd));
            if (!IsPostBack)
            {
                bindRole();
                bindDep();
                bindAcademic();
            }
        }

        //绑定用户类型
        protected void bindRole()
        {
            //查询条件确保层级添加用户
            DataSet ds = role_bll.GetList(" role_id >" + Convert.ToInt32(Session[Constant.roleID].ToString()));
            ddl_role.DataValueField = "role_id";
            ddl_role.DataTextField = "role_name";
            ddl_role.DataSource = ds;
            ddl_role.DataBind();
            ddl_role.Items.Insert(0, new ListItem("", "0"));
        }
        //绑定部门列表
        protected void bindDep()
        {
            DataSet ds = dep_bll.GetDepList();
            ddl_dep.DataValueField = "dep_id";
            ddl_dep.DataTextField = "dep_name";
            ddl_dep.DataSource = ds;
            ddl_dep.DataBind();
            ddl_dep.Items.Insert(0, new ListItem("", "0"));
        }

        //绑定学院列表
        protected void bindAcademic()
        {
            DataSet ds = aca_bll.GetAcademic();
            ddl_academic.DataValueField = "academic_id";
            ddl_academic.DataTextField = "academic_name";
            ddl_academic.DataSource = ds;
            ddl_academic.DataBind();
            ddl_academic.Items.Insert(0, new ListItem("", "0"));
        }

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            //确保添加用户的唯一性
            YouthUsersBLL bll = new YouthUsersBLL();
            string user_name = txt_userName.Text.ToString();
            bool i = bll.IsExits(user_name);
            if (i)
            {
                Response.Write("<script>alert('用户名已存在，请重新输入')</script>");
                return;
            }

            else
            {
                YouthInitialPwdBLL ip_bll = new YouthInitialPwdBLL();
                user_model.User_name = txt_userName.Text.ToString();
                user_model.User_pwd = MyUtil.MD5(ip_bll.GetInitialPwd());
                user_model.Role_id = Convert.ToInt32(ddl_role.SelectedValue.ToString());
                user_model.True_name = txt_trueName.Text.ToString();
                user_model.User_sex = ddl_sex.SelectedItem.Text;
                user_model.User_dep = Convert.ToInt32(ddl_dep.SelectedValue.ToString());
                user_model.User_academic_id = Convert.ToInt32(ddl_academic.SelectedValue.ToString());
                if (ddl_status.SelectedItem.Text.Trim().Equals("正常"))
                {
                    user_model.User_status = "Y";
                }
                else
                {
                    user_model.User_status = "N";
                }
                user_model.User_phone = txt_phone.Text;
                user_model.User_email = txt_email.Text;
                user_model.User_points = Convert.ToInt32(txt_points.Text.ToString());
                user_model.User_address = txt_address.Text;
                if (user_bll.AddUsers(user_model))
                {
                    //添加成功
                    MyUtil.ShowMessageRedirect(this.Page, "添加成功", "youth_UserList.aspx");
                }
                else
                {
                    //添加失败，清空
                    MyUtil.ShowMessage(this.Page, "添加失败");
                }
            }
        }

        [Ajax.AjaxMethod]
        public string IsExits(string user_name)
        {
            string result = "";
            YouthUsersBLL bll = new YouthUsersBLL();
            bool i = bll.IsExits(user_name);
            if (i)
            {
                result = "用户名已存在，请重新添加";
            }
            else
            {
                result = "";
            }
            return result;
        }
    }
}