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

namespace AUTO.youth_admin.SpeSubject
{
    public partial class spe_subjectItemList : BasePage
    {
        YouthSpecialSubBLL spe_sub_bll = new YouthSpecialSubBLL();
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
                bindSpecial();
                bindSpeSub();
            }
        }

        protected void bindSpeSub()
        {
            pageTotal = spe_sub_bll.GetRecordCount(" 1=1 " + GetStrWhere());
            DataSet ds = spe_sub_bll.GetListByPage(" 1=1 " + GetStrWhere(), pageSize, pageIndex, " sub_paixu asc");
            gvwData.DataSource = ds;
            gvwData.DataBind();
        }

        protected void bindSpecial()
        {
            YouthSpecialBLL spe_bll = new YouthSpecialBLL();
            DataSet ds = spe_bll.GetList();
            ddl_item.DataValueField = "special_id";
            ddl_item.DataTextField = "special_title";
            ddl_item.DataSource = ds;
            ddl_item.DataBind();
            ddl_item.Items.Insert(0, new ListItem("", "0"));
        }

        //获取筛选条件
        public string GetStrWhere()
        {
            StringBuilder str = new StringBuilder();
            if (!String.IsNullOrEmpty(txtWord.Text.ToString()))
            {
                str.Append(" and sub_title like '%" + txtWord.Text.Trim().ToString() + "%'");
            }
            if (!ddl_item.SelectedValue.ToString().Equals("0"))
            {
                str.Append(" and special_id=" + Convert.ToInt32(ddl_item.SelectedValue.ToString()));
            }
            if (str.Length == 0)
            {
                str.Append(" and 1=1 ");
            }
            return str.ToString();
        }

        //分页
        protected void btnHide_Click(object sender, EventArgs e)
        {
            bindSpeSub();
        }

        //搜索
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            bindSpeSub();
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
                    int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    spe_sub_bll.DelSpeSub(id);
                    success++;
                }
            }
            bindSpeSub();
            String message = "成功删除" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }

        //编辑
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int sub_id = Convert.ToInt32(lbtn.CommandArgument);
            Response.Redirect("spe_subjectItemUpd.aspx?sub_id=" + sub_id);
        }

        //添加
        protected void addAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("spe_subjectItemAdd.aspx");
        }

    }
}