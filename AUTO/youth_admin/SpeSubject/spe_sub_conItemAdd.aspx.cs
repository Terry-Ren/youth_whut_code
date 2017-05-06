using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AUTO.Model;
using AUTO.BLL;
using AUTO.Utility;

namespace AUTO.youth_admin.SpeSubject
{
    public partial class spe_sub_conItemAdd : System.Web.UI.Page
    {
        YouthSpecialSubConBLL bll = new YouthSpecialSubConBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindSpeList();
                bindSorce();
                ddl_sub.Items.Insert(0, new ListItem("", "0"));
            }
        }

        //绑定专题列表，然后动态生成栏目列表
        protected void bindSpeList()
        {
            AUTO.BLL.YouthSpecialBLL bll = new AUTO.BLL.YouthSpecialBLL();
            DataSet ds = bll.GetList();
            ddl_special.DataValueField = "special_id";
            ddl_special.DataTextField = "special_title";
            ddl_special.DataSource = ds;
            ddl_special.DataBind();
            ddl_special.Items.Insert(0, new ListItem("", "0"));
        }

        protected void ddl_special_SelectedIndexChanged(object sender, EventArgs e)
        {
            int special_id = Convert.ToInt32(ddl_special.SelectedValue);
            AUTO.BLL.YouthSpecialSubBLL bll = new AUTO.BLL.YouthSpecialSubBLL();
            DataSet ds = bll.GetListBySpe(special_id);
            ddl_sub.DataValueField = "sub_id";
            ddl_sub.DataTextField = "sub_title";
            ddl_sub.DataSource = ds;
            ddl_sub.DataBind();
        }

        //绑定内容来源列表
        protected void bindSorce()
        {
            AUTO.BLL.YouthAcademicBLL aca_bll = new BLL.YouthAcademicBLL();
            DataSet ds = aca_bll.GetAcademic();
            ddl_source.DataValueField = "academic_id";
            ddl_source.DataTextField = "academic_name";
            ddl_source.DataSource = ds;
            ddl_source.DataBind();
            ddl_source.Items.Insert(0, new ListItem("", "0"));
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            YouthSpecialSubContent model = new YouthSpecialSubContent();
            model.Special_id = Convert.ToInt32(ddl_special.SelectedValue);
            model.Sub_id = Convert.ToInt32(ddl_sub.SelectedValue);
            model.Content_title = txtTitle.Text.ToString();
            model.Content_content = txt_content.Text.ToString();
            model.Content_publisher = txt_publisher.Text.ToString();
            model.Content_email = txt_email.Text.ToString();
            model.Content_phone = txt_phone.Text.ToString();
            model.Content_publish_time = DateTime.Today;
            model.Content_click_times = 0;
            model.Content_source = Convert.ToInt32(ddl_source.SelectedValue);
            model.Last_updater = "";
            model.Last_update_time = DateTime.Today;
            model.Is_check = "N";
            model.Checker = "";
            model.Check_time = DateTime.Today;
            model.Rechecker = "";
            model.Recheck_time = DateTime.Today;
            if (bll.AddContent(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "spe_sub_conItemList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "添加失败");
            }
        }
    }
}