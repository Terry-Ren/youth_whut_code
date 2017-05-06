using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthRole
    {
        private int role_id;

        public int Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }

        private string role_name;

        public string Role_name
        {
            get { return role_name; }
            set { role_name = value; }
        }
    }
}
