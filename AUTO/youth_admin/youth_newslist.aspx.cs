using System;
using System.Text;
using System.Web.UI.WebControls;
using AUTO.Utility;
using System.Data;
using AUTO.Model;

namespace AUTO.youth_admin
{
    public partial class youth_newslist : BasePage
    {
        private AUTO.BLL.YouthNewsBLL news_bll = new BLL.YouthNewsBLL();

        private AUTO.BLL.YouthAcademicBLL aca_bll = new BLL.YouthAcademicBLL();

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
                string operate_name = Session[Constant.adminName].ToString();
                ViewState["operate_name"] = operate_name;
                int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
                ViewState["role_id"] = role_id;

                bindNewsCol();
                bindData();

            }
        }

        protected void bindData()
        {
            int role_id = Convert.ToInt32(ViewState["role_id"].ToString());
            switch (role_id)
            {
                case 3://内部编辑——包括理工才俊、共青之声和校园在线
                    pageTotal = news_bll.GetRecordCount(" 1=1 and news_father_id>2  " + GetWhereSql());
                    DataSet ds_editor = news_bll.GetListByPage(" 1=1 and news_father_id>2   " + GetWhereSql(), pageSize, pageIndex, " convert(varchar,publish_time,120) desc ");
                    for (int i = 0; i < ds_editor.Tables[0].Rows.Count; i++)
                    {
                        string first_check = ds_editor.Tables[0].Rows[i]["first_check"].ToString();
                        if (String.IsNullOrEmpty(first_check) || first_check.Trim().Equals("N"))
                        {
                            ds_editor.Tables[0].Rows[i]["first_check"] = "未审核";
                        }
                        else
                        {
                            ds_editor.Tables[0].Rows[i]["first_check"] = "已审核";
                        }

                        string is_check = ds_editor.Tables[0].Rows[i]["is_check"].ToString();
                        if (String.IsNullOrEmpty(is_check) || is_check.Trim().Equals("N"))
                        {
                            ds_editor.Tables[0].Rows[i]["is_check"] = "未审核";
                        }
                        else
                        {
                            ds_editor.Tables[0].Rows[i]["is_check"] = "已审核";
                        }
                    }
                    gvwData.DataSource = ds_editor;
                    gvwData.DataKeyNames = new String[] { "news_id" };
                    gvwData.DataBind();
                    break;
                case 4://学院账号——包括本学院的基层团建、学生社团、学院动态
                    pageTotal = news_bll.GetRecordCount(" 1=1 and news_father_id>2 and news_father_id<6 and news_source=" + Convert.ToInt32(Session[Constant.AcademicID]) + " " + GetWhereSql());
                    DataSet ds_academic = news_bll.GetListByPage(" 1=1 and news_father_id>2 and news_father_id<6 and news_source=" + Convert.ToInt32(Session[Constant.AcademicID]) + " " + GetWhereSql(), pageSize, pageIndex, "publish_time desc ");
                    for (int i = 0; i < ds_academic.Tables[0].Rows.Count; i++)
                    {
                        string first_check = ds_academic.Tables[0].Rows[i]["first_check"].ToString();
                        if (String.IsNullOrEmpty(first_check) || first_check.Trim().Equals("N"))
                        {
                            ds_academic.Tables[0].Rows[i]["first_check"] = "未审核";
                        }
                        else
                        {
                            ds_academic.Tables[0].Rows[i]["first_check"] = "已审核";
                        }

                        string is_check = ds_academic.Tables[0].Rows[i]["is_check"].ToString();
                        if (String.IsNullOrEmpty(is_check) || is_check.Trim().Equals("N"))
                        {
                            ds_academic.Tables[0].Rows[i]["is_check"] = "未审核";
                        }
                        else
                        {
                            ds_academic.Tables[0].Rows[i]["is_check"] = "已审核";
                        }
                    }
                    gvwData.DataSource = ds_academic;
                    gvwData.DataKeyNames = new String[] { "news_id" };
                    gvwData.DataBind();
                    break;
                default:
                    //站长和超级管理员默认读取所有新闻
                    pageTotal = news_bll.GetRecordCount(" 1=1 " + GetWhereSql());
                    DataSet ds = news_bll.GetListByPage(" 1=1 and first_check='Y' " + GetWhereSql(), pageSize, pageIndex, "publish_time desc ");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string first_check = ds.Tables[0].Rows[i]["first_check"].ToString();
                        if (String.IsNullOrEmpty(first_check) || first_check.Trim().Equals("N"))
                        {
                            ds.Tables[0].Rows[i]["first_check"] = "未审核";
                        }
                        else
                        {
                            ds.Tables[0].Rows[i]["first_check"] = "已审核";
                        }

                        string is_check = ds.Tables[0].Rows[i]["is_check"].ToString();
                        if (String.IsNullOrEmpty(is_check) || is_check.Trim().Equals("N"))
                        {
                            ds.Tables[0].Rows[i]["is_check"] = "未审核";
                        }
                        else
                        {
                            ds.Tables[0].Rows[i]["is_check"] = "已审核";
                        }
                    }
                    gvwData.DataSource = ds;
                    gvwData.DataKeyNames = new String[] { "news_id" };
                    gvwData.DataBind();
                    break;
            }
        }

        protected void bindNewsCol()
        {
            int role_id = Convert.ToInt32(ViewState["role_id"].ToString());
            AUTO.BLL.YouthNewsColBLL bll = new BLL.YouthNewsColBLL();
            DataSet ds = null;
            switch (role_id)
            {
                case 1://站长
                    ds = bll.GetNewsColList("");
                    break;
                case 2://超级管理员
                    ds = bll.GetNewsColList("");
                    break;
                case 3://内部编辑
                    //ds = bll.GetNewsColList(" news_column_id >2 and news_column_id<8 ");
                    ds = bll.GetNewsColList("  news_column_id >2  ");
                    break;
                case 4://学院账号
                    ds = bll.GetNewsColList(" news_column_id >2 and news_column_id<6  ");
                    //ds = bll.GetNewsColList(" news_column_id >2 and news_column_id<6 ");
                    break;
            }
            ddlNewsCol.DataValueField = "news_column_id";
            ddlNewsCol.DataTextField = "news_column_name";
            ddlNewsCol.DataSource = ds;
            ddlNewsCol.DataBind();
            ddlNewsCol.Items.Insert(0, new ListItem("", "0"));
        }

        /// <summary>
        /// 获取筛选条件
        /// </summary>
        /// <returns></returns>
        private string GetWhereSql()
        {
            StringBuilder sb = new StringBuilder();
            if (txtWord.Text.Trim() != "")
            {
                sb.Append(" and news_title like '% " + txtWord.Text.Trim() + "%' ");
            }
            if (ddlCheck.SelectedValue.Equals("1"))
            {
                sb.Append(" and is_check='Y'");
            }
            else if (ddlCheck.SelectedValue.Equals("0"))
            {
                sb.Append(" and is_check='N' ");
            }
            if (!ddlNewsCol.SelectedValue.ToString().Equals("0"))
            {
                sb.Append(" and news_father_id= " + Convert.ToInt32(ddlNewsCol.SelectedValue.ToString()));
            }
            if (sb.Length == 0)
            {
                sb.Append(" and 1=1");
            }
            return sb.ToString();
        }

        // 分页事件
        protected void btnHide_Click(object sender, EventArgs e)
        {
            bindData();
        }

        //日期格式转换
        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }


        //搜索新闻
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            bindData();
        }

        //审核新闻
        protected void lbtnCheck_Click(object sender, EventArgs e)
        {
            int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
            if (role_id == 4 || role_id == 3)
            {
                String message = "对不起，您没有相应权限";
                MyUtil.ShowMessage(this.Page, message);
                return;
            }
            else
            {
                int success = 0;
                for (int i = 0; i < gvwData.Rows.Count; i++)
                {
                    CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                    if (cbx.Checked == true)
                    {
                        int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                        news_bll.CheckNews(id, ViewState["operate_name"].ToString());
                        int source_id = news_bll.GetSourceById(id);
                        aca_bll.UpdateRank(source_id);
                        success++;
                    }
                }
                bindData();
                String message = "成功审核" + success + "条记录！";
                MyUtil.ShowMessage(this, message);
            }
        }

        //取消审核——反审核新闻
        protected void lbtnReCheck_Click(object sender, EventArgs e)
        {
            int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
            if (role_id == 4 || role_id == 3)
            {
                String message = "对不起，您没有相应权限";
                MyUtil.ShowMessage(this.Page, message);
                return;
            }
            else
            {
                int success = 0;
                for (int i = 0; i < gvwData.Rows.Count; i++)
                {
                    CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                    if (cbx.Checked == true)
                    {
                        int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                        news_bll.ReCheckNews(id, ViewState["operate_name"].ToString());
                        int source_id = news_bll.GetSourceById(id);
                        aca_bll.ReUpdateRank(source_id);
                        success++;
                    }
                }
                bindData();
                String message = "成功取消审核" + success + "条记录！";
                MyUtil.ShowMessage(this, message);
            }
        }

        //初审
        protected void lbtnFirstCheck_Click(object sender, EventArgs e)
        {
            int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
            if (role_id != 3)
            {
                String message = "对不起，您没有相应权限";
                MyUtil.ShowMessage(this.Page, message);
                return;
            }
            else
            {
                for (int i = 0; i < gvwData.Rows.Count; i++)
                {
                    CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                    if (cbx.Checked == true)
                    {
                        int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                        news_bll.FirstCheckNews(id, ViewState["operate_name"].ToString());
                    }
                }
                bindData();
                String message = "成功初审！";
                MyUtil.ShowMessage(this, message);
            }
        }

        //退稿
        protected void lbtnReject_Click(object sender, EventArgs e)
        {
            int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
            if (role_id ==3)
            {
                String message = "对不起，您没有相应权限";
                MyUtil.ShowMessage(this.Page, message);
                return;
            }
            else
            {
                for (int i = 0; i < gvwData.Rows.Count; i++)
                {
                    CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                    if (cbx.Checked == true)
                    {
                        int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                        news_bll.RejectNews(id, ViewState["operate_name"].ToString());
                    }
                }
                bindData();
                String message = "成功退稿！";
                MyUtil.ShowMessage(this, message);
            }
        }

        //删除新闻
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
            if (role_id == 4)
            {
                String message = "对不起，您没有相应权限";
                MyUtil.ShowMessage(this.Page, message);
                return;
            }
            else
            {
                int success = 0;
                for (int i = 0; i < gvwData.Rows.Count; i++)
                {
                    CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                    if (cbx.Checked == true)
                    {
                        int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                        int source_id = news_bll.GetSourceById(id);
                        aca_bll.ReUpdateRank(source_id);
                        news_bll.DeleteNews(id);
                        success++;
                    }
                }
                bindData();
                String message = "成功删除" + success + "条记录！";
                MyUtil.ShowMessage(this, message);
            }
        }

        //添加新闻
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("youth_newsadd.aspx");
        }

        //编辑新闻
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
            if (role_id == 4)
            {
                String message = "对不起，您没有相应权限";
                MyUtil.ShowMessage(this.Page, message);
                return;
            }
            else
            {
                LinkButton lbtn = (LinkButton)sender;
                int news_id = Convert.ToInt32(lbtn.CommandArgument);
                Response.Redirect("youth_newsupd.aspx?news_id=" + news_id);
            }
        }

        //决定是否在首页显示图片
        protected void lbtnShow_Click(object sender, EventArgs e)
        {
            int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
            if (role_id == 4)
            {
                String message = "对不起，您没有相应权限";
                MyUtil.ShowMessage(this.Page, message);
                return;
            }
            else
            {
                LinkButton lbtn = (LinkButton)sender;
                int news_id = Convert.ToInt32(lbtn.CommandArgument);
                YouthNews news_model = news_bll.GetYouthNews(news_id);
                if (news_model.Is_photoNews.Trim().Equals("N") || String.IsNullOrEmpty(news_model.Is_photoNews))
                {
                    //显示
                    Response.Redirect("youth_addImage.aspx?news_id=" + news_id);
                }
                else
                {
                    //取消显示
                    news_model.Photo_url = "";
                    news_model.Is_photoNews = "N";
                    news_model.Last_update = Session[Constant.adminName].ToString();
                    news_model.Last_update_time = DateTime.Today;
                    news_model.News_id = news_id;
                    if (news_bll.updNewsImage(news_model))
                    {
                        //成功
                        MyUtil.ShowMessage(this.Page, "取消首页大图显示");
                        bindData();
                    }
                }
            }
        }

        //显示——取消图片
        protected string GetDinText(string Flag)
        {
            if (Flag.Trim().Equals("Y"))
            {
                return "取消图片";
            }
            else
            {
                return "显示图片";
            }
        }

        //得到小图标
        protected string GetDinImage(string Flag)
        {
            if (Flag.Trim().Equals("Y"))
            {
                return "plain:true,iconCls:'icon-cancel'";
            }
            else
            {
                return "plain:true,iconCls:'icon-redo'";
            }
        }

        //新闻标题过长，进行截取
        protected string CutString(string strToCut)
        {
            if (strToCut.Length > 20)
            {
                strToCut = strToCut.Substring(0, 19).ToString() + "...";
            }
            return strToCut;
        }
    }
}