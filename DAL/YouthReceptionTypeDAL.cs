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
    public partial class YouthReceptionTypeDAL
    {

        /// <summary>
        /// 根据id得到会客类型实体
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public YouthReceptionType GetListById(int type_id)
        {
            YouthReceptionType model = new YouthReceptionType();
            StringBuilder str = new StringBuilder();
            str.Append(" select * from reception_type ");
            str.Append(" where reception_type_id= " + type_id);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["reception_type_id"] != null)
                {
                    model.Reception_type_id = Convert.ToInt32(ds.Tables[0].Rows[0]["reception_type_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["reception_type"] != null)
                {
                    model.Reception_type = ds.Tables[0].Rows[0]["reception_type"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到回复类型列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select * from reception_type ");
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
            parameters[0].Value = "reception_type";
            parameters[1].Value = "reception_type_id";
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
        /// 获取会客版块总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select count(1) from reception_type ");
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
        /// 添加会客版块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddReceptionType(YouthReceptionType model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into reception_type ");
            str.Append(" (reception_type) ");
            str.Append(" values ");
            str.Append("(@reception_type)");
            SqlParameter[] parameters = {
                    new SqlParameter("@reception_type", SqlDbType.NVarChar,25)
                                        };
            parameters[0].Value = model.Reception_type;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }


        /// <summary>
        /// 删除会客版块
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public int DelReceptionType(int type_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from reception_type ");
            str.Append(" where reception_type_id= " + type_id);
            int rows = DbHelperSQL.ExecuteSql(str.ToString());
            return rows;
        }

        /// <summary>
        /// 更新会客类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdReceptionType(YouthReceptionType model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update reception_type set  ");
            str.Append(" reception_type=@reception_type ");
            str.Append(" where reception_type_id=@reception_type_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@reception_type", SqlDbType.NVarChar,25),
                    new SqlParameter("@reception_type_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Reception_type;
            parameters[1].Value = model.Reception_type_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }
    }
}
