using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AUTO
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //AUTO.BLL.News newsBll = new BLL.News();

            ////绑定新闻
            ////rptNews.DataSource = newsBll.GetList(7, "ColumnId=32", "PublishTime desc");
            //rptNews.DataSource = newsBll.GetList(7, "NewsType=0", "Flag desc,PublishTime desc");
            //rptNews.DataBind();

            ////绑定通知
            //rptTongzhi.DataSource = newsBll.GetList(7, "NewsType=1", "Flag desc,PublishTime desc");
            //rptTongzhi.DataBind();

            ////绑定图片新闻
            //rptImageNews.DataSource = newsBll.GetList(4, "IsPhotoNews=1", "Flag desc,PublishTime desc");
            //rptImageNews.DataBind();
        }

        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }

        protected string CutString(string strToCut)
        {
            if (strToCut.Length > 37)
            {
                return strToCut.Substring(0, 36) + "...";
            }
            else
            {
                return strToCut;
            }
        }
    }
}