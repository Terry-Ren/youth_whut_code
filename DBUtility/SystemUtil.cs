using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;

/// <summary>
///SystemUtil 的摘要说明
/// </summary>
public class SystemUtil
{
    public SystemUtil()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static String MD5(String str)
    {
        byte[] array = Maticsoft.Common.DEncrypt.DEncrypt.MakeMD5(Encoding.UTF8.GetBytes(str));
        return BitConverter.ToString(array).Replace("-", "");
    }

    public static bool IsAllowed(String filename)
    {
        String[] array = { ".zip", ".rar", ".doc", ".docx", ".xls", ".xlsx", ".ppt", "pptx" };
        foreach (String str in array)
        {
            if (filename.EndsWith(str))
                return true;
        }
        return false;
    }
}
