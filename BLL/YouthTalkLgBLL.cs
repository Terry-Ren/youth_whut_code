using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;
using System.Data;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthTalkLgBLL
    {
        YouthTalkLgDAL dal = new YouthTalkLgDAL();

        /// <summary>
        /// 根据id获取图说理工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public YouthTalkLg GetListById(int id)
        {
            return dal.GetListById(id);
        }

        /// <summary>
        /// 根据条件获取前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetTopTalk(int top, string strWhere, string order)
        {
            return dal.GetTopTalk(top, strWhere, order);
        }

        /// <summary>
        /// 首页分页获取图说理工列表
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

        ///<summary>
        ///对阅读次数加1——新闻id
        ///</summary>
        ///
        public int AddReadCount(int talk_id)
        {
            return dal.AddReadCount(talk_id);
        }

        /// <summary>
        /// 添加图说理工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddTalkLG(YouthTalkLg model)
        {
            int rows = dal.AddTalkLG(model);
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
        /// 审核图说理工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckTalkLg(YouthTalkLg model)
        {
            int rows = dal.CheckTalkLg(model);
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
        /// 反审核图说理工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ReCheckTalkLg(YouthTalkLg model)
        {
            int rows = dal.ReCheckTalkLg(model);
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
        /// 删除图说理工
        /// </summary>
        /// <param name="talk_id"></param>
        /// <returns></returns>
        public bool DelTalkLg(int talk_id)
        {
            int rows = dal.DelTalkLg(talk_id);
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
        /// 更新图说理工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdTalkLg(YouthTalkLg model)
        {
            int rows = dal.UpdTalkLg(model);
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
