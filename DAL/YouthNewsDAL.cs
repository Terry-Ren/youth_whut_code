using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.Utility;
using System.Data.SqlClient;
using AUTO.Model;

namespace AUTO.DAL
{
    public partial class YouthNewsDAL
    {
        ///<summary>
        ///取得新闻列表前几行数据
        ///</summary>
        ///
        //public DataSet GetList(int news_column_id, int top, string order)
        //{
        //    StringBuilder str = new StringBuilder();
        //    str.Append("select ");
        //    if (top > 0)
        //    {
        //        str.Append("top " + top);
        //    }
        //    str.Append(" news_id,news_title,news_content,publish_time ");
        //    str.Append(" from news ");
        //    str.Append("where news_father_id=" + news_column_id);
        //    str.Append(" and is_check='Y' ");
        //    str.Append(" order by  " + order);
        //    DataSet result = DbHelperSQL.Query(str.ToString());
        //    return result;
        //}
        public DataSet GetList(int top, string strWhere, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select ");
            if (top > 0)
            {
                str.Append("top " + top);
            }
            str.Append(" news_id,news_title,news_content,publisher,publish_time ");
            str.Append(" from news ");
            if (strWhere.Trim() != "")
            {
                str.Append("where " + strWhere);
            }
            if (order.Trim() != "")
            {
                str.Append(" order by  " + order);
            }
            DataSet result = DbHelperSQL.Query(str.ToString());
            return result;
        }

        /// <summary>
        /// 根据一系列条件得到去除第一条数据后的几条新闻
        /// select * from news where news_id not in(select top 1 news_id from news where news_father_id=1 and is_check='Y' order by publish_time desc) and news_father_id=1 and is_check='Y' order by publish_time desc
        /// </summary>
        /// <param name="strWhere1"></param>
        /// <param name="strWhere2"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetOtherFirstList(int top, string strWhere1, string strWhere2, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top  " + top);
            str.Append(" * from news  ");
            str.Append(" where " + strWhere1);
            str.Append(" not in (select top 1 " + strWhere1 + " from news where " + strWhere2 + " order by " + order + ") ");
            str.Append(" and " + strWhere2);
            str.Append(" order by  " + order);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 得到排序后的第一条新闻实体
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public YouthNews GetFirstList(string strWhere, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top 1 * from news ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where  " + strWhere);
            }
            str.Append(" order by  " + order);
            DataSet result = DbHelperSQL.Query(str.ToString());
            if (result.Tables[0].Rows.Count > 0)
            {
                return GetModel(result.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取首页大图展示新闻
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetHomeImg(int top, string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + top + " * from news  ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where " + strWhere);
            }
            str.Append(" order by last_update_time desc ");
            DataSet result = DbHelperSQL.Query(str.ToString());
            return result;
        }


        ///<summary>
        ///获得新闻列表—根据news_column_id,order by
        ///</summary>
        ///
        //public DataSet GetList(int news_column_id, string order)
        //{
        //    StringBuilder str = new StringBuilder();
        //    str.Append("select ");
        //    str.Append("news_id,news_title,news_content,publish_time,news_father_id ");
        //    str.Append(" from news ");
        //    str.Append(" where news_father_id=@news_father_id ");
        //    str.Append(" and is_check='Y' ");
        //    str.Append(" order by  " + order);
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@news_father_id",SqlDbType.Int,8)
        //    };
        //    parameters[0].Value = news_column_id;
        //    DataSet result = DbHelperSQL.Query(str.ToString(), parameters);
        //    return result;
        //}
        public DataSet GetList(string strWhere, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select ");
            str.Append("news_id,news_title,news_content,publish_time,news_father_id ");
            str.Append(" from news ");
            if (strWhere.Trim() != "")
            {
                str.Append("where " + strWhere);
            }
            str.Append(" order by  " + order);
            DataSet result = DbHelperSQL.Query(str.ToString());
            return result;
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
            parameters[0].Value = "news";
            parameters[1].Value = "news_id";
            parameters[2].Value = pageIndex;
            parameters[3].Value = pageSize;
            parameters[4].Value = sortString;
            parameters[5].Value = strWhere;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            /*注：没有参数 @FieldShow，则默认显示表或视图中的所有字段*/
            return DbHelperSQL.RunProcedures("sp_PageList", parameters);
        }


