using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.Model;
using AUTO.DAL;

namespace AUTO.BLL
{
    public partial class YouthSecretaryBLL
    {
        YouthSecretaryDAL dal = new YouthSecretaryDAL();

        /// <summary>
        /// 根据问题id判断是否已经回复并得到该实体
        /// </summary>
        /// <param name="reception_id"></param>
        /// <returns></returns>
        public YouthSecretary GetListById(int reception_id)
        {
            return dal.GetListById(reception_id);
        }

        /// <summary>
        /// 书记会客室回复
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddSecretary(YouthSecretary model)
        {
            int rows = dal.AddSecretary(model);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除问题下的回复
        /// </summary>
        /// <param name="reception_id"></param>
        /// <returns></returns>
        public bool DelSecretary(int reception_id)
        {
            int rows = dal.DelSecretary(reception_id);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
