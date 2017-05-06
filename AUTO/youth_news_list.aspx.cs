using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;

namespace AUTO
{
    public partial class youth_news_list : System.Web.UI.Page
    {
        YouthNewsBLL news_bll = new YouthNewsBLL();
        YouthNewsColBLL news_col_bll = new YouthNewsColBLL();

        public String news_col_name = String.Empty;
        public int news_col_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                news_col_id = int.Parse(Request.QueryString["news_col_id"].ToString());
                ViewState["news_col_id"] = news_col_id;
                bindCeBian();
                bindNews();
                bindNewsCol();
            }
        }

        protected void bindNews()
        {
            if (pagerList.CurrentPageIndex == 1)
            {
                rpt_news_list.DataSource = news_bll.GetList(pagerList.PageSize, "news_father_id=" + news_col_id + " and is_check='Y'", " publish_time desc ");
                rpt_news_list.DataBind();
            }
            else
            {
                rpt_news_list.DataSource = news_bll.GetListByPage("news_father_id=" + news_col_id + " and is_check='Y'", " publish_time desc ", pagerList.StartRecordIndex, pagerList.EndRecordIndex);
                rpt_news_list.DataBind();
            }
            pagerList.RecordCount = news_bll.GetRecordCount("news_father_id=" + news_col_id + " and is_check='Y'");
            //switch (news_col_id)
            //{
            //    case 1://绑定新闻速递            
            //        break;
            //    case 2://绑定通知公告
            //        break;
            //    case 3://绑定基层团建
            //        break;
            //    case 4://绑定学生社团
            //        break;
            //    case 5://绑定学院动态
            //        break;
            //    case 6://绑定理工才俊
            //        break;
            //    case 7://绑定共青之声
            //        break;
            //    case 8://绑定校园在线
            //        break;
            //}
        }

        //绑定侧边栏
        protected void bindCeBian()
        {
            DataSet ds = news_bll.GetList(5, "  is_check='Y' and news_father_id= " + Convert.ToInt32(ViewState["news_col_id"].ToString()), " publish_time desc  ");
            rptCeBian.DataSource = ds;
            rptCeBian.DataBind();
        }

        protected void bindNewsCol()
        {
            DataSet ds_news_col = news_col_bll.GetNewsCol();
            news_col_name = ds_news_col.Tables[0].Rows[news_col_id - 1]["news_column_name"].ToString();
            ColumnNameFather.Text = news_col_name;
            lblTitle.InnerText = news_col_name;
        }

        //新闻标题过长，进行截取
        protected string CutString(string strToCut)
        {
            if (strToCut.Length > 40)
            {
                strToCut = strToCut.Substring(0, 39).ToString() + "...";
            }
            return strToCut;
        }

        //日期格式转换
        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }

        protected void pagerList_PageChanged(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                bindNews();
            }
        }
    }
}