        ///<summary>
        ///分页获取新闻列表—根据news_column_id,order by,startIndex,endIndex
        ///</summary>
        ///
        //public DataSet GetListByPage(int news_column_id, string order, int startIndex, int endIndex)
        //{
        //    StringBuilder str = new StringBuilder();
        //    str.Append(" select top " + (endIndex - startIndex + 1) + " * from news ");
        //    str.Append(" where news_id not in(");
        //    str.Append(" select top " + (startIndex - 1) + " news_id from news ");
        //    if (!String.IsNullOrEmpty(order))
        //    {
        //        str.Append(" order by " + order);
        //    }
        //    str.Append(")");
        //    str.Append(" and news_father_id=" + news_column_id);
        //    if (!String.IsNullOrEmpty(order))
        //    {
        //        str.Append(" order by " + order);
        //    }
        //    return DbHelperSQL.Query(str.ToString());
        //}

        public DataSet GetListByPage(string strWhere, string order, int startIndex, int endIndex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select * from news where 1=1  ");
            if (strWhere.Trim() != "")
            {
                str.Append(" and " + strWhere);
            }
            String sql = "";
            int top = endIndex - startIndex+1;
            sql = " select top " + top + " * from (select m.*, ROW_NUMBER() over (order by m.publish_time desc) as rownumber from(" + str.ToString() + ")m)t ";
            sql += " where t.rownumber<=" + endIndex + " and t.rownumber>" + (startIndex-1) + " ";
            return DbHelperSQL.Query(sql);


            /*
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + (endIndex - startIndex + 1) + " * from news ");
            str.Append(" where news_id not in(");
            str.Append(" select top " + (startIndex - 1) + " news_id from news ");
            //str.Append(" select top " + (startIndex-1) + " * from (select top "+endIndex+" * from news ");
            if (!String.IsNullOrEmpty(order))
            {
                str.Append(" order by " + order);
            }
            str.Append(")");
            if (strWhere.Trim() != "")
            {
                str.Append(" and " + strWhere);
                //str.Append(" where " + strWhere);
            }
           // if (!String.IsNullOrEmpty(order))
           // {
           //     str.Append(" order by " + order);
            //}
            //str.Append(" )a");
            //if (!String.IsNullOrEmpty(order))
            //{
            //    str.Append(" order by " + order);
            //}
            return DbHelperSQL.Query(str.ToString());
            */

        }

