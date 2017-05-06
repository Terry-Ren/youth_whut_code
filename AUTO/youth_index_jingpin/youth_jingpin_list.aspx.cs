using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;

namespace AUTO.youth_index_jingpin
{
    public partial class youth_jingpin_list : System.Web.UI.Page
    {
        YouthSpecialBLL special_bll = new YouthSpecialBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindSpecial();
                bindCeBian();
            }
        }

        protected void bindSpecial()
        {
            if (pagerList.CurrentPageIndex == 1)
            {
                rpt_jingpin_list.DataSource = special_bll.GetSpecial(pagerList.PageSize, "", " special_id asc ");
                rpt_jingpin_list.DataBind();
            }
            else
            {
                rpt_jingpin_list.DataSource = special_bll.GetListByPage("", " special_id asc ", pagerList.StartRecordIndex, pagerList.EndRecordIndex);
                rpt_jingpin_list.DataBind();
            }
            pagerList.RecordCount = special_bll.GetRecordCount("");
        }

        protected void bindCeBian()
        {
            DataSet ds = special_bll.GetSpecial(5, "", " special_id asc  ");
            rptCeBian.DataSource = ds;
            rptCeBian.DataBind();
        }

        protected void pagerList_PageChanged(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                bindSpecial();
            }
        }
    }
}