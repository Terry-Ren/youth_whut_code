using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AUTO.DAL;

namespace AUTO.BLL
{
    public partial class YouthAcademicBLL
    {
        YouthAcademicDAL aca_dal = new YouthAcademicDAL();
        /// <summary>
        /// 取得学院列表——新闻来源
        /// </summary>
        /// <returns></returns>
        public DataSet GetAcademic()
        {
            return aca_dal.GetAcademic();
        }

        /// <summary>
        /// 获取学院投稿有效排名
        /// </summary>
        /// <returns></returns>
        public DataSet GetRank(string condition)
        {
            return aca_dal.GetRank(condition);
        }

        /// <summary>
        /// 更新学院投稿数——增加————审核
        /// </summary>
        /// <param name="academic_id"></param>
        /// <returns></returns>
        public int UpdateRank(int academic_id)
        {
            return aca_dal.UpdateRank(academic_id);
        }

        /// <summary>
        /// 更新学院投稿数——减少————反审核，删除，编辑
        /// </summary>
        /// <param name="academic_id"></param>
        /// <returns></returns>
        public int ReUpdateRank(int academic_id)
        {
            return aca_dal.ReUpdateRank(academic_id);
        }

        /// <summary>
        /// 稿件数量一键清零
        /// </summary>
        /// <returns></returns>
        public Boolean clearRank()
        {
            int rows = aca_dal.clearRank();
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
