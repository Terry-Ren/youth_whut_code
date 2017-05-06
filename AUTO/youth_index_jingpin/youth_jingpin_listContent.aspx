<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_jingpin_listContent.aspx.cs" Inherits="AUTO.youth_index_jingpin.youth_jingpin_listContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix border_bottom">
        <div class="content content_big">
            <div class="daohang">
                当前位置：<a href="../youth_index.aspx">首页</a>><a href="youth_jingpin_list.aspx">精品专题</a>>
                <a>正文</a>
            </div>
            <a></a>
            <div class="detail_content">
                <div class="detail_title">
                    <h2>
                        <%=model.Content_title %></h2>
                </div>
                <div class="detail_time">
                    发布时间：<span><%=FormatTime(model.Content_publish_time)%></span>&nbsp;&nbsp;&nbsp;&nbsp;作者：<span><%=model.Content_publisher %></span>&nbsp;&nbsp;&nbsp;&nbsp;点击：<span><%=model.Content_click_times %></span>
                </div>
                <div class="detail_content_p">
                    <%=model.Content_content %>
                </div>
                <div class="bianji">
                    <p>
                        [编辑：<span><%=model.Last_updater %></span>&nbsp;&nbsp;&nbsp; 审核：<span><%=model.Checker %></span>]</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
