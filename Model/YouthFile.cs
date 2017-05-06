using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthFile
    {
        private int file_id;

        public int File_id
        {
            get { return file_id; }
            set { file_id = value; }
        }

        private string file_title;

        public string File_title
        {
            get { return file_title; }
            set { file_title = value; }
        }

        private string file_remark;

        public string File_remark
        {
            get { return file_remark; }
            set { file_remark = value; }
        }
        private int file_father_id;

        public int File_father_id
        {
            get { return file_father_id; }
            set { file_father_id = value; }
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

        private int file_source;

        public int File_source
        {
            get { return file_source; }
            set { file_source = value; }
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
