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
using AUTO.Model;

namespace AUTO.youth_admin.SpeSubject
{
    public partial class ChangeBanner : BasePage
    {
        YouthSpecial model = new YouthSpecial();
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

        //分页
        protected void btnHide_Click(object sender, EventArgs e)
        {
            bindSpecial();
        }

        //设置首页banner
        protected void lbtnChange_Click(object sender, EventArgs e)
        {
            int flag = 0;
            for (int i = 0; i < gvwData.Rows.Count; i++)
            {
                CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                if (cbx.Checked == true)
                {
                    flag++;
                    if (flag > 1)
                    {
                        MyUtil.ShowMessage(this, "仅能首页显示一个banner，请重新操作");
                        return;
                    }
                    else
                    {
                        int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                        model.Is_banner = "Y";
                        model.Special_id = id;
                        special_bll.updIsBanner(model);
                    }
                }
                else
                {
                    continue;
                }
            }
            bindSpecial();
            String message = "成功替换首页banner！";
            MyUtil.ShowMessage(this, message);
        }
    }
}