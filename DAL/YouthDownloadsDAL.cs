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
    public partial class YouthDownloadsDAL
    {
        /// <summary>
        /// 获取前几条文件数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDownloads(int top, string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + top + " * from downloads ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where " + strWhere);
            }
            str.Append(" order by upload_time desc");
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select ");
            str.Append("download_id,download_title,download_path,upload_time,download_father_id ");
            str.Append(" from downloads ");
            if (strWhere.Trim() != "")
            {
                str.Append("where " + strWhere);
            }
            if (order.Trim() != "")
            {
                str.Append(" order by  " + order);
            }
            DataSet result = DbHelperSQL.Query(str.ToString());
            return result;
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
            StringBuilder str = new StringBuilder();
            str.Append(" select top  " + top + " * from downloads ");
            if (!String.IsNullOrEmpty(strWhere))
            {
                str.Append(" where " + strWhere);
            }
            if (!String.IsNullOrEmpty(order))
            {
                str.Append(" order by  " + order);
            }
            DataSet ds = DbHelperSQL.Query(str.ToString());
            return ds;
        }

        /// <summary>
        /// 根据文件id得到文件实体
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public AUTO.Model.YouthDownload GetDownloadsById(int download_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top 1 * from downloads ");
            str.Append(" where download_id=@download_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@download_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = download_id;
            DataSet ds = DbHelperSQL.Query(str.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetDownloadsModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个model
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public AUTO.Model.YouthDownload GetDownloadsModel(DataRow row)
        {
            AUTO.Model.YouthDownload model = new Model.YouthDownload();
            if (row != null)
            {
                if (row["download_id"] != null)
                {
                    model.Download_id = Convert.ToInt32(row["download_id"].ToString());
                }
                if (row["download_title"] != null)
                {
                    model.Download_title = row["download_title"].ToString();
                }
                if (row["download_path"] != null)
                {
                    model.Download_path = row["download_path"].ToString();
                }
                if (row["download_father_id"] != null)
                {
                    model.Download_father_id = Convert.ToInt32(row["download_father_id"].ToString());
                }
                if (row["uploader"] != null)
                {
                    model.Uploader = row["uploader"].ToString();
                }
                if (row["upload_time"] != null)
                {
                    model.Upload_time = DateTime.Parse(row["upload_time"].ToString());
                }
                if (row["click_times"] != null)
                {
                    model.Click_times = Convert.ToInt32(row["click_times"].ToString());
                }
                if (row["download_source"] != null)
                {
                    model.Download_source = Convert.ToInt32(row["download_source"].ToString());
                }
                /*
                if (row["last_updater"] != null)
                {
                    model.Last_updater = row["last_updater"].ToString();
                }
                if (row["last_update_time"] != null)
                {
                    model.Last_update_time = DateTime.Parse(row["last_update_time"].ToString());
                }
                if (row["is_check"] != null)
                {
                    model.Is_check = row["is_check"].ToString();
                }
                if (row["checker"] != null)
                {
                    model.Checker = row["checker"].ToString();
                }
                if (row["check_time"] != null)
                {
                    model.Check_time = DateTime.Parse(row["check_time"].ToString());
                }
                if (row["rechecker"] != null)
                {
                    model.Rechecker = row["rechecker"].ToString();
                }
                if (row["recheck_time"] != null && !"".Equals(row["recheck_time"].ToString()))
                {
                    model.Recheck_time = DateTime.Parse(row["recheck_time"].ToString());
                }
                */
                return model;
            }
            else
            {
                return null;
            }
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
            StringBuilder str = new StringBuilder();
            str.Append(" select * from downloads where 1=1  ");
            if (strWhere.Trim() != "")
            {
                str.Append(" and " + strWhere);
            }
            String sql = "";
            int top = endIndex - startIndex + 1;
            sql = " select top " + top + " * from (select m.*, ROW_NUMBER() over (order by m.upload_time desc) as rownumber from(" + str.ToString() + ")m)t ";
            sql += " where t.rownumber<=" + endIndex + " and t.rownumber>" + (startIndex - 1) + " ";
            return DbHelperSQL.Query(sql);
            /*
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + (endIndex - startIndex + 1) + " * from downloads ");
            str.Append(" where download_id not in(");
            str.Append(" select top " + (startIndex - 1) + " download_id from downloads ");
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
            */
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
            parameters[0].Value = "downloads";
            parameters[1].Value = "download_id";
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
        /// 获得满足条件的文件总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select count(1) from downloads ");
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

        ///<summary>
        ///对阅读次数加1——文件id
        ///</summary>
        ///
        public int AddReadCount(int download_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("update downloads set click_times=click_times+1 ");
            str.Append(" where download_id=@download_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@download_id", SqlDbType.Int,8)
            };
            parameters[0].Value = download_id;
            return DbHelperSQL.ExecuteSql(str.ToString(), parameters);
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddYouthDownload(YouthDownload model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into downloads(");
            str.Append(" download_title,download_path,download_father_id,uploader,upload_time,click_times,download_source");
            str.Append(")");
            str.Append(" values ");
            str.Append("(@download_title,@download_path,@download_father_id,@uploader,@upload_time,@click_times,@download_source)");
            SqlParameter[] parameters = {
                    new SqlParameter("@download_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@download_path",SqlDbType.NText),
                    new SqlParameter("@download_father_id",SqlDbType.Int,8),
                    new SqlParameter("@uploader",SqlDbType.NVarChar,25),
                    new SqlParameter("@upload_time",SqlDbType.DateTime),
                    new SqlParameter("@click_times",SqlDbType.Int,8),
                    new SqlParameter("@download_source",SqlDbType.Int,8)
                    /*
                    new SqlParameter("@last_updater",SqlDbType.NVarChar,25),
                    new SqlParameter("@last_update_time",SqlDbType.DateTime),
                    new SqlParameter("@is_check",SqlDbType.VarChar,8),
                    new SqlParameter("@checker",SqlDbType.NVarChar,25),
                    new SqlParameter("@check_time",SqlDbType.DateTime),
                    new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                    new SqlParameter("@recheck_time",SqlDbType.DateTime)
                    */
                                        };
            parameters[0].Value = model.Download_title;
            parameters[1].Value = model.Download_path;
            parameters[2].Value = model.Download_father_id;
            parameters[3].Value = model.Uploader;
            parameters[4].Value = model.Upload_time;
            parameters[5].Value = model.Click_times;
            parameters[6].Value = model.Download_source;
            /*
            parameters[7].Value = model.Last_updater;
            parameters[8].Value = model.Last_update_time;
            parameters[9].Value = model.Is_check;
            parameters[10].Value = model.Checker;
            parameters[11].Value = model.Check_time;
            parameters[12].Value = model.Rechecker;
            parameters[13].Value = model.Recheck_time;
            */
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }
        /*
        /// <summary>
        /// 审核文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CheckDownload(YouthDownload model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update downloads set ");
            str.Append(" is_check=@is_check,");
            str.Append(" checker=@checker,");
            str.Append(" check_time=@check_time ");
            str.Append(" where download_id=@download_id ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@is_check",SqlDbType.VarChar,10),
                                        new SqlParameter("@checker",SqlDbType.NVarChar,25),
                                        new SqlParameter("@check_time",SqlDbType.DateTime),
                                        new SqlParameter("@download_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Is_check;
            parameters[1].Value = model.Checker;
            parameters[2].Value = model.Check_time;
            parameters[3].Value = model.Download_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 反审核文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ReCheckDownload(YouthDownload model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update downloads set ");
            str.Append(" is_check=@is_check,");
            str.Append(" rechecker=@rechecker,");
            str.Append(" recheck_time=@recheck_time ");
            str.Append(" where download_id=@download_id ");
            SqlParameter[] parameters = {
                                        new SqlParameter("@is_check",SqlDbType.VarChar,10),
                                        new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                                        new SqlParameter("@recheck_time",SqlDbType.DateTime),
                                        new SqlParameter("@download_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Is_check;
            parameters[1].Value = model.Rechecker;
            parameters[2].Value = model.Recheck_time;
            parameters[3].Value = model.Download_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }
        */
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="download_id"></param>
        /// <returns></returns>
        public int DelDownload(int download_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from downloads ");
            str.Append(" where download_id=@download_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@download_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = download_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 更新文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdDownload(YouthDownload model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update downloads  set ");
            str.Append(" download_title=@download_title,");
            str.Append(" download_path=@download_path,");
            str.Append(" download_father_id=@download_father_id,");
            str.Append(" uploader=@uploader,");
            str.Append(" upload_time=@upload_time,");
            str.Append(" click_times=@click_times,");
            str.Append("download_source=@download_source,");
            /*
            str.Append(" last_updater=@last_updater,");
            str.Append(" last_update_time=@last_update_time,");
            str.Append(" is_check=@is_check,");
            str.Append(" checker=@checker,");
            str.Append(" check_time=@check_time,");
            str.Append(" rechecker=@rechecker,");
            str.Append(" recheck_time=@recheck_time ");
            */
            str.Append(" where download_id=@download_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@download_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@download_path",SqlDbType.NText),
                    new SqlParameter("@download_father_id",SqlDbType.Int,8),
                    new SqlParameter("@uploader",SqlDbType.NVarChar,25),
                    new SqlParameter("@upload_time",SqlDbType.DateTime),
                    new SqlParameter("@click_times",SqlDbType.Int,8),
                    new SqlParameter("@download_source",SqlDbType.Int,8),
                    /*
                    new SqlParameter("@last_updater",SqlDbType.NVarChar,25),
                    new SqlParameter("@last_update_time",SqlDbType.DateTime),
                    new SqlParameter("@is_check",SqlDbType.VarChar,8),
                    new SqlParameter("@checker",SqlDbType.NVarChar,25),
                    new SqlParameter("@check_time",SqlDbType.DateTime),
                    new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                    new SqlParameter("@recheck_time",SqlDbType.DateTime),
                    new SqlParameter("@download_id",SqlDbType.Int,8)
                    */
                                        };
            parameters[0].Value = model.Download_title;
            parameters[1].Value = model.Download_path;
            parameters[2].Value = model.Download_father_id;
            parameters[3].Value = model.Uploader;
            parameters[4].Value = model.Upload_time;
            parameters[5].Value = model.Click_times;
            parameters[6].Value = model.Download_source;
            /*
            parameters[7].Value = model.Last_updater;
            parameters[8].Value = model.Last_update_time;
            parameters[9].Value = model.Is_check;
            parameters[10].Value = model.Checker;
            parameters[11].Value = model.Check_time;
            parameters[12].Value = model.Rechecker;
            parameters[13].Value = model.Recheck_time;
            parameters[14].Value = model.Download_id;
            */
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;

        }
    }
}
