<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="IndexAdd.aspx.cs" Inherits="AUTO.youth_admin.IndexContent.IndexAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <script src="../../js/ckeditor/ckeditor.js" type="text/javascript"></script>--%>

    <script type="text/javascript">
        function checkinput() {
            document.getElementById("<%=txtContent.ClientID%>").value = ue.getContent;
            return true;
        }
    </script>
     <!--引入Ueditor配置文件  -->
    <script type="text/javascript" src="../ueditor/ueditor.config.js"></script>
    <!--引入Ueditor编辑器-->
    <script type="text/javascript" src="../ueditor/ueditor.all.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="addtable">
        <tr>
            <td>
                首页版块名称：
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                首页版块内容：
            </td>
            <td>
                <%--<asp:TextBox ID="txtContent" CssClass="ckeditor" TextMode="MultiLine" runat="server"></asp:TextBox>--%>
            
            <script type="text/plain" id="txtcontent" style="width:750px;height:300px;">
                   
                </script>
                <asp:TextBox ID="txtContent" runat="server" style="display:none;"></asp:TextBox>
                <script type="text/javascript">
                    var ue = UE.getEditor('txtcontent');
                 </script>
            
            
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
                    data-options="iconCls:'icon-save'" OnClientClick="return checkinput()" onclick="lbtnSave_Click">保存</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
