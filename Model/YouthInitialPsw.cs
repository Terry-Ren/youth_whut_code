using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthInitialPsw
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string initialPsw;

        public string InitialPsw
        {
            get { return initialPsw; }
            set { initialPsw = value; }
        }
    }
}
