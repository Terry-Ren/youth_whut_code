<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RightSide.ascx.cs" Inherits="AUTO.ascx.RightSide" %>

<div class="side">
    <div class="annou hei1 fix">
        <h2 class="title"><a href="#">学生活动</a></h2>
        <div class="news_list">
            <ul>
                <li><a href="#" target="_blank">团委</a></li>
                <li><a href="#" target="_blank">学生会</a></li>
                <li><a href="#" target="_blank">汽车协会</a></li>
                <li><a href="#" target="_blank">引擎大学生科技创新基地</a></li>
                <li><a href="#" target="_blank">马协</a></li>
                <li><a href="#" target="_blank">心协</a></li>
                <li><a href="#" target="_blank">研究生会</a></li>
                <li><a href="NewsList.aspx?columnid=35" target="_blank">学生动态</a></li>
            </ul>
        </div>
    </div>
    <div class="annou hei1 fix">
        <h2 class="title"><a href="#">招生微博</a></h2>
        <div class="news_list">
            <ul>
                <li><a href="#" target="_blank">本科生招生微博</a></li>
            </ul>
        </div>
    </div>
    <div class="annou hei1 fix">
        <h2 class="title"><a href="Information.aspx?columnid=21">招聘信息</a></h2>
        <div class="news_list">
            <ul>
                <li><a href="Information.aspx?columnid=21" target="_blank">招聘信息</a></li>
            </ul>
        </div>
    </div>
    <div class="annou hei1 fix">
        <h2 class="title"><a href="#">友情链接</a></h2>
        <div class="news_list">
            <ul>
                <asp:Repeater ID="rptLinkList" runat="server">
                    <ItemTemplate>
                        <li><a href="<%# TranslateUrl(Eval("LinkUrl").ToString()) %>" target="_blank" ><%# Eval("LinkName").ToString() %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>