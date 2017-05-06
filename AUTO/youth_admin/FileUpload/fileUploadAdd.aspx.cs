using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AUTO.Model;
using AUTO.Utility;

namespace AUTO.youth_admin.FileUpload
{
    public partial class fileUploadAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindFileCol();
                bindSource();
            }
        }

        //绑定文件分类
        protected void bindFileCol()
        {
            AUTO.DAL.YouthFilesColDAL file_col_dal = new DAL.YouthFilesColDAL();
            DataSet ds = file_col_dal.GetFilesCol();
            ddl_file_col.DataValueField = "file_column_id";
            ddl_file_col.DataTextField = "file_column_name";
            ddl_file_col.DataSource = ds;
            ddl_file_col.DataBind();
            ddl_file_col.Items.Insert(0, new ListItem("", "0"));
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
            YouthFile model = new YouthFile();
            model.File_title = txtTitle.Text.Trim();
            model.File_remark = txt_content.Text.ToString();
            model.File_father_id = Convert.ToInt32(ddl_file_col.SelectedValue);
            model.Uploader = Session[Constant.adminName].ToString();
            model.Upload_time = DateTime.Today;
            model.Click_times = 0;
            model.File_source = Convert.ToInt32(ddl_source.SelectedValue);
            model.Last_updater = Session[Constant.adminName].ToString();
            model.Last_update_time = DateTime.Today;
            model.Is_check = "N";
            model.Checker = "";
            model.Check_time = DateTime.Today;
            model.Rechecker = "";
            model.Recheck_time = DateTime.Today;
            AUTO.BLL.YouthFilesBLL file_dal = new AUTO.BLL.YouthFilesBLL();
            if (file_dal.AddYouthFile(model))
            {
                //添加成功
                MyUtil.ShowMessageRedirect(this.Page, "添加成功", "fileUpload.aspx");
            }
            else
            {
                //添加失败
                MyUtil.ShowMessage(this.Page, "添加失败");
            }
        }
    }
}