using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTO.Model
{
    public partial class YouthVideo
    {
        private int video_id;

        public int Video_id
        {
            get { return video_id; }
            set { video_id = value; }
        }

        private string video_title;

        public string Video_title
        {
            get { return video_title; }
            set { video_title = value; }
        }

        private string video_uper;

        public string Video_uper
        {
            get { return video_uper; }
            set { video_uper = value; }
        }

        private DateTime video_up_time;

        public DateTime Video_up_time
        {
            get { return video_up_time; }
            set { video_up_time = value; }
        }

        private string video_pic;

        public string Video_pic
        {
            get { return video_pic; }
            set { video_pic = value; }
        }

        private string video_link;

        public string Video_link
        {
            get { return video_link; }
            set { video_link = value; }
        }
    }
}
