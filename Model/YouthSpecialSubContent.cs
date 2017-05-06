using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthSpecialSubContent
    {
        private int content_id;

        public int Content_id
        {
            get { return content_id; }
            set { content_id = value; }
        }

        private int special_id;

        public int Special_id
        {
            get { return special_id; }
            set { special_id = value; }
        }

        private int sub_id;

        public int Sub_id
        {
            get { return sub_id; }
            set { sub_id = value; }
        }

        private string content_title;

        public string Content_title
        {
            get { return content_title; }
            set { content_title = value; }
        }

        private string content_content;

        public string Content_content
        {
            get { return content_content; }
            set { content_content = value; }
        }

        private string content_publisher;

        public string Content_publisher
        {
            get { return content_publisher; }
            set { content_publisher = value; }
        }

        private string content_email;

        public string Content_email
        {
            get { return content_email; }
            set { content_email = value; }
        }

        private string content_phone;

        public string Content_phone
        {
            get { return content_phone; }
            set { content_phone = value; }
        }

        private DateTime content_publish_time;

        public DateTime Content_publish_time
        {
            get { return content_publish_time; }
            set { content_publish_time = value; }
        }

        private int content_click_times;

        public int Content_click_times
        {
            get { return content_click_times; }
            set { content_click_times = value; }
        }

        private int content_source;

        public int Content_source
        {
            get { return content_source; }
            set { content_source = value; }
        }

        private string last_updater;

        public string Last_updater
        {
            get { return last_updater; }
            set { last_updater = value; }
        }

        private DateTime last_update_time;

        public DateTime Last_update_time
        {
            get { return last_update_time; }
            set { last_update_time = value; }
        }

        private string is_check;

        public string Is_check
        {
            get { return is_check; }
            set { is_check = value; }
        }

        private string checker;

        public string Checker
        {
            get { return checker; }
            set { checker = value; }
        }

        private DateTime check_time;

        public DateTime Check_time
        {
            get { return check_time; }
            set { check_time = value; }
        }

        private string rechecker;

        public string Rechecker
        {
            get { return rechecker; }
            set { rechecker = value; }
        }
        private DateTime recheck_time;

        public DateTime Recheck_time
        {
            get { return recheck_time; }
            set { recheck_time = value; }
        }
    }
}
