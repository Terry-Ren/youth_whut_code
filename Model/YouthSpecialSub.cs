using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthSpecialSub
    {
        private int sub_id;

        public int Sub_id
        {
            get { return sub_id; }
            set { sub_id = value; }
        }

        private int special_id;

        public int Special_id
        {
            get { return special_id; }
            set { special_id = value; }
        }

        private string sub_title;

        public string Sub_title
        {
            get { return sub_title; }
            set { sub_title = value; }
        }

        private int sub_paixu;

        public int Sub_paixu
        {
            get { return sub_paixu; }
            set { sub_paixu = value; }
        }
    }
}
