using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;
using AUTO.Model;
using System.Data;

namespace AUTO.BLL
{
    public partial class YouthSpecialSubBLL
    {
        YouthSpecialSubDAL dal = new YouthSpecialSubDAL();

        /// <summary>
        /// 根据专题id得到该专题下的目录
        /// </summary>
        /// <param name="special_id"></param>
        /// <returns></returns>
        public DataSet GetItemBySpeId(int special_id)
        {
            return dal.GetItemBySpeId(special_id);
        }

        /// <summary>
        /// 根据id得到子栏目
        /// </summary>
        /// <param name="sub_id"></param>
        /// <returns></returns>
        public YouthSpecialSub GetListById(int sub_id)
        {
            return dal.GetListById(sub_id);
        }

        /// <summary>
        /// 得到专题列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据专题id得到栏目列表
        /// </summary>
        /// <param name="special_id"></param>
        /// <returns></returns>
        public DataSet GetListBySpe(int special_id)
        {
            return dal.GetListBySpe(special_id);
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
        /// 获取记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 得到最大的排序Id并加1
        /// </summary>
        /// <returns></returns>
        public int GetMaxPaixu()
        {
            return dal.GetMaxPaixu();
        }

        /// <summary>
        /// 添加子栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddSpeSub(YouthSpecialSub model)
        {
            int rows = dal.AddSpeSub(model);
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
        /// 删除指定子栏目
        /// </summary>
        /// <param name="sub_id"></param>
        /// <returns></returns>
        public bool DelSpeSub(int sub_id)
        {
            int rows = dal.DelSpeSub(sub_id);
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
        /// 编辑更新子栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdSpeSub(YouthSpecialSub model)
        {
            int rows = dal.UpdSpeSub(model);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getSubIdOfSpecial(int specialId)
        {
            return dal.getSubIdOfSpecial(specialId);
        }
    }
}
