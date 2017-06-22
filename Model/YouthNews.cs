using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthNews
    {
        private int news_id;

        public int News_id
        {
            get { return news_id; }
            set { news_id = value; }
        }

        private string news_title;

        public string News_title
        {
            get { return news_title; }
            set { news_title = value; }
        }

        private string news_revise;

        public string News_revise
        {
            get { return news_revise; }
            set { news_revise = value; }
        }
        private string news_content;

        public string News_content
        {
            get { return news_content; }
            set { news_content = value; }
        }

        private int news_father_id;

        public int News_father_id
        {
            get { return news_father_id; }
            set { news_father_id = value; }
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

        private int news_source;

        public int News_source
        {
            get { return news_source; }
            set { news_source = value; }
        }

        private string last_update;

        public string Last_update
        {
            get { return last_update; }
            set { last_update = value; }
        }

        private DateTime last_update_time;

        public DateTime Last_update_time
        {
            get { return last_update_time; }
            set { last_update_time = value; }
        }

        private string firse_check;

        public string First_check
        {
            get { return firse_check; }
            set { firse_check = value; }
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

        private string is_photoNews;

        public string Is_photoNews
        {
            get { return is_photoNews; }
            set { is_photoNews = value; }
        }

        private string photo_url;

        public string Photo_url
        {
            get { return photo_url; }
            set { photo_url = value; }
        }
    }
}
