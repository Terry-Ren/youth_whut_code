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
using AUTO.Model;

namespace AUTO.youth_admin.TuShuoLG
{
    public partial class TuShuoLGList : BasePage
    {
        YouthTalkLgBLL bll = new YouthTalkLgBLL();
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
                bindTalkLG();
            }
        }

        protected void bindTalkLG()
        {
            pageTotal = bll.GetRecordCount(" 1=1 " + GetStrWhere());
            DataSet ds = bll.GetListByPage(" 1=1 " + GetStrWhere(), pageSize, pageIndex, " publish_time desc ");
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

        protected string GetStrWhere()
        {
            StringBuilder str = new StringBuilder();
            if (!String.IsNullOrEmpty(txtWord.Text.ToString()))
            {
                str.Append(" and talk_title like '%" + txtWord.Text.ToString() + "%' ");
            }
            if (!String.IsNullOrEmpty(txtAuthor.Text.ToString()))
            {
                str.Append(" and publisher like '%" + txtAuthor.Text.ToString() + "%' ");
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
            bindTalkLG();
        }

        //分页
        protected void btnHide_Click(object sender, EventArgs e)
        {
            bindTalkLG();
        }

        //添加
        protected void addTalk_Click(object sender, EventArgs e)
        {
            Response.Redirect("TuShuoLGAdd.aspx");
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

        //日期格式转换
        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }
        //审核
        protected void lbtnCheck_Click(object sender, EventArgs e)
        {
            int success = 0;
            YouthTalkLg model;
            for (int i = 0; i < gvwData.Rows.Count; i++)
            {
                CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                if (cbx.Checked == true)
                {
                    model = new YouthTalkLg();
                    int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    model.Talk_id = id;
                    model.Checker = Session[Constant.adminName].ToString();
                    model.Check_time = DateTime.Today;
                    model.Is_check = "Y";
                    bll.CheckTalkLg(model);
                    success++;
                }
            }
            bindTalkLG();
            String message = "成功审核" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }

        //反审核
        protected void lbtnReCheck_Click(object sender, EventArgs e)
        {
            int success = 0;
            YouthTalkLg model;
            for (int i = 0; i < gvwData.Rows.Count; i++)
            {
                CheckBox cbx = (CheckBox)gvwData.Rows[i].FindControl("chkbOne");
                if (cbx.Checked == true)
                {
                    model = new YouthTalkLg();
                    int id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    model.Talk_id = id;
                    model.Rechecker = Session[Constant.adminName].ToString();
                    model.Recheck_time = DateTime.Today;
                    model.Is_check = "N";
                    bll.ReCheckTalkLg(model);
                    success++;
                }
            }
            bindTalkLG();
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
                    bll.DelTalkLg(id);
                    success++;
                }
            }
            bindTalkLG();
            String message = "成功删除" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }


        //编辑
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int talk_id = Convert.ToInt32(lbtn.CommandArgument);
            Response.Redirect("TuShuoLGUpd.aspx?talk_id=" + talk_id);
        }
    }
}