<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="OnlineSwitch.aspx.cs" Inherits="AUTO.youth_admin.IndexContent.OnlineSwitch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="addtable">
        <tr>
            <td>
                在线投稿是否开放：
            </td>
            <td>
                <asp:RadioButtonList ID="txtName" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">关闭</asp:ListItem>
                            <asp:ListItem Value="2">开启</asp:ListItem>
                        </asp:RadioButtonList>

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
