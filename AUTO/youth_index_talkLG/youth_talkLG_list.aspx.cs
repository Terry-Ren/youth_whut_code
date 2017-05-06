using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;

namespace AUTO.youth_index_talkLG
{
    public partial class youth_talkLG_list : System.Web.UI.Page
    {
        YouthTalkLgBLL talk_bll = new YouthTalkLgBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindTalkLg();
                bindCeBian();
            }
        }


        protected void bindTalkLg()
        {
            if (pagerList.CurrentPageIndex == 1)
            {
                rpt_talk_list.DataSource = talk_bll.GetTopTalk(pagerList.PageSize, " is_check='Y' ", " publish_time desc ");
                rpt_talk_list.DataBind();
            }
            else
            {
                rpt_talk_list.DataSource = talk_bll.GetListByPage("  is_check='Y'  ", " publish_time desc ", pagerList.StartRecordIndex, pagerList.EndRecordIndex);
                rpt_talk_list.DataBind();
            }
            pagerList.RecordCount = talk_bll.GetRecordCount("  is_check='Y'  ");
        }

        protected void bindCeBian()
        {
            DataSet ds = talk_bll.GetTopTalk(5, " is_check='Y' ", " publish_time desc ");
            rptCeBian.DataSource = ds;
            rptCeBian.DataBind();
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
                bindTalkLg();
            }
        }
    }
}