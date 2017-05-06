<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="youth_UserAdd.aspx.cs" Inherits="AUTO.youth_admin.Users.youth_UserAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function checkUserName() {
            var username = document.getElementById("txt_userName").value;
            document.getElementById("lbcheckName").innerHTML = youth_UserAdd.IsExits(username).value;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="addtable">
        <tr>
            <td>
                账号：
            </td>
            <td>
                <asp:TextBox ID="txt_userName" runat="server" onblur="checkUserName()"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lbcheckName" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                用户类型：
            </td>
            <td>
                <asp:DropDownList ID="ddl_role" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                真实姓名：
            </td>
            <td>
                <asp:TextBox ID="txt_trueName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                性别：
            </td>
            <td>
                <asp:DropDownList ID="ddl_sex" runat="server">
                    <asp:ListItem Value="1" Text="男">男</asp:ListItem>
                    <asp:ListItem Value="2" Text="女">女</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                用户部门：
            </td>
            <td>
                <asp:DropDownList ID="ddl_dep" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                用户学院：
            </td>
            <td>
                <asp:DropDownList ID="ddl_academic" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                用户状态：
            </td>
            <td>
                <asp:DropDownList ID="ddl_status" runat="server">
                    <asp:ListItem Value="1" Text="Y">正常</asp:ListItem>
                    <asp:ListItem Value="2" Text="N">冻结</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                用户电话：
            </td>
            <td>
                <asp:TextBox ID="txt_phone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                用户邮箱：
            </td>
            <td>
                <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                用户积分：
            </td>
            <td>
                <asp:TextBox ID="txt_points" runat="server" Text="0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                用户住址：
            </td>
            <td>
                <asp:TextBox ID="txt_address" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblInfo" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="lbtnAdd" runat="server" CssClass="easyui-linkbutton" data-options="iconCls:'icon-save'"
                    OnClick="lbtnAdd_Click">保存</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
