<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="VideoAdd.aspx.cs" Inherits="AUTO.youth_admin.Video.VideoAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="addtable">
        <tr>
            <td>
                视频名称:
            </td>
            <td>
                <asp:TextBox ID="videoTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                视频上传人:
            </td>
            <td>
                <asp:TextBox ID="videoUper" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                视频图片:
            </td>
            <td>
                <asp:FileUpload ID="fupImage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                视频链接:
            </td>
            <td>
                <asp:TextBox ID="videoLink" runat="server"></asp:TextBox>
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
                <asp:LinkButton ID="lbtnSave" runat="server" CssClass="easyui-linkbutton" data-options="iconCls:'icon-save'"
                    OnClientClick="return checkinput()" onclick="lbtnSave_Click">保存</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
