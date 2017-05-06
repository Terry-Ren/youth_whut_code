using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.DAL;

namespace AUTO.BLL
{
    public partial class YouthDepBLL
    {
        YouthDepDAL dep_dal = new YouthDepDAL();
        /// <summary>
        /// 取得部门列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetDepList()
        {
            return dep_dal.GetDepList();
        }
    }
}
