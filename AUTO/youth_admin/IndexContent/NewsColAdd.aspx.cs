using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;

namespace AUTO.youth_admin.IndexContent
{
    public partial class NewsColAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            YouthNewsColumn model = new YouthNewsColumn();
            YouthNewsColBLL bll = new YouthNewsColBLL();
            model.News_column_name = txtName.Text.ToString();
            if (bll.AddNewsCol(model))
            {
                AUTO.Utility.MyUtil.ShowMessageRedirect(this.Page, "添加成功", "NewsColList.aspx");
            }
            else
            {
                AUTO.Utility.MyUtil.ShowMessage(this.Page, "添加失败");
            }
        }

    }
}