<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="spe_subjectItemUpd.aspx.cs" Inherits="AUTO.youth_admin.SpeSubject.spe_subjectItemUpd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="addtable">
        <tr>
            <td>
                子栏目类别：
            </td>
            <td>
                <asp:DropDownList ID="ddl_item" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                子栏目名称：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtTitle" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                子栏目排序:
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtPaixu" runat="server" ReadOnly="true"></asp:TextBox>
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
