using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;

namespace AUTO.youth_index_videos
{
    public partial class youth_videos_list : System.Web.UI.Page
    {
        YouthVideoBLL video_bll = new YouthVideoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindVideo();
                bindCeBian();
            }
        }

        protected void bindVideo()
        {
            if (pagerList.CurrentPageIndex == 1)
            {
                rpt_videos_list.DataSource = video_bll.GetTopVideo(pagerList.PageSize, "", " video_up_time desc ");
                rpt_videos_list.DataBind();
            }
            else
            {
                rpt_videos_list.DataSource = video_bll.GetListByPage("", " video_up_time desc ", pagerList.StartRecordIndex, pagerList.EndRecordIndex);
                rpt_videos_list.DataBind();
            }
            pagerList.RecordCount = video_bll.GetRecordCount("");
        }

        protected void bindCeBian()
        {
            DataSet ds = video_bll.GetTopVideo(5, "", " video_up_time desc ");
            rptCeBian.DataSource = ds;
            rptCeBian.DataBind();
        }

        protected void pagerList_PageChanged(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                bindVideo();
            }
        }
    }
}