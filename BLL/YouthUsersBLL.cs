using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;
using System.Data;
using AUTO.Model;

namespace AUTO.BLL
{
    public partial class YouthUsersBLL
    {
        /// <summary>
        /// 验证登录用户是否存在
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="user_pwd"></param>
        /// <param name="Role_id"></param>
        /// <returns></returns>
        public bool check_user(string user_name, string user_pwd, int Role_id)
        {
            YouthUsersDAL user_dal = new YouthUsersDAL();
            int i = user_dal.check_user(user_name, user_pwd, Role_id);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 登录成功后，根据用户名和密码得到登录用户数据
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="user_pwd"></param>
        /// <returns></returns>
        public int GetUserIdByName(string user_name, string user_pwd)
        {
            YouthUsersDAL user_dal = new YouthUsersDAL();
            return user_dal.GetUserIdByName(user_name, user_pwd);
        }

        /// <summary>
        /// 根据用户id得到用户实体
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public AUTO.Model.YouthUsers GetUserById(int user_id)
        {
            YouthUsersDAL user_dal = new YouthUsersDAL();
            return user_dal.GetUserById(user_id);
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
            YouthUsersDAL user_dal = new YouthUsersDAL();
            return user_dal.GetListByPage(strWhere, pageSize, pageIndex, sortString);
        }


        /// <summary>
        /// 获得满足条件的用户总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere)
        {
            YouthUsersDAL user_dal = new YouthUsersDAL();
            return user_dal.GetRecordCount(strWhere);
        }


        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddUsers(YouthUsers model)
        {
            YouthUsersDAL user_dal = new YouthUsersDAL();
            int rows = user_dal.AddUsers(model);
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
        /// 删除用户
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public bool DelUsers(int user_id)
        {
            YouthUsersDAL user_dal = new YouthUsersDAL();
            int rows = user_dal.DelUsers(user_id);
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
        /// 冻结与解冻账号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool FrezzeUsers(YouthUsers model)
        {
            YouthUsersDAL user_dal = new YouthUsersDAL();
            int rows = user_dal.FrezzeUsers(model);
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
        /// 初始化——重置密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ResetPwd(YouthUsers model)
        {
            YouthUsersDAL user_dal = new YouthUsersDAL();
            int rows = user_dal.ResetPwd(model);
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
        /// 根据用户名来验证是否已经存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsExits(string username)
        {
            YouthUsersDAL user_dal = new YouthUsersDAL();
            int i = user_dal.IsExits(username);
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 书记会客室得到书记列表
        /// </summary>
        /// <returns></returns>
        public DataSet getShuJi()
        {
            YouthUsersDAL user_dal = new YouthUsersDAL();
            return user_dal.getShuJi();
        }
    }
}
