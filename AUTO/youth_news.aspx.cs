using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using AUTO.Model;
using System.Data;

namespace AUTO
{
    public partial class youth_news : System.Web.UI.Page
    {
        public int news_col_id;
        public string news_col_name;
        YouthNews news_model = null;
        YouthNewsColumn news_col_model = new YouthNewsColumn();
        YouthNewsBLL news_bll = new YouthNewsBLL();
        YouthNewsColBLL news_col_bll = new YouthNewsColBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //int news_col_id = int.Parse(Request.QueryString["news_col_id"].ToString());
            int news_id = int.Parse(Request.QueryString["news_id"].ToString());
            ViewState["news_id"] = news_id;
            news_bll.AddReadCount(news_id);
            bindNews(news_id);
            news_col_id = news_model.News_father_id;
            bindNewsCol();
            bindNewsCeBian();
        }

        protected void bindNews(int news_id)
        {
            //根据新闻id得到实体
            news_model = news_bll.GetYouthNews(news_id);
            news_title.Text = news_model.News_title;
            PublishTime.Text = FormatTime(news_model.Publish_time);
            Publisher.Text = news_model.Publisher;
            Clicks.Text = news_model.Click_times.ToString();
            updater.Text = news_model.Last_update;
            checker.Text = news_model.Checker;
            news_content.InnerHtml = news_model.News_content;
        }

        //加载侧边栏名称
        private void bindNewsCol()
        {
            news_col_model = news_col_bll.GetListById(news_col_id);
            news_col_name = news_col_model.News_column_name;
        }

        //加载侧边栏数据
        protected void bindNewsCeBian()
        {
            DataSet ds = news_bll.GetList(5, " news_father_id= " + news_col_id, " publish_time desc  ");
            rptCeBian.DataSource = ds;
            rptCeBian.DataBind();
        }

        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }
    }
}