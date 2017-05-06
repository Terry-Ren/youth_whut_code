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

namespace AUTO.youth_admin.MeetingRoom
{
    public partial class questionList : BasePage
    {
        YouthReceptionBLL bll = new YouthReceptionBLL();
        YouthSecretaryBLL sec_bll = new YouthSecretaryBLL();
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
                bindReception();
            }
        }

        //得到问题类型列表
        protected void bindReceptionType()
        {
            YouthReceptionTypeBLL type_bll = new YouthReceptionTypeBLL();
            DataSet ds = type_bll.GetList();
            ddl_type.DataValueField = "reception_type_id";
            ddl_type.DataTextField = "reception_type";
            ddl_type.DataSource = ds;
            ddl_type.DataBind();
            ddl_type.Items.Insert(0, new ListItem("", "0"));
        }

        protected void bindReception()
        {
            pageTotal = bll.GetRecordCount(" 1=1 " + GetStrWhere());
            DataSet ds = bll.GetListByPage(" 1=1 " + GetStrWhere(), pageSize, pageIndex, " reception_time desc ");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string is_reply = ds.Tables[0].Rows[i]["is_reply"].ToString();
                if (String.IsNullOrEmpty(is_reply) || is_reply.Trim().Equals("N"))
                {
                    ds.Tables[0].Rows[i]["is_reply"] = "未回复";
                }
                else
                {
                    ds.Tables[0].Rows[i]["is_reply"] = "已回复";
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
                str.Append(" and reception_title like '%" + txtWord.Text.Trim() + "%' ");
            }
            if (!ddl_type.SelectedValue.ToString().Equals("0"))
            {
                str.Append(" and reception_type_id= " + Convert.ToInt32(ddl_type.SelectedValue.ToString()));
            }
            if (ddl_reply.SelectedValue.ToString().Equals("0"))
            {
                str.Append(" and is_reply='N' ");
            }
            else if (ddl_reply.SelectedValue.ToString().Equals("1"))
            {
                str.Append(" and is_reply='Y' ");
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
            bindReception();
        }
        //分页
        protected void btnHide_Click(object sender, EventArgs e)
        {
            bindReception();
        }

        //查看并回复
        protected void lbtnReply_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int reception_id = Convert.ToInt32(lbtn.CommandArgument);
            Response.Redirect("questionReview.aspx?reception_id=" + Convert.ToInt32(reception_id));
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
                    int reception_id = Convert.ToInt32(gvwData.DataKeys[i].Value);
                    sec_bll.DelSecretary(reception_id);
                    bll.DelReception(reception_id);
                    success++;
                }
            }
            bindReception();
            String message = "成功删除" + success + "条记录！";
            MyUtil.ShowMessage(this, message);
        }
    }
}