<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_news_list.aspx.cs" Inherits="AUTO.youth_news_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#muen li").hover(function () {
                $(this).children("a").addClass("active");
                //$(this).children(".secondbox").children(".second").slideDown(300);
                $(this).children(".secondbox").children(".second").show();
            }, function () {
                $(this).children("a").removeClass("active");
                //$(this).children(".secondbox").children(".second").slideUp(100);
                $(this).children(".secondbox").children(".second").hide();
            });

            $("#muen li:eq(0)").hover(function () {
                $(this).children("a").addClass("active2");
            }, function () {
                $(this).children("a").removeClass("active2");
            });
        });
    </script>
    <style type="text/css">.num_nav input{display:none;}.cke_dialog_ui_vbox_child{height:80px;}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="youth_index.aspx">首页</a>>
                <asp:HyperLink ID="ColumnNameFather" runat="server" NavigateUrl="" Text="" />
                <asp:Label ID="lblColumnNameFather" runat="server" Text=""></asp:Label>
            </div>
            <div class="detail_content">
                <!--新闻列表-->
                <div class="news fix">
                    <ul>
                        <asp:Repeater ID="rpt_news_list" runat="server">
                            <ItemTemplate>
                                <li><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>'>
                                    <%# CutString(Eval("news_title").ToString()) %></a> <span>
                                        <%# FormatTime((DateTime)Eval("publish_time"))%></span></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="num_nav" align="center" style="font-size: 14px">
			<webdiyer:AspNetPager ID="pagerList" runat="server" Width="100%" NumericButtonCount="10"
                            UrlPaging="true" NumericButtonTextFormatString="[{0}]" CustomInfoHTML=" 第 <b>%CurrentPageIndex%</b> 页 共 <span>%PageCount%</span> 页 "
                            ShowCustomInfoSection="left" FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            PrevPageText="上页" Font-Names="Arial" BackColor="#ffffff" AlwaysShow="true" 
                            SubmitButtonText="跳转" SubmitButtonStyle="botton" PageSize="10" ReverseUrlPageIndex="True"
                            OnPageChanged="pagerList_PageChanged" ShowFirstLast="false" ShowPrevNext="false">
                        </webdiyer:AspNetPager>
<!--显示 %StartRecordIndex%-%EndRecordIndex% 条-->
                    </div>
                </div>
            </div>
        </div>
        <div class="side">
            <div class="annou hei1 fix">
                <h2 class="block_title" style="border-top: none;">
                    <a href='youth_news_list.aspx?news_col_id=<%=news_col_id %>' class="more">more</a><label
                        id="lblTitle" runat="server"></label><span><%--XINWEN SUDI--%></span></h2>
                <div class="news_list">
                    <ul>
                        <asp:Repeater ID="rptCeBian" runat="server">
                            <ItemTemplate>
                                <li><a href='youth_news.aspx?news_id=<%#Eval("news_id") %>' title='<%# Eval("news_title")%>'>
                                    <%# CutString(Eval("news_title").ToString()) %></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
