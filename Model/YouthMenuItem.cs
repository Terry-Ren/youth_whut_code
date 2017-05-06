using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthMenuItem
    {
        private int menuitem_id;

        public int Menuitem_id
        {
            get { return menuitem_id; }
            set { menuitem_id = value; }
        }

        private int menu_id;

        public int Menu_id
        {
            get { return menu_id; }
            set { menu_id = value; }
        }

        private string menuitem_name;

        public string Menuitem_name
        {
            get { return menuitem_name; }
            set { menuitem_name = value; }
        }

        private string menuitem_content;

        public string Menuitem_content
        {
            get { return menuitem_content; }
            set { menuitem_content = value; }
        }
    }
}
