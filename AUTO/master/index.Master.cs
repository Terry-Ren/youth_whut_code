using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;

namespace AUTO.master
{
    public partial class index : System.Web.UI.MasterPage
    {
        YouthMenuBLL bll = new YouthMenuBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string bindMenuCommittee()
        {
            string str = "";
            DataSet ds = bll.GetList();
            str += "<li><a href='../youth_information.aspx?menu_id=" + Convert.ToInt32(ds.Tables[0].Rows[2]["menu_id"].ToString()) + "'>" + ds.Tables[0].Rows[2]["menu_name"] + "</a></li>";
            return str;
        }

        public string bindMenuScience()
        {
            string str = "";
            DataSet ds = bll.GetList();
            str += "<li><a href='../youth_information.aspx?menu_id=" + Convert.ToInt32(ds.Tables[0].Rows[0]["menu_id"].ToString()) + "'>" + ds.Tables[0].Rows[0]["menu_name"] + "</a></li>";
            return str;
        }

        public string bindMenuOrganization()
        {
            string str = "";
            DataSet ds = bll.GetList();
            str += "<li><a href='../youth_information.aspx?menu_id=" + Convert.ToInt32(ds.Tables[0].Rows[1]["menu_id"].ToString()) + "'>" + ds.Tables[0].Rows[1]["menu_name"] + "</a></li>";
            return str;
        }
    }
}