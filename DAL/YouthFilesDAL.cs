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
    public partial class YouthFilesDAL
    {
        /// <summary>
        /// 获取前几条文件数据
        /// </summary>
        /// <param name="top"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetFiles(int top, string strWhere)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top " + top + " * from files ");
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
            str.Append("file_id,file_title,file_remark,upload_time,file_father_id ");
            str.Append(" from files ");
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
        public DataSet GetFiles(int top, string strWhere, string order)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top  " + top + " * from files ");
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
        public AUTO.Model.YouthFile GetFilesById(int file_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" select top 1 * from files ");
            str.Append(" where file_id=@file_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@file_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = file_id;
            DataSet ds = DbHelperSQL.Query(str.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetFilesModel(ds.Tables[0].Rows[0]);
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
        public AUTO.Model.YouthFile GetFilesModel(DataRow row)
        {
            AUTO.Model.YouthFile model = new Model.YouthFile();
            if (row != null)
            {
                if (row["file_id"] != null)
                {
                    model.File_id = Convert.ToInt32(row["file_id"].ToString());
                }
                if (row["file_title"] != null)
                {
                    model.File_title = row["file_title"].ToString();
                }
                if (row["file_remark"] != null)
                {
                    model.File_remark = row["file_remark"].ToString();
                }
                if (row["file_father_id"] != null)
                {
                    model.File_father_id = Convert.ToInt32(row["file_father_id"].ToString());
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
                if (row["file_source"] != null)
                {
                    model.File_source = Convert.ToInt32(row["file_source"].ToString());
                }
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
            str.Append(" select * from files where 1=1  ");
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
            str.Append(" select top " + (endIndex - startIndex + 1) + " * from files ");
            str.Append(" where file_id not in(");
            str.Append(" select top " + (startIndex - 1) + " file_id from files ");
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
            parameters[0].Value = "files";
            parameters[1].Value = "file_id";
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
            str.Append(" select count(1) from files ");
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
        public int AddReadCount(int file_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("update files set click_times=click_times+1 ");
            str.Append(" where file_id=@file_id");
            SqlParameter[] parameters = {
					new SqlParameter("@file_id", SqlDbType.Int,8)
			};
            parameters[0].Value = file_id;
            return DbHelperSQL.ExecuteSql(str.ToString(), parameters);
        }

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddYouthFile(YouthFile model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" insert into files(");
            str.Append(" file_title,file_remark,file_father_id,uploader,upload_time,click_times,file_source,last_updater,last_update_time,is_check,checker,check_time,rechecker,recheck_time");
            str.Append(")");
            str.Append(" values ");
            str.Append("(@file_title,@file_remark,@file_father_id,@uploader,@upload_time,@click_times,@file_source,@last_updater,@last_update_time,@is_check,@checker,@check_time,@rechecker,@recheck_time)");
            SqlParameter[] parameters = {
					new SqlParameter("@file_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@file_remark",SqlDbType.NText),
                    new SqlParameter("@file_father_id",SqlDbType.Int,8),
                    new SqlParameter("@uploader",SqlDbType.NVarChar,25),
                    new SqlParameter("@upload_time",SqlDbType.DateTime),
                    new SqlParameter("@click_times",SqlDbType.Int,8),
                    new SqlParameter("@file_source",SqlDbType.Int,8),
                    new SqlParameter("@last_updater",SqlDbType.NVarChar,25),
                    new SqlParameter("@last_update_time",SqlDbType.DateTime),
                    new SqlParameter("@is_check",SqlDbType.VarChar,8),
                    new SqlParameter("@checker",SqlDbType.NVarChar,25),
                    new SqlParameter("@check_time",SqlDbType.DateTime),
                    new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                    new SqlParameter("@recheck_time",SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.File_title;
            parameters[1].Value = model.File_remark;
            parameters[2].Value = model.File_father_id;
            parameters[3].Value = model.Uploader;
            parameters[4].Value = model.Upload_time;
            parameters[5].Value = model.Click_times;
            parameters[6].Value = model.File_source;
            parameters[7].Value = model.Last_updater;
            parameters[8].Value = model.Last_update_time;
            parameters[9].Value = model.Is_check;
            parameters[10].Value = model.Checker;
            parameters[11].Value = model.Check_time;
            parameters[12].Value = model.Rechecker;
            parameters[13].Value = model.Recheck_time;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 审核文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CheckFile(YouthFile model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update files set ");
            str.Append(" is_check=@is_check,");
            str.Append(" checker=@checker,");
            str.Append(" check_time=@check_time ");
            str.Append(" where file_id=@file_id ");
            SqlParameter[] parameters = { 
                                        new SqlParameter("@is_check",SqlDbType.VarChar,10),
                                        new SqlParameter("@checker",SqlDbType.NVarChar,25),
                                        new SqlParameter("@check_time",SqlDbType.DateTime),
                                        new SqlParameter("@file_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Is_check;
            parameters[1].Value = model.Checker;
            parameters[2].Value = model.Check_time;
            parameters[3].Value = model.File_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 反审核文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ReCheckFile(YouthFile model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update files set ");
            str.Append(" is_check=@is_check,");
            str.Append(" rechecker=@rechecker,");
            str.Append(" recheck_time=@recheck_time ");
            str.Append(" where file_id=@file_id ");
            SqlParameter[] parameters = { 
                                        new SqlParameter("@is_check",SqlDbType.VarChar,10),
                                        new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                                        new SqlParameter("@recheck_time",SqlDbType.DateTime),
                                        new SqlParameter("@file_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.Is_check;
            parameters[1].Value = model.Rechecker;
            parameters[2].Value = model.Recheck_time;
            parameters[3].Value = model.File_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="file_id"></param>
        /// <returns></returns>
        public int DelFile(int file_id)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" delete from files ");
            str.Append(" where file_id=@file_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@file_id", SqlDbType.Int,8)
                                        };
            parameters[0].Value = file_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 更新文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdFile(YouthFile model)
        {
            StringBuilder str = new StringBuilder();
            str.Append(" update files  set ");
            str.Append(" file_title=@file_title,");
            str.Append(" file_remark=@file_remark,");
            str.Append(" file_father_id=@file_father_id,");
            str.Append(" uploader=@uploader,");
            str.Append(" upload_time=@upload_time,");
            str.Append(" click_times=@click_times,");
            str.Append("file_source=@file_source,");
            str.Append(" last_updater=@last_updater,");
            str.Append(" last_update_time=@last_update_time,");
            str.Append(" is_check=@is_check,");
            str.Append(" checker=@checker,");
            str.Append(" check_time=@check_time,");
            str.Append(" rechecker=@rechecker,");
            str.Append(" recheck_time=@recheck_time ");
            str.Append(" where file_id=@file_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@file_title", SqlDbType.NVarChar,50),
                    new SqlParameter("@file_remark",SqlDbType.NText),
                    new SqlParameter("@file_father_id",SqlDbType.Int,8),
                    new SqlParameter("@uploader",SqlDbType.NVarChar,25),
                    new SqlParameter("@upload_time",SqlDbType.DateTime),
                    new SqlParameter("@click_times",SqlDbType.Int,8),
                    new SqlParameter("@file_source",SqlDbType.Int,8),
                    new SqlParameter("@last_updater",SqlDbType.NVarChar,25),
                    new SqlParameter("@last_update_time",SqlDbType.DateTime),
                    new SqlParameter("@is_check",SqlDbType.VarChar,8),
                    new SqlParameter("@checker",SqlDbType.NVarChar,25),
                    new SqlParameter("@check_time",SqlDbType.DateTime),
                    new SqlParameter("@rechecker",SqlDbType.NVarChar,25),
                    new SqlParameter("@recheck_time",SqlDbType.DateTime),
                    new SqlParameter("@file_id",SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.File_title;
            parameters[1].Value = model.File_remark;
            parameters[2].Value = model.File_father_id;
            parameters[3].Value = model.Uploader;
            parameters[4].Value = model.Upload_time;
            parameters[5].Value = model.Click_times;
            parameters[6].Value = model.File_source;
            parameters[7].Value = model.Last_updater;
            parameters[8].Value = model.Last_update_time;
            parameters[9].Value = model.Is_check;
            parameters[10].Value = model.Checker;
            parameters[11].Value = model.Check_time;
            parameters[12].Value = model.Rechecker;
            parameters[13].Value = model.Recheck_time;
            parameters[14].Value = model.File_id;
            int rows = DbHelperSQL.ExecuteSql(str.ToString(), parameters);
            return rows;

        }
    }
}
