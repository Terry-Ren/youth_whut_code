using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using AUTO.Model;
using System.Data;
using System.IO;

namespace AUTO.youth_index_downloads
{
    public partial class youth_download : System.Web.UI.Page
    {
        public int download_id;
        public string download_col_name;
        public int download_col_id;
        public string download_path;
        public string download_name;

        YouthDownloadsBLL download_bll = new YouthDownloadsBLL();
        YouthDownloadsColBLL download_col_bll = new YouthDownloadsColBLL();
        YouthDownload download = new YouthDownload();
        YouthDownloadColumn download_col = new YouthDownloadColumn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                download_id = Convert.ToInt32(Request.QueryString["download_id"].ToString());
                download_bll.AddReadCount(download_id);
                bindDownload();
                download_col_id = download.Download_father_id;
                bindDownloadCol();
                bindCeBian();
            }
        }


        protected void bindDownload()
        {
            download = download_bll.GetDownloadsById(download_id);
            downloads_title.Text = download.Download_title;
            download_path = download.Download_path;
            download_name = download_path.Split('/').Last();
            UploadTime.Text = FormatTime(download.Upload_time);
            Uploader.Text = download.Uploader;
            Clicks.Text = download.Click_times.ToString();
            /*
            updater.Text = download.Last_updater;
            checker.Text = download.Checker;
            */
        }

        protected void bindDownloadCol()
        {
            download_col = download_col_bll.GetDownloadsColById(download_col_id);
            download_col_name = download_col.Download_column_name;
        }

        //加载侧边栏
        protected void bindCeBian()
        {
            DataSet ds = download_bll.GetDownloads(5, " download_father_id=" + download_col_id , " upload_time desc  ");
            rptCeBian.DataSource = ds;
            rptCeBian.DataBind();
        }

        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }
        //新闻标题过长，进行截取
        protected string CutString(string strToCut)
        {
            if (strToCut.Length > 20)
            {
                strToCut = strToCut.Substring(0, 19).ToString() + "...";
            }
            return strToCut;
        }

       
    }
}