using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.DAL;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthSpecialSubConBLL
    {
        YouthSpecialSubConDAL dal = new YouthSpecialSubConDAL();




        /// <summary>
        /// 取得指定专题下的新闻列表
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
        /// 取得指定专题下的分页新闻列表
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
        /// 得到专题目录下的内容列表
        /// </summary>
        /// <param name="sub_id"></param>
        /// <returns></returns>
        public DataSet GetListBySubId(int sub_id)
        {
            return dal.GetListBySubId(sub_id);
        }

        /// <summary>
        /// 根据id得到内容实体
        /// </summary>
        /// <param name="content_id"></param>
        /// <returns></returns>
        public YouthSpecialSubContent GetListById(int content_id)
        {
            return dal.GetListById(content_id);
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
        /// 审核或者取消审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckCon(YouthSpecialSubContent model)
        {
            int rows = dal.CheckCon(model);
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
        /// 取消审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ReCheckCon(YouthSpecialSubContent model)
        {
            int rows = dal.ReCheckCon(model);
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
        /// 删除
        /// </summary>
        /// <param name="content_id"></param>
        /// <returns></returns>
        public bool DelContent(int content_id)
        {
            int rows = dal.DelContent(content_id);
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
        /// 添加内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddContent(YouthSpecialSubContent model)
        {
            int rows = dal.AddContent(model);
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
        /// 更新内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdContent(YouthSpecialSubContent model)
        {
            int rows = dal.UpdContent(model);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///<summary>
        ///对阅读次数加1——新闻id
        ///</summary>
        ///
        public int AddReadCount(int content_id)
        {
            return dal.AddReadCount(content_id);
        }
    }
}
