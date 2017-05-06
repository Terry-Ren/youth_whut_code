<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_online.aspx.cs" Inherits="AUTO.youth_online_post.youth_online"
    Debug="true" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /*投稿*/
            $(".tg_a").click(function () {
                var ok = true;
                var val1 = $("#tg_bt").val();
                var val2 = $("#tg_ly").val();
                var val3 = $("#tg_nr").val();
                var val4 = $("#tg_yx").val();
                var val5 = $("#tg_zz").val();
                if (val1 == "") {
                    $("#tg_span_bt").show();
                    ok = false;
                } else {
                    $("#tg_span_bt").hide();
                }
                if (val2 == "") {
                    $("#tg_span_ly").show();
                    ok = false;
                } else {
                    $("#tg_span_ly").hide();
                }
                if (val3 == "") {
                    $("#tg_span_nr").show();
                    ok = false;
                } else {
                    $("#tg_span_nr").hide();
                }
                if (val4 == "") {
                    $("#tg_span_xm").show();
                    ok = false;
                } else {
                    $("#tg_span_xm").hide();
                }
                if (val5 == "") {
                    $("#tg_span_yx").show();
                    ok = false;
                } else {
                    $("#tg_span_yx").hide();
                }
                if (ok == false) {
                    //alert("请完善投稿信息！");
                    return false;
                }

            });
            //            $(".input_p input").blur(function () {
            //                var val = $(this).val();
            //                if (val != "") {
            //                    $(this).parent().prev().children("span").hide();
            //                }
            //            });
            //            $(".textarea_p textarea").blur(function () {
            //                var val = $(this).val();
            //                if (val != "") {
            //                    $(this).parent().prev().children("span").hide();
            //                }
            //            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="../youth_index.aspx">首页</a>><a href="youth_online.aspx">投稿</a></div>
            <div class="detail_content">
                <p class="tg_title">
                    新闻标题<span id="tg_span_bt">请输入文章标题</span>
                </p>
                <p class="input_p">
                    <asp:TextBox ID="tg_bt" runat="server"></asp:TextBox></p>
                <p class="tg_title">
                    新闻类型<span id="tg_span_type">请选择新闻类型</span>
                </p>
                <p class="input_p">
                    <asp:DropDownList ID="ddl_news_type" runat="server" OnSelectedIndexChanged="ddl_news_type_SelectedIndexChanged"
                        AutoPostBack="true">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="3">原创文学</asp:ListItem>
                        <asp:ListItem Value="4">社团天地</asp:ListItem>
                        <asp:ListItem Value="8">基层团建</asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p class="tg_title">
                    新闻内容<span id="tg_span_nr">请输入文章内容</span>
                </p>
                <p class="textarea_p">
                    <asp:TextBox ID="tg_nr" name="txtContent" class="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>
                </p>
                <p class="tg_title">
                    作者<span id="tg_span_xm">请输入作者姓名</span>
                </p>
                <p class="input_p">
                    <asp:TextBox ID="tg_zz" runat="server"></asp:TextBox>
                </p>
                <p class="tg_title">
                    电话<span id="tg_span_dh">请输入作者电话</span></p>
                <p class="input_p">
                    <asp:TextBox ID="txt_phone" runat="server"></asp:TextBox>
                </p>
                <p class="tg_title">
                    邮箱<span id="tg_span_yx">请输入作者邮箱</span></p>
                <p class="input_p">
                    <asp:TextBox ID="tg_yx" runat="server"></asp:TextBox>
                </p>
                <p class="tg_title">
                    新闻来源<span id="tg_span_ly">请选择来源</span></p>
                <p class="input_p">
                    <asp:DropDownList ID="tg_ly" runat="server">
                        <asp:ListItem Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p class="tg_title">
                    验证码</p>
                <p class="input_p">
                    <asp:TextBox ID="txt_Check" runat="server" CssClass="input-small" placeholder="验证码"></asp:TextBox>
                    <img height="26" src="../CheckCode.ashx" onclick="this.src=this.src+'?r='+Math.random();"
                        title="单击刷新验证码" id="img_rrand_code">
                </p>
                <asp:Button ID="btn_submit" runat="server" Text="提交" class="tg_a" OnClick="btn_submit_Click" />
            </div>
        </div>
        <div class="side">
            <div class="annou hei1 fix">
                <h2 class="block_title" style="border-top: none;">
                    投稿注意事项<span></span></h2>
                <div class="news_list tougao_ts">
                    <p>
                        1、敬请使用中文标点符号</p>
                    <p>
                        2、推荐填写真实电子邮件地址，以方便得到文章的反馈信息</p>
                    <p>
                        3、不能用word文档投稿</p>
                    <p>
                        4、图片大小不小于1M</p>
                    <p>
                        5、如不能正常投稿，请投至lgqnbianjibu@163.com</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
