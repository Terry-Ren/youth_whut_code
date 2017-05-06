<%@ Page Title="" Language="C#" MasterPageFile="~/master/admin.master" AutoEventWireup="true"
    CodeBehind="NewsRange.aspx.cs" Inherits="AUTO.youth_admin.NewsRange.NewsRange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="box">
        <div id="box_top">
            选择稿件范围:<asp:DropDownList runat="server" ID="ddl_type">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="1">投稿量</asp:ListItem>
                <asp:ListItem Value="2">上稿量</asp:ListItem>
            </asp:DropDownList>
            选择稿件周期:<asp:DropDownList runat="server" ID="ddl_time">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="1">一个月内</asp:ListItem>
                <asp:ListItem Value="2">三个月内</asp:ListItem>
                <asp:ListItem Value="3">一周年内</asp:ListItem>
            </asp:DropDownList>
            <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search'"
                OnClick="lbtnSearch_Click">搜索</asp:LinkButton>
        </div>
        <div id="box_middle">
            <asp:GridView ID="gvwData" runat="server" AutoGenerateColumns="false" CssClass="table"
                HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="排名">
                        <ItemTemplate>
                            <%# Eval("rank")%>
                        </ItemTemplate>
                        <ItemStyle CssClass="table_head" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学院">
                        <ItemTemplate>
                            <%# Eval("academic_name")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="稿件数目">
                        <ItemTemplate>
                            <%# Eval("account")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    没有返回任何数据！
                </EmptyDataTemplate>
                <HeaderStyle CssClass="table_head" />
                <RowStyle HorizontalAlign="Center" />
                <EmptyDataRowStyle Font-Size="16px" ForeColor="Red" Font-Bold="true" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
