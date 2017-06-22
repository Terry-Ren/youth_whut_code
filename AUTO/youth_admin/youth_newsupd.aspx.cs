using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;
using System.Data;
using AUTO.Utility;

namespace AUTO.youth_admin
{

    public partial class youth_newsupd : System.Web.UI.Page
    {
        YouthAcademicBLL aca_bll = new YouthAcademicBLL();
        YouthNews news_model = new YouthNews();
        YouthNewsBLL news_bll = new YouthNewsBLL();
        YouthNewsColBLL news_col_bll = new YouthNewsColBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int news_id = Convert.ToInt32(Request.QueryString["news_id"].ToString());
                ViewState["news_id"] = news_id;
                bindSorce();
                bindNewsCol();
                bindData(news_id);
            }
        }

        protected void bindData(int news_id)
        {
            news_model = news_bll.GetYouthNews(news_id);
            txtTitle.Text = news_model.News_title;
            txt_clickTimes.Text = news_model.Click_times.ToString();
            txt_content.Text = news_model.News_content;
            txt_revise.Text = news_model.News_revise;
            txt_publisher.Text = news_model.Publisher;
            txt_publish_time.Text = news_model.Publish_time.ToString("yyyy-MM-dd");
            txt_phone.Text = news_model.Publisher_phone;
            txt_email.Text = news_model.Publisher_mail;
            ddl_source.Items.FindByValue(news_model.News_source.ToString()).Selected = true;
            ddl_news_col.Items.FindByValue(news_model.News_father_id.ToString()).Selected = true;

        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            int news_id = Convert.ToInt32(ViewState["news_id"].ToString());
            YouthNews originalModel = news_bll.GetYouthNews(news_id);

            news_model.News_id = news_id;
            news_model.News_title = txtTitle.Text.Trim().ToString();
            news_model.News_content = txt_content.Text;
            news_model.News_revise = txt_revise.Text;
            news_model.News_father_id = Convert.ToInt32(ddl_news_col.SelectedValue);
            news_model.Publisher = txt_publisher.Text.ToString();
            news_model.Publisher_phone = txt_phone.Text;
            news_model.Publisher_mail = txt_email.Text;
            news_model.Publish_time = Convert.ToDateTime(txt_publish_time.Text.ToString());
            news_model.Click_times = Convert.ToInt32(txt_clickTimes.Text.ToString());
            news_model.News_source = Convert.ToInt32(ddl_source.SelectedValue.ToString());
            news_model.Last_update = Session[Constant.adminName].ToString();
            news_model.Last_update_time = DateTime.Now;
            news_model.First_check = originalModel.First_check;
            news_model.Is_check = originalModel.Is_check;
            news_model.Checker = "";
            news_model.Check_time = originalModel.Check_time;
            news_model.Rechecker = originalModel.Rechecker;
            news_model.Recheck_time = originalModel.Recheck_time;
            news_model.Is_photoNews = originalModel.Is_photoNews;
            news_model.Photo_url = originalModel.Photo_url;
            if (news_bll.UpdYouthNews(news_model))
            {
                aca_bll.ReUpdateRank(originalModel.News_source);
                aca_bll.UpdateRank(news_model.News_source);
                //编辑成功
                MyUtil.ShowMessageRedirect(this.Page, "修改成功", "youth_newslist.aspx");
            }
            else
            {
                //编辑失败
                MyUtil.ShowMessage(this.Page, "修改失败");
            }
        }

        protected void bindSorce()
        {
            DataSet ds = aca_bll.GetAcademic();
            ddl_source.DataValueField = "academic_id";
            ddl_source.DataTextField = "academic_name";
            ddl_source.DataSource = ds;
            ddl_source.DataBind();
            this.ddl_source.Items.Insert(0, new ListItem("", "0"));
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
                case 3://高级管理员
                    //ds = bll.GetNewsColList(" news_column_id >5 ");
                    ds = bll.GetNewsColList("");
                    break;
                case 4://学院账号
                    ds = bll.GetNewsColList(" news_column_id >2 and news_column_id<6 ");
                    break;
            }
            ddl_news_col.DataValueField = "news_column_id";
            ddl_news_col.DataTextField = "news_column_name";
            ddl_news_col.DataSource = ds;
            ddl_news_col.DataBind();
            ddl_news_col.Items.Insert(0, new ListItem("", "0"));
        }
    }
}