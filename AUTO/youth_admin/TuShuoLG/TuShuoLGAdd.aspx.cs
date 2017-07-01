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

namespace AUTO.youth_admin.TuShuoLG
{
    public partial class TuShuoLGAdd : System.Web.UI.Page
    {
        YouthAcademicBLL aca_bll = new YouthAcademicBLL();

        YouthTalkLg model = new YouthTalkLg();
        YouthTalkLgBLL bll = new YouthTalkLgBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string operate_name = Session[Constant.adminName].ToString();
                ViewState["operate_name"] = operate_name;
                bindSorce();

            }
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            if (fupImage.HasFile)
            {
                string fileName = fupImage.FileName;
                string ext = fileName.Substring(fileName.LastIndexOf('.'));
                string url = "../upload/Talkimg/" + DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateSixNum() + ext;
                fupImage.SaveAs(Server.MapPath(url));
                model.Talk_Img_url = url.Substring(3);
            }
            model.Talk_title = txtTitle.Text.ToString();
            model.Talk_content = txtContent.Text.ToString();
            model.Publisher = txt_publisher.Text.ToString();
            model.Publisher_phone = txt_phone.Text.ToString();
            model.Publisher_mail = txt_email.Text.ToString();
            model.Publish_time = DateTime.Now;
            model.Click_times = 0;
            model.Talk_source = Convert.ToInt32(ddl_source.SelectedValue.ToString());
            model.Last_updater = ViewState["operate_name"].ToString();
            model.Last_update_time = DateTime.Now;
            model.Is_check = "N";
            model.Checker = "";
            model.Check_time = DateTime.Now;
            model.Rechecker = "";
            model.Recheck_time = DateTime.Now;
            if (bll.AddTalkLG(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "TuShuoLGList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "添加失败");
            }
        }

        protected void bindSorce()
        {
            DataSet ds = aca_bll.GetAcademic();
            ddl_source.DataValueField = "academic_id";
            ddl_source.DataTextField = "academic_name";
            ddl_source.DataSource = ds;
            ddl_source.DataBind();
            ddl_source.Items.Insert(0, new ListItem("", "0"));
        }

        //产生6位随机数
        protected string GenerateSixNum()
        {
            Random rad = new Random();//实例化随机数产生器rad；
            int value = rad.Next(100000, 1000000);//用rad生成大于等于1000，小于等于9999的随机数；
            return value.ToString();
        }
    }
}