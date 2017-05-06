using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.DAL;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthNewsBLL
    {
        private YouthNewsDAL news_dal = new YouthNewsDAL();
        ///<summary>
        ///取得新闻列表前几行数据
        ///</summary>
        ///
        public DataSet GetList(int top, string strWhere, string order)
        {
            return news_dal.GetList(top, strWhere, order);
        }

        /// <summary>
        /// 根据一系列条件得到出去第一条数据后的新闻
        /// </summary>
        /// <param name="strWhere1"></param>
        /// <param name="strWhere2"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetOtherFirstList(int top, string strWhere1, string strWhere2, string order)
        {
            return news_dal.GetOtherFirstList(top, strWhere1, strWhere2, order);
        }


        /// <summary>
        /// 得到排序后的第一条新闻实体
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public YouthNews GetFirstList(string strWhere, string order)
        {
            return news_dal.GetFirstList(strWhere, order);
        }

        /// <summary>
        /// 获取首页大图展示新闻
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetHomeImg(int top, string strWhere)
        {
            return news_dal.GetHomeImg(top, strWhere);
        }

        ///<summary>
        ///获得新闻列表—根据news_column_id,order by
        ///</summary>
        ///
        public DataSet GetList(string strWhere, string order)
        {
            return news_dal.GetList(strWhere, order);
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
            return news_dal.GetListByPage(strWhere, pageSize, pageIndex, sortString);
        }


        ///<summary>
        ///分页获取新闻列表—根据news_column_id,order by,startIndex,endIndex
        ///</summary>
        ///
        public DataSet GetListByPage(string strWhere, string order, int startIndex, int endIndex)
        {
            return news_dal.GetListByPage(strWhere, order, startIndex, endIndex);
        }

        ///<summary>
        ///获取新闻列表记录总数
        ///</summary>
        ///
        public int GetRecordCount(string strWhere)
        {
            return news_dal.GetRecordCount(strWhere);
        }

        ///<summary>
        ///获得新闻实体—根据news_column_id和news_id
        ///</summary>
        ///
        public YouthNews GetYouthNews(int news_id)
        {
            return news_dal.GetYouthNews(news_id);
        }

        ///<summary>
        ///对阅读次数加1——新闻id
        ///</summary>
        ///
        public int AddReadCount(int news_id)
        {
            return news_dal.AddReadCount(news_id);
        }

        /// <summary>
        /// 在线投稿，增加新闻
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddYouthNews(YouthNews model)
        {
            int i = news_dal.AddYouthNews(model);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 更新编辑新闻
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdYouthNews(YouthNews model)
        {
            int rows = news_dal.UpdYouthNews(model);
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
        /// 审核新闻
        /// </summary>
        /// <param name="news_id"></param>
        /// <param name="operate_name"></param>
        /// <returns></returns>
        public bool CheckNews(int news_id, string operate_name)
        {
            int rows = news_dal.CheckNews(news_id, operate_name);
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
        /// 取消审核新闻
        /// </summary>
        /// <param name="news_id"></param>
        /// <param name="operate_name"></param>
        /// <returns></returns>
        public bool ReCheckNews(int news_id, string operate_name)
        {
            int rows = news_dal.ReCheckNews(news_id, operate_name);
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
        /// 删除新闻
        /// </summary>
        /// <param name="news_id"></param>
        /// <returns></returns>
        public bool DeleteNews(int news_id)
        {
            int rows = news_dal.DeleteNews(news_id);
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
        /// 决定是否在首页显示图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool updNewsImage(YouthNews model)
        {
            int rows = news_dal.updNewsImage(model);
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
        /// 根据新闻id得到新闻来源id
        /// </summary>
        /// <param name="news_id"></param>
        /// <returns></returns>
        public int GetSourceById(int news_id)
        {
            return news_dal.GetSourceById(news_id);
        }

        /// <summary>
        /// 根据一系列条件在后台得到稿件排行
        /// </summary>
        /// <param name="inWhere"></param>
        /// <param name="outWhere"></param>
        /// <returns></returns>
        public DataSet GetRankByCondition(string inWhere, string outWhere)
        {
            return news_dal.GetRankByCondition(inWhere, outWhere);
        }
    }
}
