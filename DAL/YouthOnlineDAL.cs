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
    public partial class YouthOnlineDAL
    {

        /// <summary>
        /// 根据id得到会客类型实体
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public DataSet GetListById()
        {
            
            StringBuilder str = new StringBuilder();
            str.Append(" select * from onlineSwitch ");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
            /*
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["online_switch"] != null)
                {
                    model.Online_Switch = Convert.ToInt32(ds.Tables[0].Rows[0]["online_switch"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
            */
        }

        
        /// <summary>
        /// 更新会客类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet UpdOnline(int onlineswitch)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@onlineswitch", SqlDbType.Int,4) };
             parameters[0].Value =onlineswitch;
            StringBuilder str = new StringBuilder();
            str.Append(" update onlineSwitch set  ");
            str.Append(" online_switch=@onlineswitch ");
            DataSet ds= DbHelperSQL.Query(str.ToString(), parameters);
            return ds;
        }
    
    }
}
