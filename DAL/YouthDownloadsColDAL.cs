using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.Utility;
using AUTO.Model;

namespace AUTO.DAL
{
    public partial class YouthDownloadsColDAL
    {

        ///<summary>
        ///得到文件列表
        ///</summary>
        ///
        public DataSet GetDownloadsCol()
        {
            StringBuilder str = new StringBuilder();
            str.Append("select ");
            str.Append("download_column_id, download_column_name ");
            str.Append(" from downloads_column ");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 根据文件栏目id得到栏目实体
        /// </summary>
        /// <param name="download_col_id"></param>
        /// <returns></returns>
        public YouthDownloadColumn GetDownloadsColById(int download_col_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select ");
            str.Append("download_column_id, download_column_name ");
            str.Append(" from downloads_column ");
            str.Append(" where download_column_id=" + download_col_id);
            YouthDownloadColumn model = new YouthDownloadColumn();
            DataSet ds = DbHelperSQL.Query(str.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                model.Download_column_id = Convert.ToInt32(row["download_column_id"].ToString());
                model.Download_column_name = row["download_column_name"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
