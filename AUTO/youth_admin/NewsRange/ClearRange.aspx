<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="ClearRange.aspx.cs" Inherits="AUTO.youth_admin.NewsRange.ClearRange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="box">
        <asp:LinkButton ID="lbtnClear" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-reload'"
            OnClientClick="return confirm('您确定一键清零吗？')" onclick="lbtnClear_Click">一键清零</asp:LinkButton>
    </div>
</asp:Content>
