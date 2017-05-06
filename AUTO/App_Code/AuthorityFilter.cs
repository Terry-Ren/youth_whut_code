using System;
using System.Web;

namespace Web.App_Code
{
    public class AuthorityFilter : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PostAcquireRequestState += (new EventHandler(this.Application_AcquireRequestState));
        }

        //拦截请求，进行权限判断
        private void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            if (context.Request.Path.Contains(".aspx") && context.Request.Path.Contains("youth_admin"))
            {
                if (context.Session[Constant.adminID] == null)
                {
                    //context.Response.Redirect("~/whutauto/Login.aspx");
                    context.Response.Redirect("~/youth_manage/youth_login.aspx");
                }
            }
        }
    }
}