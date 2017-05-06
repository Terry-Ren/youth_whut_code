<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.Master" AutoEventWireup="true"
    CodeBehind="youth_meetingroomLy.aspx.cs" Inherits="AUTO.youth_huike.youth_meetingroomLy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /*书记会客室*/
            $(".tg_a").click(function () {
                var ok = true;
                var val1 = $("#tg_bt").val();
                var val2 = $("#tg_ly").val();
                //var val3 = $("#tg_nr").val();
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
                //                if (val3 == "") {
                //                    $("#tg_span_nr").show();
                //                    ok = false;
                //                } else {
                //                    $("#tg_span_nr").hide();
                //                }
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
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maincontent fix">
        <div class="content">
            <div class="daohang">
                当前位置：<a href="#">首页</a>><a href="#">团委书记会客室提交留言</a></div>
            <div class="detail_content">
                <!--留言-->
                <div class="ly_gr">
                    基本信息</div>
                <p class="tg_title">
                    选择留言类别<span id="tg_span_ly">请选择留言类别</span></p>
                <p class="input_p">
                    <asp:DropDownList ID="ddl_type" runat="server">
                    </asp:DropDownList>
                </p>
                <p class="tg_title">
                    姓名<span id="tg_span_xm">请输入你的姓名</span></p>
                <p class="input_p">
                    <asp:TextBox ID="tg_zz" runat="server" Text="游客"></asp:TextBox></p>
                <p class="tg_title">
                    性别</p>
                <p class="radio">
                    <asp:RadioButton ID="male" GroupName="genger" Text="男" Checked="true" runat="server" />
                    <asp:RadioButton ID="female" GroupName="genger" Text="女" runat="server" />
                </p>
                <p class="tg_title">
                    邮箱</p>
                <p class="input_p">
                    <asp:TextBox ID="tg_yx" runat="server"></asp:TextBox></p>
                <p class="tg_title">
                    联系方式</p>
                <p class="input_p">
                    <asp:TextBox ID="txt_qq" runat="server"></asp:TextBox></p>
                <p class="tg_title">
                    学院团支部</p>
                <p class="input_p">
                    <asp:TextBox ID="txt_homepage" runat="server"></asp:TextBox></p>
                <div class="ly_gr">
                    留言内容</div>
                <p class="tg_title">
                    标题<span id="tg_span_bt">请输入留言标题</span></p>
                <p class="input_p">
                    <asp:TextBox ID="tg_bt" runat="server"></asp:TextBox>
                </p>
                <p class="tg_title">
                    正文<span id="tg_span_nr">请输入留言正文</span></p>
                <p class="textarea_p">
                    <asp:TextBox ID="tg_nr" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
                </p>
                <%--<p class="tg_title">
                    选择回复留言的书记<span id="tg_span_ly">请选择回复留言的书记</span></p>
                <p class="input_p">
                    <select id="tg_ly">
                        <option>郎坤</option>
                        <option>黄嵩</option>
                        <option>周慧</option>
                        <option>魏明华</option>
                    </select>
                </p>--%>
                <asp:Button ID="btn_submit" runat="server" class="tg_a" Text="提交" OnClick="btn_submit_Click" />
            </div>
        </div>
        <div class="side">
            <%--<div class="annou hei1 fix">
                <h2 class="block_title" style="border-top: none;">
                    团委书记<span></span></h2>
                <div class="news_list tougao_ts shuji">
                    <p>
                        郎坤</p>
                    <p>
                        黄嵩</p>
                    <p>
                        周慧</p>
                    <p>
                        魏明华</p>
                </div>
            </div>--%>
            <div class="annou hei1 fix huikeshi">
                <a href="youth_meetingroomLy.aspx">提交留言</a> <a href="youth_meetingroom.aspx" id="ckly">
                    查看留言</a> <a href="../youth_manage/youth_login.aspx" id="sjdl">书记登录</a>
            </div>
        </div>
    </div>
</asp:Content>
