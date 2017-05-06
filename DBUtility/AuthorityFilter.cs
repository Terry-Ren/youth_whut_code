using System;
using System.Web;

using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using System.Web.SessionState;

/// <summary>
///Authority 权限过滤
/// </summary>
public class AuthorityFilter : IHttpModule
{
    HttpContext context;
    HttpRequest request;
    HttpSessionState session;
    String adminPath;//admin文件夹路径
    String requestPath;//请求路径

    public AuthorityFilter()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region IHttpModule 成员

    public void Dispose()
    {

    }

    // Init方法仅用于给期望的事件注册方法
    public void Init(HttpApplication context)
    {
        context.PostAcquireRequestState += (new EventHandler(this.Application_AcquireRequestState));
    }
    #endregion

    //处理BeginRequest事件的实际代码
    void Application_AcquireRequestState(object sender, EventArgs e)
    {
        context = ((HttpApplication)sender).Context;
        request = context.Request;
        session = context.Session;

        requestPath = request.Path;
        adminPath = request.ApplicationPath + "/admin/";

        //仅处理向页面的请求，排除向资源文件的请求，排除非文件夹admin下的所有文件
        if (requestPath.IndexOf(".aspx") != -1 && requestPath.StartsWith(adminPath))
        {
            if (session[Constant.adminID] == null)
            {
                //还没有登陆
                if (requestPath.IndexOf("Menu.aspx") != -1)
                {
                    //首页
                    context.Response.Redirect("~/Login.aspx");
                }
                else
                {
                    context.Response.Write("<script>parent.location.href='" + request.ApplicationPath + "/Login.aspx';</script>");
                }
            }            
        }
    }
}
