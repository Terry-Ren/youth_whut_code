<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_jingpin_listItem.aspx.cs" Inherits="AUTO.youth_index_jingpin.youth_jingpin_listItem" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="../youth_index.aspx">首页</a>> <a href="youth_jingpin_list.aspx">精品专题</a>
                ><a href="##"><%=special_title%></a>
            </div>
            <div class="detail_content">
                <div class="news fix">
                    <ul>
                        <asp:Repeater ID="rpt_sub_list" runat="server">
                            <ItemTemplate>
                                <li><a href='youth_jingpin_listContent.aspx?content_id=<%#Eval("content_id") %>'
                                    title='<%# Eval("content_title")%>'>
                                    <%# CutString(Eval("content_title").ToString())%></a> <span>
                                        <%# FormatTime((DateTime)Eval("content_publish_time"))%></span></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="num_nav" align="center" style="font-size: 14px">
                        <webdiyer:AspNetPager ID="pagerList" runat="server" Width="100%" NumericButtonCount="6"
                            UrlPaging="true" NumericButtonTextFormatString="[{0}]" CustomInfoHTML=" 第 <font ><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 "
                            ShowCustomInfoSection="left" FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            PrevPageText="上页" Font-Names="Arial" BackColor="#000000" AlwaysShow="true" showinputbox="Always"
                            SubmitButtonText="跳转" SubmitButtonStyle="botton" PageSize="10" ReverseUrlPageIndex="True"
                            OnPageChanged="pagerList_PageChanged" ShowFirstLast="false" ShowPrevNext="false">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
        <div class="side">
            <div class="annou hei1 fix">
                <h2 class="block_title" style="border-top: none;">
                    <label id="lblTitle" runat="server">
                        <%=special_title%></label><span></span></h2>
                <div class="news_list">
                    <ul>
                        <asp:Repeater ID="rptItem" runat="server">
                            <ItemTemplate>
                                <li><a href='youth_jingpin_listItem.aspx?special_id=<%#Eval("special_id") %>&sub_id=<%#Eval("sub_id") %>'
                                    title='<%# Eval("sub_title")%>'>
                                    <%#Eval("sub_title").ToString()%></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
