using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using AUTO.Model;
using AUTO.Utility;

namespace AUTO.youth_admin.Video
{
    public partial class VideoUpd : System.Web.UI.Page
    {
        YouthVideoBLL bll = new YouthVideoBLL();
        YouthVideo model = new YouthVideo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int video_id = Convert.ToInt32(Request.QueryString["video_id"].ToString());
                ViewState["video_id"] = video_id;
                bindVideo();
            }
        }

        protected void bindVideo()
        {
            int video_id = Convert.ToInt32(ViewState["video_id"].ToString());
            model = bll.GetListById(video_id);
            videoTitle.Text = model.Video_title;
            videoUper.Text = model.Video_uper;
            videoLink.Text = model.Video_link;

            String pic = model.Video_pic;
            ViewState["pic"] = pic;
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            int video_id = Convert.ToInt32(ViewState["video_id"].ToString());
            model.Video_id = video_id;
            model.Video_title = videoTitle.Text.ToString();
            model.Video_uper = videoUper.Text.ToString();
            model.Video_up_time = DateTime.Today;
            model.Video_pic = ViewState["pic"].ToString();
            model.Video_link = videoLink.Text.ToString();
            if (bll.UpdVideo(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "更新成功", "VideoList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "更新失败");
            }
        }
    }
}