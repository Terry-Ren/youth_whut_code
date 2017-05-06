using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;
using AUTO.Utility;

namespace AUTO.youth_admin.MeetingRoom
{
    public partial class questionReview : System.Web.UI.Page
    {
        YouthReception model = new YouthReception();
        YouthReceptionBLL bll = new YouthReceptionBLL();
        YouthSecretaryBLL huifu_bll = new YouthSecretaryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int reception_id = Convert.ToInt32(Request.QueryString["reception_id"].ToString());
                ViewState["reception_id"] = reception_id;
                bindData();
            }
        }

        protected void bindData()
        {
            int reception_id = Convert.ToInt32(ViewState["reception_id"].ToString());
            model = bll.GetListById(reception_id);
            lblsender.Text = model.Reception_name;
            lbltitle.Text = model.Reception_title;
            lblquestioncontent.Text = model.Reception_content;
            YouthSecretary sec_model = huifu_bll.GetListById(reception_id);
            if (sec_model != null)
            {
                txtanswercontent.Text = sec_model.Secretary_content;
            }
        }

        //回复并保存
        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            YouthSecretary model = new YouthSecretary();
            model.Reception_id = Convert.ToInt32(ViewState["reception_id"].ToString());
            model.Secretary_sid = Convert.ToInt32(Session[Constant.adminID].ToString());
            model.Secretary_name = Session[Constant.adminName].ToString();
            model.Secretary_content = txtanswercontent.Text;
            model.Secretary_time = DateTime.Now;
            if (huifu_bll.AddSecretary(model))
            {
                //并更新reception表的is_reply
                bll.UpdReception(Convert.ToInt32(ViewState["reception_id"].ToString()));

                MyUtil.ShowMessageRedirect(this.Page, "回复成功", "questionList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "回复失败");
            }
        }
    }
}