using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Utility;
using AUTO.BLL;
using System.Data;
using System.Text;

namespace AUTO.youth_admin.IndexContent
{
    public partial class IndexList : BasePage
    {
        YouthMenuBLL menu_bll = new YouthMenuBLL();
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
                bindMenu();
            }
        }

        protected void bindMenu()
        {
            DataSet ds = menu_bll.GetListByPage(" 1=1 " + GetWhereSql(), pageSize, pageIndex, " menu_id asc ");
            pageTotal = menu_bll.GetRecordCount(" 1=1 " + GetWhereSql());
            gvwData.DataSource = ds;
            gvwData.DataBind();
        }

        /// <summary>
        /// 获取筛选条件
        /// </summary>
        /// <returns></returns>
        private string GetWhereSql()
        {
            StringBuilder sb = new StringBuilder();
            if (txtWord.Text.Trim() != "")
            {
                sb.Append(" and menu_name like '%" + txtWord.Text.Trim() + "%' ");
            }
            return sb.ToString();
        }

        protected void btnHide_Click(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                bindMenu();
            }
        }

        //添加首页版块
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexAdd.aspx");
        }

        //搜索
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            bindMenu();
        }
        //删除
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            int success = 0;
            for (int i = 0; i < gvwData.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                if (chk.Checked == true)
                {
                    int menu_id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    menu_bll.DelMenu(menu_id);
                    success++;
                }
            }
            bindMenu();
            String message = "成功删除" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }
        //编辑
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int menu_id = Convert.ToInt32(lbtn.CommandArgument);
            Response.Redirect("IndexUpd.aspx?menu_id=" + menu_id);
        }
    }
}