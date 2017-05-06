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
    public partial class ReceptionTypeUpd : System.Web.UI.Page
    {
        YouthReceptionType model = new YouthReceptionType();
        YouthReceptionTypeBLL bll = new YouthReceptionTypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int type_id = Convert.ToInt32(Request.QueryString["type_id"].ToString());
                ViewState["type_id"] = type_id;
                bindReceptionType();
            }
        }

        protected void bindReceptionType()
        {
            int type_id = Convert.ToInt32(ViewState["type_id"].ToString());
            model = bll.GetListById(type_id);
            txtName.Text = model.Reception_type;
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            model.Reception_type = txtName.Text;
            model.Reception_type_id = Convert.ToInt32(ViewState["type_id"].ToString());
            if (bll.UpdReceptionType(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "编辑成功", "ReceptionType.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "编辑失败");
            }
        }
    }
}