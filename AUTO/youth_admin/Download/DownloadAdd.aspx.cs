using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AUTO.Model;
using AUTO.Utility;
using System.IO;
using System.Globalization;

namespace AUTO.youth_admin.Download
{
    public partial class DownloadAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDownloadCol();
                bindSource();
            }
        }

        //绑定文件分类
        protected void bindDownloadCol()
        {
            AUTO.DAL.YouthDownloadsColDAL download_col_dal = new DAL.YouthDownloadsColDAL();
            DataSet ds = download_col_dal.GetDownloadsCol();
            ddl_download_col.DataValueField = "download_column_id";
            ddl_download_col.DataTextField = "download_column_name";
            ddl_download_col.DataSource = ds;
            ddl_download_col.DataBind();
            ddl_download_col.Items.Insert(0, new ListItem("", "0"));
        }

        //绑定文件来源
        protected void bindSource()
        {
            AUTO.BLL.YouthAcademicBLL aca_bll = new AUTO.BLL.YouthAcademicBLL();
            DataSet ds = aca_bll.GetAcademic();
            ddl_source.DataValueField = "academic_id";
            ddl_source.DataTextField = "academic_name";
            ddl_source.DataSource = ds;
            ddl_source.DataBind();
            ddl_source.Items.Insert(0, new ListItem("", "0"));
        }

        //文件保存路径
        string savePath= "../Download/download_file/";
        string saveUrl= "/youth_admin/Download/download_file/";
        //上传文件到服务器
        protected void UploadFile()
        {
            //创建文件夹
            string dirPath= Server.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            dirPath += ymd + "/";
            saveUrl += ymd + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            download_content.SaveAs(dirPath + download_content.FileName);
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            UploadFile();
            YouthDownload model = new YouthDownload();
            //文件保存路径
            model.Download_title = txtTitle.Text.Trim();
            model.Download_path = saveUrl + download_content.FileName;
            model.Download_father_id = Convert.ToInt32(ddl_download_col.SelectedValue);
            model.Uploader = Session[Constant.adminName].ToString();
            model.Upload_time = DateTime.Today;
            model.Click_times = 0;
            model.Download_source = Convert.ToInt32(ddl_source.SelectedValue);
            /*
            model.Last_updater = Session[Constant.adminName].ToString();
            model.Last_update_time = DateTime.Today;
            model.Is_check = "N";
            model.Checker = "";
            model.Check_time = DateTime.Today;
            model.Rechecker = "";
            model.Recheck_time = DateTime.Today;
            */
            AUTO.BLL.YouthDownloadsBLL download_dal = new AUTO.BLL.YouthDownloadsBLL();
            if (download_dal.AddYouthDownload(model))
            {
                //添加成功
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "Download.aspx");
            }
            else
            {
                //添加失败
                MyUtil.ShowMessage(this.Page, "添加失败");
            }
        }
    }
}