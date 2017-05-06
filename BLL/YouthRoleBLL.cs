using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.Model;
using AUTO.DAL;

namespace AUTO.BLL
{
    public partial class YouthRoleBLL
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return new YouthRoleDAL().GetList(strWhere);
        }

        /// <summary>
        /// 得到角色实体
        /// </summary>
        /// <param name="role_id"></param>
        /// <returns></returns>
        public YouthRole GetModel(int role_id)
        {
            return new YouthRoleDAL().GetModel(role_id);
        }
    }
}
