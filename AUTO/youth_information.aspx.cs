using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;

namespace AUTO
{
    public partial class youth_information : System.Web.UI.Page
    {
        public string content = "";
        public string name = "";
        public int menu_id = 0;
        YouthMenuBLL bll = new YouthMenuBLL();
        YouthMenu model = new YouthMenu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                menu_id = Convert.ToInt32(Request.QueryString["menu_id"].ToString());
                ViewState["menu_id"] = menu_id;
                bindMenu();
            }
        }

        public void bindMenu()
        {
            menu_id = Convert.ToInt32(ViewState["menu_id"].ToString());
            model = bll.GetModel(menu_id);
            menu_id = model.Menu_id;
            name = model.Menu_name;
            content = model.Menu_content;
        }
    }
}