using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;
using System.Data;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthFilesColBLL
    {
        YouthFilesColDAL file_col_dal = new YouthFilesColDAL();
        ///<summary>
        ///得到文件列表
        ///</summary>
        ///
        public DataSet GetFilesCol()
        {
            return file_col_dal.GetFilesCol();
        }

        /// <summary>
        /// 根据文件栏目id得到栏目实体
        /// </summary>
        /// <param name="file_col_id"></param>
        /// <returns></returns>
        public YouthFileColumn GetFilesColById(int file_col_id)
        {
            return file_col_dal.GetFilesColById(file_col_id);
        }
    }
}
