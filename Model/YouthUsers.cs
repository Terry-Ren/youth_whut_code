using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthUsers
    {
        private int user_id;

        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        private string user_name;

        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }

        private string user_pwd;

        public string User_pwd
        {
            get { return user_pwd; }
            set { user_pwd = value; }
        }

        private int role_id;

        public int Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }

        private string true_name;

        public string True_name
        {
            get { return true_name; }
            set { true_name = value; }
        }

        private string user_sex;

        public string User_sex
        {
            get { return user_sex; }
            set { user_sex = value; }
        }

        private int user_dep_id;

        public int User_dep
        {
            get { return user_dep_id; }
            set { user_dep_id = value; }
        }

        private string user_status;

        public string User_status
        {
            get { return user_status; }
            set { user_status = value; }
        }

        private string user_phone;

        public string User_phone
        {
            get { return user_phone; }
            set { user_phone = value; }
        }

        private string user_email;

        public string User_email
        {
            get { return user_email; }
            set { user_email = value; }
        }

        private int user_academic_id;

        public int User_academic_id
        {
            get { return user_academic_id; }
            set { user_academic_id = value; }
        }

        private int user_points;

        public int User_points
        {
            get { return user_points; }
            set { user_points = value; }
        }

        private string user_address;

        public string User_address
        {
            get { return user_address; }
            set { user_address = value; }
        }
    }
}
