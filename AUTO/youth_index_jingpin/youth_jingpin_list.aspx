<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_jingpin_list.aspx.cs" Inherits="AUTO.youth_index_jingpin.youth_jingpin_list" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="../youth_index.aspx">首页</a>> <a href="youth_jingpin_list.aspx">精品专题</a>
            </div>
            <div class="detail_content">
                <div class="detail_title">
                    <h2>
                        精品专题</h2>
                </div>
                <div class="detail_time">
                </div>
                <div class="detail_content_p">
                    <asp:Repeater ID="rpt_jingpin_list" runat="server">
                        <ItemTemplate>
                            <div class="zhuanti_d">
                                <a href='youth_jingpin_listItem.aspx?special_id=<%#Eval("special_id") %>'>
                                    <img src='../youth_admin/<%#Eval("special_img_url") %>' /></a> <a href='youth_jingpin_listItem.aspx?special_id=<%#Eval("special_id") %>'
                                        class="zhuanti_d_title">
                                        <%#Eval("special_title")%></a>
                                <div>
                                    <a href='youth_jingpin_listItem.aspx?special_id=<%#Eval("special_id") %>' class="enter_zhuanti">
                                        进入专题</a></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="num_nav" align="center" style="font-size: 14px">
                        <webdiyer:AspNetPager ID="pagerList" runat="server" Width="100%" NumericButtonCount="6"
                            UrlPaging="true" NumericButtonTextFormatString="[{0}]" CustomInfoHTML=" 第 <font ><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 "
                            ShowCustomInfoSection="left" FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            PrevPageText="上页" Font-Names="Arial" BackColor="#ffffff" AlwaysShow="true" showinputbox="Always"
                            SubmitButtonText="跳转" SubmitButtonStyle="botton" PageSize="4" ReverseUrlPageIndex="True"
                            OnPageChanged="pagerList_PageChanged" ShowFirstLast="false" ShowPrevNext="false">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
        <div class="side">
            <div class="annou hei1 fix">
                <h2 class="block_title" style="border-top: none;">
                    <a href="youth_jingpin_list.aspx" class="more">more</a><label id="lblTitle" runat="server">精品专题</label><span><%--JINGPIN ZHUANTI--%></span></h2>
                <div class="news_list">
                    <ul>
                        <asp:Repeater ID="rptCeBian" runat="server">
                            <ItemTemplate>
                                <li><a href="" title='<%# Eval("special_title")%>'>
                                    <%#Eval("special_title").ToString()%></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
