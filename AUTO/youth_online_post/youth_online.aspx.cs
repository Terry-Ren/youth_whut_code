using System;
using System.Data;
using AUTO.BLL;
using AUTO.Model;
using AUTO.Utility;

namespace AUTO.youth_online_post
{
    public partial class youth_online : System.Web.UI.Page
    {
        YouthAcademicBLL aca_bll = new YouthAcademicBLL();
        YouthNews news_model = new YouthNews();
        YouthNewsBLL news_bll = new YouthNewsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindSource();
            }

            //启动监听
            FSWatcher fsw = new FSWatcher();

        }

        //绑定新闻来源——院系
        protected void bindSource()
        {
            DataSet ds = aca_bll.GetAcademic();
            DataTable dtSource = ds.Tables[0];

            DataRow newRow = dtSource.NewRow();
            newRow["academic_id"] = "-1";
            newRow["academic_name"] = "请选择来源";
            dtSource.Rows.InsertAt(newRow, 0);

            this.tg_ly.DataValueField = "academic_id";
            this.tg_ly.DataTextField = "academic_name";
            this.tg_ly.DataSource = dtSource;
            this.tg_ly.DataBind();
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!txt_Check.Text.Equals(Session[Constant.CheckCode].ToString()))
            {
                //验证码有误
                MyUtil.ShowMessage(this.Page, "验证码错误");
                return;
            }

            news_model.News_title = tg_bt.Text.ToString();
            news_model.News_content = txt_content.Text.ToString();
            // "记者在线","基层团建","学生组织"; 
            news_model.News_father_id = Convert.ToInt32(ddl_news_type.SelectedValue.ToString());
            news_model.Publisher = tg_zz.Text.ToString();
            news_model.Publisher_phone = txt_phone.Text.ToString();
            news_model.Publisher_mail = tg_yx.Text.ToString();
            news_model.Publish_time = DateTime.Now;
            news_model.Click_times = 0;

            //根据选择的投稿版块，决定最终新闻来源
            if (ddl_news_type.SelectedValue.ToString().Equals("3"))
            {
                news_model.News_source = Convert.ToInt32(tg_ly.SelectedValue.ToString());
            }
            else if (ddl_news_type.SelectedValue.ToString().Equals("4") || ddl_news_type.SelectedValue.ToString().Equals("8"))
            {
                news_model.News_source = Convert.ToInt32(tg_ly.SelectedValue.ToString());
            }

            news_model.Last_update = tg_zz.Text.ToString();
            news_model.Last_update_time = DateTime.Now;
            news_model.Is_check = "N";
            news_model.Checker = "";
            news_model.Check_time = DateTime.Now;
            news_model.Rechecker = "";
            news_model.Recheck_time = DateTime.Now;
            if (news_bll.AddYouthNews(news_model))
            {
                //添加成功
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "youth_online.aspx");
            }
            else
            {
                //添加失败，清空
                MyUtil.ShowMessage(this.Page, "添加失败");
            }
        }

        protected void ddl_news_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_news_type.SelectedValue.ToString().Equals("3"))
            {
                tg_ly.Enabled = true;
            }
            else if (ddl_news_type.SelectedValue.ToString().Equals("4") || ddl_news_type.SelectedValue.ToString().Equals("8"))
            {
                tg_ly.Enabled = true;
            }
        }

    }
}