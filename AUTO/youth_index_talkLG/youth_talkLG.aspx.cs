using AUTO.BLL;
using AUTO.Model;
using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;

namespace AUTO.youth_index_talkLG
{
    public partial class youth_talkLG : System.Web.UI.Page
    {
        YouthTalkLgBLL talk_bll = new YouthTalkLgBLL();
        YouthTalkLg model = new YouthTalkLg();
        public int talk_id = 0;

        public string talk_content_con = "";//图说理工内容html
        public string talk_src = "";
        public string talk_alt = "";
        public ArrayList al_src = new ArrayList();
        public ArrayList al_alt = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                talk_id = Convert.ToInt32(Request.QueryString["talk_id"].ToString());
                talk_bll.AddReadCount(talk_id);
                bindTalk();
                bindCeBian();
            }
        }

        protected void bindTalk()
        {
            model = talk_bll.GetListById(talk_id);
            talk_title.Text = model.Talk_title;
            PublishTime.Text = FormatTime(model.Publish_time);
            Publisher.Text = model.Publisher;
            Clicks.Text = model.Click_times.ToString();
            //talk_content.InnerHtml = model.Talk_content;

            talk_content_con = model.Talk_content;
            //1.正则表达式处理
            MatchCollection col = GetCollection(talk_content_con);
            foreach (Match item in col)
            {
                string str = item.ToString();
                XmlNodeList xnl = GetNoteList(str, "//img");
                //for (int i = 0; i < xnl.Count; i++)
                //{
                talk_alt = (xnl[0].Attributes["alt"] == null) ? "" : xnl[0].Attributes["alt"].Value;
                talk_src = "<img src='" + xnl[0].Attributes["src"].Value.Trim() + "' height='367' width='668'/>";
                // }
                al_src.Add(talk_src);
                al_alt.Add(talk_alt);
            }

            //2.xml处理
            //XmlNodeList xnl = GetNoteList(talk_content_con, "//img");
            //for (int i = 0; i < xnl.Count; i++)
            //{
            //    talk_alt = xnl[i].Attributes["alt"].Value;
            //    string test = xnl[i].Attributes["src"].Value;
            //    talk_src = "<img src='" + xnl[i].Attributes["src"].Value.Trim() + "' height='367' width='668'/>";
            //}

            updater.Text = model.Last_updater;
            checker.Text = model.Checker;
        }

        //根据正则表达式提取img元素
        private MatchCollection GetCollection(string str)
        {
            Regex r = new Regex(@"<img[\s\S]*?>", RegexOptions.IgnoreCase);
            MatchCollection col = r.Matches(str);
            return col;
        }

        //获取img元素后当做xml来处理
        private XmlNodeList GetNoteList(string xmlText, string tag)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(new System.IO.MemoryStream(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(xmlText)));
            return xDoc.SelectNodes(tag);
        }


        protected void bindCeBian()
        {
            DataSet ds = talk_bll.GetTopTalk(5, " is_check='Y' ", " publish_time desc ");
            rptCeBian.DataSource = ds;
            rptCeBian.DataBind();
        }

        protected string FormatTime(DateTime time)
        {
            string str = time.ToString("yyyy-MM-dd");
            return str;
        }
        //新闻标题过长，进行截取
        protected string CutString(string strToCut)
        {
            if (strToCut.Length > 20)
            {
                strToCut = strToCut.Substring(0, 19).ToString() + "...";
            }
            return strToCut;
        }

    }
}