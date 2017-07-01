<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="youth_newsupd.aspx.cs" Inherits="AUTO.youth_admin.youth_newsupd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../js/ckeditor/ckeditor.js" type="text/javascript"></script>--%>
    <style type="text/css">.cke_dialog_ui_vbox_child{height:80px;}</style>

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
    <table id="addtable" style="width:90%;">
        <tr>
            <td>
                新闻类别：
            </td>
            <td>
                <asp:DropDownList ID="ddl_news_col" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                新闻标题：
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                阅读次数：
            </td>
            <td>
                <asp:TextBox ID="txt_clickTimes" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                内容：
            </td>
            <td>
                <%--<asp:TextBox ID="txt_content" name="txtContent" class="ckeditor" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox><br />
            --%>
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
                投递时间:
            </td>
            <td>
                <asp:TextBox ID="txt_publish_time" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                作者：
            </td>
            <td>
                <asp:TextBox ID="txt_publisher" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                电话：
            </td>
            <td>
                <asp:TextBox ID="txt_phone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                邮箱：
            </td>
            <td>
                <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                新闻来源：
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
