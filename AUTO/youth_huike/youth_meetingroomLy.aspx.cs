using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using System.Data;
using AUTO.BLL;
using AUTO.Utility;

namespace AUTO.youth_huike
{
    public partial class youth_meetingroomLy : System.Web.UI.Page
    {
        YouthReception model = new YouthReception();
        YouthReceptionBLL bll = new YouthReceptionBLL();
        YouthReceptionTypeBLL type_bll = new YouthReceptionTypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindReceptionType();
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            model.Reception_name = tg_zz.Text;
            if (male.Checked == true)
            {
                model.Reception_sex = male.Text;
            }
            else if (female.Checked == true)
            {
                model.Reception_sex = female.Text;
            }
            model.Reception_homepage = txt_homepage.Text;
            model.Reception_email = tg_yx.Text;
            model.Reception_qq = txt_qq.Text;
            model.Reception_title = tg_bt.Text;
            model.Reception_content = tg_nr.Text;
            model.Reception_time = DateTime.Today;
            model.Is_reply = "N";
            model.Reception_type_id = Convert.ToInt32(ddl_type.SelectedValue);
            if (bll.AddReception(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "留言提交成功,请等待回复", "youth_meetingroom.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "提交失败");
            }
        }

        protected void bindReceptionType()
        {
            DataSet ds = type_bll.GetList();
            ddl_type.DataValueField = "reception_type_id";
            ddl_type.DataTextField = "reception_type";
            ddl_type.DataSource = ds;
            ddl_type.DataBind();
        }
    }
}