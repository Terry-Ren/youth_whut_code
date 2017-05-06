<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_news.aspx.cs" Inherits="AUTO.youth_news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="youth_index.aspx">首页</a>> <a href='youth_news_list.aspx?news_col_id=<%=news_col_id %>'>
                    <%=news_col_name %></a>
                <asp:HyperLink ID="ColumnName1" runat="server" NavigateUrl="#" Text=">正文" />
            </div>
            <div class="detail_content">
                <!--这里是文章新闻发布样式-->
                <div class="detail_title">
                    <h2>
                        <asp:Label ID="news_title" runat="server" Text=""></asp:Label></h2>
                </div>
                <div class="detail_time">
                    发布时间：<span><asp:Label ID="PublishTime" runat="server" Text="" /></span>&nbsp;&nbsp;&nbsp;&nbsp;
                    来源：<span><asp:Label ID="Publisher" runat="server" Text="" /></span>&nbsp;&nbsp;&nbsp;&nbsp;
                    点击：<span><asp:Label ID="Clicks" runat="server" Text="" /></span>
                </div>
                <div class="detail_content_p" id="news_content" runat="server">
                </div>
                <div class="bianji">
                    【编辑】<span><asp:Label ID="updater" runat="server" Text="" /></span> 【审核】<span><asp:Label
                        ID="checker" runat="server" Text="" /></span>
                </div>
            </div>
        </div>
        <div class="side">
            <div class="annou hei1 fix">
                <h2 class="block_title" style="border-top: none;">
                    <a href='youth_news_list.aspx?news_col_id=<%=news_col_id %>' class="more">more</a><%=news_col_name %><span><%--XINWEN SUDI--%></span></h2>
                <div class="news_list">
                    <ul>
                        <asp:Repeater ID="rptCeBian" runat="server">
                            <ItemTemplate>
                                <li><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>'>
                                    <%#Eval("news_title") %></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
