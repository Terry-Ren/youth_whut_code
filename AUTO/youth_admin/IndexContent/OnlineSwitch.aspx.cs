using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;
using AUTO.Utility;
using System.Data;

namespace AUTO.youth_admin.IndexContent
{
    public partial class OnlineSwitch : System.Web.UI.Page
    {
        YouthOnlineBLL online_bll = new YouthOnlineBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }


        protected void lbtnSave_Click(object sender, EventArgs e)
        {
             online_bll.UpdOnline(int.Parse(txtName.SelectedValue));
        }
    }
}