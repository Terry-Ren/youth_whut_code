using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Utility;
using AUTO.BLL;
using System.Text;
using System.Data;

namespace AUTO.youth_admin.SpeSubject
{
    public partial class specialItemList : BasePage
    {
        YouthSpecialBLL special_bll = new YouthSpecialBLL();
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
            }
        }

        protected void bindSpecial()
        {
            pageTotal = special_bll.GetRecordCount(GetStrWhere());
            DataSet ds = special_bll.GetListByPage(GetStrWhere(), pageSize, pageIndex, " special_id asc");
            gvwData.DataSource = ds;
            gvwData.DataBind();
        }

        //获取筛选条件
        public string GetStrWhere()
        {
            StringBuilder str = new StringBuilder();
            if (!String.IsNullOrEmpty(txtWord.Text.ToString()))
            {
                str.Append(" special_title like '%" + txtWord.Text.Trim().ToString() + "%'");
            }
            if (str.Length == 0)
            {
                str.Append(" 1=1 ");
            }
            return str.ToString();
        }

        //搜索
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            bindSpecial();
        }

        //分页
        protected void btnHide_Click(object sender, EventArgs e)
        {
            bindSpecial();
        }

        //添加
        protected void addAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("specialItemAdd.aspx");
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
                    special_bll.DelSpecial(id);
                    success++;
                }
            }
            bindSpecial();
            String message = "成功删除" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }

        //编辑
        protected void lbtnReset_Click(object sender, EventArgs e)
        {

            LinkButton lbtn = (LinkButton)sender;
            int special_id = Convert.ToInt32(lbtn.CommandArgument);
            Response.Redirect("specialItemUpd.aspx?special_id=" + special_id);
        }
    }
}