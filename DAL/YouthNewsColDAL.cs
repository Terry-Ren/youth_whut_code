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
    public partial class YouthNewsColDAL
    {
        /// <summary>
        /// 根据id得到新闻版块
        /// </summary>
        /// <param name="news_col_id"></param>
        /// <returns></returns>
        public YouthNewsColumn GetListById(int news_col_id)
        {
            YouthNewsColumn model = new YouthNewsColumn();
            StringBuilder str = new StringBuilder();
            str.Append(" select * from news_column  ");
            str.Append(" where news_column_id=" + news_col_id);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["news_column_id"] != null)
                {
                    model.News_column_id = Convert.ToInt32(ds.Tables[0].Rows[0]["news_column_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["news_column_name"] != null)
                {
                    model.News_column_name = ds.Tables[0].Rows[0]["news_column_name"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        ///<summary>
        ///得到新闻栏目列表
        ///</summary>
        ///
        public DataSet GetNewsCol()
        {
            StringBuilder str = new StringBuilder();
            str.Append("select ");
            str.Append("news_column_id, news_column_name ");
            str.Append(" from news_column ");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 根据条件得到新闻版块
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetNewsColList(String where)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select ");
            str.Append("news_column_id, news_column_name ");
            str.Append(" from news_column ");
            if (!String.IsNullOrEmpty(where))
            {
                str.Append(" where  " + where);
            }
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
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
            parameters[0].Value = "news_column";
            parameters[1].Value = "news_column_id";
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
        /// 获取新闻版块总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select count(1) from news_column ");
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
        /// 添加新闻版块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNewsCol(YouthNewsColumn model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into news_column ");
            str.Append(" (news_column_name) ");
            str.Append(" values ");
            str.Append(" (@news_column_name) ");
            SqlParameter[] parameters = {
                    new SqlParameter("@news_column_name", SqlDbType.NVarChar,25)
                                        };
            parameters[0].Value = model.News_column_name;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除新闻版块
        /// </summary>
        /// <param name="news_column_id"></param>
        /// <returns></returns>
        public int DelNewsCol(int news_column_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from news_column ");
            str.Append(" where news_column_id= " + news_column_id);
            int rows = DbHelperSQL.ExecuteSql(str.ToString());
            return rows;
        }

        /// <summary>
        /// 更新新闻版块
        /// </summary>
        /// <param name="news_column_id"></param>
        /// <returns></returns>
        public int UpdNewsCol(YouthNewsColumn model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update news_column set  ");
            str.Append(" news_column_name=@news_column_name ");
            str.Append(" where news_column_id=@news_column_id  ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@news_column_name", SqlDbType.NVarChar,25),
                                            new SqlParameter("@news_column_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.News_column_name;
            parameters[1].Value = model.News_column_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }
    }
}
