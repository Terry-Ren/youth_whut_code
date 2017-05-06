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
    public partial class spe_subjectItemAdd : System.Web.UI.Page
    {
        YouthSpecialSubBLL spe_sub_bll = new YouthSpecialSubBLL();
        YouthSpecialSub spe_sub_model = new YouthSpecialSub();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindSpecial();
                bindPaixu();
            }
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

        protected void bindPaixu()
        {
            int paixuId = spe_sub_bll.GetMaxPaixu();
            txtPaixu.Text = paixuId.ToString();
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            spe_sub_model.Special_id = Convert.ToInt32(ddl_item.SelectedValue);
            spe_sub_model.Sub_title = txtTitle.Text;
            spe_sub_model.Sub_paixu = Convert.ToInt32(txtPaixu.Text);
            if (spe_sub_bll.AddSpeSub(spe_sub_model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "spe_subjectItemList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "添加失败");
            }
        }
    }
}