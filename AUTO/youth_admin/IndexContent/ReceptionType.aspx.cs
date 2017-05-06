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
    public partial class ReceptionType : BasePage
    {
        YouthReceptionTypeBLL bll = new YouthReceptionTypeBLL();
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
                bindReceptionType();
            }
        }

        protected void bindReceptionType()
        {
            pageTotal = bll.GetRecordCount(" 1=1 " + GetStrWhere());
            DataSet ds = bll.GetListByPage(" 1=1 " + GetStrWhere(), pageSize, pageIndex, " reception_type_id asc ");
            gvwData.DataSource = ds;
            gvwData.DataBind();
        }

        protected string GetStrWhere()
        {
            StringBuilder str = new StringBuilder();
            if (!String.IsNullOrEmpty(txtWord.Text.ToString()))
            {
                str.Append(" and reception_type like '%" + txtWord.Text.ToString() + "%' ");
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
            bindReceptionType();
        }

        //编辑
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int type_id = Convert.ToInt32(lbtn.CommandArgument);
            Response.Redirect("ReceptionTypeUpd.aspx?type_id=" + type_id);
        }

        //搜索
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            bindReceptionType();
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
                    int type_id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    bll.DelReceptionType(type_id);
                    success++;
                }
            }
            bindReceptionType();
            String message = "成功删除" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }

        //添加
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReceptionTypeAdd.aspx");
        }
    }
}