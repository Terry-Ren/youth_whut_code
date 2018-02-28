<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_index.aspx.cs" Inherits="AUTO.youth_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="imgroll_news_top fix">
        <div class="imgroll_news">
            <!--========新闻速递=========-->
            <div class="news_fast_two news_fast_top float_right"  >
                <h2 class="block_title">
                    <a href='youth_news_list.aspx?news_col_id=<%=news_fast_id %>' target="_blank" class="more">
                        more</a><%=news_fast_name%><span>XINWEN SUDI</span>
                </h2>
                <ul class="news_list_all news_list_all_top">
                    <!--绑定第一条-->
                   <%-- <li class="news_first news_first_two news_first_three">--%><li class="news_first"><a href='youth_news.aspx?news_id=<%=fast_id %>'>
                        <%=fast_title%></a><span class="time time2"><%=fast_time %></span> <%--<span class="first_small first_small_two">
                            <%=fast_content %></span> --%></li>
                    <!--绑定剩余几条-->
                    <asp:Repeater ID="rptSudi" runat="server">
                        <ItemTemplate>
                            <li ><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>' target="_blank">
                                <%# CutStringNewsSD(Eval("news_title").ToString())%></a><span class="time time2"><%# FormatTime((DateTime)Eval("publish_time"))%></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <!--========滚动图片=========-->
            <div class="img_fast_news">
                <div class="img_fast_news_inner">
                    <div class="index w1000 mlra p10">
                        <div class="firArea clearfix">
                            <div class="focus fl oh pos-r slider">
                                <div class="focus-pic oh ">
                                    <ul class="clearfix thememain">
                                        <asp:Repeater ID="rptHomeImg" runat="server">
                                            <ItemTemplate>
                                                <li class="themeitem"><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' target="_blank">
                                                    <img src='youth_admin/<%#Eval("photo_url") %>' width="580" height="367" alt=""></a><div
                                                        class="halfO">
                                                    </div>
                                                    <p class="fs18 yahei tc txtOh white">
                                                        <a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' class="white" target="_blank">
                                                            <%#Eval("news_title")%></a></p>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                <ul class="slide-item tc pos-a">
                                </ul>
                                <a href="#" class="pre pos-a" target="_blank"></a><a href="#" class="nex pos-a"></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="block_three">
        <!--========基层团建=========-->
            <div class="news_fast float_left">
                <h2 class="block_title">
                    <a href='youth_news_list.aspx?news_col_id=<%=news_zaixian_id %>' target="_blank" class="more">
                        more</a><%=news_zaixian_name%><span>JICENG TUANJIAN</span>
                </h2>
                <ul class="news_list_all news_list_all_middle">
                    <!--绑定第一条-->
                    <%--<li class="news_first news_first_two news_first_three">--%><li class="news_first"><a href='youth_news.aspx?news_id=<%=zaixian_id %>' target="_blank">
                        <%=zaixian_title%></a><span class="time time2"><%=zaixian_time%></span><%-- <span class="first_small first_small_two">
                            <%=zaixian_content%></span>--%> </li>
                    <!--绑定剩余几条-->
                    <asp:Repeater ID="rptZaiXian" runat="server">
                        <ItemTemplate>
                            <li><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>' target="_blank" >
                                <%# CutString(Eval("news_title").ToString())%></a><span class="time time2"><%# FormatTime((DateTime)Eval("publish_time"))%></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        <!--========学院动态=========-->
        <div class="news_fast float_left">
            <h2 class="block_title">
                <a href='youth_news_list.aspx?news_col_id=<%=news_xueyuan_id %>' target="_blank" class="more">
                    more</a><%=news_xueyuan_name%><span>XUEYUAN DONGTAI</span>
            </h2>
            <ul class="news_list_all news_list_all_middle">
                <!--绑定第一条-->
                <li class="news_first"><a href='youth_news.aspx?news_id=<%=xueyuan_id %>' target="_blank">
                    <%=xueyuan_title%></a><span class="time"><%=xueyuan_time%></span> </li>
                <!--绑定剩余几条-->
                <asp:Repeater ID="rptXueyuan" runat="server">
                    <ItemTemplate>
                        <li><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>' target="_blank">
                            <%# CutString(Eval("news_title").ToString())%></a><span class="time"><%# FormatTime((DateTime)Eval("publish_time"))%></span></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!--========社团天地=========-->
        <div class="news_fast float_left">
            <h2 class="block_title">
                <a href='youth_news_list.aspx?news_col_id=<%=news_shetuan_id %>' target="_blank" class="more" target="_blank">
                    more</a><%=news_shetuan_name%><span>SHETUAN TIANDI</span>
            </h2>
            <ul class="news_list_all news_list_all_middle">
                <!--绑定第一条-->
                <li class="news_first"><a href='youth_news.aspx?news_id=<%=shetuan_id %>' target="_blank">
                    <%=shetuan_title%></a><span class="time"><%=shetuan_time%></span> </li>
                <!--绑定剩余几条-->
                <asp:Repeater ID="rptShetuan" runat="server">
                    <ItemTemplate>
                        <li><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>' target="_blank">
                            <%# CutString(Eval("news_title").ToString())%></a><span class="time"><%# FormatTime((DateTime)Eval("publish_time"))%></span></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <!--============banner专区==============-->
    <div class="big_banner">
        <%--<a href='youth_index_jingpin/youth_jingpin_listItem.aspx?special_id=<%=special_id %>'
            target="_blank">--%>
            <a href='#'
             target="_blank">
            <%--<img src="youth_admin/<%=special_img_url %>" /></a>--%>
        <img src="youth_admin/upload/SpecialImg/20171013204906284383.png" /></a>
    </div>
    <div class="block_two">
        <!--==right==-->
        <div class="block_one_small float_right">
            <!--file-->
            <!--办公文件与通知公告-->
            <div class="file">
                <h2 class="social_title">
                    <a href="#" class="bangong_btn active" target="_blank">办公文件</a><em class="shu">|</em><a href="#"
                        class="guizhang_btn"><%=file_guizhang_name %></a></h2>
                <ul class="news_list_all news_list_all_file bangong">
                    <a href="youth_index_files/youth_files_list.aspx?file_father_id=1" class="file_more" target="_blank">
                        more</a>
                    <asp:Repeater ID="rptFiles" runat="server">
                        <ItemTemplate>
                            <li><a href="youth_index_files/youth_file.aspx?file_id=<%#Eval("file_id") %>" title='<%# Eval("file_title")%>' target="_blank">
                                <%# CutString(Eval("file_title").ToString())%></a><span class="time time2"><%# FormatTime((DateTime)Eval("upload_time"))%></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="news_list_all news_list_all_file guizhang">
                    <a href="youth_index_files/youth_files_list.aspx?file_father_id=2" class="file_more" target="_blank">
                        more</a>
                    <asp:Repeater ID="rptGuiZhang" runat="server">
                        <ItemTemplate>
                            <li><a href="youth_index_files/youth_file.aspx?file_id=<%#Eval("file_id") %>" title='<%# Eval("file_title")%>' target="_blank">
                                <%# CutString(Eval("file_title").ToString())%></a><span class="time time2"><%# FormatTime((DateTime)Eval("upload_time"))%></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                   <%-- <ul class="news_list_all news_list_all_file tongzhi">
                    <a href='youth_news_list.aspx?news_col_id=<%=news_gonggao_id %>' class="file_more" target="_blank">more</a>
                    <asp:Repeater ID="rptGongGao" runat="server">
                        <ItemTemplate>
                            <li><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>' target="_blank">
                                <%# CutString(Eval("news_title").ToString())%></a><span class="time time2"><%# FormatTime((DateTime)Eval("publish_time"))%></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>--%>
            </div>
            <!--其他版块-->
            <div class="huike" runat="server" id="Online">
                <ul class="qita">
                    <li class="icon_chat">
                        <asp:HyperLink ID="HyperLink1"  class="in" runat="server"  NavigateUrl="youth_huike/youth_meetingroom.aspx" Text="点击进入"></asp:HyperLink><span>团委书记会客室</span></li>
                    <li class="icon_mail">
                        <asp:HyperLink ID="HyperLink2"  class="in" runat="server"  NavigateUrl="youth_online_post/youth_online.aspx" Text="点击进入"></asp:HyperLink><span>在线投稿</span></li>
                </ul>
            </div>
            <!--一块-->
            <div class="social paiming">
                <h2 class="block_title">
                    稿件排行<span>GAOJIAN PAIHANG</span></h2>
                <div class="tougao">
                    <h3 class="tougao_title">
                        <span class="pm">排名</span><span class="xy">学院</span><span class="tgs">投稿数</span></h3>
                    <ul class="tougao_ul">
                        <asp:Repeater ID="rpt_rank" runat="server">
                            <ItemTemplate>
                                <li><span class="tg_count">
                                    <%#Eval("account")%></span><span class="range"><%#Eval("rank") %></span><span
                                        class="college"><%#Eval("academic_name")%></span></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <!--===left===-->
        <div class="block_big_two float_left">
            <!--一块-->
            <!--========理工才俊=========-->
            <div class="news_fast_two news_fast_two2">
                <h2 class="block_title">
                    <a href='youth_news_list.aspx?news_col_id=<%=news_caijun_id %>' target="_blank" class="more">
                        more</a><%=news_caijun_name%><span>LIGONG CAIJUN</span>
                </h2>
                <ul class="news_list_all news_list_all_top">
                    <!--绑定第一条-->
                    <%--<li class="news_first news_first_two news_first_three">--%><li class="news_first"><a href='youth_news.aspx?news_id=<%=caijun_id %>' target="_blank">
                        <%=caijun_title%></a><span class="time time2"><%=caijun_time %></span> <%--<span class="first_small first_small_two">
                            <%=caijun_content %></span> --%></li>
                    <!--绑定剩余几条-->
                    <asp:Repeater ID="rptCaiJun" runat="server">
                        <ItemTemplate>
                            <li><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>' target="_blank">
                                <%# CutString(Eval("news_title").ToString())%></a><span class="time time2"><%# FormatTime((DateTime)Eval("publish_time"))%></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <!--一块-->
            <!--========共青之声=========-->
            <div class="news_fast_two news_fast_two2">
                <h2 class="block_title">
                    <a href='youth_news_list.aspx?news_col_id=<%=news_gongqing_id %>' target="_blank"
                        class="more">more</a><%=news_gongqing_name%><span>GONGQING ZHISHENG</span>
                </h2>
                <ul class="news_list_all news_list_all_top">
                    <!--绑定第一条-->
                    <%--<li class="news_first news_first_two news_first_three">--%><li class="news_first"><a href='youth_news.aspx?news_id=<%=gongqing_id %>'   target="_blank">
                        <%=gongqing_title%></a><span class="time time2"><%=gongqing_time%></span> <%--<span class="first_small first_small_two">
                            <%=gongqing_content%></span>--%> </li>
                    <!--绑定剩余几条-->
                    <asp:Repeater ID="rptGongQing" runat="server">
                        <ItemTemplate>
                            <li><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>' target="_blank">
                                <%# CutString(Eval("news_title").ToString())%></a><span class="time time2"><%# FormatTime((DateTime)Eval("publish_time"))%></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <!--一块-->
            <!--========原创文学=========-->
        <div class="news_fast_two news_fast_two2">
            <h2 class="block_title">
                <a href='youth_news_list.aspx?news_col_id=<%=news_jiceng_id %>' target="_blank" class="more" >
                    more</a><%=news_jiceng_name%><span>YUANCHUANG WENXUE</span>
            </h2>
            <ul class="news_list_all news_list_all_top">
                <!--绑定第一条-->
                <li class="news_first"><a href='youth_news.aspx?news_id=<%=jiceng_id %>' target="_blank">
                    <%=jiceng_title%></a><span class="time"><%=jiceng_time %></span> </li>
                <!--绑定剩余几条-->
                <asp:Repeater ID="rptJiceng" runat="server">
                    <ItemTemplate>
                        <li><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>' target="_blank">
                            <%# CutString(Eval("news_title").ToString())%></a><span class="time"><%# FormatTime((DateTime)Eval("publish_time"))%></span></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
            
        </div>
        <!--===center===-->
        <div class="block_center float_left">
            <!--微信微博-->
            <div class="social">
                <h2 class="social_title">
                    <span class="bright_top">社交版块</span><a href="http://weibo.com/u/2004398110?refer_flag=1001030101" class="weibo_btn active"  target="_blank">微博</a><em
                        class="shu">|</em><a href="#" class="weixin_btn"  target="_blank">微信</a></h2>
                <div class="social_box weibo">
                    <iframe width="280" height="550" class="share_blank"  frameborder="0" scrolling="no" src="http://widget.weibo.com/weiboshow/index.php?language=&width=280&height=550&fansRow=2&ptype=1&speed=0&skin=1&isTitle=1&noborder=1&isWeibo=1&isFans=1&uid=2004398110&verifier=7b660e07&dpc=1"></iframe>
                </div>
                <div class="social_box weixin">
                    <div style="text-align:center;margin-bottom:10px;margin-top:20px;font-weight:bold;font-size:14px;">扫描二维码关注校团委微信</div>
                    <img src="images/weixin.png" style="width:80%;margin-left:30px;"/>
                </div>
            </div>
            <!--精品专题-->
            <div class="jingpin">
                <h2 class="block_title block_title_two">
                    <a href="youth_index_jingpin/youth_jingpin_list.aspx" class="more"  target="_blank">more</a>精品专题<span>JINGPIN
                        ZHUANTI</span></h2>
                <ul class="jingpin_block">
                    <asp:Repeater ID="rptJingPin" runat="server">
                        <ItemTemplate>
                            <li><a href='youth_index_jingpin/youth_jingpin_listItem.aspx?special_id=<%#Eval("special_id") %>'  target="_blank">
                                <img src='youth_admin/<%#Eval("special_img_url") %>'></a> <a href='youth_index_jingpin/youth_jingpin_listItem.aspx?special_id=<%#Eval("special_id") %>'
                                    class="jp_title">
                                    <%#Eval("special_title")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <!--视频专区-->
            <div class="jingpin">
                <h2 class="block_title block_title_two">
                    <a href="youth_index_videos/youth_videos_list.aspx" class="more"  target="_blank">more</a>视频专区<span>SHIPIN
                        ZHUANQU</span></h2>
                <ul class="jingpin_block ul_video">
                    <asp:Repeater ID="rptVideo" runat="server">
                        <ItemTemplate>
                            <embed src="武汉理工大学是什么.mp4" width="280" height="140" />
                                <a class="jp_title" href='<%#Eval("video_link") %>' target="_blank">
                                    <%#Eval("video_title")%></a><a href='<%#Eval("video_link") %>' target="_blank">
                                        <img src="images/play.jpg" class="play" /></a> </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <!--============图说理工==============-->
    <div class="block_video">
        <h2 class="block_title block_title2">
            <a href="youth_index_talkLG/youth_talkLG_list.aspx" class="more"  target="_blank">more</a>图说理工<span>TUSHUO
                LIGONG</span></h2>
        <div class="block_video_inner block_video_inner2">
            <asp:Repeater ID="rptTalkLG" runat="server">
                <ItemTemplate>
                    <div class=" video video2 ">
                        <a href='youth_index_talkLG/youth_talkLG.aspx?talk_id=<%#Eval("talk_id") %>'  target="_blank">
                            <img src='youth_admin/<%#Eval("talk_Img_url") %>  '></a>
                        <h3>
                            <a href='youth_index_talkLG/youth_talkLG.aspx?talk_id=<%#Eval("talk_id") %>' style="font:14px tahoma,arial,\5b8b\4f53;font-weight:bold;"  target="_blank">
                                <%#Eval("talk_title")%></a>
                        </h3>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
