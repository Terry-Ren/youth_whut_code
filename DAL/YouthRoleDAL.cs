using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.Utility;
using AUTO.Model;
using System.Data.SqlClient;

namespace AUTO.DAL
{
    public partial class YouthRoleDAL
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select role_id,role_name ");
            str.Append(" from role ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(str.ToString());
        }

        /// <summary>
        /// 得到角色实体
        /// </summary>
        /// <param name="role_id"></param>
        /// <returns></returns>
        public YouthRole GetModel(int role_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select role_id,role_name ");
            str.Append(" from role ");
            str.Append(" where role_id=@role_id ");
            SqlParameter[] parameters ={
                        new SqlParameter("@role_id",SqlDbType.Int,8)
                                      };
            parameters[0].Value = role_id;
            DataSet ds = DbHelperSQL.Query(str.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 00)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 角色实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public YouthRole DataRowToModel(DataRow row)
        {
            YouthRole model = new YouthRole();
            if (row != null)
            {
                if (row["role_id"] != null && row["role_id"].ToString() != "")
                {
                    model.Role_id = int.Parse(row["role_id"].ToString());
                }
                if (row["role_name"] != null)
                {
                    model.Role_name = row["role_name"].ToString();
                }
            }
            return model;
        }
    }
}
