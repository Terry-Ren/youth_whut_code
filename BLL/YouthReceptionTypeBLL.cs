using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.DAL;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthReceptionTypeBLL
    {
        YouthReceptionTypeDAL dal = new YouthReceptionTypeDAL();




        /// <summary>
        /// 根据id得到会客类型实体
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public YouthReceptionType GetListById(int type_id)
        {
            return dal.GetListById(type_id);
        }

        /// <summary>
        /// 得到回复类型列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            return dal.GetList();
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
        /// 获取会客版块总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 添加会客版块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddReceptionType(YouthReceptionType model)
        {
            int rows = dal.AddReceptionType(model);
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
        /// 删除会客版块
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public bool DelReceptionType(int type_id)
        {
            int rows = dal.DelReceptionType(type_id);
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
        /// 更新会客类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdReceptionType(YouthReceptionType model)
        {
            int rows = dal.UpdReceptionType(model);
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
