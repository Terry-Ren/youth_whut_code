using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;
using AUTO.Utility;

namespace AUTO.youth_admin.SpeSubject
{
    public partial class specialItemUpd : System.Web.UI.Page
    {
        YouthSpecial model = new YouthSpecial();
        YouthSpecialBLL special_bll = new YouthSpecialBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int special_id = Convert.ToInt32(Request.QueryString["special_id"].ToString());
                ViewState["special_id"] = special_id;
                bindSpecial();
            }
        }

        protected void bindSpecial()
        {
            int special_id = Convert.ToInt32(ViewState["special_id"].ToString());
            model = special_bll.GetListById(special_id);
            txtTitle.Text = model.Special_title;
            ViewState["Special_img_url"] = model.Special_img_url;
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            model.Special_id = Convert.ToInt32(ViewState["special_id"].ToString());
            model.Special_title = txtTitle.Text;
            model.Is_banner = "N";
            if (fupImage.HasFile)
            {
                string fileName = fupImage.FileName;
                string ext = fileName.Substring(fileName.LastIndexOf('.'));
                string url = "../upload/SpecialImg/" + DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateSixNum() + ext;
                fupImage.SaveAs(Server.MapPath(url));
                model.Special_img_url = url.Substring(3);
            }
            else
            {
                model.Special_img_url = ViewState["Special_img_url"].ToString();
            }
            if (special_bll.UpdSpecial(model))
            {
                //修改成功
                MyUtil.ShowMessageRedirect(this.Page, "修改成功", "specialItemList.aspx");
            }
            else
            {
                //修改失败，清空
                MyUtil.ShowMessage(this.Page, "修改失败");
            }
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