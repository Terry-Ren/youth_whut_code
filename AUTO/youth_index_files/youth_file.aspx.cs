using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using AUTO.Model;
using System.Data;

namespace AUTO.youth_index_files
{
    public partial class youth_file : System.Web.UI.Page
    {
        public int file_id;
        public string file_col_name;
        public int file_col_id;

        YouthFilesBLL file_bll = new YouthFilesBLL();
        YouthFilesColBLL file_col_bll = new YouthFilesColBLL();
        YouthFile file = new YouthFile();
        YouthFileColumn file_col = new YouthFileColumn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                file_id = Convert.ToInt32(Request.QueryString["file_id"].ToString());
                file_bll.AddReadCount(file_id);
                bindFile();
                file_col_id = file.File_father_id;
                bindFileCol();
                bindCeBian();
            }
        }

        protected void bindFile()
        {
            file = file_bll.GetFilesById(file_id);
            files_title.Text = file.File_title;
            UploadTime.Text = FormatTime(file.Upload_time);
            Uploader.Text = file.Uploader;
            Clicks.Text = file.Click_times.ToString();
            file_content.InnerHtml = file.File_remark;
            updater.Text = file.Last_updater;
            checker.Text = file.Checker;
        }

        protected void bindFileCol()
        {
            file_col = file_col_bll.GetFilesColById(file_col_id);
            file_col_name = file_col.File_column_name;
        }

        //加载侧边栏
        protected void bindCeBian()
        {
            DataSet ds = file_bll.GetFiles(5, " file_father_id=" + file_col_id + " and is_check='Y'", " upload_time desc  ");
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