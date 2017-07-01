<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="fileUploadAdd.aspx.cs" Inherits="AUTO.youth_admin.FileUpload.fileUploadAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../../js/ckeditor/ckeditor.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        function checkinput() {
            document.getElementById("<%=txt_content.ClientID%>").value = ue.getContent;
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
                文件分类：
            </td>
            <td>
                <asp:DropDownList ID="ddl_file_col" runat="server">
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
               <%-- <asp:TextBox ID="txt_content" name="txtContent" class="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox><br />
           --%>
                <script type="text/plain" id="txtcontent" style="width:650px;height:300px;">
                   
                </script>
                <asp:TextBox ID="txt_content" runat="server" style="display:none;"></asp:TextBox>
                <script type="text/javascript">
                    var ue = UE.getEditor('txtcontent');
                 </script>

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
                <asp:LinkButton ID="lbtnSave" runat="server" CssClass="easyui-linkbutton" data-options="iconCls:'icon-save'"
                    OnClientClick="return checkinput()" OnClick="lbtnSave_Click">保存</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
