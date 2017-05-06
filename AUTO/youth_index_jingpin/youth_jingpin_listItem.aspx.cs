using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AUTO.BLL;

namespace AUTO.youth_index_jingpin
{
    public partial class youth_jingpin_listItem : System.Web.UI.Page
    {
        YouthSpecialBLL special_bll = new YouthSpecialBLL();
        YouthSpecialSubBLL special_sub_bll = new YouthSpecialSubBLL();
        YouthSpecialSubConBLL special_sub_con_bll = new YouthSpecialSubConBLL();
        public int special_id=0;
        public string special_title = "";
        public int sub_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["special_id"] != null)
                {
                    special_id = Convert.ToInt32(Request.QueryString["special_id"].ToString());
                }
                if (Request.QueryString["sub_id"] != null)
                {
                    sub_id = Convert.ToInt32(Request.QueryString["sub_id"].ToString());
                }
                else {
                    sub_id = special_sub_bll.getSubIdOfSpecial(special_id);
                }
                bindSpecial();
                bindItem();
                bindSpecialSub();
            }
        }
        //绑定专题名称
        protected void bindSpecial()
        {
            AUTO.Model.YouthSpecial model = new Model.YouthSpecial();
            model = special_bll.GetListById(special_id);
            special_title = model.Special_title;
        }

        //得到侧边栏该专题下的目录列表
        protected void bindItem()
        {
            DataSet ds = special_sub_bll.GetItemBySpeId(special_id);
            rptItem.DataSource = ds;
            rptItem.DataBind();
        }
        //分别得到专题目录下的内容列表
        protected void bindSpecialSub()
        {
            if (pagerList.CurrentPageIndex == 1)
            {
                rpt_sub_list.DataSource = special_sub_con_bll.GetList(pagerList.PageSize, "sub_id=" + sub_id + " and is_check='Y'", " content_publish_time desc ");
                rpt_sub_list.DataBind();
            }
            else
            {
                rpt_sub_list.DataSource = special_sub_con_bll.GetListByPage("sub_id=" + sub_id + " and is_check='Y'", " content_publish_time desc ", pagerList.StartRecordIndex, pagerList.EndRecordIndex);
                rpt_sub_list.DataBind();
            }
            pagerList.RecordCount = special_sub_con_bll.GetRecordCount("sub_id=" + sub_id + " and is_check='Y'");
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
                bindSpecialSub();
            }
        }
    }
}