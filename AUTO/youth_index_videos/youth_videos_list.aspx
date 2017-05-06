<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_videos_list.aspx.cs" Inherits="AUTO.youth_index_videos.youth_videos_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="../youth_index.aspx">首页</a>> <a href="youth_videos_list.aspx">视频专区</a>
            </div>
            <div class="detail_content">
                <div class="detail_title">
                    <h2>
                        视频专区</h2>
                </div>
                <div class="detail_time">
                </div>
                <div class="detail_content_p">
                    <asp:Repeater ID="rpt_videos_list" runat="server">
                        <ItemTemplate>
                            <div class="zhuanti_d">
                                <a href='<%#Eval("video_link") %>' target="_blank">
                                    <img src='../youth_admin/<%#Eval("video_pic") %>' /></a> <a href='<%#Eval("video_link") %>'
                                        class="zhuanti_d_title" target="_blank">
                                        <%#Eval("video_title")%></a>
                                <div>
                                    <a href='<%#Eval("video_link") %>' class="enter_zhuanti" target="_blank">观看视频</a></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="num_nav" align="center" style="font-size: 14px">
                        <webdiyer:AspNetPager ID="pagerList" runat="server" Width="100%" NumericButtonCount="6"
                            UrlPaging="true" NumericButtonTextFormatString="[{0}]" CustomInfoHTML=" 第 <font ><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
                            ShowCustomInfoSection="left" FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            PrevPageText="上页" Font-Names="Arial" BackColor="#ffffff" AlwaysShow="true" showinputbox="Always"
                            SubmitButtonText="跳转" SubmitButtonStyle="botton" PageSize="4" ReverseUrlPageIndex="True"
                            OnPageChanged="pagerList_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
        <div class="side">
            <div class="annou hei1 fix">
                <h2 class="block_title" style="border-top: none;">
                    <a href="youth_videos_list.aspx" class="more">more</a><label id="lblTitle" runat="server">视频专区</label><span><%--JINGPIN ZHUANTI--%></span></h2>
                <div class="news_list">
                    <ul>
                        <asp:Repeater ID="rptCeBian" runat="server">
                            <ItemTemplate>
                                <li><a href='<%#Eval("video_link") %>' title='<%# Eval("video_title")%>'>
                                    <%#Eval("video_title").ToString()%></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
