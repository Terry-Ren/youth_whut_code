using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AUTO.Utility;
using AUTO.Model;

namespace AUTO.DAL
{
    public partial class YouthSpecialSubConDAL
    {

        /// <summary>
        /// 取得指定专题下的新闻列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetList(int top, string strWhere, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select ");
            if (top > 0)
            {
                str.Append("top " + top);
            }
            str.Append(" * from special_sub_content ");
            if (strWhere.Trim() != "")
            {
                str.Append("where " + strWhere);
            }
            str.Append(" order by  " + order);
            DataSet result = DbHelperSQL.Query(str.ToString());
            return result;
        }

        /// <summary>
        /// 取得指定专题下的分页新闻列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string order, int startIndex, int endIndex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + (endIndex - startIndex + 1) + " * from special_sub_content ");
            str.Append(" where content_id not in(");
            str.Append(" select top " + (startIndex - 1) + " content_id from special_sub_content ");
            if (!String.IsNullOrEmpty(order))
            {
                str.Append(" order by " + order);
            }
            str.Append(")");
            if (strWhere.Trim() != "")
            {
                str.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(str.ToString());
        }

        /// <summary>
        /// 得到专题目录下的内容列表
        /// </summary>
        /// <param name="sub_id"></param>
        /// <returns></returns>
        public DataSet GetListBySubId(int sub_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select * from special_sub_content  ");
            str.Append(" where sub_id=@sub_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@sub_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = sub_id;
            DataSet ds = DbHelperSQL.Query(str.ToString(), parameters);
            return ds;
        }

        /// <summary>
        /// 根据id得到内容实体
        /// </summary>
        /// <param name="content_id"></param>
        /// <returns></returns>
        public YouthSpecialSubContent GetListById(int content_id)
        {
            YouthSpecialSubContent model = new YouthSpecialSubContent();
            StringBuilder str = new StringBuilder();
            str.Append(" select * from special_sub_content ");
            str.Append(" where content_id=" + content_id);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["content_id"] != null)
                {
                    model.Content_id = Convert.ToInt32(row["content_id"].ToString());
                }
                if (row["special_id"] != null)
                {
                    model.Special_id = Convert.ToInt32(row["special_id"].ToString());
                }
                if (row["sub_id"] != null)
                {
                    model.Sub_id = Convert.ToInt32(row["sub_id"].ToString());
                }
                if (row["content_title"] != null)
                {
                    model.Content_title = row["content_title"].ToString();
                }
                if (row["content_content"] != null)
                {
                    model.Content_content = row["content_content"].ToString();
                }
                if (row["content_publisher"] != null)
                {
                    model.Content_publisher = row["content_publisher"].ToString();
                }
                if (row["content_email"] != null)
                {
                    model.Content_email = row["content_email"].ToString();
                }
                if (row["content_phone"] != null)
                {
                    model.Content_phone = row["content_phone"].ToString();
                }
                if (row["content_publish_time"] != null)
                {
                    model.Content_publish_time = DateTime.Parse(row["content_publish_time"].ToString());
                }
                if (row["content_click_times"] != null)
                {
                    model.Content_click_times = Convert.ToInt32(row["content_click_times"].ToString());
                }
                if (row["content_source"] != null)
                {
                    model.Content_source = Convert.ToInt32(row["content_source"].ToString());
                }
                if (row["last_updater"] != null)
                {
                    model.Last_updater = row["last_updater"].ToString();
                }
                if (row["last_update_time"] != null)
                {
                    model.Last_update_time = DateTime.Parse(row["last_update_time"].ToString());
                }
                if (row["is_check"] != null)
                {
                    model.Is_check = row["is_check"].ToString();
                }
                if (row["checker"] != null)
                {
                    model.Checker = row["checker"].ToString();
                }
                if (row["check_time"] != null)
                {
                    model.Check_time = DateTime.Parse(row["check_time"].ToString());
                }
                if (row["rechecker"] != null)
                {
                    model.Rechecker = row["rechecker"].ToString();
                }
                if (row["recheck_time"] != null)
                {
                    model.Recheck_time = DateTime.Parse(row["recheck_time"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sortString"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, int pageSize, int pageIndex, string sortString)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tbname", SqlDbType.NVarChar,128),
                    new SqlParameter("@FieldKey", SqlDbType.NVarChar,128),
                    new SqlParameter("@PageCurrent", SqlDbType.Int,4),
                    new SqlParameter("@PageSize", SqlDbType.Int,4),
                    new SqlParameter("@FieldOrder", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Where", SqlDbType.NVarChar,1000),
                    new SqlParameter("@RecordCount", SqlDbType.Int,4),
                    new SqlParameter("@PageCount", SqlDbType.Int,4)
            };
            parameters[0].Value = "special_sub_content";
            parameters[1].Value = "content_id";
            parameters[2].Value = pageIndex;
            parameters[3].Value = pageSize;
            parameters[4].Value = sortString;
            parameters[5].Value = strWhere;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            /*注：没有参数 @FieldShow，则默认显示表或视图中的所有字段*/
            return DbHelperSQL.RunProcedures("sp_PageList", parameters);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select count(1) from special_sub_content ");
            if (strWhere.Trim() != "")
            {
                str.Append(" where " + strWhere);
            }
            object result = DbHelperSQL.GetSingle(str.ToString());
            if (result == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(result);
            }
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CheckCon(YouthSpecialSubContent model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update special_sub_content set ");
            str.Append(" is_check=@is_check, ");
            str.Append(" checker=@checker,");
            str.Append(" check_time=@check_time ");
            str.Append(" where content_id=@content_id ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@is_check",SqlDbType.VarChar,10),
                                            new SqlParameter("@checker",SqlDbType.NVarChar,25),
                                            new SqlParameter("@check_time",SqlDbType.DateTime),
					                        new SqlParameter("@content_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Is_check;
            parameters[1].Value = model.Checker;
            parameters[2].Value = model.Check_time;
            parameters[3].Value = model.Content_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 取消审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ReCheckCon(YouthSpecialSubContent model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update special_sub_content set ");
            str.Append(" is_check=@is_check, ");
            str.Append(" rechecker=@rechecker,");
            str.Append(" recheck_time=@recheck_time ");
            str.Append(" where content_id=@content_id ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@is_check",SqlDbType.VarChar,10),
                                            new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                                            new SqlParameter("@recheck_time",SqlDbType.DateTime),
					                        new SqlParameter("@content_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Is_check;
            parameters[1].Value = model.Rechecker;
            parameters[2].Value = model.Recheck_time;
            parameters[3].Value = model.Content_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="content_id"></param>
        /// <returns></returns>
        public int DelContent(int content_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from special_sub_content ");
            str.Append(" where content_id=@content_id ");
            SqlParameter[] parameters = {
					                        new SqlParameter("@content_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = content_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddContent(YouthSpecialSubContent model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into special_sub_content ");
            str.Append("(special_id,sub_id,content_title,content_content,content_publisher,content_email,content_phone,content_publish_time,content_click_times,content_source,last_updater,last_update_time,is_check,checker,check_time,rechecker,recheck_time )");
            str.Append(" values ");
            str.Append("(@special_id,@sub_id,@content_title,@content_content,@content_publisher,@content_email,@content_phone,@content_publish_time,@content_click_times,@content_source,@last_updater,@last_update_time,@is_check,@checker,@check_time,@rechecker,@recheck_time )");
            SqlParameter[] parameters = {
					                        new SqlParameter("@special_id", SqlDbType.Int,8),
					                        new SqlParameter("@sub_id", SqlDbType.Int,8),
                                            new SqlParameter("@content_title",SqlDbType.NVarChar,50),
                                            new SqlParameter("@content_content",SqlDbType.NText),
                                            new SqlParameter("@content_publisher",SqlDbType.NVarChar,50),
                                            new SqlParameter("@content_email",SqlDbType.NVarChar,50),
                                            new SqlParameter("@content_phone",SqlDbType.NVarChar,50),
                                            new SqlParameter("@content_publish_time",SqlDbType.DateTime),
                                            new SqlParameter("@content_click_times",SqlDbType.Int,8),
                                            new SqlParameter("@content_source",SqlDbType.Int,8),
                                            new SqlParameter("@last_updater",SqlDbType.NVarChar,50),
                                            new SqlParameter("@last_update_time",SqlDbType.DateTime),
                                            new SqlParameter("@is_check",SqlDbType.VarChar,10),
                                            new SqlParameter("@checker",SqlDbType.NVarChar,50),
                                            new SqlParameter("@check_time",SqlDbType.DateTime),
                                            new SqlParameter("@rechecker",SqlDbType.NVarChar,50),
                                            new SqlParameter("@recheck_time",SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.Special_id;
            parameters[1].Value = model.Sub_id;
            parameters[2].Value = model.Content_title;
            parameters[3].Value = model.Content_content;
            parameters[4].Value = model.Content_publisher;
            parameters[5].Value = model.Content_email;
            parameters[6].Value = model.Content_phone;
            parameters[7].Value = model.Content_publish_time;
            parameters[8].Value = model.Content_click_times;
            parameters[9].Value = model.Content_source;
            parameters[10].Value = model.Last_updater;
            parameters[11].Value = model.Last_update_time;
            parameters[12].Value = model.Is_check;
            parameters[13].Value = model.Checker;
            parameters[14].Value = model.Check_time;
            parameters[15].Value = model.Rechecker;
            parameters[16].Value = model.Recheck_time;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 更新内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdContent(YouthSpecialSubContent model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update special_sub_content set ");
            str.Append(" special_id=@special_id,");
            str.Append(" sub_id=@sub_id,");
            str.Append(" content_title=@content_title,");
            str.Append("content_content=@content_content,");
            str.Append(" content_publisher=@content_publisher,");
            str.Append(" content_email=@content_email,");
            str.Append(" content_phone=@content_phone,");
            str.Append(" content_publish_time=@content_publish_time,");
            str.Append(" content_click_times=@content_click_times,");
            str.Append("content_source=@content_source,");
            str.Append(" last_updater=@last_updater,");
            str.Append("last_update_time=@last_update_time,");
            str.Append("is_check=@is_check,");
            str.Append(" checker=@checker,");
            str.Append(" check_time=@check_time,");
            str.Append(" rechecker=@rechecker,");
            str.Append(" recheck_time=@recheck_time ");
            str.Append(" where content_id=@content_id ");
            SqlParameter[] parameters = {
					                        new SqlParameter("@special_id", SqlDbType.Int,8),
					                        new SqlParameter("@sub_id", SqlDbType.Int,8),
                                            new SqlParameter("@content_title",SqlDbType.NVarChar,50),
                                            new SqlParameter("@content_content",SqlDbType.NText),
                                            new SqlParameter("@content_publisher",SqlDbType.NVarChar,50),
                                            new SqlParameter("@content_email",SqlDbType.NVarChar,50),
                                            new SqlParameter("@content_phone",SqlDbType.NVarChar,50),
                                            new SqlParameter("@content_publish_time",SqlDbType.DateTime),
                                            new SqlParameter("@content_click_times",SqlDbType.Int,8),
                                            new SqlParameter("@content_source",SqlDbType.Int,8),
                                            new SqlParameter("@last_updater",SqlDbType.NVarChar,50),
                                            new SqlParameter("@last_update_time",SqlDbType.DateTime),
                                            new SqlParameter("@is_check",SqlDbType.VarChar,10),
                                            new SqlParameter("@checker",SqlDbType.NVarChar,50),
                                            new SqlParameter("@check_time",SqlDbType.DateTime),
                                            new SqlParameter("@rechecker",SqlDbType.NVarChar,50),
                                            new SqlParameter("@recheck_time",SqlDbType.DateTime),
                                            new SqlParameter("@content_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Special_id;
            parameters[1].Value = model.Sub_id;
            parameters[2].Value = model.Content_title;
            parameters[3].Value = model.Content_content;
            parameters[4].Value = model.Content_publisher;
            parameters[5].Value = model.Content_email;
            parameters[6].Value = model.Content_phone;
            parameters[7].Value = model.Content_publish_time;
            parameters[8].Value = model.Content_click_times;
            parameters[9].Value = model.Content_source;
            parameters[10].Value = model.Last_updater;
            parameters[11].Value = model.Last_update_time;
            parameters[12].Value = model.Is_check;
            parameters[13].Value = model.Checker;
            parameters[14].Value = model.Check_time;
            parameters[15].Value = model.Rechecker;
            parameters[16].Value = model.Recheck_time;
            parameters[17].Value = model.Content_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;

        }

        ///<summary>
        ///对阅读次数加1——新闻id
        ///</summary>
        ///
        public int AddReadCount(int content_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("update special_sub_content set content_click_times=content_click_times+1 ");
            str.Append(" where content_id=@content_id");
            SqlParameter[] parameters = {
					new SqlParameter("@content_id", SqlDbType.Int,8)
			};
            parameters[0].Value = content_id;
            return DbHelperSQL.ExecuteSql(str.ToString(), parameters);
        }
    }
}
