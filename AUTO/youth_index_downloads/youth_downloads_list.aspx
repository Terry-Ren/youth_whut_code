<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
     CodeBehind="youth_downloads_list.aspx.cs" Inherits="AUTO.youth_index_downloads.youth_downloads_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="../youth_index.aspx">首页</a>>
                <asp:HyperLink ID="ColumnNameFather" runat="server" NavigateUrl="" Text="" />
                <asp:Label ID="lblColumnNameFather" runat="server" Text=""></asp:Label>
            </div>
            <div class="detail_content">
                <!--文件列表-->
                <div class="news2 fix">
                    <ul>
                        <asp:Repeater ID="rpt_downloads_list" runat="server">
                            <ItemTemplate>
                                <li><a href='youth_download.aspx?download_id=<%#Eval("download_id") %>' title='<%# Eval("download_title")%>'>
                                    <%# CutString(Eval("download_title").ToString())%></a> <span>
                                        <%# FormatTime((DateTime)Eval("upload_time"))%></span></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="num_nav2" align="center" style="font-size: 14px">
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
        <div class="side">
            <div class="annou hei1 fix">
                <h2 class="block_title" style="border-top: none;">
                    <a href='youth_downloads_list.aspx?download_father_id=<%=download_father_id %>' class="more">more</a><label
                        id="lblTitle" runat="server"></label><span><%--WENJIAN XIAZAI--%></span></h2>
                <div class="news_list">
                    <ul>
                        <asp:Repeater ID="rptCeBian" runat="server">
                            <ItemTemplate>
                                <li><a href='youth_download.aspx?download_id=<%#Eval("download_id") %>' title='<%# Eval("download_title")%>'>
                                    <%# CutString(Eval("download_title").ToString())%></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
