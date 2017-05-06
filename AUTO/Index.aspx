<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="AUTO.Index" %>

<%@ Register TagName="RightSide" TagPrefix="XG" Src="~/ascx/RightSide.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <!--=====图片新闻=====-->
        <div id="dong">
            <div class="img_roll">
                <div class="container">
                    <div class="folio_block">
                        <div class="main_view">
                            <div class="window">
                                <div class="image_reel" style="width: 2512px; left: -1256px;">
                                    <asp:Repeater ID="rptImageNews" runat="server">
                                        <ItemTemplate>
                                            <div class="img_news">
                                                <a href="<%# string.Format("News.aspx?id={0}",Eval("ID")) %>" target="_blank">
                                                    <img src="<%# string.Format("admin/{0}",Eval("PhotoUrl")) %>" alt="" width="628px"
                                                        height="324px">
                                                </a>
                                                <h2>
                                                    <a href="<%# string.Format("News.aspx?id={0}",Eval("ID")) %>" target="_blank">
                                                        <%# Eval("NewsTitle").ToString() %></a>
                                                </h2>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="paging" style="display: block;">
                                <a href="#" rel="1" class="">1</a> <a href="#" rel="2" class="">2</a> <a href="#"
                                    rel="3" class="">3</a> <a href="#" rel="4" class="">4</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--=====工作动态，列表新闻=====-->
        <div class="news fix">
            <div class="tit_box">
                <h2>
                    新闻动态</h2>
                <a href="NewsList.aspx?columnid=32" target="_blank">更多&gt;&gt;</a>
            </div>
            <ul>
                <asp:Repeater ID="rptNews" runat="server">
                    <ItemTemplate>
                        <li><a href="<%# string.Format("News.aspx?id={0}",Eval("ID")) %>" target="_blank"
                            title="<%# Eval("NewsTitle").ToString() %>">
                            <%# CutString(Eval("NewsTitle").ToString()) %></a><span><%# FormatTime((DateTime)Eval("PublishTime")) %></span></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!--=====工作动态，列表新闻=====-->
        <div class="news fix">
            <div class="tit_box">
                <h2>
                    通知公告</h2>
                <a href="NewsList.aspx?columnid=88" target="_blank">更多&gt;&gt;</a>
            </div>
            <ul>
                <asp:Repeater ID="rptTongzhi" runat="server">
                    <ItemTemplate>
                        <li><a href="<%# string.Format("News.aspx?id={0}",Eval("ID")) %>" target="_blank"
                            title="<%# Eval("NewsTitle").ToString() %>">
                            <%# CutString(Eval("NewsTitle").ToString()) %></a><span><%# FormatTime((DateTime)Eval("PublishTime")) %></span></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <XG:RightSide ID="RightSide1" runat="server" />
</asp:Content>
