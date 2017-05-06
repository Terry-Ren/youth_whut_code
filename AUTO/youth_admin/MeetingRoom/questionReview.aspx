<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="questionReview.aspx.cs" Inherits="AUTO.youth_admin.MeetingRoom.questionReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/ckeditor/ckeditor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="addtable">
        <tr>
            <td>
                问题详细描述
            </td>
        </tr>
        <tr>
            <td>
                提问人：
            </td>
            <td>
                <asp:Label ID="lblsender" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                标题：
            </td>
            <td>
                <asp:Label ID="lbltitle" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                问题详情：
            </td>
            <td>
                <asp:Label ID="lblquestioncontent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                回复内容：
            </td>
            <td>
                <asp:TextBox ID="txtanswercontent" TextMode="MultiLine" CssClass="ckeditor" Rows="5"
                    Columns="50" runat="server"></asp:TextBox>
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
                    OnClientClick="return checkinput()" OnClick="lbtnSave_Click">保存</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
