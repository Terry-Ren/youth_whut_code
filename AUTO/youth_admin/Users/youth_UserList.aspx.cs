using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Utility;
using AUTO.BLL;
using System.Data;
using System.Text;
using AUTO.Model;

namespace AUTO.youth_admin.Users
{
    public partial class youth_UserList : BasePage
    {
        YouthUsersBLL user_bll = new YouthUsersBLL();
        YouthRoleBLL role_bll = new YouthRoleBLL();
        YouthDepBLL dep_bll = new YouthDepBLL();
        YouthAcademicBLL aca_bll = new YouthAcademicBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(hfPageIndex.Value))
            {
                pageIndex = Convert.ToInt32(hfPageIndex.Value);
            }
            if (!String.IsNullOrEmpty(hfPageSize.Value))
            {
                pageSize = Convert.ToInt32(hfPageSize.Value);
            }
            if (!IsPostBack)
            {
                bindRole();
                bindDep();
                bindAcademic();
                bindUsers();
            }
        }

        protected void bindUsers()
        {
            //根据登录角色，取得不同用户列表
            int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
            switch (role_id)
            {
                case 1://站长
                    pageTotal = user_bll.GetRecordCount(" 1=1 and role_id>" + Convert.ToInt32(Session[Constant.roleID].ToString()) + GetStrWhere());
                    DataSet ds = user_bll.GetListByPage(" 1=1 and role_id>" + Convert.ToInt32(Session[Constant.roleID].ToString()) + GetStrWhere(), pageSize, pageIndex, " Role_id asc");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string status = ds.Tables[0].Rows[i]["user_status"].ToString();
                            if (status.Trim().Equals("Y"))
                            {
                                ds.Tables[0].Rows[i]["user_status"] = "正常";
                            }
                            else
                            {
                                ds.Tables[0].Rows[i]["user_status"] = "冻结";
                            }
                        }
                    }
                    gvwData.DataSource = ds;
                    //gvwData.DataKeyNames = new String[] { "user_id " };
                    gvwData.DataBind();
                    break;
                case 2://超级管理员
                    pageTotal = user_bll.GetRecordCount(" 1=1 and role_id>" + Convert.ToInt32(Session[Constant.roleID].ToString()) + GetStrWhere());
                    DataSet ds_super = user_bll.GetListByPage(" 1=1 and role_id>" + Convert.ToInt32(Session[Constant.roleID].ToString()) + GetStrWhere(), pageSize, pageIndex, " Role_id asc");
                    if (ds_super.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_super.Tables[0].Rows.Count; i++)
                        {
                            string status = ds_super.Tables[0].Rows[i]["user_status"].ToString();
                            if (status.Trim().Equals("Y"))
                            {
                                ds_super.Tables[0].Rows[i]["user_status"] = "正常";
                            }
                            else
                            {
                                ds_super.Tables[0].Rows[i]["user_status"] = "冻结";
                            }
                        }
                    }
                    gvwData.DataSource = ds_super;
                    gvwData.DataBind();
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        //获取筛选条件
        public string GetStrWhere()
        {
            StringBuilder str = new StringBuilder();
            if (!String.IsNullOrEmpty(txtWord.Text.ToString()))
            {
                str.Append(" and user_name like '%" + txtWord.Text.Trim().ToString() + "%'");
            }
            if (!ddl_role.SelectedValue.Equals("0"))
            {
                str.Append(" and Role_id=" + int.Parse(ddl_role.SelectedValue));
            }
            if (!ddl_dep.SelectedValue.Equals("0"))
            {
                str.Append(" and user_dep_id=" + int.Parse(ddl_dep.SelectedValue));
            }
            if (!ddl_academic.SelectedValue.Equals("0"))
            {
                str.Append(" and user_academic_id=" + int.Parse(ddl_academic.SelectedValue));
            }
            if (str.Length == 0)
            {
                str.Append(" and 1=1 ");
            }
            return str.ToString();
        }

        //绑定用户类型
        protected void bindRole()
        {
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

        //根据role_id得到role_name
        protected string getRoleNameById(int role_id)
        {
            DataSet ds = role_bll.GetList(" role_id=" + role_id);
            string role_name = ds.Tables[0].Rows[0]["role_name"].ToString();
            return role_name;
        }

        //搜索
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            bindUsers();
        }

        //添加用户
        protected void addAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("youth_UserAdd.aspx");
        }

        //分页事件
        protected void btnHide_Click(object sender, EventArgs e)
        {
            bindUsers();
        }

        //删除用户
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            int success = 0;
            for (int i = 0; i < gvwData.Rows.Count; i++)
            {
                CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                if (cbx.Checked == true)
                {
                    int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    user_bll.DelUsers(id);
                    success++;
                }
            }
            bindUsers();
            String message = "成功删除" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }

        //重置密码
        protected void lbtnReset_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int user_id = Convert.ToInt32(lbtn.CommandArgument);
            YouthUsers model = new YouthUsers();
            model.User_pwd = MyUtil.MD5(new YouthInitialPwdBLL().GetInitialPwd());
            model.User_id = user_id;
            if (user_bll.ResetPwd(model))
            {
                MyUtil.ShowMessage(this.Page, "成功重置密码为:" + new YouthInitialPwdBLL().GetInitialPwd());
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "重置密码失败");
            }
        }

        //冻结与解冻账号
        protected void lbtnOper_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int user_id = Convert.ToInt32(lbtn.CommandArgument);
            AUTO.Model.YouthUsers model = new Model.YouthUsers();
            model = user_bll.GetUserById(user_id);
            if (model.User_status.Trim().ToString().Equals("Y"))
            {
                //冻结账号
                model.User_id = user_id;
                model.User_status = "N";
                if (user_bll.FrezzeUsers(model))
                {
                    //冻结成功
                    MyUtil.ShowMessage(this.Page, "成功冻结账号");
                    bindUsers();
                }
            }
            else
            {
                //解冻账号
                model.User_id = user_id;
                model.User_status = "Y";
                if (user_bll.FrezzeUsers(model))
                {
                    //解冻成功
                    MyUtil.ShowMessage(this.Page, "成功解冻账号");
                    bindUsers();
                }
            }
        }

        //冻结账号与解冻账号
        protected string GetDinText(string Flag)
        {
            if (Flag.Trim().Equals("正常"))
            {
                return "点击冻结";
            }
            else
            {
                return "点击解冻";
            }
        }

        //得到小图标
        protected string GetDinImage(string Flag)
        {
            if (Flag.Trim().Equals("正常"))
            {
                return "plain:true,iconCls:'icon-undo'";
            }
            else
            {
                return "plain:true,iconCls:'icon-reload'";
            }
        }
    }
}