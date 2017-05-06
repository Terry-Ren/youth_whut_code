using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AUTO.Utility;
using AUTO.Model;

namespace AUTO.DAL
{
    public partial class YouthVideoDAL
    {
        /// <summary>
        /// 根据id得到视频对象实体
        /// </summary>
        /// <param name="video_id"></param>
        /// <returns></returns>
        public YouthVideo GetListById(int video_id)
        {
            YouthVideo model = new YouthVideo();
            StringBuilder str = new StringBuilder();
            str.Append(" select * from video ");
            str.Append(" where video_id=" + video_id);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["video_id"] != null)
                {
                    model.Video_id = Convert.ToInt32(row["video_id"].ToString());
                }
                if (row["video_title"] != null)
                {
                    model.Video_title = row["video_title"].ToString();
                }
                if (row["video_uper"] != null)
                {
                    model.Video_uper = row["video_uper"].ToString();
                }
                if (row["video_up_time"] != null)
                {
                    model.Video_up_time = DateTime.Parse(row["video_up_time"].ToString());
                }
                if (row["video_pic"] != null)
                {
                    model.Video_pic = row["video_pic"].ToString();
                }
                if (row["video_link"] != null)
                {
                    model.Video_link = row["video_link"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据条件获取前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetTopVideo(int top, string strWhere, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top  " + top + " * from video  ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where " + strWhere);
            }
            str.Append(" order by " + order);
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }


        /// <summary>
        /// 首页分页获取视频列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string order, int startIndex, int endIndex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + (endIndex - startIndex + 1) + " * from video ");
            str.Append(" where video_id not in(");
            str.Append(" select top " + (startIndex - 1) + " video_id from video ");
            if (!String.IsNullOrEmpty(order))
            {
                str.Append(" order by " + order);
            }
            str.Append(")");
            if (strWhere.Trim() != "")
            {
                str.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(str.ToString());
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
            SqlParameter[] parameters = {
                    new SqlParameter("@tbname", SqlDbType.NVarChar,128),
                    new SqlParameter("@FieldKey", SqlDbType.NVarChar,128),
                    new SqlParameter("@PageCurrent", SqlDbType.Int,4),
                    new SqlParameter("@PageSize", SqlDbType.Int,4),
                    new SqlParameter("@FieldOrder", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Where", SqlDbType.NVarChar,1000),
                    new SqlParameter("@RecordCount", SqlDbType.Int,4),
                    new SqlParameter("@PageCount", SqlDbType.Int,4)
            };
            parameters[0].Value = "video";
            parameters[1].Value = "video_id";
            parameters[2].Value = pageIndex;
            parameters[3].Value = pageSize;
            parameters[4].Value = sortString;
            parameters[5].Value = strWhere;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            /*注：没有参数 @FieldShow，则默认显示表或视图中的所有字段*/
            return DbHelperSQL.RunProcedures("sp_PageList", parameters);
        }

        /// <summary>
        /// 获得满足条件的用户总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select count(1) from video ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(str.ToString());
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 添加视频
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddVideo(YouthVideo model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into video ");
            str.Append("(video_title,video_uper,video_up_time,video_pic,video_link)");
            str.Append(" values ");
            str.Append(" (@video_title,@video_uper,@video_up_time,@video_pic,@video_link) ");
            SqlParameter[] parameters = {
                    new SqlParameter("@video_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@video_uper", SqlDbType.NVarChar,25),
                    new SqlParameter("@video_up_time", SqlDbType.DateTime),
                    new SqlParameter("@video_pic", SqlDbType.NVarChar,50),
                    new SqlParameter("@video_link", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.Video_title;
            parameters[1].Value = model.Video_uper;
            parameters[2].Value = model.Video_up_time;
            parameters[3].Value = model.Video_pic;
            parameters[4].Value = model.Video_link;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }


        /// <summary>
        /// 删除视频
        /// </summary>
        /// <param name="video_id"></param>
        /// <returns></returns>
        public int DelVideo(int video_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from video ");
            str.Append(" where video_id=" + video_id);
            int rows = DbHelperSQL.ExecuteSql(str.ToString());
            return rows;
        }

        /// <summary>
        /// 更新视频
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdVideo(YouthVideo model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update video set  ");
            str.Append(" video_title=@video_title,");
            str.Append(" video_uper=@video_uper,");
            str.Append(" video_up_time=@video_up_time,");
            str.Append(" video_pic=@video_pic,");
            str.Append(" video_link=@video_link ");
            str.Append(" where video_id=@video_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@video_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@video_uper", SqlDbType.NVarChar,25),
                    new SqlParameter("@video_up_time", SqlDbType.DateTime),
                    new SqlParameter("@video_pic", SqlDbType.NVarChar,50),
                    new SqlParameter("@video_link", SqlDbType.NVarChar,50),
                    new SqlParameter("@video_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Video_title;
            parameters[1].Value = model.Video_uper;
            parameters[2].Value = model.Video_up_time;
            parameters[3].Value = model.Video_pic;
            parameters[4].Value = model.Video_link;
            parameters[5].Value = model.Video_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }
    }
}
