using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;
using AUTO.Model;
using AUTO.Utility;

namespace AUTO.youth_admin
{
    public partial class youth_newsadd : System.Web.UI.Page
    {
        YouthAcademicBLL aca_bll = new YouthAcademicBLL();
        YouthNews news_model = new YouthNews();
        YouthNewsBLL news_bll = new YouthNewsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //添加新闻
                string operate_name = Session[Constant.adminName].ToString();
                ViewState["operate_name"] = operate_name;
                bindSorce();
                bindNewsCol();
            }
            FSWatcher fsw = new FSWatcher();
        }

        protected void bindNewsCol()
        {
            int role_id = Convert.ToInt32(Session[Constant.roleID].ToString());
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
                case 3://高级管理员——内部编辑
                    //ds = bll.GetNewsColList(" news_column_id >5 and news_column_id<8 ");
                    ds = bll.GetNewsColList("  news_column_id >5  ");
                    break;
                case 4://学院账号
                    //ds = bll.GetNewsColList(" news_column_id >2 and news_column_id<6 ");
                    ds = bll.GetNewsColList(" news_column_id >2 and news_column_id<6  ");
                    break;
            }
            ddlNewsCol.DataValueField = "news_column_id";
            ddlNewsCol.DataTextField = "news_column_name";
            ddlNewsCol.DataSource = ds;
            ddlNewsCol.DataBind();
            ddlNewsCol.Items.Insert(0, new ListItem("", "0"));
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            news_model.News_title = txtTitle.Text.Trim().ToString();
            news_model.News_content = txt_content.Text;
            news_model.News_father_id = Convert.ToInt32(ddlNewsCol.SelectedValue);
            news_model.Publisher = txt_publisher.Text.ToString();
            news_model.Publisher_phone = txt_phone.Text;
            news_model.Publisher_mail = txt_email.Text;
            news_model.Publish_time = DateTime.Now;
            news_model.Click_times = 0;
            news_model.News_source = Convert.ToInt32(ddl_source.SelectedValue.ToString());
            news_model.Last_update = ViewState["operate_name"].ToString();
            news_model.Last_update_time = DateTime.Now;
            news_model.Is_check = "N";
            news_model.Checker = "";
            news_model.Check_time = DateTime.Now;
            news_model.Rechecker = "";
            news_model.Recheck_time = DateTime.Now;
            news_model.Is_photoNews = "N";
            news_model.Photo_url = "";
            if (news_bll.AddYouthNews(news_model))
            {
                //添加成功
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "youth_newslist.aspx");
            }
            else
            {
                //添加失败，清空
                MyUtil.ShowMessage(this.Page, "添加失败");
            }
        }

        protected void bindSorce()
        {
            DataSet ds = aca_bll.GetAcademic();
            ddl_source.DataValueField = "academic_id";
            ddl_source.DataTextField = "academic_name";
            ddl_source.DataSource = ds;
            ddl_source.DataBind();
        }

    }
}