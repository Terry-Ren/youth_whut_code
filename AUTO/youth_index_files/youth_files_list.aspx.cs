using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;

namespace AUTO.youth_index_files
{
    public partial class youth_files_list : System.Web.UI.Page
    {
        YouthFilesBLL files_bll = new YouthFilesBLL();
        YouthFilesColBLL files_col_bll = new YouthFilesColBLL();

        public string file_father_name = String.Empty;
        public int file_father_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                file_father_id = Convert.ToInt32(Request.QueryString["file_father_id"].ToString());
                bindCeBian();
                bindFiles();
                bindFilesCol();
            }
        }

        protected void bindFiles()
        {

            if (pagerList.CurrentPageIndex == 1)
            {
                rpt_files_list.DataSource = files_bll.GetFiles(pagerList.PageSize, "file_father_id=" + file_father_id + " and is_check='Y'", " upload_time desc ");
                rpt_files_list.DataBind();
            }
            else
            {
                rpt_files_list.DataSource = files_bll.GetListByPage("file_father_id=" + file_father_id + " and is_check='Y'", " upload_time desc ", pagerList.StartRecordIndex, pagerList.EndRecordIndex);
                rpt_files_list.DataBind();
            }
            pagerList.RecordCount = files_bll.GetRecordCount("file_father_id=" + file_father_id + " and is_check='Y'");
        }

        protected void bindCeBian()
        {
            DataSet ds = files_bll.GetFiles(5, " file_father_id=" + file_father_id + " and is_check='Y'", " upload_time desc  ");
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

        protected void bindFilesCol()
        {
            DataSet ds_files_col = files_col_bll.GetFilesCol();
            file_father_name = ds_files_col.Tables[0].Rows[file_father_id - 1]["file_column_name"].ToString();
            ColumnNameFather.Text = file_father_name;
            lblTitle.InnerText = file_father_name;
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
                bindFiles();
            }
        }
    }
}