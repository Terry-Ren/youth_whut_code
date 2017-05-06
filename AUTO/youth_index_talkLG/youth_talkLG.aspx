<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_talkLG.aspx.cs" Inherits="AUTO.youth_index_talkLG.youth_talkLG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img_fast_news_inner
        {
            width: 668px;
        }
        .index .firArea .focus
        {
            width: 668px;
        }
        .index .firArea .focus .focus-pic li
        {
            width: 668px;
        }
        .fs18
        {
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="../youth_index.aspx">首页</a>> <a href="youth_talkLG_list.aspx">图说理工</a>
                <asp:HyperLink ID="ColumnName1" runat="server" NavigateUrl="#" Text=">正文" />
            </div>
            <div class="detail_content">
                <!--这里是文章新闻发布样式-->
                <div class="detail_title">
                    <h2>
                        <asp:Label ID="talk_title" runat="server" Text=""></asp:Label></h2>
                </div>
                <div class="detail_time">
                    发布时间：<span><asp:Label ID="PublishTime" runat="server" Text="" /></span>&nbsp;&nbsp;&nbsp;&nbsp;
                    来源：<span><asp:Label ID="Publisher" runat="server" Text="" /></span>&nbsp;&nbsp;&nbsp;&nbsp;
                    点击：<span><asp:Label ID="Clicks" runat="server" Text="" /></span>
                </div>
                <!--========滚动图片=========-->
                <div class="img_fast_news" style="margin-top: 10px;">
                    <div class="img_fast_news_inner">
                        <div class="index w1000 mlra p10">
                            <div class="firArea clearfix">
                                <div class="focus fl oh pos-r slider">
                                    <div class="focus-pic oh ">
                                        <ul class="clearfix thememain">
                                            <%for (int i = 0; i < al_src.Count; i++)
                                              {
                                            %>
                                            <li class="themeitem">
                                                <%=al_src[i] %>
                                                <div class="halfO">
                                                </div>
                                                <p class="fs18 yahei tc txtOh white">
                                                    <%=al_alt[i] %>
                                                </p>
                                            </li>
                                            <%
                                              }
                                            %>
                                            <%--<li class="themeitem">
                                                <%=talk_src %>
                                                <div class="halfO">
                                                </div>
                                                <p class="fs18 yahei tc txtOh white">
                                                    <%=talk_alt %></p>
                                            </li>--%>
                                            <%--<li class="themeitem"><a href="youth_news.aspx?news_id=32">
                                                <img src="../images/01.jpg" alt="" height="367" width="668">
                                            </a>
                                                <div class="halfO">
                                                </div>
                                                <p class="fs18 yahei tc txtOh white">
                                                    <a href="youth_news.aspx?news_id=32" class="white">111</a>
                                                </p>
                                            </li>--%>
                                        </ul>
                                    </div>
                                    <ul class="slide-item tc pos-a">
                                    </ul>
                                    <a href="#" class="pre pos-a"></a><a href="#" class="nex pos-a"></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--滚动图片结束-->
                <%--<div class="detail_content_p" id="talk_content" runat="server">
                </div>--%>
                <div class="bianji">
                    【编辑】<span><asp:Label ID="updater" runat="server" Text="" /></span> 【审核】<span><asp:Label
                        ID="checker" runat="server" Text="" /></span>
                </div>
            </div>
        </div>
        <div class="side">
            <div class="annou hei1 fix">
                <h2 class="block_title" style="border-top: none;">
                    <a href="youth_talkLG_list.aspx" class="more">more</a>图说理工<span><%--WENJIAN XIAZAI--%></span></h2>
                <div class="news_list">
                    <ul>
                        <asp:Repeater ID="rptCeBian" runat="server">
                            <ItemTemplate>
                                <li><a href='youth_talkLG.aspx?talk_id=<%#Eval("talk_id") %>' title='<%# Eval("talk_title")%>'>
                                    <%# CutString(Eval("talk_title").ToString())%></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
