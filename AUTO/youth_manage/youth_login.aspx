<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="youth_login.aspx.cs" Inherits="AUTO.youth_manage.youth_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录</title>
    <link rel="stylesheet" type="text/css" href="../css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/style1.css" />
    <!--[if lte IE 6]>
  <!-- bsie css 补丁文件 -->
    <link rel="stylesheet" type="text/css" href="../css/bootstrap-ie6.css" />
    <!-- bsie 额外的 css 补丁文件 -->
    <link rel="stylesheet" type="text/css" href="../css/ie.css" />
    <![endif]-->
    <style type="text/css">
        html
        {
            background: #f5f5f5;
        }
        
        body
        {
            padding-top: 80px;
            padding-bottom: 40px;
            background-color: #f5f5f5;
            background-image: url(images/bg2.jpg);
            background-repeat: no-repeat;
        }
        
        .container
        {
            height: 646px;
        }
        
        .form-signin
        {
            width: 300px;
            padding: 19px 29px 29px;
            margin: 0 auto 20px;
            background-color: #fff;
            border: 1px solid #e5e5e5;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.05);
            -moz-box-shadow: 0 1px 2px rgba(0,0,0,.05);
            box-shadow: 0 1px 2px rgba(0,0,0,.05);
            font-family: "微软雅黑";
        }
        
        .form-signin .form-signin-heading, .form-signin .checkbox
        {
            margin-bottom: 10px;
        }
        
        .form-signin input[type="text"], .form-signin input[type="password"]
        {
            font-size: 16px;
            height: auto;
            margin-bottom: 15px;
            padding: 7px 9px;
        }
    </style>
</head>
<body>
    <div class="container">
        <form class="form-signin" runat="server" id="form1">
        <h2 class="form-signin-heading" style="font-size: 26px;">
            登录</h2>
        账号：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txbAdminName" runat="server"
            CssClass="text" placeholder="账号"></asp:TextBox><br />
        密码：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txbPassword" runat="server"
            TextMode="Password" CssClass="text" placeholder="密码"></asp:TextBox><br />
        验证码：&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txbCheck" runat="server" CssClass="input-small"
            placeholder="验证码"></asp:TextBox>
        <img height="26" src="../CheckCode.ashx" onclick="this.src=this.src+'?r='+Math.random();"
            title="单击刷新验证码" id="img_rrand_code">
        <br />
        用户类型：<asp:DropDownList ID="ddlRole" runat="server" CssClass="select-multiple">
        </asp:DropDownList>
        <br />
        <asp:Button ID="login" runat="server" Font-Names="微软雅黑" CssClass="btn btn-large btn-primary"
            Text="登录" OnClick="login_Click" />
        <asp:Label ID="lblTip" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label><a
            href='<%=ResolveClientUrl("~/youth_index.aspx") %>' style="float: right; margin-top: 14px;">返回首页</a>
        </form>
    </div>
    <![endif]-->
</body>
</html>
