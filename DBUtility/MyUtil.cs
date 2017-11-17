using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

//using Maticsoft.DBUtility;
//using DataBaseToExcel;

namespace AUTO.Utility
{
    /// <summary>
    ///Util 的摘要说明
    /// </summary>
    public class MyUtil
    {
        public MyUtil()
        {
        }

        /// <summary>
        /// 分页初始化参数
        /// </summary>
        /// <param name="page"></param>
        public static void initParam(BasePage page)
        {
            try
            {
                HiddenField hfPageIndex = (HiddenField)page.FindControl("hfPageIndex");
                HiddenField hfPageSize = (HiddenField)page.FindControl("hfPageSize");
                if (!String.IsNullOrEmpty(hfPageIndex.Value))
                {
                    page.pageIndex = Convert.ToInt32(hfPageIndex.Value);
                }
                if (!String.IsNullOrEmpty(hfPageSize.Value))
                {
                    page.pageSize = Convert.ToInt32(hfPageSize.Value);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 执行JS
        /// </summary>
        /// <param name="page"></param>
        /// <param name="str"></param>
        public static void ExecuteJS(System.Web.UI.Page page, String str)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", str, true);
        }

        /// <summary>
        /// 前台显示通知
        /// </summary>
        /// <param name="page"></param>
        /// <param name="str"></param>
        public static void ShowMessage(System.Web.UI.Page page, String str)
        {
            String strNew = "$.messager.alert('消息','" + str + "','alert');";
            page.ClientScript.RegisterStartupScript(page.GetType(), "", strNew, true);
        }

        /// <summary>
        /// 前台显示后重定向
        /// </summary>
        /// <param name="page"></param>
        /// <param name="str"></param>
        /// <param name="url"></param>
        public static void ShowMessageRedirect(System.Web.UI.Page page, String str, String url)
        {
            String strNew = "alert('" + str + "');";
            String strRedirect = "window.location.href='" + url + "';";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "", strNew + strRedirect, true);
        }

        /// <summary>
        /// 前台显示错误
        /// </summary>
        /// <param name="page"></param>
        /// <param name="str"></param>
        public static void ShowError(System.Web.UI.Page page, String str)
        {
            String strNew = "$.messager.alert('错误','" + str + "','error');";
            page.ClientScript.RegisterStartupScript(page.GetType(), "", strNew, true);
        }

        /// <summary>
        /// 处理搜索结果，渲染红色
        /// </summary>
        /// <param name="content"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static String SplitArround(String content, String word)
        {
            StringBuilder sb = new StringBuilder();
            String ret;
            String[] array = content.Split(new String[] { word }, System.StringSplitOptions.RemoveEmptyEntries);
            String newWord = "<span style='color:Red'>" + word + "</span>";
            if (array.Length == 0)
            {
                if (content == word)
                {
                    return newWord;
                }
                else
                {
                    return content;
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(array[i]);
                sb.Append(newWord);
            }
            if (content.StartsWith(word))
            {
                sb.Insert(0, newWord);
            }
            ret = sb.ToString();
            if (!content.EndsWith(word))
            {
                ret = ret.TrimEnd(newWord.ToCharArray());
            }
            return ret.ToString();
        }

        /// <summary>
        /// MD5算法加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String MD5(String str) 
        {
            byte[] array = Maticsoft.Common.DEncrypt.DEncrypt.MakeMD5(Encoding.UTF8.GetBytes(str));
            return BitConverter.ToString(array).Replace("-", "");
        }

        /// <summary>
        /// 把DataTable转换成Excel文件并下载
        /// </summary>
        /// <param name="dt"></param>
        public static void DownloadExcel(DataTable dt, String fileName, BasePage page)
        {
            HttpResponse response = page.Response;

            if (!Directory.Exists(page.Server.MapPath("~/temp/")))
            {
                Directory.CreateDirectory(page.Server.MapPath("~/temp/"));
            }
            //导出Excel保存的路径！
            String path = page.Server.MapPath("~/temp/" + fileName + ".xls");
            ExcelHelper.ExportDTtoExcel(dt, "名单", path);

            System.IO.FileInfo file = new System.IO.FileInfo(path);
            response.Clear();
            response.Charset = "utf-8";//设置输出的编码
            response.ContentEncoding = System.Text.Encoding.UTF8;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名
            response.AddHeader("Content-Disposition", "attachment; filename=" + page.Server.UrlEncode(file.Name));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度
            response.AddHeader("Content-Length", file.Length.ToString());
            // 指定返回的是一个不能被客户端读取的流，必须被下载
            response.ContentType = "application/excel";
            // 把文件流发送到客户端
            response.WriteFile(file.FullName);
            response.End();
        }

        /// <summary>
        /// 把DataTable转换成Excel文件并下载
        /// </summary>
        /// <param name="dt"></param>
        public static void DownloadExcel(DataTable dt, BasePage page)
        {
            DownloadExcel(dt, DateTime.Now.ToFileTime().ToString(), page);
        }

        /// <summary>
        /// 多表分页查询
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="selectField">选择的字段</param>
        /// <param name="tableNames">如"tbSubject,tbChapter"</param>
        /// <param name="strWhere1">如"tbSubject.id=tbChapter.subjectid"</param>
        /// <param name="strWhere2">自定义条件</param>
        /// <param name="filedOrder">排序字段</param>
        /// <returns></returns>
        public static DataSet GetListByIndex(int pageSize, int pageIndex, string selectField, string tableNames, string strWhere1, string strWhere2, string filedOrder)
        {
            //StringBuilder coreSql = new StringBuilder();
            //coreSql.Append("select ROW_NUMBER() OVER ");
            //if (filedOrder != "")
            //{
            //    coreSql.Append(" (ORDER BY " + filedOrder + ")");
            //}
            //coreSql.Append(" AS RowNumber," + selectField + " from " + tableNames + " ");
            //coreSql.Append(" where " + strWhere1 + " ");
            //if (strWhere2.Trim() != "")
            //{
            //    coreSql.Append(" and " + strWhere2);
            //}
            //String strSql = "SELECT TOP " + pageSize + " * FROM (" + coreSql.ToString() + ") A WHERE RowNumber > " + (pageIndex - 1) * pageSize;
            //PrintSql(strSql.ToString());
            //return DbHelperOleDb.Query(strSql.ToString());

            String id;
            int index = tableNames.IndexOf(',');
            if (index > 0)
            {
                id = tableNames.Substring(0, index) + ".id";
            }
            else
            {
                id = tableNames + ".id";
            }
            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " " + id + " from " + tableNames + " ");
            coreSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(" and " + strWhere2);
            }
            if (filedOrder != "")
            {
                coreSql.Append(" order by " + filedOrder + " ");
            }

            if (pageIndex == 1)
            {
                //access数据库不能使用select top 0
                coreSql.Remove(0, coreSql.Length);
                coreSql.Append("0");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " " + selectField + " from " + tableNames + " ");
            strSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                strSql.Append(" and " + strWhere2);
            }
            strSql.Append(" and " + id + " not in(" + coreSql.ToString() + ")");
            if (filedOrder != "")
            {
                strSql.Append(" order by " + filedOrder + " ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 存在group的SQL语句分页
        /// </summary>
        public static DataSet GetListByIndex2(int pageSize, int pageIndex, string selectField, string tableNames, string strWhere1, string strWhere2, String strGroup, String ids, string filedOrder)
        {
            String id = ids;

            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " " + id + " from " + tableNames + " ");
            coreSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(" and " + strWhere2);
            }
            if (strGroup.Trim() != "")
            {
                coreSql.Append(" group by " + strGroup);
            }
            if (filedOrder != "")
            {
                coreSql.Append(" order by " + filedOrder + " ");
            }

            if (pageIndex == 1)
            {
                //access数据库不能使用select top 0
                coreSql.Remove(0, coreSql.Length);
                coreSql.Append("0");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " " + selectField + " from " + tableNames + " ");
            strSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                strSql.Append(" and " + strWhere2);
            }
            strSql.Append(" and " + id + " not in(" + coreSql.ToString() + ")");
            if (strGroup.Trim() != "")
            {
                strSql.Append(" group by " + strGroup);
            }
            if (filedOrder != "")
            {
                strSql.Append(" order by " + filedOrder + " ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 存在join的SQL语句分页
        /// </summary>
        public static DataSet GetListByIndex3(int pageSize, int pageIndex, string selectField, string tableNames, string strWhere1, string strWhere2, string filedOrder)
        {
            String id = filedOrder;

            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " " + id + " from " + tableNames + " ");
            coreSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(strWhere2);
            }
            if (filedOrder != "")
            {
                coreSql.Append(" order by " + filedOrder + " ");
            }

            if (pageIndex == 1)
            {
                //access数据库不能使用select top 0
                coreSql.Remove(0, coreSql.Length);
                coreSql.Append("0");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " " + selectField + " from " + tableNames + " ");
            strSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                strSql.Append(strWhere2);
            }
            strSql.Append(" and " + id + " not in(" + coreSql.ToString() + ")");
            if (filedOrder != "")
            {
                strSql.Append(" order by " + filedOrder + " ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }      

        /// <summary>
        /// 获取多表查询的记录数
        /// </summary>
        /// <param name="tableNames">如"tbSubject,tbChapter"</param>
        /// <param name="strWhere1">如"tbSubject.id=tbChapter.subjectid"</param>
        /// <param name="strWhere2">自定义条件</param>
        /// <returns></returns>
        public static int GetCount(string tableNames, string strWhere1, string strWhere2)
        {
            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select count(*) from ");
            coreSql.Append(tableNames);
            coreSql.Append(" where ");
            coreSql.Append(strWhere1);
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(" and " + strWhere2);
            }
            return (int)DbHelperSQL.GetSingle(coreSql.ToString());
        }

        /// <summary>
        /// 获取所有数据源
        /// </summary>
        /// <param name="tableNames">如"tbSubject,tbChapter"</param>
        /// <param name="strWhere1">如"tbSubject.id=tbChapter.subjectid"</param>
        /// <param name="strWhere2">自定义条件</param>
        /// <returns></returns>
        public static DataTable GetAll(string field, string tableNames, string strWhere1, string strWhere2)
        {
            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select " + field + " from ");
            coreSql.Append(tableNames);
            coreSql.Append(" where ");
            coreSql.Append(strWhere1);
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(" and " + strWhere2);
            }
            return DbHelperSQL.Query(coreSql.ToString()).Tables[0];
        }

