using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AUTO.Utility;
using AUTO.Model;

namespace AUTO.DAL
{
    public partial class YouthUsersDAL
    {

        /// <summary>
        /// 验证登录用户
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="user_pwd"></param>
        /// <param name="Role_id"></param>
        /// <returns></returns>
        public int check_user(string user_name, string user_pwd, int Role_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select count(1) from users ");
            str.Append("where user_name=@user_name ");
            str.Append(" and user_pwd=@user_pwd ");
            str.Append(" and Role_id=@Role_id ");
            str.Append(" and user_status='Y' ");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_name", SqlDbType.NVarChar,128),
                    new SqlParameter("@user_pwd", SqlDbType.NVarChar,128),
                    new SqlParameter("@Role_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = user_name;
            parameters[1].Value = user_pwd;
            parameters[2].Value = Role_id;
            object result = DbHelperSQL.GetSingle(str.ToString(), parameters);
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
        /// 登录成功后，根据用户名和密码得到登录用户id
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="user_pwd"></param>
        /// <returns></returns>
        public int GetUserIdByName(string user_name, string user_pwd)
        {
            int user_id;
            StringBuilder str = new StringBuilder();
            str.Append(" select top 1 * from users ");
            str.Append("where user_name=@user_name ");
            str.Append(" and user_pwd=@user_pwd ");
            str.Append(" and user_status='Y' ");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_name", SqlDbType.NVarChar,128),
                    new SqlParameter("@user_pwd", SqlDbType.NVarChar,128)
                                        };
            parameters[0].Value = user_name;
            parameters[1].Value = user_pwd;
            DataSet ds = DbHelperSQL.Query(str.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                user_id = Convert.ToInt32(ds.Tables[0].Rows[0]["user_id"].ToString());
                return user_id;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 根据用户id得到用户实体
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public AUTO.Model.YouthUsers GetUserById(int user_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top 1 * from users ");
            str.Append(" where user_id=@user_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = user_id;
            DataSet ds = DbHelperSQL.Query(str.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetUserModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个model
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public AUTO.Model.YouthUsers GetUserModel(DataRow row)
        {
            AUTO.Model.YouthUsers model = new Model.YouthUsers();
            if (row != null)
            {
                if (row["user_id"] != null)
                {
                    model.User_id = Convert.ToInt32(row["user_id"].ToString());
                }
                if (row["user_name"] != null)
                {
                    model.User_name = row["user_name"].ToString();
                }
                if (row["user_pwd"] != null)
                {
                    model.User_pwd = row["user_pwd"].ToString();
                }
                if (row["Role_id"] != null)
                {
                    model.Role_id = Convert.ToInt32(row["Role_id"]);
                }
                if (row["true_name"] != null)
                {
                    model.True_name = row["true_name"].ToString();
                }
                if (row["user_sex"] != null)
                {
                    model.User_sex = row["user_sex"].ToString();
                }
                if (row["user_dep_id"] != null)
                {
                    model.User_dep = Convert.ToInt32(row["user_dep_id"]);
                }
                if (row["user_academic_id"] != null)
                {
                    model.User_academic_id = Convert.ToInt32(row["user_academic_id"]);
                }
                if (row["user_status"] != null)
                {
                    model.User_status = row["user_status"].ToString();
                }
                if (row["user_phone"] != null)
                {
                    model.User_phone = row["user_phone"].ToString();
                }
                if (row["user_email"] != null)
                {
                    model.User_email = row["user_email"].ToString();
                }
                if (row["user_points"] != null)
                {
                    model.User_points = Convert.ToInt32(row["user_points"]);
                }
                if (row["user_address"] != null)
                {
                    model.User_address = row["user_address"].ToString();
                }
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
            parameters[0].Value = "users";
            parameters[1].Value = "user_id";
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
            str.Append(" select count(1) from users ");
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
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddUsers(YouthUsers model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into users(");
            str.Append(" user_name,user_pwd,Role_id,true_name,user_sex,user_dep_id,user_academic_id,user_status,user_phone,user_email,user_points,user_address");
            str.Append(") values (");
            str.Append("@user_name,@user_pwd,@Role_id,@true_name,@user_sex,@user_dep_id,@user_academic_id,@user_status,@user_phone,@user_email,@user_points,@user_address");
            str.Append(")");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_name", SqlDbType.NVarChar,25),
                    new SqlParameter("@user_pwd", SqlDbType.NVarChar,50),
                    new SqlParameter("@Role_id", SqlDbType.Int,8),
                    new SqlParameter("@true_name", SqlDbType.NVarChar,25),
                    new SqlParameter("@user_sex", SqlDbType.VarChar,10),
                    new SqlParameter("@user_dep_id", SqlDbType.Int,8),
                    new SqlParameter("@user_academic_id", SqlDbType.Int,8),
                    new SqlParameter("@user_status", SqlDbType.VarChar,10),
                    new SqlParameter("@user_phone", SqlDbType.NVarChar,25),
                    new SqlParameter("@user_email", SqlDbType.NVarChar,25),
                    new SqlParameter("@user_points", SqlDbType.Int,8),
                    new SqlParameter("@user_address", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.User_name;
            parameters[1].Value = model.User_pwd;
            parameters[2].Value = model.Role_id;
            parameters[3].Value = model.True_name;
            parameters[4].Value = model.User_sex;
            parameters[5].Value = model.User_dep;
            parameters[6].Value = model.User_academic_id;
            parameters[7].Value = model.User_status;
            parameters[8].Value = model.User_phone;
            parameters[9].Value = model.User_email;
            parameters[10].Value = model.User_points;
            parameters[11].Value = model.User_address;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public int DelUsers(int user_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from users ");
            str.Append(" where user_id=@user_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = user_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;

        }

        /// <summary>
        /// 冻结与解冻账号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int FrezzeUsers(YouthUsers model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update users set ");
            str.Append(" user_status=@user_status ");
            str.Append(" where user_id=@user_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_status",SqlDbType.VarChar,10),
                    new SqlParameter("@user_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.User_status;
            parameters[1].Value = model.User_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 初始化——重置——修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ResetPwd(YouthUsers model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update users set ");
            str.Append(" user_pwd =@user_pwd ");
            str.Append(" where user_id=@user_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_pwd",SqlDbType.NVarChar,50),
                    new SqlParameter("@user_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.User_pwd;
            parameters[1].Value = model.User_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 根据用户名来验证是否已经存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int IsExits(string username)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top 1 * from users ");
            str.Append(" where user_name='" + username + "' ");
            object obj = DbHelperSQL.GetSingle(str.ToString());
            if (obj != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 书记会客室得到书记列表
        /// </summary>
        /// <returns></returns>
        public DataSet getShuJi()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select * from users where Role_id=5 ");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }
    }
}
