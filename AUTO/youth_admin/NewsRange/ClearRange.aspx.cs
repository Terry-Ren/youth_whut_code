using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using AUTO.Utility;

namespace AUTO.youth_admin.NewsRange
{
    public partial class ClearRange : System.Web.UI.Page
    {
        YouthAcademicBLL aca_bll = new YouthAcademicBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnClear_Click(object sender, EventArgs e)
        {
            Boolean flag = aca_bll.clearRank();
            if (flag)
            {
                MyUtil.ShowMessageRedirect(this.Page, "清零成功", "ClearRange.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "清零失败");
            }
        }
    }
}