using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthDownloadColumn
    {
        private int download_column_id;

        public int Download_column_id
        {
            get { return download_column_id; }
            set { download_column_id = value; }
        }

        private string download_column_name;

        public string Download_column_name
        {
            get { return download_column_name; }
            set { download_column_name = value; }
        }
    }
}
