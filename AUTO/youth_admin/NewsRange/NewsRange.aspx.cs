using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Utility;
using AUTO.BLL;
using System.Data;
using System.Text;

namespace AUTO.youth_admin.NewsRange
{
    public partial class NewsRange : BasePage
    {
        YouthNewsBLL news_bll = new YouthNewsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindRank();
            }
        }

        protected void bindRank()
        {
            DataSet ds = news_bll.GetRankByCondition(" 1=1 " + GetStrWhere(), "a.news_source=b.academic_id");
            gvwData.DataSource = ds;
            gvwData.DataBind();
        }

        //搜索条件
        protected string GetStrWhere()
        {
            StringBuilder str = new StringBuilder();
            if (ddl_type.SelectedValue.ToString().Equals("1"))
            {
                str.Append(" and 1=1 ");
            }
            else if (ddl_type.SelectedValue.ToString().Equals("2"))
            {
                str.Append(" and is_check='Y' ");
            }
            if (ddl_time.SelectedValue.ToString().Equals("1"))
            {
                str.Append(" and publish_time >DATEADD(MONTH,-1,GETDATE()) and publish_time < GETDATE() ");
            }
            else if (ddl_time.SelectedValue.ToString().Equals("2"))
            {
                str.Append(" and publish_time >DATEADD(MONTH,-3,GETDATE()) and publish_time < GETDATE() ");
            }
            else if (ddl_time.SelectedValue.ToString().Equals("3"))
            {
                str.Append(" and publish_time >DATEADD(MONTH,-12,GETDATE()) and publish_time < GETDATE() ");
            }
            if (str.Length == 0)
            {
                str.Append(" and 1=1");
            }
            return str.ToString();
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            bindRank();
        }
    }
}