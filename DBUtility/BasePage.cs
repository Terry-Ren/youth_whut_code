using System;

/// <summary>
///Page的基类
/// </summary>

namespace AUTO.Utility
{
    public class BasePage : System.Web.UI.Page
    {
        public int pageTotal;
        public int pageSize = 12;
        public int pageIndex = 1;

        public BasePage()
        {
            this.Load += new EventHandler(BasePage_Load);
        }

        private void BasePage_Load(object sender, EventArgs e)
        {
        }
    }
}