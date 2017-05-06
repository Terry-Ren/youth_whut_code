<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_Academic.aspx.cs"
    Inherits="AUTO.youth_admin.Menu_Academic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台管理</title>
    <link href="js/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <link href="js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="js/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="js/easyui-lang-zh_CN.js"></script>
    <link href="css/all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function addTab(title, url) {
            if ($('#mytabs').tabs('exists', title)) {
                $('#mytabs').tabs('close', title);
                addTab(title, url);
            } else {
                var content = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
                $('#mytabs').tabs('add', {
                    title: title,
                    content: content,
                    closable: true
                });
            }
        }
    </script>
    <style type="text/css">
        ul li
        {
            list-style: none;
            margin-top: 10px;
        }
        #top_left
        {
            float: left;
            width: 200px;
            height: 60px;
            font-size: 14px;
            font-weight: bold;
        }
        #top_right
        {
            float: left;
            width: 800px;
        }
    </style>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div data-options="region:'north',border:false" style="height: 62px; padding: 1px;
        background-image: url(images/bg_top.jpg); background-repeat: repeat-x;">
        <div id="top_left">
            <table style="margin: 0px auto; margin-top: 8px;">
                <tr>
                    <td>
                        用户：
                    </td>
                    <td>
                        <asp:Label ID="lblRealName" runat="server" Text="admin" Font-Bold="true" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        角色：
                    </td>
                    <td>
                        <asp:Label ID="lblRole" Text="管理员" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="top_right">
        </div>
        <div style="padding: 15px 15px 15px 15px">
            <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-undo'"
                OnClick="lbtnEdit_Click">注销</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="../youth_index.aspx" target="_blank"
                class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-reload'">返回首页</a>
        </div>
    </div>
    <div data-options="region:'south',border:false" style="height: 40px; padding: 10px;
        text-align: center; vertical-align: middle; color: #515151; background-image: url(images/bg_bottom.jpg);
        background-repeat: repeat-x;">
        版权所有 © 武汉理工大学理工青年 地址：湖北省武汉市洪山区珞狮路122号</div>
    <div data-options="region:'west',split:true" title="后台管理" style="width: 200px; padding: 1px;
        overflow: hidden;">
        <div class="easyui-accordion" data-options="fit:true,border:false">
            <div title="新闻管理" data-options="selected:true" style="padding: 2px; overflow: auto;"
                runat="server" id="menu1">
                <ul>
                    <li><span><a href="#" class="easyui-linkbutton" onclick="addTab('新闻管理','youth_newslist.aspx')">
                        新闻管理</a></span></li>
                </ul>
            </div>
            <div title="新闻排行" data-options="selected:true" style="padding: 2px; overflow: auto;"
                runat="server" id="Div8">
                <ul>
                    <li><span><a href="#" class="easyui-linkbutton" onclick="addTab('新闻排行','NewsRange/NewsRange.aspx')">
                        新闻排行</a></span></li>
                </ul>
            </div>
        </div>
    </div>
    <div data-options="region:'center'" title="" style="overflow: hidden;">
        <div id="mytabs" class="easyui-tabs" data-options="fit:true,border:false">
            <div title="首页" style="overflow: hidden;">
                <div style="width: 800px; padding-left: 20px; padding-top: 5px;">
                    <h3>
                        基本信息</h3>
                    <div style="padding-left: 10px;">
                        <div style="float: left; width: 200px; height: 150px; text-align: center; vertical-align: middle;">
                            <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" ImageUrl="~/youth_admin/images/admin.jpg" />
                        </div>
                        <div style="float: left; width: 300px; height: 150px; vertical-align: middle; font-size: 14px;
                            padding-left: 20px;">
                            <table cellspacing="12">
                                <tr>
                                    <td>
                                        登录名：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLoginName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        本次登陆时间：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLoginTime" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        本次登陆IP：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLoginIP" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span><a href="#" class="easyui-linkbutton" onclick="addTab('修改登录密码','Users/ChangePersonPsw.aspx')">
                                            修改登录密码</a></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
