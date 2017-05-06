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

namespace AUTO.youth_admin.SpeSubject
{
    public partial class spe_sub_conItemList : BasePage
    {
        YouthSpecialSubConBLL spe_sub_con_bll = new YouthSpecialSubConBLL();
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
                bindSpeList();
                ddl_sub.Items.Insert(0, new ListItem("", "0"));
                bindSpeSubCon();
            }
        }

        protected void bindSpeSubCon()
        {
            pageTotal = spe_sub_con_bll.GetRecordCount(" 1=1 " + GetStrWhere());
            DataSet ds = spe_sub_con_bll.GetListByPage(" 1=1 " + GetStrWhere(), pageSize, pageIndex, " content_publish_time desc ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string is_check = ds.Tables[0].Rows[i]["is_check"].ToString();
                if (String.IsNullOrEmpty(is_check) || is_check.Trim().Equals("N"))
                {
                    ds.Tables[0].Rows[i]["is_check"] = "未审核";
                }
                else
                {
                    ds.Tables[0].Rows[i]["is_check"] = "已审核";
                }
            }
            gvwData.DataSource = ds;
            gvwData.DataBind();
        }

        //绑定专题列表，然后动态生成栏目列表
        protected void bindSpeList()
        {
            YouthSpecialBLL bll = new YouthSpecialBLL();
            DataSet ds = bll.GetList();
            ddl_special.DataValueField = "special_id";
            ddl_special.DataTextField = "special_title";
            ddl_special.DataSource = ds;
            ddl_special.DataBind();
            ddl_special.Items.Insert(0, new ListItem("", "0"));
        }

        protected void ddl_special_SelectedIndexChanged(object sender, EventArgs e)
        {
            int special_id = Convert.ToInt32(ddl_special.SelectedValue);
            YouthSpecialSubBLL bll = new YouthSpecialSubBLL();
            DataSet ds = bll.GetListBySpe(special_id);
            ddl_sub.DataValueField = "sub_id";
            ddl_sub.DataTextField = "sub_title";
            ddl_sub.DataSource = ds;
            ddl_sub.DataBind();
        }

        protected string GetStrWhere()
        {
            StringBuilder str = new StringBuilder();
            if (!String.IsNullOrEmpty(txtWord.Text.ToString()))
            {
                str.Append(" and content_title like '%" + txtWord.Text.Trim().ToString() + "%'");
            }
            if (!String.IsNullOrEmpty(txtContent.Text.ToString()))
            {
                str.Append(" and content_content like '%" + txtWord.Text.Trim().ToString() + "%' ");
            }
            if (!ddl_special.SelectedValue.ToString().Equals("0"))
            {
                str.Append(" and special_id=" + Convert.ToInt32(ddl_special.SelectedValue.ToString()));
            }
            if (!ddl_sub.SelectedValue.ToString().Equals("0"))
            {
                str.Append(" and sub_id=" + Convert.ToInt32(ddl_sub.SelectedValue.ToString()));
            }
            if (ddl_ischeck.SelectedValue.Equals("1"))
            {
                str.Append(" and is_check='Y' ");
            }
            else if (ddl_ischeck.SelectedValue.Equals("0"))
            {
                str.Append(" and is_check='N'");
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
            bindSpeSubCon();
        }
        //分页
        protected void btnHide_Click(object sender, EventArgs e)
        {
            bindSpeSubCon();
        }

        //日期格式转换
        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }
        //新闻标题过长，进行截取
        protected string CutString(string strToCut)
        {
            if (strToCut.Length > 20)
            {
                strToCut = strToCut.Substring(0, 19).ToString() + "...";
            }
            return strToCut;
        }

        //审核
        protected void lbtnCheck_Click(object sender, EventArgs e)
        {
            int success = 0;
            for (int i = 0; i < gvwData.Rows.Count; i++)
            {
                CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                if (cbx.Checked == true)
                {
                    int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    AUTO.Model.YouthSpecialSubContent model = new Model.YouthSpecialSubContent();
                    model.Content_id = id;
                    model.Is_check = "Y";
                    model.Checker = Session[Constant.adminName].ToString();
                    model.Check_time = DateTime.Today;
                    spe_sub_con_bll.CheckCon(model);
                    success++;
                }
            }
            bindSpeSubCon();
            String message = "成功审核" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }

        //取消审核
        protected void lbtnReCheck_Click(object sender, EventArgs e)
        {
            int success = 0;
            for (int i = 0; i < gvwData.Rows.Count; i++)
            {
                CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                if (cbx.Checked == true)
                {
                    int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    AUTO.Model.YouthSpecialSubContent model = new Model.YouthSpecialSubContent();
                    model.Content_id = id;
                    model.Is_check = "N";
                    model.Rechecker = Session[Constant.adminName].ToString();
                    model.Recheck_time = DateTime.Today;
                    spe_sub_con_bll.ReCheckCon(model);
                    success++;
                }
            }
            bindSpeSubCon();
            String message = "成功取消审核" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
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
                    spe_sub_con_bll.DelContent(id);
                    success++;
                }
            }
            bindSpeSubCon();
            String message = "成功删除" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }

        //添加内容
        protected void addAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("spe_sub_conItemAdd.aspx");
        }

        //编辑
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int content_id = Convert.ToInt32(lbtn.CommandArgument);
            Response.Redirect("spe_sub_conItemUpd.aspx?content_id=" + content_id);
        }
    }
}