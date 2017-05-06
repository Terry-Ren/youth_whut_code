using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUTO.DAL;

namespace AUTO.BLL
{
    public partial class YouthInitialPwdBLL
    {
        YouthInitialPwdDAL ip_dal = new YouthInitialPwdDAL();
        /// <summary>
        /// 取得初始密码
        /// </summary>
        /// <returns></returns>
        public string GetInitialPwd()
        {
            return ip_dal.GetInitialPwd();
        }
    }
}
