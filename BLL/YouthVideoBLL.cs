using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;
using System.Data;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthVideoBLL
    {
        YouthVideoDAL dal = new YouthVideoDAL();

        /// <summary>
        /// 根据id得到视频对象实体
        /// </summary>
        /// <param name="video_id"></param>
        /// <returns></returns>
        public YouthVideo GetListById(int video_id)
        {
            return dal.GetListById(video_id);
        }

        /// <summary>
        /// 根据条件获取前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetTopVideo(int top, string strWhere, string order)
        {
            return dal.GetTopVideo(top, strWhere, order);
        }

        /// <summary>
        /// 首页分页获取视频列表
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
        /// 添加视频
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddVideo(YouthVideo model)
        {
            int rows = dal.AddVideo(model);
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
        /// 删除视频
        /// </summary>
        /// <param name="video_id"></param>
        /// <returns></returns>
        public bool DelVideo(int video_id)
        {
            int rows = dal.DelVideo(video_id);
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
        /// 更新视频
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdVideo(YouthVideo model)
        {
            int rows = dal.UpdVideo(model);
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
