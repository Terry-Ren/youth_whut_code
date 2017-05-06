using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;
using System.Data;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthReceptionBLL
    {
        YouthReceptionDAL dal = new YouthReceptionDAL();

        /// <summary>
        /// 根据id得到问题实体
        /// </summary>
        /// <param name="reception_id"></param>
        /// <returns></returns>
        public YouthReception GetListById(int reception_id)
        {
            return dal.GetListById(reception_id);
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
            return dal.GetList(top, strWhere, order);
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
            return dal.GetListByPage(strWhere, order, startIndex, endIndex);
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
            return dal.GetListByPage(strWhere, pageSize, pageIndex, sortString);
        }

        /// <summary>
        /// 获得满足条件的用户总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 更新reception表的is_reply字段
        /// </summary>
        /// <param name="reception_id"></param>
        /// <returns></returns>
        public bool UpdReception(int reception_id)
        {
            int rows = dal.UpdReception(reception_id);
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
        /// 删除提问
        /// </summary>
        /// <param name="reception_id"></param>
        /// <returns></returns>
        public bool DelReception(int reception_id)
        {
            int rows = dal.DelReception(reception_id);
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
        /// 添加留言提问
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddReception(YouthReception model)
        {
            int rows = dal.AddReception(model);
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
