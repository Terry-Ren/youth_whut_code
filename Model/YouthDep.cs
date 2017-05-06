using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthDep
    {
        private int dep_id;

        public int Dep_id
        {
            get { return dep_id; }
            set { dep_id = value; }
        }

        private string dep_name;

        public string Dep_name
        {
            get { return dep_name; }
            set { dep_name = value; }
        }
    }
}
