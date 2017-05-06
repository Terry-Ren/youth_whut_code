using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthNewsColumn
    {
        private int news_column_id;

        public int News_column_id
        {
            get { return news_column_id; }
            set { news_column_id = value; }
        }

        private string news_column_name;

        public string News_column_name
        {
            get { return news_column_name; }
            set { news_column_name = value; }
        }
    }
}
