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
    public partial class YouthMenuDAL
    {
        /// <summary>
        /// 根据id得到首页实体
        /// </summary>
        /// <param name="menu_id"></param>
        /// <returns></returns>
        public YouthMenu GetModel(int menu_id)
        {
            YouthMenu model = new YouthMenu();
            StringBuilder str = new StringBuilder();
            str.Append(" select * from menu  ");
            str.Append(" where menu_id= " + menu_id);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                model.Menu_id = Convert.ToInt32(row["menu_id"].ToString());
                model.Menu_name = row["menu_name"].ToString();
                model.Menu_content = row["menu_content"].ToString();
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
            parameters[0].Value = "menu";
            parameters[1].Value = "menu_id";
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
            str.Append(" select count(1) from menu ");
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
        /// 获取首页列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select * from menu  ");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 添加首页版块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddMenu(YouthMenu model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into menu  ");
            str.Append(" (menu_name,menu_content) ");
            str.Append(" values ");
            str.Append(" (@menu_name,@menu_content) ");
            SqlParameter[] parameters = {
                    new SqlParameter("@menu_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@menu_content", SqlDbType.NText)
                                        };
            parameters[0].Value = model.Menu_name;
            parameters[1].Value = model.Menu_content;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除首页版块
        /// </summary>
        /// <param name="menu_id"></param>
        /// <returns></returns>
        public int DelMenu(int menu_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from menu ");
            str.Append(" where menu_id= " + menu_id);
            int rows = DbHelperSQL.ExecuteSql(str.ToString());
            return rows;
        }

        /// <summary>
        /// 更新首页版块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdMenu(YouthMenu model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update menu ");
            str.Append(" set menu_name=@menu_name, ");
            str.Append(" menu_content=@menu_content ");
            str.Append(" where menu_id=@menu_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@menu_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@menu_content", SqlDbType.NText),
                    new SqlParameter("@menu_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Menu_name;
            parameters[1].Value = model.Menu_content;
            parameters[2].Value = model.Menu_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }
    }
}
