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
    public partial class YouthTalkLgDAL
    {
        /// <summary>
        /// 根据id获取图说理工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public YouthTalkLg GetListById(int id)
        {
            YouthTalkLg model = new YouthTalkLg();
            StringBuilder str = new StringBuilder();
            str.Append(" select * from talkLG ");
            str.Append(" where talk_id= " + id);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["talk_id"] != null)
                {
                    model.Talk_id = Convert.ToInt32(row["talk_id"].ToString());
                }
                if (row["talk_title"] != null)
                {
                    model.Talk_title = row["talk_title"].ToString();
                }
                if (row["talk_Img_url"] != null)
                {
                    model.Talk_Img_url = row["talk_Img_url"].ToString();
                }
                if (row["talk_content"] != null)
                {
                    model.Talk_content = row["talk_content"].ToString();
                }
                if (row["publisher"] != null)
                {
                    model.Publisher = row["publisher"].ToString();
                }
                if (row["publisher_phone"] != null)
                {
                    model.Publisher_phone = row["publisher_phone"].ToString();
                }
                if (row["publisher_mail"] != null)
                {
                    model.Publisher_mail = row["publisher_mail"].ToString();
                }
                if (row["publish_time"] != null)
                {
                    model.Publish_time = DateTime.Parse(row["publish_time"].ToString());
                }
                if (row["click_times"] != null)
                {
                    model.Click_times = Convert.ToInt32(row["click_times"].ToString());
                }
                if (row["talk_source"] != null)
                {
                    model.Talk_source = Convert.ToInt32(row["talk_source"].ToString());
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
        /// 根据条件获取前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetTopTalk(int top, string strWhere, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top  " + top + " * from talkLG  ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where " + strWhere);
            }
            str.Append(" order by " + order);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 首页分页获取图说理工列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string order, int startIndex, int endIndex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + (endIndex - startIndex + 1) + " * from talkLG ");
            str.Append(" where talk_id not in(");
            str.Append(" select top " + (startIndex - 1) + " talk_id from talkLG ");
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
            parameters[0].Value = "talkLG";
            parameters[1].Value = "talk_id";
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
        /// 获得满足条件的用户总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select count(1) from talkLG ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(str.ToString());
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        ///<summary>
        ///对阅读次数加1——新闻id
        ///</summary>
        ///
        public int AddReadCount(int talk_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("update talkLG set click_times=click_times+1 ");
            str.Append(" where talk_id=@talk_id");
            SqlParameter[] parameters = {
					new SqlParameter("@talk_id", SqlDbType.Int,8)
			};
            parameters[0].Value = talk_id;
            return DbHelperSQL.ExecuteSql(str.ToString(), parameters);
        }

        /// <summary>
        /// 添加图说理工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddTalkLG(YouthTalkLg model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into talkLG ");
            str.Append("(talk_title,talk_Img_url,talk_content,publisher,publisher_phone,publisher_mail,publish_time,click_times,talk_source,last_updater,last_update_time,is_check,checker,check_time,rechecker,recheck_time )");
            str.Append("values");
            str.Append(" (@talk_title,@talk_Img_url,@talk_content,@publisher,@publisher_phone,@publisher_mail,@publish_time,@click_times,@talk_source,@last_updater,@last_update_time,@is_check,@checker,@check_time,@rechecker,@recheck_time ) ");
            SqlParameter[] parameters = {
                    new SqlParameter("@talk_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@talk_Img_url", SqlDbType.NVarChar,50),
                    new SqlParameter("@talk_content", SqlDbType.NText),
                    new SqlParameter("@publisher", SqlDbType.NVarChar,25),
                    new SqlParameter("@publisher_phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@publisher_mail", SqlDbType.NVarChar,50),
                    new SqlParameter("@publish_time", SqlDbType.DateTime),
                    new SqlParameter("@click_times", SqlDbType.Int,8),
                    new SqlParameter("@talk_source", SqlDbType.Int,8),
                    new SqlParameter("@last_updater", SqlDbType.NVarChar,25),
                    new SqlParameter("@last_update_time", SqlDbType.DateTime),
                    new SqlParameter("@is_check", SqlDbType.VarChar,10),
                    new SqlParameter("@checker", SqlDbType.NVarChar,25),
                    new SqlParameter("@check_time", SqlDbType.DateTime),
                    new SqlParameter("@rechecker", SqlDbType.NVarChar,25),
                    new SqlParameter("@recheck_time", SqlDbType.DateTime)
                                         };
            parameters[0].Value = model.Talk_title;
            parameters[1].Value = model.Talk_Img_url;
            parameters[2].Value = model.Talk_content;
            parameters[3].Value = model.Publisher;
            parameters[4].Value = model.Publisher_phone;
            parameters[5].Value = model.Publisher_mail;
            parameters[6].Value = model.Publish_time;
            parameters[7].Value = model.Click_times;
            parameters[8].Value = model.Talk_source;
            parameters[9].Value = model.Last_updater;
            parameters[10].Value = model.Last_update_time;
            parameters[11].Value = model.Is_check;
            parameters[12].Value = model.Checker;
            parameters[13].Value = model.Check_time;
            parameters[14].Value = model.Rechecker;
            parameters[15].Value = model.Recheck_time;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 审核图说理工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CheckTalkLg(YouthTalkLg model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update talkLG set ");
            str.Append(" is_check=@is_check,");
            str.Append(" checker=@checker,");
            str.Append(" check_time=@check_time ");
            str.Append(" where talk_id=@talk_id ");
            SqlParameter[] parameters = { 
                                        new SqlParameter("@is_check",SqlDbType.VarChar,10),
                                        new SqlParameter("@checker",SqlDbType.NVarChar,25),
                                        new SqlParameter("@check_time",SqlDbType.DateTime),
                                        new SqlParameter("@talk_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Is_check;
            parameters[1].Value = model.Checker;
            parameters[2].Value = model.Check_time;
            parameters[3].Value = model.Talk_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 反审核图说理工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ReCheckTalkLg(YouthTalkLg model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update talkLG set ");
            str.Append(" is_check=@is_check,");
            str.Append(" rechecker=@rechecker,");
            str.Append(" recheck_time=@recheck_time ");
            str.Append(" where talk_id=@talk_id ");
            SqlParameter[] parameters = { 
                                        new SqlParameter("@is_check",SqlDbType.VarChar,10),
                                        new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                                        new SqlParameter("@recheck_time",SqlDbType.DateTime),
                                        new SqlParameter("@talk_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Is_check;
            parameters[1].Value = model.Rechecker;
            parameters[2].Value = model.Recheck_time;
            parameters[3].Value = model.Talk_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除图说理工
        /// </summary>
        /// <param name="talk_id"></param>
        /// <returns></returns>
        public int DelTalkLg(int talk_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from talkLG  ");
            str.Append(" where talk_id= " + talk_id);
            int rows = DbHelperSQL.ExecuteSql(str.ToString());
            return rows;
        }

        /// <summary>
        /// 更新图说理工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdTalkLg(YouthTalkLg model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update talkLG set  ");
            str.Append(" talk_title=@talk_title, ");
            str.Append("talk_Img_url=@talk_Img_url,");
            str.Append(" talk_content=@talk_content, ");
            str.Append(" publisher=@publisher, ");
            str.Append(" publisher_phone=@publisher_phone, ");
            str.Append(" publisher_mail=@publisher_mail, ");
            str.Append(" publish_time=@publish_time, ");
            str.Append(" click_times=@click_times, ");
            str.Append(" talk_source=@talk_source, ");
            str.Append(" last_updater=@last_updater, ");
            str.Append(" last_update_time=@last_update_time, ");
            str.Append(" is_check=@is_check, ");
            str.Append(" checker=@checker, ");
            str.Append(" check_time=@check_time, ");
            str.Append(" rechecker=@rechecker, ");
            str.Append(" recheck_time=@recheck_time ");
            str.Append(" where talk_id=@talk_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@talk_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@talk_Img_url", SqlDbType.NVarChar,50),
                    new SqlParameter("@talk_content", SqlDbType.NText),
                    new SqlParameter("@publisher", SqlDbType.NVarChar,25),
                    new SqlParameter("@publisher_phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@publisher_mail", SqlDbType.NVarChar,50),
                    new SqlParameter("@publish_time", SqlDbType.DateTime),
                    new SqlParameter("@click_times", SqlDbType.Int,8),
                    new SqlParameter("@talk_source", SqlDbType.Int,8),
                    new SqlParameter("@last_updater", SqlDbType.NVarChar,25),
                    new SqlParameter("@last_update_time", SqlDbType.DateTime),
                    new SqlParameter("@is_check", SqlDbType.VarChar,10),
                    new SqlParameter("@checker", SqlDbType.NVarChar,25),
                    new SqlParameter("@check_time", SqlDbType.DateTime),
                    new SqlParameter("@rechecker", SqlDbType.NVarChar,25),
                    new SqlParameter("@recheck_time", SqlDbType.DateTime),
                    new SqlParameter("@talk_id",SqlDbType.Int,8)
                                         };
            parameters[0].Value = model.Talk_title;
            parameters[1].Value = model.Talk_Img_url;
            parameters[2].Value = model.Talk_content;
            parameters[3].Value = model.Publisher;
            parameters[4].Value = model.Publisher_phone;
            parameters[5].Value = model.Publisher_mail;
            parameters[6].Value = model.Publish_time;
            parameters[7].Value = model.Click_times;
            parameters[8].Value = model.Talk_source;
            parameters[9].Value = model.Last_updater;
            parameters[10].Value = model.Last_update_time;
            parameters[11].Value = model.Is_check;
            parameters[12].Value = model.Checker;
            parameters[13].Value = model.Check_time;
            parameters[14].Value = model.Rechecker;
            parameters[15].Value = model.Recheck_time;
            parameters[16].Value = model.Talk_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }
    }
}
