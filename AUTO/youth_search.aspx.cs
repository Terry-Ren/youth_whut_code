using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AUTO.BLL;

namespace AUTO
{
    public partial class youth_search : System.Web.UI.Page
    {
        public string word = "";
        YouthNewsBLL news_bll = new YouthNewsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["txtword"] != null)
                {
                    word = Request["txtword"].ToString();
                    Session["word"] = word;
                }
                else
                {
                    word = Session["word"].ToString();
                }
                bindSearchList();
            }
        }

        protected void bindSearchList()
        {
            //根据关键词进行搜索
            if (pagerList.CurrentPageIndex == 1)
            {
                rpt_news_list.DataSource = news_bll.GetList(pagerList.PageSize, " is_check='Y'" + GetStrWhere(), "");
                rpt_news_list.DataBind();
            }
            else
            {
                rpt_news_list.DataSource = news_bll.GetListByPage(" is_check='Y'" + GetStrWhere(), "", pagerList.StartRecordIndex, pagerList.EndRecordIndex);
                rpt_news_list.DataBind();
            }
            pagerList.RecordCount = news_bll.GetRecordCount(" is_check='Y'" + GetStrWhere());
        }

        public string GetStrWhere()
        {
            StringBuilder str = new StringBuilder();
            if (word.Trim() != "")
            {
                str.Append(" and news_title like  '%" + word.Trim() + "%'  ");
                //str.Append(" or news_content like '%" + word.Trim() + "%' ");
                //str.Append(" or publisher like '%" + word.Trim() + "%' ");
            }
            else
            {
                str.Append(" and 1=1 ");
            }
            return str.ToString();
        }

        protected void pagerList_PageChanged(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                bindSearchList();
            }
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
    }
}