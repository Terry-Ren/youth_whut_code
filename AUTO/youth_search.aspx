<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_search.aspx.cs" Inherits="AUTO.youth_search" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix border_bottom">
        <div class="content content_big">
            <div class="daohang">
                当前位置：<a href="youth_index.aspx">首页</a>><a>搜索结果</a></div>
            <div class="detail_content">
                <div class="news fix">
                    搜索列表
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
                        <webdiyer:AspNetPager ID="pagerList" runat="server" Width="100%" NumericButtonCount="6"
                            UrlPaging="true" NumericButtonTextFormatString="[{0}]" CustomInfoHTML=" 第 <font ><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 "
                            ShowCustomInfoSection="left" FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            PrevPageText="上页" Font-Names="Arial" BackColor="#ffffff" AlwaysShow="true" showinputbox="Always"
                            SubmitButtonText="跳转" SubmitButtonStyle="botton" PageSize="10" ReverseUrlPageIndex="True"
                            OnPageChanged="pagerList_PageChanged" ShowFirstLast="false" ShowPrevNext="false">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
