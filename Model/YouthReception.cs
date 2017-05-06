using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthReception
    {
        private int reception_id;

        public int Reception_id
        {
            get { return reception_id; }
            set { reception_id = value; }
        }

        private string reception_name;

        public string Reception_name
        {
            get { return reception_name; }
            set { reception_name = value; }
        }

        private string reception_sex;

        public string Reception_sex
        {
            get { return reception_sex; }
            set { reception_sex = value; }
        }

        private string reception_homepage;

        public string Reception_homepage
        {
            get { return reception_homepage; }
            set { reception_homepage = value; }
        }

        private string reception_email;

        public string Reception_email
        {
            get { return reception_email; }
            set { reception_email = value; }
        }

        private string reception_qq;

        public string Reception_qq
        {
            get { return reception_qq; }
            set { reception_qq = value; }
        }

        private string reception_title;

        public string Reception_title
        {
            get { return reception_title; }
            set { reception_title = value; }
        }

        private string reception_content;

        public string Reception_content
        {
            get { return reception_content; }
            set { reception_content = value; }
        }

        private DateTime reception_time;

        public DateTime Reception_time
        {
            get { return reception_time; }
            set { reception_time = value; }
        }

        private string is_reply;

        public string Is_reply
        {
            get { return is_reply; }
            set { is_reply = value; }
        }

        private int reception_type_id;

        public int Reception_type_id
        {
            get { return reception_type_id; }
            set { reception_type_id = value; }
        }
    }
}
