<%@ WebHandler Language="C#" Class="CheckCode" %>

using System;
using System.Web;

public class CheckCode : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest (HttpContext context) {
        VerifyCode vcode = new VerifyCode();
        vcode.CreateImage(context);
        context.Session[Constant.CheckCode] = vcode.RandomCode.ToLower();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}