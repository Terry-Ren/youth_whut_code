using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.Model;
using AUTO.BLL;

namespace AUTO.youth_index_jingpin
{
    public partial class youth_jingpin_listContent : System.Web.UI.Page
    {
        public YouthSpecialSubContent model;
        public YouthSpecialSubConBLL bll = new YouthSpecialSubConBLL();
        public int content_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                content_id = Convert.ToInt32(Request.QueryString["content_id"].ToString());
                bll.AddReadCount(content_id);
                model = bll.GetListById(content_id);

            }
        }
        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }
    }
}