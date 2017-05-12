using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;
using System.Data;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthDownloadsBLL
    {
        YouthDownloadsDAL download_dal = new YouthDownloadsDAL();

        /// <summary>
        /// 获取前几条文件数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDownloads(int top, string strWhere)
        {
            return download_dal.GetDownloads(top, strWhere);
        }

        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string order)
        {
            return download_dal.GetList(strWhere, order);
        }

        /// <summary>
        /// 按条件获取文件列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetDownloads(int top, string strWhere, string order)
        {
            return download_dal.GetDownloads(top, strWhere, order);
        }

        /// <summary>
        /// 根据用户id得到用户实体
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public AUTO.Model.YouthDownload GetDownloadsById(int download_id)
        {
            return download_dal.GetDownloadsById(download_id);
        }


        /// <summary>
        /// 首页分页获取文件列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string order, int startIndex, int endIndex)
        {
            return download_dal.GetListByPage(strWhere, order, startIndex, endIndex);
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
            return download_dal.GetListByPage(strWhere, pageSize, pageIndex, sortString);
        }

        /// <summary>
        /// 获得满足条件的文件总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            return download_dal.GetRecordCount(strWhere);
        }

        ///<summary>
        ///对阅读次数加1——文件id
        ///</summary>
        ///
        public int AddReadCount(int download_id)
        {
            return download_dal.AddReadCount(download_id);
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddYouthDownload(YouthDownload model)
        {
            int rows = download_dal.AddYouthDownload(model);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*
        /// <summary>
        /// 审核文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckDownload(YouthDownload model)
        {
            int rows = download_dal.CheckDownload(model);
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
        /// 反审核文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ReCheckDownload(YouthDownload model)
        {
            int rows = download_dal.ReCheckDownload(model);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="download_id"></param>
        /// <returns></returns>
        public bool DelDownload(int download_id)
        {
            int rows = download_dal.DelDownload(download_id);
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
        /// 更新文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdDownload(YouthDownload model)
        {
            int rows = download_dal.UpdDownload(model);
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
