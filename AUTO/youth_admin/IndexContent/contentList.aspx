<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="contentList.aspx.cs" Inherits="AUTO.youth_admin.IndexContent.contentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                内容：
            </td>
            <td>
                <!-- 加载编辑器的容器 -->
                <script id="container" name="content" type="text/plain">
                    
                </script>
                <!-- 配置文件 -->
                <script type="text/javascript" src="../../ueditor/ueditor.config.js"></script>
                <!-- 编辑器源码文件 -->
                <script type="text/javascript" src="../../ueditor/ueditor.all.js"></script>
                <!-- 实例化编辑器 -->
                <script type="text/javascript">
                    var ue = UE.getEditor('container');
                </script>
            </td>
        </tr>
    </table>
</asp:Content>
