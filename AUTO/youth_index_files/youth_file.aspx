<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_file.aspx.cs" Inherits="AUTO.youth_index_files.youth_file" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="../youth_index.aspx">首页</a>> <a href='youth_files_list.aspx?file_father_id=<%=file_col_id %>'>
                    <%=file_col_name%></a>
                <asp:HyperLink ID="ColumnName1" runat="server" NavigateUrl="#" Text=">正文" />
            </div>
            <div class="detail_content">
                <!--这里是文章新闻发布样式-->
                <div class="detail_title">
                    <h2>
                        <asp:Label ID="files_title" runat="server" Text=""></asp:Label></h2>
                </div>
                <div class="detail_time">
                    发布时间：<span><asp:Label ID="UploadTime" runat="server" Text="" /></span>&nbsp;&nbsp;&nbsp;&nbsp;
                    来源：<span><asp:Label ID="Uploader" runat="server" Text="" /></span>&nbsp;&nbsp;&nbsp;&nbsp;
                    点击：<span><asp:Label ID="Clicks" runat="server" Text="" /></span>
                </div>
                <div class="detail_content_p" id="file_content" runat="server">
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
                    <a href='youth_files_list.aspx?file_father_id=<%=file_col_id %>' class="more">more</a><%=file_col_name %><span><%--WENJIAN XIAZAI--%></span></h2>
                <div class="news_list">
                    <ul>
                        <asp:Repeater ID="rptCeBian" runat="server">
                            <ItemTemplate>
                                <li><a href='youth_file.aspx?file_id=<%#Eval("file_id") %>' title='<%# Eval("file_title")%>'>
                                    <%# CutString(Eval("file_title").ToString())%></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
