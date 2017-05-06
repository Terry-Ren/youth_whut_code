using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.Model;
using System.Data.SqlClient;
using System.Data;
using AUTO.Utility;

namespace AUTO.DAL
{
    public partial class YouthSecretaryDAL
    {
        YouthSecretary model = new YouthSecretary();

        /// <summary>
        /// 根据问题id判断是否已经回复并得到该实体
        /// </summary>
        /// <param name="reception_id"></param>
        /// <returns></returns>
        public YouthSecretary GetListById(int reception_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select * from secretary ");
            str.Append(" where reception_id=" + reception_id);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["reception_id"] != null)
                {
                    model.Reception_id = Convert.ToInt32(row["reception_id"].ToString());
                }
                if (row["Secretary_sid"] != null)
                {
                    model.Secretary_sid = Convert.ToInt32(row["Secretary_sid"].ToString());
                }
                if (row["Secretary_name"] != null)
                {
                    model.Secretary_name = row["Secretary_name"].ToString();
                }
                if (row["Secretary_content"] != null)
                {
                    model.Secretary_content = row["Secretary_content"].ToString();
                }
                if (row["Secretary_time"] != null)
                {
                    model.Secretary_time = DateTime.Parse(row["Secretary_time"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 书记会客室回复
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSecretary(YouthSecretary model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into secretary ");
            str.Append("(reception_id,Secretary_sid,Secretary_name,Secretary_content,Secretary_time)");
            str.Append(" values ");
            str.Append("(@reception_id,@Secretary_sid,@Secretary_name,@Secretary_content,@Secretary_time)");
            SqlParameter[] parameters = {
                    new SqlParameter("@reception_id", SqlDbType.Int,8),
                    new SqlParameter("Secretary_sid",SqlDbType.Int,8),
                    new SqlParameter("Secretary_name",SqlDbType.NVarChar,25),
                    new SqlParameter("Secretary_content",SqlDbType.NText),
                    new SqlParameter("Secretary_time",SqlDbType.DateTime)
                                         };
            parameters[0].Value = model.Reception_id;
            parameters[1].Value = model.Secretary_sid;
            parameters[2].Value = model.Secretary_name;
            parameters[3].Value = model.Secretary_content;
            parameters[4].Value = model.Secretary_time;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除问题下的回复
        /// </summary>
        /// <param name="reception_id"></param>
        /// <returns></returns>
        public int DelSecretary(int reception_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from secretary ");
            str.Append(" where reception_id= " + reception_id);
            int rows = DbHelperSQL.ExecuteSql(str.ToString());
            return rows;
        }
    }
}
