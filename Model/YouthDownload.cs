using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthDownload
    {
        private int download_id;

        public int Download_id
        {
            get { return download_id; }
            set { download_id = value; }
        }

        private string download_title;

        public string Download_title
        {
            get { return download_title; }
            set { download_title = value; }
        }

        private string download_path;

        public string Download_path
        {
            get { return download_path; }
            set { download_path = value; }
        }

        private string download_content;

        public string Download_content
        {
            get { return download_content; }
            set { download_content = value; }
        }
        private int download_father_id;

        public int Download_father_id
        {
            get { return download_father_id; }
            set { download_father_id = value; }
        }

        private string uploader;

        public string Uploader
        {
            get { return uploader; }
            set { uploader = value; }
        }

        private DateTime upload_time;

        public DateTime Upload_time
        {
            get { return upload_time; }
            set { upload_time = value; }
        }

        private int click_times;

        public int Click_times
        {
            get { return click_times; }
            set { click_times = value; }
        }

        private int download_source;

        public int Download_source
        {
            get { return download_source; }
            set { download_source = value; }
        }
        /*
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
        */
    }
}
