using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using AUTO.Model;
using AUTO.Utility;

namespace AUTO.youth_admin.IndexContent
{
    public partial class IndexUpd : System.Web.UI.Page
    {
        YouthMenuBLL bll = new YouthMenuBLL();
        YouthMenu model = new YouthMenu();
        YouthMenu originalModel = new YouthMenu();
        public int menu_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                menu_id = Convert.ToInt32(Request.QueryString["menu_id"].ToString());
                ViewState["menu_id"] = menu_id;
                bindOriginalMenu();
            }
        }

        protected void bindOriginalMenu()
        {
            originalModel = bll.GetModel(menu_id);
            txtName.Text = originalModel.Menu_name;
            txtContent.Text = originalModel.Menu_content;
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            model.Menu_id = Convert.ToInt32(ViewState["menu_id"].ToString());
            model.Menu_name = txtName.Text;
            model.Menu_content = txtContent.Text;
            if (bll.UpdMenu(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "编辑成功", "IndexList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "编辑失败");
            }
        }
    }
}