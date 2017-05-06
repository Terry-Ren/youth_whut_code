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
    public partial class ReceptionTypeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            YouthReceptionType model = new YouthReceptionType();
            YouthReceptionTypeBLL bll = new YouthReceptionTypeBLL();
            model.Reception_type = txtName.Text.ToString();
            if (bll.AddReceptionType(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "ReceptionType.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "添加失败");
            }
        }
    }
}