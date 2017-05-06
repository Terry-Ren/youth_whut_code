using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthSpecial
    {
        private int special_id;

        public int Special_id
        {
            get { return special_id; }
            set { special_id = value; }
        }

        private string special_title;

        public string Special_title
        {
            get { return special_title; }
            set { special_title = value; }
        }

        private string special_img_url;

        public string Special_img_url
        {
            get { return special_img_url; }
            set { special_img_url = value; }
        }

        private string is_banner;

        public string Is_banner
        {
            get { return is_banner; }
            set { is_banner = value; }
        }
    }
}
