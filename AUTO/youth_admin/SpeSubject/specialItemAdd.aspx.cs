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
    public partial class specialItemAdd : System.Web.UI.Page
    {
        YouthSpecial special_model = new YouthSpecial();
        YouthSpecialBLL special_bll = new YouthSpecialBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            if (fupImage.HasFile)
            {
                string fileName = fupImage.FileName;
                string ext = fileName.Substring(fileName.LastIndexOf('.'));
                string url = "../upload/SpecialImg/" + DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateSixNum() + ext;
                fupImage.SaveAs(Server.MapPath(url));
                special_model.Special_img_url = url.Substring(3);
            }
            special_model.Special_title = txtTitle.Text;
            if (special_bll.AddSpecial(special_model))
            {
                //添加成功
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "specialItemList.aspx");
            }
            else
            {
                //添加失败，清空
                MyUtil.ShowMessage(this.Page, "添加失败");
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