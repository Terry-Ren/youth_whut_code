using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthTalkLg
    {
        private int talk_id;

        public int Talk_id
        {
            get { return talk_id; }
            set { talk_id = value; }
        }

        private string talk_title;

        public string Talk_title
        {
            get { return talk_title; }
            set { talk_title = value; }
        }

        private string talk_Img_url;

        public string Talk_Img_url
        {
            get { return talk_Img_url; }
            set { talk_Img_url = value; }
        }

        private string talk_content;

        public string Talk_content
        {
            get { return talk_content; }
            set { talk_content = value; }
        }

        private string publisher;

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        private string publisher_phone;

        public string Publisher_phone
        {
            get { return publisher_phone; }
            set { publisher_phone = value; }
        }

        private string publisher_mail;

        public string Publisher_mail
        {
            get { return publisher_mail; }
            set { publisher_mail = value; }
        }

        private DateTime publish_time;

        public DateTime Publish_time
        {
            get { return publish_time; }
            set { publish_time = value; }
        }

        private int click_times;

        public int Click_times
        {
            get { return click_times; }
            set { click_times = value; }
        }

        private int talk_source;

        public int Talk_source
        {
            get { return talk_source; }
            set { talk_source = value; }
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
