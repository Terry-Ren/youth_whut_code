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
    public partial class YouthReceptionDAL
    {

        /// <summary>
        /// 根据id得到问题实体
        /// </summary>
        /// <param name="reception_id"></param>
        /// <returns></returns>
        public YouthReception GetListById(int reception_id)
        {
            YouthReception model = new YouthReception();
            StringBuilder str = new StringBuilder();
            str.Append(" select * from reception ");
            str.Append(" where reception_id=" + reception_id);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["reception_id"] != null)
                {
                    model.Reception_id = Convert.ToInt32(row["reception_id"].ToString());
                }
                if (row["reception_name"] != null)
                {
                    model.Reception_name = row["reception_name"].ToString();
                }
                if (row["reception_sex"] != null)
                {
                    model.Reception_sex = row["reception_sex"].ToString();
                }
                if (row["reception_homepage"] != null)
                {
                    model.Reception_homepage = row["reception_homepage"].ToString();
                }
                if (row["reception_email"] != null)
                {
                    model.Reception_email = row["reception_email"].ToString();
                }
                if (row["reception_qq"] != null)
                {
                    model.Reception_qq = row["reception_qq"].ToString();
                }
                if (row["reception_title"] != null)
                {
                    model.Reception_title = row["reception_title"].ToString();
                }
                if (row["reception_content"] != null)
                {
                    model.Reception_content = row["reception_content"].ToString();
                }
                if (row["reception_time"] != null)
                {
                    model.Reception_time = DateTime.Parse(row["reception_time"].ToString());
                }
                if (row["is_reply"] != null)
                {
                    model.Is_reply = row["is_reply"].ToString();
                }
                if (row["reception_type_id"] != null)
                {
                    model.Reception_type_id = Convert.ToInt32(row["reception_type_id"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据条件得到问题列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetList(int top, string strWhere, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select ");
            if (top > 0)
            {
                str.Append(" top " + top);
            }
            str.Append(" * from reception r,secretary s  ");
            if (strWhere.Trim() != "")
            {
                str.Append(" where " + strWhere);
            }
            if (order.Trim() != "")
            {
                str.Append(" order by  " + order);
            }
            DataSet result = DbHelperSQL.Query(str.ToString());
            return result;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string order, int startIndex, int endIndex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + (endIndex - startIndex + 1) + " * from reception r,secretary s   ");
            str.Append(" where r.reception_id not in(");
            str.Append(" select top " + (startIndex - 1) + " r.reception_id from reception r ");
            if (!String.IsNullOrEmpty(order))
            {
                str.Append(" order by " + order);
            }
            str.Append(")");
            if (strWhere.Trim() != "")
            {
                str.Append(" and " + strWhere);
            }
            //if (!String.IsNullOrEmpty(order))
            //{
            //    str.Append(" order by " + order);
            //}
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
            parameters[0].Value = "reception";
            parameters[1].Value = "reception_id";
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
        /// 获得满足条件的提问总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select count(1) from reception ");
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

        /// <summary>
        /// 更新reception表的is_reply字段
        /// </summary>
        /// <param name="reception_id"></param>
        /// <returns></returns>
        public int UpdReception(int reception_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update reception set ");
            str.Append(" is_reply='Y' ");
            str.Append(" where reception_id=" + reception_id);
            int rows = DbHelperSQL.ExecuteSql(str.ToString());
            return rows;
        }

        /// <summary>
        /// 删除提问
        /// </summary>
        /// <param name="reception_id"></param>
        /// <returns></returns>
        public int DelReception(int reception_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from reception ");
            str.Append(" where reception_id=" + reception_id);
            int rows = DbHelperSQL.ExecuteSql(str.ToString());
            return rows;
        }

        /// <summary>
        /// 添加留言提问
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddReception(YouthReception model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into reception ");
            str.Append(" (reception_name,reception_sex,reception_homepage,reception_email,reception_qq,reception_title,reception_content,reception_time,is_reply,reception_type_id) ");
            str.Append(" values ");
            str.Append(" (@reception_name,@reception_sex,@reception_homepage,@reception_email,@reception_qq,@reception_title,@reception_content,@reception_time,@is_reply,@reception_type_id)  ");
            SqlParameter[] parameters = {
					new SqlParameter("@reception_name", SqlDbType.NVarChar,25),
					new SqlParameter("@reception_sex", SqlDbType.VarChar,10),
					new SqlParameter("@reception_homepage", SqlDbType.NVarChar,50),
					new SqlParameter("@reception_email", SqlDbType.NVarChar,25),
					new SqlParameter("@reception_qq", SqlDbType.NVarChar,25),
					new SqlParameter("@reception_title", SqlDbType.NVarChar,50),
					new SqlParameter("@reception_content", SqlDbType.NText),
					new SqlParameter("@reception_time", SqlDbType.DateTime),
					new SqlParameter("@is_reply", SqlDbType.VarChar,10),
					new SqlParameter("@reception_type_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Reception_name;
            parameters[1].Value = model.Reception_sex;
            parameters[2].Value = model.Reception_homepage;
            parameters[3].Value = model.Reception_email;
            parameters[4].Value = model.Reception_qq;
            parameters[5].Value = model.Reception_title;
            parameters[6].Value = model.Reception_content;
            parameters[7].Value = model.Reception_time;
            parameters[8].Value = model.Is_reply;
            parameters[9].Value = model.Reception_type_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }
    }
}
