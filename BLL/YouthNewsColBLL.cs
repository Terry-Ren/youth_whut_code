using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.DAL;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthNewsColBLL
    {
        private readonly YouthNewsColDAL news_col_dal = new YouthNewsColDAL();

        /// <summary>
        /// 根据id得到新闻版块
        /// </summary>
        /// <param name="news_col_id"></param>
        /// <returns></returns>
        public YouthNewsColumn GetListById(int news_col_id)
        {
            return news_col_dal.GetListById(news_col_id);
        }

        ///<summary>
        ///得到新闻栏目列表
        ///</summary>
        public DataSet GetNewsCol()
        {
            return news_col_dal.GetNewsCol();
        }

        /// <summary>
        /// 根据条件得到新闻版块
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetNewsColList(String where)
        {
            return news_col_dal.GetNewsColList(where);
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
            return news_col_dal.GetListByPage(strWhere, pageSize, pageIndex, sortString);
        }

        /// <summary>
        /// 获取新闻版块总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            return news_col_dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 添加新闻版块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddNewsCol(YouthNewsColumn model)
        {
            int rows = news_col_dal.AddNewsCol(model);
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
        /// 删除新闻版块
        /// </summary>
        /// <param name="news_column_id"></param>
        /// <returns></returns>
        public bool DelNewsCol(int news_column_id)
        {
            int rows = news_col_dal.DelNewsCol(news_column_id);
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
        /// 更新新闻版块
        /// </summary>
        /// <param name="news_column_id"></param>
        /// <returns></returns>
        public bool UpdNewsCol(YouthNewsColumn model)
        {
            int rows = news_col_dal.UpdNewsCol(model);
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
