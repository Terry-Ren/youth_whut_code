<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_meetingroom.aspx.cs" Inherits="AUTO.youth_huike.youth_meetingroom" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //$("#divId").load("../youth_information.aspx?menu_id=1");
        $("#divId").load("test.htm");
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="#">首页</a>><a href="#">团委书记会客室</a></div>
            <div class="detail_content">
                <div class="ly_gr">
                    留言总数：<span><%=RecordCount %></span></div>
                <ul class="ly_ul">
                    <asp:Repeater ID="rpt_reception" runat="server">
                        <ItemTemplate>
                            <li>
                                <p>
                                    <span class="name">
                                        <%#Eval("reception_name") %></span> <span class="ly_time">
                                            <%#FormatTime((DateTime)Eval("reception_time"))%></span>
                                </p>
                                <p class="ly_title">
                                    标题：<span><%#Eval("reception_title") %></span></p>
                                <div class="ly_nr">
                                    <%#Eval("reception_content")%></div>
                                <div class="ly_hf">
                                    <p>
                                        <span class="name">
                                            <%#Eval("Secretary_name")%></span><span class="ly_time">回复于
                                                <%#FormatTime((DateTime)Eval("Secretary_time"))%></span></p>
                                    <%#Eval("Secretary_content")%></div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="num_nav" align="center" style="font-size: 14px">
                    <webdiyer:AspNetPager ID="pagerList" runat="server" Width="100%" NumericButtonCount="6"
                        UrlPaging="true" NumericButtonTextFormatString="[{0}]" CustomInfoHTML=" 第 <font ><b>%CurrentPageIndex%</b></font> 页 共 %PageCount% 页 显示 %StartRecordIndex%-%EndRecordIndex% 条"
                        ShowCustomInfoSection="left" FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                        PrevPageText="上页" Font-Names="Arial" BackColor="#ffffff" AlwaysShow="true" showinputbox="Always"
                        SubmitButtonText="跳转" SubmitButtonStyle="botton" PageSize="5" ReverseUrlPageIndex="True"
                        OnPageChanged="pagerList_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
        <div class="side">
            <div class="annou hei1 fix">
               <%-- <h2 class="block_title" style="border-top: none;">
                    团委书记<span></span></h2>--%>
                <div class="news_list tougao_ts shuji" id="divId">
                    <asp:Repeater ID="repeaterShuji" runat="server">
                        <ItemTemplate>
                            <%--<p>
                                <%#Eval("true_name") %><span class="time"></span>
                            </p>--%>
                        </ItemTemplate>
                    </asp:Repeater>   
                   <%--   <p>
                        郎坤</p>                  
                    <p>
                        黄嵩</p>               
                    <p>
                        周慧</p>                  
                    <p>
                        魏明华</p>--%>
                </div>
            </div>
            <div class="annou hei1 fix huikeshi">
                <a href="youth_meetingroomLy.aspx">提交留言</a> <a href="youth_meetingroom.aspx" id="ckly">
                    查看留言</a> <a href="../youth_manage/youth_login.aspx" id="sjdl">书记登录</a>
            </div>
        </div>
    </div>
</asp:Content>
