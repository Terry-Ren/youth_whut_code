using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;

namespace AUTO.youth_huike
{
    public partial class youth_meetingroom : System.Web.UI.Page
    {
        public int RecordCount = 0;
        YouthReceptionBLL reception_bll = new YouthReceptionBLL();
        YouthUsersBLL user_bll = new YouthUsersBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindReception();
                bindShuJi();
            }
        }

        public void bindReception()
        {
            if (pagerList.CurrentPageIndex == 1)
            {
                rpt_reception.DataSource = reception_bll.GetList(pagerList.PageSize, " r.reception_id=s.reception_id and  r.is_reply='Y' ", " r.reception_time desc ");
                rpt_reception.DataBind();
            }
            else
            {
                rpt_reception.DataSource = reception_bll.GetListByPage(" r.reception_id=s.reception_id and r.is_reply='Y' ", " r.reception_time desc ", pagerList.StartRecordIndex, pagerList.EndRecordIndex);
                rpt_reception.DataBind();
            }
            RecordCount = reception_bll.GetRecordCount(" is_reply='Y'");
            pagerList.RecordCount = reception_bll.GetRecordCount(" is_reply='Y'");
        }

        protected void pagerList_PageChanged(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                bindReception();
            }
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

        protected void bindShuJi()
        {
            DataSet ds = user_bll.getShuJi();
            repeaterShuji.DataSource = ds;
            repeaterShuji.DataBind();
        }
    }
}