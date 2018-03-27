<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="youth_newsadd.aspx.cs" Inherits="AUTO.youth_admin.youth_newsadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../js/ckeditor/ckeditor.js" type="text/javascript"></script>--%>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("[id$=chkPic]").click(function () {
                if ($(this).attr("checked")) {
                    $("#fileUp").show();
                }
                else {
                    $("#fileUp").hide();
                }
            });
        });

        function alertMessage(message) {
            alert(message);
        }

        function checkinput() {
            //检查用户输入信息
            var title = document.getElementById("<%=txtTitle.ClientID%>").value;
            var type = document.getElementById("<%=ddlNewsCol.ClientID%>").value;
            var content = ue.getContent();
            var writerName = document.getElementById("<%=txt_publisher.ClientID%>").value;
            var tel = document.getElementById("<%=txt_phone.ClientID%>").value;
            var email = document.getElementById("<%=txt_email.ClientID%>").value;
            var region = document.getElementById("<%=ddl_source.ClientID%>").value;

            if (title != "") {
                if (type != "-1") {
                    if (content != "") {
                        if (writerName != "") {
                            if (tel != "" && (/^1[34578]\d{9}$/.test(tel))) {
                                if (email != "" && (/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/.test(email))) {
                                    if (region != "-1") {
                                        document.getElementById("<%=txt_content.ClientID%>").value = ue.getContent();
                                        return true;
                                    }
                                    else {
                                        alertMessage('未选择新闻来源！');
                                        return false;
                                    }
                                }
                                else {
                                    alertMessage('未填写邮箱地址或邮箱地址格式错误！');
                                    return false;
                                }
                            }
                            else {
                                alertMessage('未填写联系电话或联系电话格式错误！');
                                return false;
                            }
                        }
                        else {
                            alertMessage('未填写作者姓名！');
                            return false;
                        }
                    }
                    else {
                        alertMessage('新闻内容不能为空！');
                        return false;
                    }
                }
                else {
                    alertMessage('未选择新闻类型！');
                    return false;
                }
            }
            else {
                alertMessage('新闻标题不能为空！');
                return false;
            }
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
                新闻类别：
            </td>
            <td>
                <asp:DropDownList ID="ddlNewsCol" runat="server">
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
                内容：
            </td>
            <td>
               <%-- <asp:TextBox ID="txt_content" name="txtContent" class="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox><br />--%>
                <script type="text/plain" id="txtcontent" style="width:750px;height:300px;">
                   
                </script>
                <asp:TextBox ID="txt_content" runat="server" style="display:none;"></asp:TextBox>
            </td>
            <!--实例化编辑器-->
        <script type="text/javascript">
            var ue = UE.getEditor('txtcontent');
            </script>
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
