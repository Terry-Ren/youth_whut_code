using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthFileColumn
    {
        private int file_column_id;

        public int File_column_id
        {
            get { return file_column_id; }
            set { file_column_id = value; }
        }

        private string file_column_name;

        public string File_column_name
        {
            get { return file_column_name; }
            set { file_column_name = value; }
        }
    }
}
