using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;
using AUTO.Utility;

namespace AUTO.youth_admin.Video
{
    public partial class VideoAdd : System.Web.UI.Page
    {
        YouthVideo model = new YouthVideo();
        YouthVideoBLL bll = new YouthVideoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                videoUper.Text = Session[Constant.adminName].ToString();
            }
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            if (fupImage.HasFile)
            {
                string fileName = fupImage.FileName;
                string ext = fileName.Substring(fileName.LastIndexOf('.'));
                string url = "../upload/VideoImg/" + DateTime.Now.ToString("yyyyMMddHHmmss") + GenerateSixNum() + ext;
                fupImage.SaveAs(Server.MapPath(url));
                model.Video_pic = url.Substring(3);
            }
            model.Video_uper = videoUper.Text;
            model.Video_title = videoTitle.Text;
            model.Video_up_time = DateTime.Today;
            model.Video_link = videoLink.Text;
            if (bll.AddVideo(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "VideoList.aspx");
            }
            else
            {
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