        public static DataTable GetAll(string sql)
        {
            return DbHelperSQL.Query(sql).Tables[0];
        }


        #region zhs
        /// <summary>
        /// 存在join的SQL语句分页
        /// </summary>
        public static DataSet GetListByIndexNew(int pageSize, int pageIndex, string selectField, string tableNames, string strWhere1, string strWhere2, string key,string filedOrder)
        {
            string id = key;

            StringBuilder coreSql = new StringBuilder();
            coreSql.Append("select top " + (pageIndex - 1) * pageSize + " " + id + " from " + tableNames + " ");
            coreSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                coreSql.Append(strWhere2);
            }
            if (filedOrder != "")
            {
                coreSql.Append(" order by " + filedOrder + " ");
            }

            if (pageIndex == 1)
            {
                //access数据库不能使用select top 0
                coreSql.Remove(0, coreSql.Length);
                coreSql.Append("0");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " " + selectField + " from " + tableNames + " ");
            strSql.Append(" where " + strWhere1 + " ");
            if (strWhere2.Trim() != "")
            {
                strSql.Append(strWhere2);
            }
            strSql.Append(" and " + id + " not in(" + coreSql.ToString() + ")");
            if (filedOrder != "")
            {
                strSql.Append(" order by " + filedOrder + " ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion zhs
    }
}