using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Utility;
using System.Text;
using AUTO.BLL;
using System.Data;

namespace AUTO.youth_admin.Video
{
    public partial class VideoList : BasePage
    {
        YouthVideoBLL bll = new YouthVideoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(hfPageIndex.Value))
            {
                pageIndex = Convert.ToInt32(hfPageIndex.Value);
            }
            if (!String.IsNullOrEmpty(hfPageSize.Value))
            {
                pageSize = Convert.ToInt32(hfPageSize.Value);
            }
            if (!IsPostBack)
            {
                bindVideo();
            }
        }

        protected void bindVideo()
        {
            pageTotal = bll.GetRecordCount(" 1=1 " + GetStrWhere());
            DataSet ds = bll.GetListByPage(" 1=1 " + GetStrWhere(), pageSize, pageIndex, " video_up_time desc ");
            gvwData.DataSource = ds;
            gvwData.DataBind();
        }

        //获取搜索条件
        protected string GetStrWhere()
        {
            StringBuilder str = new StringBuilder();
            if (!String.IsNullOrEmpty(txtWord.Text.ToString()))
            {
                str.Append(" and video_title like '%" + txtWord.Text.ToString() + "%' ");
            }
            if (!String.IsNullOrEmpty(txtLink.Text.ToString()))
            {
                str.Append(" and video_link like '%" + txtLink.Text.ToString() + "%' ");
            }
            if (str.Length == 0)
            {
                str.Append(" and 1=1 ");
            }
            return str.ToString();
        }

        //搜索
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            bindVideo();
        }

        //删除
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            int success = 0;
            for (int i = 0; i < gvwData.Rows.Count; i++)
            {
                CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                if (cbx.Checked == true)
                {
                    int video_id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    bll.DelVideo(video_id);
                    success++;
                }
            }
            bindVideo();
            String message = "成功删除" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }

        //分页
        protected void btnHide_Click(object sender, EventArgs e)
        {
            bindVideo();
        }

        //日期格式转换
        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }

        //添加
        protected void addVideo_Click(object sender, EventArgs e)
        {
            Response.Redirect("VideoAdd.aspx");
        }

        //编辑
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int video_id = Convert.ToInt32(lbtn.CommandArgument);
            Response.Redirect("VideoUpd.aspx?video_id=" + video_id);
        }
    }
}