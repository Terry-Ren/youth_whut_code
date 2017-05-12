using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;
using System.Data;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthDownloadsColBLL
    {
        YouthDownloadsColDAL download_col_dal = new YouthDownloadsColDAL();
        ///<summary>
        ///得到文件列表
        ///</summary>
        ///
        public DataSet GetDownloadsCol()
        {
            return download_col_dal.GetDownloadsCol();
        }

        /// <summary>
        /// 根据文件栏目id得到栏目实体
        /// </summary>
        /// <param name="download_col_id"></param>
        /// <returns></returns>
        public YouthDownloadColumn GetDownloadsColById(int download_col_id)
        {
            return download_col_dal.GetDownloadsColById(download_col_id);
        }
    }
}
