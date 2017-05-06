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

namespace AUTO.youth_admin.FileUpload
{
    public partial class fileUploadUpd : System.Web.UI.Page
    {
        YouthFilesBLL file_bll = new YouthFilesBLL();
        YouthFile model = new YouthFile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int file_id = Convert.ToInt32(Request.QueryString["file_id"].ToString());
                ViewState["file_id"] = file_id;
                bindFileCol();
                bindSource();
                bindFile(file_id);
            }
        }

        protected void bindFile(int file_id)
        {
            model = file_bll.GetFilesById(file_id);
            ddl_file_col.Items.FindByValue(model.File_father_id.ToString()).Selected = true;
            txtTitle.Text = model.File_title;
            txt_content.Text = model.File_remark;
            ddl_source.Items.FindByValue(model.File_source.ToString()).Selected = true;
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
            int file_id = Convert.ToInt32(ViewState["file_id"].ToString());
            YouthFile original_model = file_bll.GetFilesById(file_id);
            model.File_id = file_id;
            model.File_title = txtTitle.Text.Trim();
            model.File_remark = txt_content.Text.ToString();
            model.File_father_id = Convert.ToInt32(ddl_file_col.SelectedValue);
            model.Uploader = original_model.Uploader;
            model.Upload_time = original_model.Upload_time;
            model.Click_times = original_model.Click_times;
            model.File_source = Convert.ToInt32(ddl_source.SelectedValue);
            model.Last_updater = Session[Constant.adminName].ToString();
            model.Last_update_time = DateTime.Now;
            model.Is_check = "N";
            model.Checker = "";
            model.Check_time = original_model.Check_time;
            model.Rechecker = "";
            model.Recheck_time = original_model.Recheck_time;
            if (file_bll.UpdFile(model))
            {
                //编辑成功
                MyUtil.ShowMessageRedirect(this.Page, "修改成功", "fileUpload.aspx");
            }
            else
            {
                //编辑失败
                MyUtil.ShowMessage(this.Page, "修改失败");
            }
        }
    }
}