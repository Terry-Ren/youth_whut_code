using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.DAL;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthMenuBLL
    {
        YouthMenuDAL dal = new YouthMenuDAL();

        /// <summary>
        /// 根据id得到首页实体
        /// </summary>
        /// <param name="menu_id"></param>
        /// <returns></returns>
        public YouthMenu GetModel(int menu_id)
        {
            return dal.GetModel(menu_id);
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
        /// 获取首页列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 添加首页版块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddMenu(YouthMenu model)
        {
            int rows = dal.AddMenu(model);
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
        /// 删除首页版块
        /// </summary>
        /// <param name="menu_id"></param>
        /// <returns></returns>
        public bool DelMenu(int menu_id)
        {
            int rows = dal.DelMenu(menu_id);
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
        /// 更新首页版块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdMenu(YouthMenu model)
        {
            int rows = dal.UpdMenu(model);
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
