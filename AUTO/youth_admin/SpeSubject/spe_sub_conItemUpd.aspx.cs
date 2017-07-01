using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;
using System.Data;
using AUTO.Utility;

namespace AUTO.youth_admin.SpeSubject
{
    public partial class spe_sub_conItemUpd : System.Web.UI.Page
    {
        YouthSpecialSubContent model = new YouthSpecialSubContent();
        YouthSpecialSubConBLL bll = new YouthSpecialSubConBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindSpeList();
                bindSubList();
                bindSource();
                int content_id = Convert.ToInt32(Request.QueryString["content_id"].ToString());
                ViewState["content_id"] = content_id;
                bindSpeSubCon();
            }
        }

        protected void bindSpeSubCon()
        {
            int content_id = Convert.ToInt32(ViewState["content_id"].ToString());
            model = bll.GetListById(content_id);
            ddl_special.Items.FindByValue(model.Special_id.ToString()).Selected = true;
            ddl_sub.Items.FindByValue(model.Sub_id.ToString()).Selected = true;
            txtTitle.Text = model.Content_title;
            txtContent.Text = model.Content_content;
            txt_click.Text = model.Content_click_times.ToString();
            txt_publisher.Text = model.Content_publisher;
            txt_phone.Text = model.Content_phone;
            txt_email.Text = model.Content_email;
            ddl_source.Items.FindByValue(model.Content_source.ToString()).Selected = true;
            //应该把所有元素都取到，这样在下面的修改保存中可以保持一致性
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            int content_id = Convert.ToInt32(ViewState["content_id"].ToString());
            YouthSpecialSubContent original_model = bll.GetListById(content_id);

            model.Content_id = content_id;
            model.Special_id = Convert.ToInt32(ddl_special.SelectedValue);
            model.Sub_id = Convert.ToInt32(ddl_sub.SelectedValue);
            model.Content_title = txtTitle.Text.ToString();
            model.Content_content = txtContent.Text.ToString();
            model.Content_publisher = txt_publisher.Text.ToString();
            model.Content_phone = txt_phone.Text.ToString();
            model.Content_email = txt_email.Text.ToString();
            model.Content_publish_time = original_model.Content_publish_time;
            model.Content_click_times = Convert.ToInt32(txt_click.Text.ToString());
            model.Content_source = Convert.ToInt32(ddl_source.SelectedValue);
            model.Last_updater = Session[Constant.adminName].ToString();
            model.Last_update_time = DateTime.Today;
            model.Is_check = "N";
            model.Checker = "";
            model.Check_time = original_model.Check_time;
            model.Rechecker = "";
            model.Recheck_time = original_model.Recheck_time;
            if (bll.UpdContent(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "编辑成功", "spe_sub_conItemList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "编辑失败");
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

        //初始化栏目列表
        protected void bindSubList()
        {
            AUTO.BLL.YouthSpecialSubBLL bll = new AUTO.BLL.YouthSpecialSubBLL();
            DataSet ds = bll.GetList();
            ddl_sub.DataValueField = "sub_id";
            ddl_sub.DataTextField = "sub_title";
            ddl_sub.DataSource = ds;
            ddl_sub.DataBind();
        }

        //绑定内容来源列表
        protected void bindSource()
        {
            AUTO.BLL.YouthAcademicBLL aca_bll = new BLL.YouthAcademicBLL();
            DataSet ds = aca_bll.GetAcademic();
            ddl_source.DataValueField = "academic_id";
            ddl_source.DataTextField = "academic_name";
            ddl_source.DataSource = ds;
            ddl_source.DataBind();
            ddl_source.Items.Insert(0, new ListItem("", "0"));
        }
    }
}