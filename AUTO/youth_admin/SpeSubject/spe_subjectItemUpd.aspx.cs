using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;
using AUTO.Model;
using AUTO.Utility;

namespace AUTO.youth_admin.SpeSubject
{
    public partial class spe_subjectItemUpd : System.Web.UI.Page
    {
        YouthSpecialSubBLL spe_sub_bll = new YouthSpecialSubBLL();
        YouthSpecialSub spe_sub_model = new YouthSpecialSub();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int sub_id = Convert.ToInt32(Request.QueryString["sub_id"].ToString());
                ViewState["sub_id"] = sub_id;
                bindSpecial();
                bindSpeSub();
            }
        }

        protected void bindSpeSub()
        {
            int sub_id = Convert.ToInt32(ViewState["sub_id"].ToString());
            spe_sub_model = spe_sub_bll.GetListById(sub_id);
            ddl_item.Items.FindByValue(spe_sub_model.Special_id.ToString()).Selected = true;
            txtTitle.Text = spe_sub_model.Sub_title;
            txtPaixu.Text = spe_sub_model.Sub_paixu.ToString();

        }

        protected void bindSpecial()
        {
            YouthSpecialBLL spe_bll = new YouthSpecialBLL();
            DataSet ds = spe_bll.GetList();
            ddl_item.DataValueField = "special_id";
            ddl_item.DataTextField = "special_title";
            ddl_item.DataSource = ds;
            ddl_item.DataBind();
            ddl_item.Items.Insert(0, new ListItem("", "0"));
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            spe_sub_model.Sub_title = txtTitle.Text;
            spe_sub_model.Special_id = Convert.ToInt32(ddl_item.SelectedValue);
            spe_sub_model.Sub_paixu = Convert.ToInt32(txtPaixu.Text);
            spe_sub_model.Sub_id = Convert.ToInt32(ViewState["sub_id"].ToString());
            if (spe_sub_bll.UpdSpeSub(spe_sub_model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "修改成功", "spe_subjectItemList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "修改失败");
            }

        }
    }
}