using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.DAL;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthOnlineBLL
    {
        YouthOnlineDAL dal = new YouthOnlineDAL();
        
        /// <summary>
        /// 根据id得到会客类型实体
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public DataSet GetListById()
        {
            return dal.GetListById();
        }

        

        /// <summary>
        /// 更新会客类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet UpdOnline(int onlineswitch)
        {
           return dal.UpdOnline(onlineswitch);
        }
       
    }
}
