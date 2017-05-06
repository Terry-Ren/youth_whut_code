using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;
using System.Data;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthSpecialBLL
    {
        YouthSpecialDAL special_dal = new YouthSpecialDAL();

        /// <summary>
        /// 根据id得到一个专题实体对象
        /// </summary>
        /// <param name="special_id"></param>
        /// <returns></returns>
        public YouthSpecial GetListById(int special_id)
        {
            return special_dal.GetListById(special_id);
        }

        /// <summary>
        /// 得到专题列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            return special_dal.GetList();
        }


        /// <summary>
        /// 获取前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetTopList(int top, string strWhere)
        {
            return special_dal.GetTopList(top, strWhere);
        }

        /// <summary>
        /// 按条件获取精品专题列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetSpecial(int top, string strWhere, string order)
        {
            return special_dal.GetSpecial(top, strWhere, order);
        }

        /// <summary>
        /// 首页分页获取精品专题列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string order, int startIndex, int endIndex)
        {
            return special_dal.GetListByPage(strWhere, order, startIndex, endIndex);
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
            return special_dal.GetListByPage(strWhere, pageSize, pageIndex, sortString);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            return special_dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 添加专题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddSpecial(YouthSpecial model)
        {
            int rows = special_dal.AddSpecial(model);
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
        /// 删除专题
        /// </summary>
        /// <param name="special_id"></param>
        /// <returns></returns>
        public bool DelSpecial(int special_id)
        {
            int rows = special_dal.DelSpecial(special_id);
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
        /// 编辑更新专题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdSpecial(YouthSpecial model)
        {
            int rows = special_dal.UpdSpecial(model);
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
        /// 更新首页banner
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool updIsBanner(YouthSpecial model)
        {
            int rows = special_dal.updIsBanner(model);
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
