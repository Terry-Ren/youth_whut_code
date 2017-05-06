using System;

namespace AUTO.ascx
{
    public partial class RightSide : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //rptLinkList.DataSource = new AUTO.BLL.Link().GetAllList();
            //rptLinkList.DataBind();
        }

        //保证链接可直接访问
        protected string TranslateUrl(string url)
        {
            if (url.Contains("http"))
            {
                return url;
            }
            return "http://" + url;
        }
    }
}