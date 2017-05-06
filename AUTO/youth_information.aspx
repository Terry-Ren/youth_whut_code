<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_information.aspx.cs" Inherits="AUTO.youth_information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix border_bottom">
        <div class="content content_big">
            <div class="daohang">
                当前位置：<a href="youth_index.aspx">首页</a>><a href="youth_information.aspx?menu_id=<%=menu_id %>"><%=name %></a></div>
            <div class="detail_content">
                <div class="detail_content_p">
                    <%=content %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
