using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;
using AUTO.Utility;

namespace AUTO.youth_admin.IndexContent
{
    public partial class IndexAdd : System.Web.UI.Page
    {
        YouthMenu model = new YouthMenu();
        YouthMenuBLL bll = new YouthMenuBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            model.Menu_name = txtName.Text;
            model.Menu_content = txtContent.Text;
            if (bll.AddMenu(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "IndexList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "添加失败");
            }
        }
    }
}