using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;
using AUTO.Utility;

namespace AUTO.youth_admin.IndexContent
{
    public partial class NewsColUpd : System.Web.UI.Page
    {
        YouthNewsColumn model = new YouthNewsColumn();
        YouthNewsColBLL bll = new YouthNewsColBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int news_col_id = Convert.ToInt32(Request.QueryString["news_column_id"].ToString());
                ViewState["news_column_id"] = news_col_id;
                bindNewsCol();
            }
        }

        protected void bindNewsCol()
        {
            int news_col_id = Convert.ToInt32(ViewState["news_column_id"]);
            model = bll.GetListById(news_col_id);
            txtName.Text = model.News_column_name;
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            model.News_column_id = Convert.ToInt32(ViewState["news_column_id"].ToString());
            model.News_column_name = txtName.Text.ToString();
            if (bll.UpdNewsCol(model))
            {
                MyUtil.ShowMessageRedirect(this.Page, "编辑成功", "NewsColList.aspx");
            }
            else
            {
                MyUtil.ShowMessage(this.Page, "编辑失败");
            }
        }
    }
}