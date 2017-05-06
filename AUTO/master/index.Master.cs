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

        public string bindMenu()
        {
            string str = "";
            DataSet ds = bll.GetList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //str += "<li><a href='../youth_information.aspx?menu_id='>" + ds.Tables[0].Rows[i]["menu_name"] + "</a></li>";
                str += "<li><a href='../youth_information.aspx?menu_id=" + Convert.ToInt32(ds.Tables[0].Rows[i]["menu_id"].ToString()) + "'>" + ds.Tables[0].Rows[i]["menu_name"] + "</a></li>";
            }
            return str;
        }
    }
}