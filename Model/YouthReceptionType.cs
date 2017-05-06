using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthReceptionType
    {
        private int reception_type_id;

        public int Reception_type_id
        {
            get { return reception_type_id; }
            set { reception_type_id = value; }
        }
        private string reception_type;

        public string Reception_type
        {
            get { return reception_type; }
            set { reception_type = value; }
        }
    }
}
