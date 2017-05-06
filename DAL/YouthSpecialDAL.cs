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
    public partial class YouthSpecialDAL
    {
        /// <summary>
        /// 根据id得到一个专题实体对象
        /// </summary>
        /// <param name="special_id"></param>
        /// <returns></returns>
        public YouthSpecial GetListById(int special_id)
        {
            YouthSpecial model = new YouthSpecial();
            StringBuilder str = new StringBuilder();
            str.Append(" select * from special ");
            str.Append(" where special_id=@special_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@special_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = special_id;
            DataSet ds = DbHelperSQL.Query(str.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["special_id"] != null)
                {
                    model.Special_id = Convert.ToInt32(ds.Tables[0].Rows[0]["special_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["special_title"] != null)
                {
                    model.Special_title = ds.Tables[0].Rows[0]["special_title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["special_img_url"] != null)
                {
                    model.Special_img_url = ds.Tables[0].Rows[0]["special_img_url"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到专题列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select * from special ");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }



        /// <summary>
        /// 获取前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetTopList(int top, string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + top + " * from special ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 按条件获取精品专题列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetSpecial(int top, string strWhere, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top  " + top + " * from special ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where " + strWhere);
            }
            if (!String.IsNullOrEmpty(order))
            {
                str.Append(" order by  " + order);
            }
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 首页分页获取精品专题列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string order, int startIndex, int endIndex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + (endIndex - startIndex + 1) + " * from special ");
            str.Append(" where special_id not in(");
            str.Append(" select top " + (startIndex - 1) + " special_id from special ");
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
            parameters[0].Value = "special";
            parameters[1].Value = "special_id";
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
            str.Append(" select count(1) from special ");
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
        /// 添加专题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSpecial(YouthSpecial model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into special ");
            str.Append("(special_title,special_img_url)");
            str.Append("values");
            str.Append("(@special_title,@special_img_url)");
            SqlParameter[] parameters = {
                    new SqlParameter("@special_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@special_img_url", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.Special_title;
            parameters[1].Value = model.Special_img_url;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除专题
        /// </summary>
        /// <param name="special_id"></param>
        /// <returns></returns>
        public int DelSpecial(int special_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("delete from special ");
            str.Append(" where special_id=@special_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@special_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = special_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 编辑更新专题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdSpecial(YouthSpecial model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update special set ");
            str.Append(" special_title=@special_title,");
            str.Append(" special_img_url=@special_img_url ");
            str.Append(" where special_id=@special_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@special_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@special_img_url", SqlDbType.NVarChar,50),
                    new SqlParameter("@special_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Special_title;
            parameters[1].Value = model.Special_img_url;
            parameters[2].Value = model.Special_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }
        /// <summary>
        /// 更新首页banner
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int updIsBanner(YouthSpecial model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update special set ");
            str.Append(" is_banner=@is_banner ");
            str.Append(" where special_id=@special_id ");
            SqlParameter[] parameters = {
                    
                    new SqlParameter("@is_banner", SqlDbType.NVarChar,10),
                    new SqlParameter("@special_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Is_banner;
            parameters[1].Value = model.Special_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);

            StringBuilder str1 = new StringBuilder();
            str1.Append(" update special set ");
            str1.Append(" is_banner='N' ");
            str1.Append(" where special_id<>@special_id ");
            SqlParameter[] parameters1 = {
                    new SqlParameter("@special_id",SqlDbType.Int,8)
                                        };
            parameters1[0].Value = model.Special_id;
            DbHelperSQL.ExecuteSql(str1.ToString(), parameters1);
            return rows;
        }
    }
}
