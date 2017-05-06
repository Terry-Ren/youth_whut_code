using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.Utility;
using AUTO.Model;

namespace AUTO.DAL
{
    public partial class YouthFilesColDAL
    {

        ///<summary>
        ///得到文件列表
        ///</summary>
        ///
        public DataSet GetFilesCol()
        {
            StringBuilder str = new StringBuilder();
            str.Append("select ");
            str.Append("file_column_id, file_column_name ");
            str.Append(" from files_column ");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 根据文件栏目id得到栏目实体
        /// </summary>
        /// <param name="file_col_id"></param>
        /// <returns></returns>
        public YouthFileColumn GetFilesColById(int file_col_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select ");
            str.Append("file_column_id, file_column_name ");
            str.Append(" from files_column ");
            str.Append(" where file_column_id=" + file_col_id);
            YouthFileColumn model = new YouthFileColumn();
            DataSet ds = DbHelperSQL.Query(str.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                model.File_column_id = Convert.ToInt32(row["file_column_id"].ToString());
                model.File_column_name = row["file_column_name"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
