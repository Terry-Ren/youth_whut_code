<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="DownloadUpd.aspx.cs" Inherits="AUTO.youth_admin.Download.DownloadUpd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/ckeditor/ckeditor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="addtable">
        <tr>
            <td>
                文件分类：
            </td>
            <td>
                <asp:DropDownList ID="ddl_download_col" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                文件标题：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                文件详情：
            </td>
            <td>
                <asp:TextBox ID="txt_content" name="txtContent" class="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td>
                文件来源：
            </td>
            <td>
                <asp:DropDownList ID="ddl_source" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblTip" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="lbtnSave" runat="server" CssClass="easyui-linkbutton" 
                    data-options="iconCls:'icon-save'" onclick="lbtnSave_Click">保存</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
