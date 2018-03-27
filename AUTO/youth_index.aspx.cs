using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTO.BLL;
using System.Data;
using System.Collections;

namespace AUTO
{
    public partial class youth_index : System.Web.UI.Page
    {
        YouthNewsBLL news_bll = new YouthNewsBLL();
        YouthNewsColBLL news_col_bll = new YouthNewsColBLL();

        YouthFilesBLL file_bll = new YouthFilesBLL();
        YouthFilesColBLL file_col_bll = new YouthFilesColBLL();

        YouthSpecialBLL special_bll = new YouthSpecialBLL();
        YouthVideoBLL video_bll = new YouthVideoBLL();
        YouthTalkLgBLL talk_bll = new YouthTalkLgBLL();
        YouthAcademicBLL aca_bll = new YouthAcademicBLL();
        YouthOnlineBLL online_bll = new YouthOnlineBLL();

        //设置新闻速递与第一条记录的ID,标题，时间，内容等
        public String news_fast_name = String.Empty;
        public int news_fast_id = 0;

        public int fast_id = 0;
        public string fast_title = "";
        public string fast_time = "";
        public string fast_content = "";

        //设置基层团建与第一条记录的ID，标题，时间，内容等
        public String news_jiceng_name = String.Empty;
        public int news_jiceng_id = 0;
        public int jiceng_id = 0;
        public string jiceng_title = "";
        public string jiceng_time = "";

        //设置学生社团与第一条记录的ID，标题，时间，内容等
        public String news_shetuan_name = String.Empty;
        public int news_shetuan_id = 0;
        public int shetuan_id = 0;
        public string shetuan_title = "";
        public string shetuan_time = "";

        //设置学院动态与第一条记录的ID，标题，时间，内容等
        public String news_xueyuan_name = String.Empty;
        public int news_xueyuan_id = 0;
        public int xueyuan_id = 0;
        public string xueyuan_title = "";
        public string xueyuan_time = "";

        //设置理工才俊与第一条记录的ID,标题，时间，内容等
        public String news_caijun_name = String.Empty;
        public int news_caijun_id = 0;

        public int caijun_id = 0;
        public string caijun_title = "";
        public string caijun_time = "";
        public string caijun_content = "";

        //设置共青之声与第一条记录的ID,标题，时间，内容等
        public String news_gongqing_name = String.Empty;
        public int news_gongqing_id = 0;

        public int gongqing_id = 0;
        public string gongqing_title = "";
        public string gongqing_time = "";
        public string gongqing_content = "";

        //设置校园在线与第一条记录的ID,标题，时间，内容等
        public String news_zaixian_name = String.Empty;
        public int news_zaixian_id = 0;

        public int zaixian_id = 0;
        public string zaixian_title = "";
        public string zaixian_time = "";
        public string zaixian_content = "";


        //设置规章制度
        public String file_guizhang_name = String.Empty;
        public int file_guizhang_id = 0;

        public int guizhang_id = 0;
        public string guizhang_title = "";
        public string guizhang_time = "";
        public string guizhang_content = "";

        //设置通知公告
        public String news_gonggao_name = String.Empty;
        public int news_gonggao_id = 0;

