using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.Utility;

namespace AUTO.DAL
{
    public partial class YouthDepDAL
    {
        /// <summary>
        /// 取得部门列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetDepList()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select dep_id,dep_name from dep ");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }
    }
}
