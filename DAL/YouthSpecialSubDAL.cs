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
    public partial class YouthSpecialSubDAL
    {
        YouthSpecialSub model = new YouthSpecialSub();

        /// <summary>
        /// 根据专题id得到该专题下的目录
        /// </summary>
        /// <param name="special_id"></param>
        /// <returns></returns>
        public DataSet GetItemBySpeId(int special_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select * from special_sub ");
            str.Append(" where special_id=@special_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@special_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = special_id;
            DataSet ds = DbHelperSQL.Query(str.ToString(), parameters);
            return ds;
        }

        /// <summary>
        /// 根据id得到子栏目
        /// </summary>
        /// <param name="sub_id"></param>
        /// <returns></returns>
        public YouthSpecialSub GetListById(int sub_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select * from special_sub ");
            str.Append(" where sub_id=@sub_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@sub_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = sub_id;
            DataSet ds = DbHelperSQL.Query(str.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["sub_id"] != null)
                {
                    model.Sub_id = Convert.ToInt32(row["sub_id"].ToString());
                }
                if (row["special_id"] != null)
                {
                    model.Special_id = Convert.ToInt32(row["special_id"].ToString());
                }
                if (row["sub_title"] != null)
                {
                    model.Sub_title = row["sub_title"].ToString();
                }
                if (row["sub_paixu"] != null)
                {
                    model.Sub_paixu = Convert.ToInt32(row["sub_paixu"].ToString());
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
            str.Append(" select * from special_sub ");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }
        /// <summary>
        /// 根据专题id得到栏目列表
        /// </summary>
        /// <param name="special_id"></param>
        /// <returns></returns>
        public DataSet GetListBySpe(int special_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select * from special_sub ");
            str.Append(" where special_id=@special_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@special_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = special_id;
            DataSet ds = DbHelperSQL.Query(str.ToString(), parameters);
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
            parameters[0].Value = "special_sub";
            parameters[1].Value = "sub_id";
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
            str.Append(" select count(1) from special_sub ");
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
        /// 得到最大的排序Id并加1
        /// </summary>
        /// <returns></returns>
        public int GetMaxPaixu()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select MAX(sub_paixu) paixuId from special_sub ");
            Object obj = DbHelperSQL.GetSingle(str.ToString());
            if (obj != null)
            {
                int result = int.Parse(obj.ToString());
                return result + 1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 添加子栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSpeSub(YouthSpecialSub model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into special_sub ");
            str.Append("(special_id,sub_title,sub_paixu)");
            str.Append("values ");
            str.Append("(@special_id,@sub_title,@sub_paixu)");
            SqlParameter[] parameters = {
                    new SqlParameter("@special_id", SqlDbType.Int,8),
                    new SqlParameter("@sub_title",SqlDbType.NVarChar,50),
                    new SqlParameter("@sub_paixu",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Special_id;
            parameters[1].Value = model.Sub_title;
            parameters[2].Value = model.Sub_paixu;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除指定子栏目
        /// </summary>
        /// <param name="sub_id"></param>
        /// <returns></returns>
        public int DelSpeSub(int sub_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from special_sub ");
            str.Append(" where sub_id=@sub_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@sub_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = sub_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 编辑更新子栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdSpeSub(YouthSpecialSub model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update special_sub set ");
            str.Append(" special_id=@special_id,");
            str.Append(" sub_title=@sub_title,");
            str.Append(" sub_paixu=@sub_paixu ");
            str.Append(" where sub_id=@sub_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@special_id", SqlDbType.Int,8),
                    new SqlParameter("@sub_title",SqlDbType.NVarChar,50),
                    new SqlParameter("@sub_paixu",SqlDbType.Int,8),
                    new SqlParameter("@sub_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Special_id;
            parameters[1].Value = model.Sub_title;
            parameters[2].Value = model.Sub_paixu;
            parameters[3].Value = model.Sub_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        public int getSubIdOfSpecial(int specialId)
        {
            int subId = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" select top 1 sub_id from special_sub where special_id = @special_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@special_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = specialId;
            DataSet ds = DbHelperSQL.Query(sb.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["sub_id"] != null)
                {
                    subId = Convert.ToInt32(row["sub_id"].ToString());
                }
                
                return subId;
            }
            else
            {
                return subId;
            }
        }

    }
}
