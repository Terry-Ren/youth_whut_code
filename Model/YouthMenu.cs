using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthMenu
    {
        private int menu_id;

        public int Menu_id
        {
            get { return menu_id; }
            set { menu_id = value; }
        }

        private string menu_name;

        public string Menu_name
        {
            get { return menu_name; }
            set { menu_name = value; }
        }

        private string menu_content;

        public string Menu_content
        {
            get { return menu_content; }
            set { menu_content = value; }
        }
    }
}