        ///<summary>
        ///获取新闻列表记录总数
        ///</summary>
        ///
        //public int GetRecordCount(int news_column_id)
        //{
        //    StringBuilder str = new StringBuilder();
        //    str.Append(" select count(1) from news ");
        //    str.Append(" where news_father_id=" + news_column_id);
        //    object result = DbHelperSQL.GetSingle(str.ToString());
        //    if (result == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //       return Convert.ToInt32(result);
        //    }
        //}
        public int GetRecordCount(string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select count(1) from news ");
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

        ///<summary>
        ///获得新闻实体—根据news_id
        ///</summary>
        ///
        public YouthNews GetYouthNews(int news_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select * from news ");
            str.Append(" where news_id=@news_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@news_id", SqlDbType.Int,8)
			};
            parameters[0].Value = news_id;
            DataSet result = DbHelperSQL.Query(str.ToString(), parameters);
            if (result.Tables[0].Rows.Count > 0)
            {
                return GetModel(result.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        //得到新闻对象实体
        public YouthNews GetModel(DataRow row)
        {
            YouthNews model = new YouthNews();
            if (row != null)
            {
                if (row["news_id"] != null)
                {
                    model.News_id = int.Parse(row["news_id"].ToString());
                }
                if (row["news_title"] != null)
                {
                    model.News_title = row["news_title"].ToString();
                }
                if (row["news_content"] != null)
                {
                    model.News_content = row["news_content"].ToString();
                }
                if (row["news_father_id"] != null)
                {
                    model.News_father_id = int.Parse(row["news_father_id"].ToString());
                }
                else
                {
                    model.News_father_id = 0;
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
                    model.Publish_time = (DateTime)(row["publish_time"]);
                }
                if (row["click_times"] != null)
                {
                    model.Click_times = int.Parse(row["click_times"].ToString());
                }
                if (row["news_source"] != null)
                {
                    model.News_source = int.Parse(row["news_source"].ToString());
                }
                if (row["last_updater"] != null)
                {
                    model.Last_update = row["last_updater"].ToString();
                }
                else
                {
                    model.Last_update = "";
                }
                if (row["last_update_time"] != null)
                {
                    model.Last_update_time = DateTime.Parse(row["last_update_time"].ToString());
                }
                else
                {
                    model.Last_update_time = DateTime.Today;
                }
                if (row["is_check"] != null)
                {
                    model.Is_check = row["is_check"].ToString();
                }
                else
                {
                    model.Is_check = "N";
                }
                if (row["checker"] != null)
                {
                    model.Checker = row["checker"].ToString();
                }
                else
                {
                    model.Checker = "";
                }
                if (row["check_time"] != null)
                {
                    model.Check_time = DateTime.Parse(row["check_time"].ToString());
                }
                else
                {
                    model.Check_time = DateTime.Today;
                }
                if (row["rechecker"] != null)
                {
                    model.Rechecker = row["rechecker"].ToString();
                }
                else
                {
                    model.Rechecker = "";
                }
                if (row["recheck_time"] != null&&!"".Equals(row["recheck_time"].ToString()))
                {
                    model.Recheck_time = DateTime.Parse(row["recheck_time"].ToString());
                }
                else
                {
                    model.Recheck_time = DateTime.Today;
                }
                if (row["is_photoNews"] != null)
                {
                    model.Is_photoNews = row["is_photoNews"].ToString();
                }
                else
                {
                    model.Is_photoNews = "N";
                }
                if (row["photo_url"] != null)
                {
                    model.Photo_url = row["photo_url"].ToString();
                }
                else
                {
                    model.Photo_url = "";
                }
            }
            return model;

        }

        ///<summary>
        ///对阅读次数加1——新闻id
        ///</summary>
        ///
        public int AddReadCount(int news_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("update news set click_times=click_times+1 ");
            str.Append(" where news_id=@news_id");
            SqlParameter[] parameters = {
					new SqlParameter("@news_id", SqlDbType.Int,8)
			};
            parameters[0].Value = news_id;
            return DbHelperSQL.ExecuteSql(str.ToString(), parameters);
        }


        /// <summary>
        /// 在线投稿，添加新闻
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddYouthNews(YouthNews model)
        {
            StringBuilder str = new StringBuilder();
            str.Append("insert into news (");
            str.Append("news_title,news_content,news_father_id,publisher,publisher_phone, publisher_mail,publish_time,click_times,news_source,last_updater,last_update_time,is_check,checker,check_time,rechecker,recheck_time)");
            str.Append(" values (@news_title,@news_content,@news_father_id,@publisher,@publisher_phone, @publisher_mail,@publish_time,@click_times,@news_source,@last_updater,@last_update_time,@is_check,@checker,@check_time,@rechecker,@recheck_time");
            str.Append(")");
            SqlParameter[] parameters = {
					new SqlParameter("@news_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@news_content",SqlDbType.NText),
                    new SqlParameter("@news_father_id",SqlDbType.Int,8),
                    new SqlParameter("@publisher",SqlDbType.NVarChar,25),
                    new SqlParameter("@publisher_phone",SqlDbType.NVarChar,50),
                    new SqlParameter("@publisher_mail",SqlDbType.NVarChar,50),
                    new SqlParameter("@publish_time",SqlDbType.DateTime),
                    new SqlParameter("@click_times",SqlDbType.Int,8),
                    new SqlParameter("@news_source",SqlDbType.Int,8),
                    new SqlParameter("@last_updater",SqlDbType.NVarChar,25),
                    new SqlParameter("@last_update_time",SqlDbType.DateTime),
                    new SqlParameter("@is_check",SqlDbType.VarChar,8),
                    new SqlParameter("@checker",SqlDbType.NVarChar,25),
                    new SqlParameter("@check_time",SqlDbType.DateTime),
                    new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                    new SqlParameter("@recheck_time",SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.News_title;
            parameters[1].Value = model.News_content;
            parameters[2].Value = model.News_father_id;
            parameters[3].Value = model.Publisher;
            parameters[4].Value = model.Publisher_phone;
            parameters[5].Value = model.Publisher_mail;
            parameters[6].Value = model.Publish_time;
            parameters[7].Value = model.Click_times;
            parameters[8].Value = model.News_source;
            parameters[9].Value = model.Last_update;
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
        /// 更新编辑新闻
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdYouthNews(YouthNews model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update news set ");
            str.Append(" news_title=@news_title,");
            str.Append(" news_content=@news_content,");
            str.Append(" news_father_id=@news_father_id,");
            str.Append(" publisher=@publisher,");
            str.Append(" publisher_phone=@publisher_phone,");
            str.Append(" publisher_mail=@publisher_mail,");
            str.Append(" publish_time=@publish_time,");
            str.Append(" click_times=@click_times,");
            str.Append(" news_source=@news_source,");
            str.Append(" last_updater=@last_updater,");
            str.Append(" last_update_time=@last_update_time,");
            str.Append("is_check=@is_check,");
            str.Append(" checker=@checker,");
            str.Append(" check_time=@check_time,");
            str.Append(" rechecker=@rechecker,");
            str.Append(" recheck_time=@recheck_time,");
            str.Append(" is_photoNews=@is_photoNews,");
            str.Append(" photo_url=@photo_url ");
            str.Append(" where news_id=@news_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@news_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@news_content",SqlDbType.NText),
                    new SqlParameter("@news_father_id",SqlDbType.Int,8),
                    new SqlParameter("@publisher",SqlDbType.NVarChar,25),
                    new SqlParameter("@publisher_phone",SqlDbType.NVarChar,50),
                    new SqlParameter("@publisher_mail",SqlDbType.NVarChar,50),
                    new SqlParameter("@publish_time",SqlDbType.DateTime),
                    new SqlParameter("@click_times",SqlDbType.Int,8),
                    new SqlParameter("@news_source",SqlDbType.Int,8),
                    new SqlParameter("@last_updater",SqlDbType.NVarChar,25),
                    new SqlParameter("@last_update_time",SqlDbType.DateTime),
                    new SqlParameter("@is_check",SqlDbType.VarChar,8),
                    new SqlParameter("@checker",SqlDbType.NVarChar,25),
                    new SqlParameter("@check_time",SqlDbType.DateTime),
                    new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                    new SqlParameter("@recheck_time",SqlDbType.DateTime),
                    new SqlParameter("@is_photoNews",SqlDbType.VarChar,10),
                    new SqlParameter("@photo_url",SqlDbType.NVarChar,50),
                    new SqlParameter("@news_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.News_title;
            parameters[1].Value = model.News_content;
            parameters[2].Value = model.News_father_id;
            parameters[3].Value = model.Publisher;
            parameters[4].Value = model.Publisher_phone;
            parameters[5].Value = model.Publisher_mail;
            parameters[6].Value = model.Publish_time;
            parameters[7].Value = model.Click_times;
            parameters[8].Value = model.News_source;
            parameters[9].Value = model.Last_update;
            parameters[10].Value = model.Last_update_time;
            parameters[11].Value = model.Is_check;
            parameters[12].Value = model.Checker;
            parameters[13].Value = model.Check_time;
            parameters[14].Value = model.Rechecker;
            parameters[15].Value = model.Recheck_time;
            parameters[16].Value = model.Is_photoNews;
            parameters[17].Value = model.Photo_url;
            parameters[18].Value = model.News_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;

        }

        /// <summary>
        /// 审核新闻
        /// </summary>
        /// <param name="news_id"></param>
        /// <returns></returns>
        public int CheckNews(int news_id, string operate_name)
        {
            StringBuilder str = new StringBuilder();
            str.Append("update news set ");
            str.Append(" is_check='Y', ");
            str.Append(" checker=@checker, ");
            str.Append(" check_time=@check_time ");
            str.Append(" where news_id=@news_id ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@checker",SqlDbType.NVarChar,25),
                                            new SqlParameter("@check_time",SqlDbType.DateTime),
					                        new SqlParameter("@news_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = operate_name;
            parameters[1].Value = DateTime.Today;
            parameters[2].Value = news_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 取消审核新闻
        /// </summary>
        /// <param name="news_id"></param>
        /// <returns></returns>
        public int ReCheckNews(int news_id, string operate_name)
        {
            StringBuilder str = new StringBuilder();
            str.Append("update news set ");
            str.Append(" is_check='N', ");
            str.Append(" rechecker=@rechecker, ");
            str.Append(" recheck_time=@recheck_time ");
            str.Append(" where news_id=@news_id ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                                            new SqlParameter("@recheck_time",SqlDbType.DateTime),
					                        new SqlParameter("@news_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = operate_name;
            parameters[1].Value = DateTime.Today;
            parameters[2].Value = news_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="news_id"></param>
        /// <returns></returns>
        public int DeleteNews(int news_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from news ");
            str.Append(" where news_id=@news_id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@news_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = news_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 决定首页是否显示图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int updNewsImage(YouthNews model)
        {
            StringBuilder str = new StringBuilder();
            str.Append("update news set ");
            str.Append(" last_updater=@last_updater,");
            str.Append(" last_update_time=@last_update_time,");
            str.Append(" is_photoNews=@is_photoNews, ");
            str.Append(" photo_url=@photo_url ");
            str.Append(" where news_id=@news_id ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@last_updater",SqlDbType.NVarChar,25),
                                            new SqlParameter("@last_update_time",SqlDbType.DateTime),
                                            new SqlParameter("@is_photoNews",SqlDbType.VarChar,10),
                                            new SqlParameter("@photo_url",SqlDbType.NVarChar,50),
					                        new SqlParameter("@news_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Last_update;
            parameters[1].Value = model.Last_update_time;
            parameters[2].Value = model.Is_photoNews;
            parameters[3].Value = model.Photo_url;
            parameters[4].Value = model.News_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 根据新闻id得到新闻来源id
        /// </summary>
        /// <param name="news_id"></param>
        /// <returns></returns>
        public int GetSourceById(int news_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select news_source from news  ");
            str.Append(" where news_id= " + news_id);
            object obj = DbHelperSQL.GetSingle(str.ToString());
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 根据一系列条件在后台得到稿件排行
        /// </summary>
        /// <param name="inWhere"></param>
        /// <param name="outWhere"></param>
        /// <returns></returns>
        public DataSet GetRankByCondition(string inWhere, string outWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select row_number() over (order by a.account desc) as rank, ");
            str.Append(" a.account,b.academic_name from ");
            str.Append(" (select count(news_source) as account,news_source from news where " + inWhere + " group by news_source) a, ");
            str.Append(" academic b where " + outWhere + " ");
            return DbHelperSQL.Query(str.ToString());
        }
    }
}
