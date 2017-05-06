using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthAcademic
    {
        private int academic_id;

        public int Academic_id
        {
            get { return academic_id; }
            set { academic_id = value; }
        }

        private string academic_name;

        public string Academic_name
        {
            get { return academic_name; }
            set { academic_name = value; }
        }

        private int academic_rank;

        public int Academic_rank
        {
            get { return academic_rank; }
            set { academic_rank = value; }
        }
    }
}
