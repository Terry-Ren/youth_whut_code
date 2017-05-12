using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AUTO.BLL;
using AUTO.Model;
using AUTO.Utility;
using System.IO;
using System.Globalization;

namespace AUTO.youth_admin.Download
{
    public partial class DownloadUpd : System.Web.UI.Page
    {
        YouthDownloadsBLL download_bll = new YouthDownloadsBLL();
        YouthDownload model = new YouthDownload();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int download_id = Convert.ToInt32(Request.QueryString["download_id"].ToString());
                ViewState["download_id"] = download_id;
                bindDownloadCol();
                bindSource();
                bindDownload(download_id);
            }
        }

        protected void bindDownload(int download_id)
        {
            model = download_bll.GetDownloadsById(download_id);
            ddl_download_col.Items.FindByValue(model.Download_father_id.ToString()).Selected = true;
            txtTitle.Text = model.Download_title;
            ddl_source.Items.FindByValue(model.Download_source.ToString()).Selected = true;
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

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            int download_id = Convert.ToInt32(ViewState["download_id"].ToString());
            YouthDownload original_model = download_bll.GetDownloadsById(download_id);
            model.Download_id = download_id;
            model.Download_title = txtTitle.Text.Trim();
            model.Download_father_id = Convert.ToInt32(ddl_download_col.SelectedValue);
            model.Uploader = original_model.Uploader;
            model.Upload_time = original_model.Upload_time;
            model.Click_times = original_model.Click_times;
            model.Download_source = Convert.ToInt32(ddl_source.SelectedValue);
            /*
            model.Last_updater = Session[Constant.adminName].ToString();
            model.Last_update_time = DateTime.Now;
            model.Is_check = "N";
            model.Checker = "";
            model.Check_time = original_model.Check_time;
            model.Rechecker = "";
            model.Recheck_time = original_model.Recheck_time;
            */
            if (download_bll.UpdDownload(model))
            {
                //编辑成功
                MyUtil.ShowMessageRedirect(this.Page, "修改成功", "Download.aspx");
            }
            else
            {
                //编辑失败
                MyUtil.ShowMessage(this.Page, "修改失败");
            }
        }
    }
}