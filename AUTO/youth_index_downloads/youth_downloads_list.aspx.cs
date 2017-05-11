using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;

namespace AUTO.youth_index_downloads
{
    public partial class youth_downloads_list : System.Web.UI.Page
    {
        YouthDownloadsBLL downloads_bll = new YouthDownloadsBLL();
        YouthDownloadsColBLL downloads_col_bll = new YouthDownloadsColBLL();

        public string download_father_name = String.Empty;
        public int download_father_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                download_father_id = Convert.ToInt32(Request.QueryString["download_father_id"].ToString());
                bindCeBian();
                bindDownloads();
                bindDownloadsCol();
            }
        }

        protected void bindDownloads()
        {

            if (pagerList.CurrentPageIndex == 1)
            {
                rpt_downloads_list.DataSource = downloads_bll.GetDownloads(pagerList.PageSize, "download_father_id=" + download_father_id , " upload_time desc ");
                rpt_downloads_list.DataBind();
            }
            else
            {
                rpt_downloads_list.DataSource = downloads_bll.GetListByPage("download_father_id=" + download_father_id , " upload_time desc ", pagerList.StartRecordIndex, pagerList.EndRecordIndex);
                rpt_downloads_list.DataBind();
            }
            pagerList.RecordCount = downloads_bll.GetRecordCount("download_father_id=" + download_father_id );
        }

        protected void bindCeBian()
        {
            DataSet ds = downloads_bll.GetDownloads(5, " download_father_id=" + download_father_id , " upload_time desc  ");
            rptCeBian.DataSource = ds;
            rptCeBian.DataBind();
        }

        //新闻标题过长，进行截取
        protected string CutString(string strToCut)
        {
            if (strToCut.Length > 30)
            {
                strToCut = strToCut.Substring(0, 29).ToString() + "...";
            }
            return strToCut;
        }

        protected void bindDownloadsCol()
        {
            DataSet ds_downloads_col = downloads_col_bll.GetDownloadsCol();
            download_father_name = ds_downloads_col.Tables[0].Rows[download_father_id - 1]["download_column_name"].ToString();
            ColumnNameFather.Text = download_father_name;
            lblTitle.InnerText = download_father_name;
        }

        //日期格式转换
        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }

        protected void pagerList_PageChanged(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                bindDownloads();
            }
        }
    }
}