using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AUTO.Utility;
using System.Data;

namespace AUTO.DAL
{
    public partial class YouthInitialPwdDAL
    {
        /// <summary>
        /// 取得初始密码
        /// </summary>
        /// <returns></returns>
        public string GetInitialPwd()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select InitPsw from initialPsw ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int, 4) };
            parameters[0].Value = 1;

            string initPsw = DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0].ToString();
            if (!string.IsNullOrEmpty(initPsw))
            {
                return initPsw;
            }
            else
            {
                return "";
            }
        }
    }
}
