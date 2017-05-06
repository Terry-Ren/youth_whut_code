using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;
using System.Data;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthFilesBLL
    {
        YouthFilesDAL file_dal = new YouthFilesDAL();

        /// <summary>
        /// 获取前几条文件数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetFiles(int top, string strWhere)
        {
            return file_dal.GetFiles(top, strWhere);
        }

        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string order)
        {
            return file_dal.GetList(strWhere, order);
        }

        /// <summary>
        /// 按条件获取文件列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetFiles(int top, string strWhere, string order)
        {
            return file_dal.GetFiles(top, strWhere, order);
        }

        /// <summary>
        /// 根据用户id得到用户实体
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public AUTO.Model.YouthFile GetFilesById(int file_id)
        {
            return file_dal.GetFilesById(file_id);
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
            return file_dal.GetListByPage(strWhere, order, startIndex, endIndex);
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
            return file_dal.GetListByPage(strWhere, pageSize, pageIndex, sortString);
        }

        /// <summary>
        /// 获得满足条件的文件总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            return file_dal.GetRecordCount(strWhere);
        }

        ///<summary>
        ///对阅读次数加1——文件id
        ///</summary>
        ///
        public int AddReadCount(int file_id)
        {
            return file_dal.AddReadCount(file_id);
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddYouthFile(YouthFile model)
        {
            int rows = file_dal.AddYouthFile(model);
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
        /// 审核文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckFile(YouthFile model)
        {
            int rows = file_dal.CheckFile(model);
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
        public bool ReCheckFile(YouthFile model)
        {
            int rows = file_dal.ReCheckFile(model);
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
        /// 删除文件
        /// </summary>
        /// <param name="file_id"></param>
        /// <returns></returns>
        public bool DelFile(int file_id)
        {
            int rows = file_dal.DelFile(file_id);
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
        public bool UpdFile(YouthFile model)
        {
            int rows = file_dal.UpdFile(model);
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
