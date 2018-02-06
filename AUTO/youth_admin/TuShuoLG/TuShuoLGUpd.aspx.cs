using AUTO.BLL;
using AUTO.Model;
using AUTO.Utility;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AUTO.youth_admin.TuShuoLG
{
    public partial class TuShuoLGUpd : System.Web.UI.Page
    {
        YouthTalkLg model = new YouthTalkLg();
        YouthTalkLgBLL bll = new YouthTalkLgBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int talk_id = Convert.ToInt32(Request.QueryString["talk_id"].ToString());
                ViewState["talk_id"] = talk_id;
                bindSorce();
                bindTalkLg();
            }
        }

        protected void bindTalkLg()
        {
            int talk_id = Convert.ToInt32(ViewState["talk_id"].ToString());
            model = bll.GetListById(talk_id);
            txtTitle.Text = model.Talk_title;
            txtContent.Text = model.Talk_content;
            txt_publisher.Text = model.Publisher;
            txt_phone.Text = model.Publisher_phone;
            txt_email.Text = model.Publisher_mail;
            ddl_source.Items.FindByValue(model.Talk_source.ToString()).Selected = true;
        }


        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            int talk_id = Convert.ToInt32(ViewState["talk_id"].ToString());
            YouthTalkLg original_model = new YouthTalkLg();
            original_model = bll.GetListById(talk_id);

            model.Talk_id = talk_id;
            model.Talk_title = txtTitle.Text.ToString();
            if (fupImage.HasFile)
            {
                string fileName = fupImage.FileName;
                string ext = fileName.Substring(fileName.LastIndexOf('.'));
                string url = "../upload/SpecialImg/" + DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateSixNum() + ext;
                fupImage.SaveAs(Server.MapPath(url));
                model.Talk_Img_url = url.Substring(3);
            }
            else
            {
                model.Talk_Img_url = original_model.Talk_Img_url;
            }
            model.Talk_content = txtContent.Text.ToString();
            model.Publisher = txt_publisher.Text.ToString();
            model.Publisher_phone = txt_phone.Text.ToString();
            model.Publisher_mail = txt_email.Text.ToString();
            model.Publish_time = original_model.Publish_time;
            model.Click_times = original_model.Click_times;
            model.Talk_source = Convert.ToInt32(ddl_source.SelectedValue.ToString());
            model.Last_updater = Session[Constant.adminName].ToString();
            model.Last_update_time = DateTime.Now;
            model.Is_check = "N";
            model.Checker = "";
            model.Check_time = original_model.Check_time;
            model.Rechecker = original_model.Rechecker;
            model.Recheck_time = original_model.Recheck_time;
            if (bll.UpdTalkLg(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "编辑成功", "TuShuoLGList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "编辑失败");
            }
        }

        protected void bindSorce()
        {
            YouthAcademicBLL aca_bll = new YouthAcademicBLL();
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