using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.Utility;

namespace AUTO.DAL
{
    public partial class YouthAcademicDAL
    {
        /// <summary>
        /// 取得学院列表——新闻来源
        /// </summary>
        /// <returns></returns>
        public DataSet GetAcademic()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select academic_id,academic_name from academic");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 获取学院投稿排名
        /// </summary>
        /// <returns></returns>
        public DataSet GetRank(string condition)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select row_number() over (order by academic_rank desc ) as rank ,academic_name,academic_rank  from academic " + condition);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 更新学院投稿数——增加
        /// </summary>
        /// <param name="academic_id"></param>
        /// <returns></returns>
        public int UpdateRank(int academic_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update academic set  ");
            str.Append(" academic_rank=academic_rank+1 ");
            str.Append(" where academic_id= " + academic_id);
            int rows = DbHelperSQL.ExecuteSql(str.ToString());
            return rows;
        }
        /// <summary>
        /// 更新学院投稿数——减少
        /// </summary>
        /// <param name="academic_id"></param>
        /// <returns></returns>
        public int ReUpdateRank(int academic_id)
        {
            string sql = "select academic_rank from academic where academic_id=" + academic_id;
            //确定是否仅有一篇文章
            int obj = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            if (!obj.Equals(0))
            {
                StringBuilder str = new StringBuilder();
                str.Append(" update academic set  ");
                str.Append(" academic_rank=academic_rank-1 ");
                str.Append(" where academic_id= " + academic_id);
                int rows = DbHelperSQL.ExecuteSql(str.ToString());
                return rows;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 稿件数量一键清零
        /// </summary>
        /// <returns></returns>
        public int clearRank()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update academic set ");
            str.Append(" academic_rank=0 ");
            int rows = DbHelperSQL.ExecuteSql(str.ToString());
            return rows;
        }
    }
}
