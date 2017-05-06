using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthSecretary
    {
        private int secretary_id;

        public int Secretary_id
        {
            get { return secretary_id; }
            set { secretary_id = value; }
        }

        private int reception_id;
        //被回复id
        public int Reception_id
        {
            get { return reception_id; }
            set { reception_id = value; }
        }

        private int secretary_sid;
        //团委书记id;
        public int Secretary_sid
        {
            get { return secretary_sid; }
            set { secretary_sid = value; }
        }

        private string secretary_name;

        public string Secretary_name
        {
            get { return secretary_name; }
            set { secretary_name = value; }
        }

        private string secretary_content;

        public string Secretary_content
        {
            get { return secretary_content; }
            set { secretary_content = value; }
        }

        private DateTime secretary_time;

        public DateTime Secretary_time
        {
            get { return secretary_time; }
            set { secretary_time = value; }
        }
    }
}