        //设置banner
        public string special_img_url = "";
        public int special_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindNewsCol();
                bindNewsFast();
                //bindGongGao();
                bindHomeImg();
                bindJicengTuanjian();
                bindStudentShetuan();
                bindAcademicDongtai();
                bindTecCaiJun();
                bindGongQing();
                bindZaiXian();
                bindGuiZhang();
                //bindFile();
                bindJingPin();
                bindVideo();
                bindTalkLG();
                bindRank();
                DataSet ds = online_bll.GetListById();
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["online_switch"]) == 1)
                {
                    Online.Style.Value = "display:none";
                    HyperLink1.Enabled = false;
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["online_switch"]) == 2)
                {
                    Online.Style.Value = "display:inline";
                }
            }
        }


        //绑定新闻速递
        protected void bindNewsFast()
        {
            //取到第一条
            AUTO.Model.YouthNews model = news_bll.GetFirstList(" news_father_id=" + news_fast_id + " and is_check='Y' ", "  publish_time desc  ");
            if (model != null)
            {
                fast_id = Convert.ToInt32(model.News_id);
                fast_title = model.News_title.Length > 24 ? model.News_title.Substring(0, 23) + "..." : model.News_title.ToString();
                fast_time = FormatTime(model.Publish_time);
                fast_content = model.News_content.Length > 40 ? model.News_content.Substring(0, 39) : model.News_content;
            }

            //取到剩余的几条数据
            DataSet ds = news_bll.GetOtherFirstList(11, " news_id ", "news_father_id=" + news_fast_id + " and is_check='Y'", " publish_time desc ");
            rptSudi.DataSource = ds;
            rptSudi.DataBind();


        }


        //绑定通知公告
        //protected void bindGongGao()
        //{
        //    DataSet ds = news_bll.GetList(6, " news_father_id =" + news_gonggao_id + " and is_check='Y'", " publish_time desc ");
        //    rptGongGao.DataSource = ds;
        //    rptGongGao.DataBind();
        //}

        //绑定基层团建
        protected void bindJicengTuanjian()
        {
            //取到第一条
            AUTO.Model.YouthNews model = news_bll.GetFirstList(" news_father_id=" + news_jiceng_id + " and is_check='Y' ", "  publish_time desc ");
            if (model != null)
            {
                jiceng_id = Convert.ToInt32(model.News_id);
                jiceng_title = model.News_title.Length > 16 ? model.News_title.Substring(0, 15) + "..." : model.News_title.ToString();
                jiceng_time = FormatTime(model.Publish_time);
            }

            //取到剩余几条数据
            DataSet ds = news_bll.GetOtherFirstList(8, " news_id ", " news_father_id=" + news_jiceng_id + " and is_check='Y' ", " publish_time desc ");
            rptJiceng.DataSource = ds;
            rptJiceng.DataBind();
        }

        //绑定学生社团
        protected void bindStudentShetuan()
        {
            //取到第一条
            AUTO.Model.YouthNews model = news_bll.GetFirstList(" news_father_id=" + news_shetuan_id + " and is_check='Y' ", "  publish_time desc ");
            if (model != null)
            {
                shetuan_id = Convert.ToInt32(model.News_id);
                shetuan_title = model.News_title.Length > 16 ? model.News_title.Substring(0, 15) + "..." : model.News_title.ToString();
                shetuan_time = FormatTime(model.Publish_time);
            }

            //取到剩余几条数据
            DataSet ds = news_bll.GetOtherFirstList(8, " news_id ", " news_father_id=" + news_shetuan_id + " and is_check='Y' ", " publish_time desc ");
            rptShetuan.DataSource = ds;
            rptShetuan.DataBind();
        }

        //绑定学院动态
        protected void bindAcademicDongtai()
        {
            //取到第一条
            AUTO.Model.YouthNews model = news_bll.GetFirstList(" news_father_id=" + news_xueyuan_id + " and is_check='Y' ", "  publish_time desc ");
            if (model != null)
            {
                xueyuan_id = Convert.ToInt32(model.News_id);
                xueyuan_title = model.News_title.Length > 16 ? model.News_title.Substring(0, 15) + "..." : model.News_title.ToString();
                xueyuan_time = FormatTime(model.Publish_time);
            }

            //取到剩余几条数据
            DataSet ds = news_bll.GetOtherFirstList(8, " news_id ", " news_father_id=" + news_xueyuan_id + " and is_check='Y' ", " publish_time desc ");
            rptXueyuan.DataSource = ds;
            rptXueyuan.DataBind();
        }

        //绑定理工才俊
        protected void bindTecCaiJun()
        {
            //取到第一条
            AUTO.Model.YouthNews model = news_bll.GetFirstList(" news_father_id=" + news_caijun_id + " and is_check='Y' ", "  publish_time desc  ");
            if (model != null)
            {
                caijun_id = Convert.ToInt32(model.News_id);
                caijun_title = model.News_title.Length > 16 ? model.News_title.Substring(0, 15) + "..." : model.News_title.ToString();
                caijun_time = FormatTime(model.Publish_time);
                caijun_content = model.News_content.Length > 40 ? model.News_content.Substring(0, 39) : model.News_content;
            }

            //取到剩余的几条数据
            DataSet ds = news_bll.GetOtherFirstList(8, " news_id ", "news_father_id=" + news_caijun_id + " and is_check='Y'", " publish_time desc ");
            rptCaiJun.DataSource = ds;
            rptCaiJun.DataBind();
        }

        //绑定共青之声
        protected void bindGongQing()
        {
            //取到第一条
            AUTO.Model.YouthNews model = news_bll.GetFirstList(" news_father_id=" + news_gongqing_id + " and is_check='Y' ", "  publish_time desc  ");
            if (model != null)
            {
                gongqing_id = Convert.ToInt32(model.News_id);
                gongqing_title = model.News_title.Length > 16 ? model.News_title.Substring(0, 15) + "..." : model.News_title.ToString();
                gongqing_time = FormatTime(model.Publish_time);
                gongqing_content = model.News_content.Length > 40 ? model.News_content.Substring(0, 39) : model.News_content;
            }

            //取到剩余的几条数据
            DataSet ds = news_bll.GetOtherFirstList(8, " news_id ", "news_father_id=" + news_gongqing_id + " and is_check='Y'", " publish_time desc ");
            rptGongQing.DataSource = ds;
            rptGongQing.DataBind();
        }

        //绑定共青之声
        protected void bindZaiXian()
        {
            //取到第一条
            AUTO.Model.YouthNews model = news_bll.GetFirstList(" news_father_id=" + news_zaixian_id + " and is_check='Y' ", "  publish_time desc  ");
            if (model != null)
            {
                zaixian_id = Convert.ToInt32(model.News_id);
                zaixian_title = model.News_title.Length > 16 ? model.News_title.Substring(0, 15) + "..." : model.News_title.ToString();
                zaixian_time = FormatTime(model.Publish_time);
                zaixian_content = model.News_content.Length > 40 ? model.News_content.Substring(0, 39) : model.News_content;
            }

            //取到剩余的几条数据
            DataSet ds = news_bll.GetOtherFirstList(8, " news_id ", "news_father_id=" + news_zaixian_id + " and is_check='Y'", " publish_time desc ");
            rptZaiXian.DataSource = ds;
            rptZaiXian.DataBind();
        }

        //绑定新闻列表——新闻速递，通知公告之类
        protected void bindNewsCol()
        {
            DataSet ds_news_col = news_col_bll.GetNewsCol();

            DataSet ds_file_col = file_col_bll.GetFilesCol();

            file_guizhang_name = ds_file_col.Tables[0].Rows[1]["file_column_name"].ToString();
            file_guizhang_id= int.Parse(ds_file_col.Tables[0].Rows[1]["file_column_id"].ToString());

            //此处的news_fast和news_fast_id后续补充完善，将所有新闻类别进行绑定
            news_fast_name = ds_news_col.Tables[0].Rows[0]["news_column_name"].ToString();
            news_fast_id = int.Parse(ds_news_col.Tables[0].Rows[0]["news_column_id"].ToString());


            //news_gonggao_name = ds_news_col.Tables[0].Rows[1]["news_column_name"].ToString();
            //news_gonggao_id = int.Parse(ds_news_col.Tables[0].Rows[1]["news_column_id"].ToString());

            news_jiceng_name = ds_news_col.Tables[0].Rows[2]["news_column_name"].ToString();
            news_jiceng_id = int.Parse(ds_news_col.Tables[0].Rows[2]["news_column_id"].ToString());

            news_shetuan_name = ds_news_col.Tables[0].Rows[3]["news_column_name"].ToString();
            news_shetuan_id = int.Parse(ds_news_col.Tables[0].Rows[3]["news_column_id"].ToString());

            news_xueyuan_name = ds_news_col.Tables[0].Rows[4]["news_column_name"].ToString();
            news_xueyuan_id = int.Parse(ds_news_col.Tables[0].Rows[4]["news_column_id"].ToString());

            news_caijun_name = ds_news_col.Tables[0].Rows[5]["news_column_name"].ToString();
            news_caijun_id = int.Parse(ds_news_col.Tables[0].Rows[5]["news_column_id"].ToString());

            news_gongqing_name = ds_news_col.Tables[0].Rows[6]["news_column_name"].ToString();
            news_gongqing_id = int.Parse(ds_news_col.Tables[0].Rows[6]["news_column_id"].ToString());

            news_zaixian_name = ds_news_col.Tables[0].Rows[7]["news_column_name"].ToString();
            news_zaixian_id = int.Parse(ds_news_col.Tables[0].Rows[7]["news_column_id"].ToString());
        }

        //绑定首页大图展示——五条数据
        protected void bindHomeImg()
        {
            DataSet ds_home_img = news_bll.GetHomeImg(5, " is_check='Y' and is_photoNews='Y' ");
            rptHomeImg.DataSource = ds_home_img;
            rptHomeImg.DataBind();
        }

        //绑定规章制度
        protected void bindGuiZhang()
        {
            DataSet ds = file_bll.GetFiles(6, " is_check='Y' and file_father_id=2 ");
            rptGuiZhang.DataSource = ds;
            rptGuiZhang.DataBind();
        }
        /*
        //绑定办公文件
        protected void bindFile()
        {
            DataSet ds = file_bll.GetFiles(6, " is_check='Y' and file_father_id=1 ");
            rptFiles.DataSource = ds;
            rptFiles.DataBind();
        }
        */
        //绑定精品专题
        protected void bindJingPin()
        {
            DataSet ds = special_bll.GetTopList(2, "");
            rptJingPin.DataSource = ds;
            rptJingPin.DataBind();

            //绑定banner
            DataSet ds1 = special_bll.GetTopList(1, " is_banner='Y' ");

            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["special_img_url"].ToString() != "")
                {
                    special_img_url = ds1.Tables[0].Rows[0]["special_img_url"].ToString();
                }
                if (ds1.Tables[0].Rows[0]["special_id"].ToString() != "")
                {
                    special_id = Convert.ToInt32(ds1.Tables[0].Rows[0]["special_id"].ToString());
                }
            }
        }


        //绑定视频专区
        protected void bindVideo()
        {
            DataSet ds = video_bll.GetTopVideo(1, "", " video_up_time desc ");
            rptVideo.DataSource = ds;
            rptVideo.DataBind();
        }

        //绑定图说理工
        protected void bindTalkLG()
        {
            DataSet ds = talk_bll.GetTopTalk(5, " is_check='Y' ", " publish_time desc ");
            rptTalkLG.DataSource = ds;
            rptTalkLG.DataBind();
        }

        //绑定学院投稿排名
        public void bindRank()
        {
            //DataSet ds = aca_bll.GetRank(" where academic_id<23 ");//排除校团委和理工青年在首页的排名
            //rpt_rank.DataSource = ds;
            ////rpt_rank.DataBind();
            DataSet ds = news_bll.GetRankByCondition(" 1=1 and is_check='Y' ", "a.news_source=b.academic_id and b.academic_id < 23");
            rpt_rank.DataSource = ds;
            rpt_rank.DataBind();

        }




























        //新闻标题过长，进行截取
        protected string CutString(string strToCut)
        {
            if (strToCut.Length >= 14)
            {
                strToCut = strToCut.Substring(0, 13).ToString() + "...";
            }
            return strToCut;
        }
        //新闻标题过长，进行截取
        protected string CutStringNewsSD(string strToCut)
        {
            if (strToCut.Length > 27)
            {
                strToCut = strToCut.Substring(0, 26).ToString() + "...";
            }
            return strToCut;
        }

        //日期格式转换
        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("MM-dd");
            //string str = time.ToString("yyyy-MM-dd");
            return str;
        }
    }
}