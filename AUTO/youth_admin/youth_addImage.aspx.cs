using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;
using AUTO.Utility;

namespace AUTO.youth_admin
{
    public partial class youth_addImage : System.Web.UI.Page
    {
        YouthNews news_model = new YouthNews();
        YouthNewsBLL news_bll = new YouthNewsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int news_id = Convert.ToInt32(Request.QueryString["news_id"].ToString());
                ViewState["news_id"] = news_id;
                txtTitle.Text = GetTitle(news_id);
            }
        }

        //得到新闻标题
        protected string GetTitle(int news_id)
        {
            news_model = news_bll.GetYouthNews(news_id);
            return news_model.News_title;
        }

        //添加图片
        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            if (fupImage.HasFile)
            {
                string fileName = fupImage.FileName;
                string ext = fileName.Substring(fileName.LastIndexOf('.'));
                string url = "upload/HomeImg/" + DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateSixNum() + ext;
                fupImage.SaveAs(Server.MapPath(url));
                news_model.Photo_url = url;
                news_model.Is_photoNews = "Y";
            }
            news_model.Last_update = Session[Constant.adminName].ToString();
            news_model.Last_update_time = DateTime.Now;
            news_model.News_id = Convert.ToInt32(ViewState["news_id"].ToString());
            if (news_bll.updNewsImage(news_model))
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

        //产生6位随机数
        protected string GenerateSixNum()
        {
            Random rad = new Random();//实例化随机数产生器rad；
            int value = rad.Next(100000, 1000000);//用rad生成大于等于1000，小于等于9999的随机数；
            return value.ToString();
        }
    }
}