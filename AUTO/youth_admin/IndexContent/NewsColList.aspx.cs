using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Utility;
using System.Text;
using AUTO.BLL;
using System.Data;

namespace AUTO.youth_admin.IndexContent
{
    public partial class NewsColList : BasePage
    {
        YouthNewsColBLL bll = new YouthNewsColBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(hfPageIndex.Value))
            {
                pageIndex = Convert.ToInt32(hfPageIndex.Value);
            }
            if (!String.IsNullOrEmpty(hfPageSize.Value))
            {
                pageSize = Convert.ToInt32(hfPageSize.Value);
            }
            if (!IsPostBack)
            {
                bindNewsCol();
            }
        }

        protected void bindNewsCol()
        {
            pageTotal = bll.GetRecordCount(" 1=1 " + GetStrWhere());
            DataSet ds = bll.GetListByPage(" 1=1 " + GetStrWhere(), pageSize, pageIndex, " news_column_id asc ");
            gvwData.DataSource = ds;
            gvwData.DataBind();
        }

        protected string GetStrWhere()
        {
            StringBuilder str = new StringBuilder();
            if (!String.IsNullOrEmpty(txtWord.Text.ToString()))
            {
                str.Append(" and news_column_name like '%" + txtWord.Text.ToString() + "%' ");
            }
            if (str.Length == 0)
            {
                str.Append(" and 1=1 ");
            }
            return str.ToString();
        }

        //搜索
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            bindNewsCol();
        }

        //分页
        protected void btnHide_Click(object sender, EventArgs e)
        {
            bindNewsCol();
        }

        //删除
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            int success = 0;
            for (int i = 0; i < gvwData.Rows.Count; i++)
            {
                CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                if (cbx.Checked == true)
                {
                    int news_col_id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    bll.DelNewsCol(news_col_id);
                    success++;
                }
            }
            bindNewsCol();
            String message = "成功删除" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }

        //添加
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsColAdd.aspx");
        }

        //编辑
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int news_column_id = Convert.ToInt32(lbtn.CommandArgument);
            Response.Redirect("NewsColUpd.aspx?news_column_id=" + news_column_id);
        }
    }
}