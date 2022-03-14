<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="BlogPostList.aspx.cs" Inherits="QuaintSAMS.Account.BlogPostList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Blog Post"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1>Blog Post</h1>
                <ol class="breadcrumb">
                    <li>
                        <span id="workingBar" runat="server" visible="false" class="working-bar"><i class="fa fa-spinner fa-pulse fa-fw"></i>Working...</span>
                        <a runat="server" href="~/Account/BlogPost.aspx" class="btn btn-default"><i class="fa fa-plus"></i>Add</a>
                    </li>
                </ol>
            </section>

            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header with-border">
                                <i class="fa fa-list-alt"></i>
                                <h3 class="box-title">
                                    <asp:Label ID="lblTitleStatus" runat="server" Text="Blog Post List"></asp:Label>
                                </h3>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-primary btn-sm" data-widget="collapse" data-toggle="tooltip" title="Toggle">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body user-form">
                                <div class="col-md-12">
                                    <table class="table table-responsive table-bordered table-striped table-hover dataTable">
                                        <thead>
                                            <tr>
                                                <th>Serial</th>
                                                <th>Blog Post Code</th>
                                                <th>Title</th>
                                                <th>Slag</th>
                                                <th>Publish Date</th>
                                                <th>Category</th>
                                                <th>Status</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>

                                        <tbody class="text-center">
                                            <asp:Repeater ID="rptrList" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Container.ItemIndex + 1 %></td>
                                                        <td><%# Eval("BlogPostCode") %></td>
                                                        <td class="text-left"><%# Eval("Title") %></td>
                                                        <td class="text-left"><%# Eval("Slag") %></td>
                                                        <td><%# Convert.ToDateTime(Eval("PublishedDate")).ToString("dd-MMM-yyyy") %></td>
                                                        <td class="text-left"><%# Eval("BlogPostCategoryName") %></td>
                                                        <td><%# Convert.ToBoolean(Eval("IsActive")) ? "<span class='text-success text-bold'>Active</span>" : "<span class='text-danger text-bold'>Deactive</span>" %></td>

                                                        <%-- Action Controls --%>
                                                        <td>
                                                            <div class="dropdown">
                                                                <button class="btn btn-info dropdown-toggle" type="button" id="dropdownMenuAction" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                                                    <i class="fa fa-bars"></i>
                                                                </button>
                                                                <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuAction">
                                                                    <li>
                                                                        <asp:LinkButton ID="btnActiveOrDeactive" runat="server" OnCommand="btnActiveOrDeactive_Command" CommandArgument='<%# QuaintPark.QuaintSecurityManager.Encrypt(Eval("BlogPostId").ToString()) %>'>
                                                                            <%# Convert.ToBoolean(Eval("IsActive")) ? "<i class='fa fa-times-circle text-red'></i>Deactive" : "<i class='fa fa-check-circle text-green'></i>Active" %>
                                                                        </asp:LinkButton>
                                                                    </li>
                                                                    <li>
                                                                        <asp:HyperLink ID="btnEdit" runat="server" NavigateUrl='<%# String.Concat("~/Account/BlogPost.aspx?Id=", QuaintPark.QuaintSecurityManager.EncryptUrl(Eval("BlogPostId").ToString())) %>'><i class="fa fa-edit text-light-blue"></i>Edit</asp:HyperLink>
                                                                    </li>
                                                                    <li class="list-seperator"></li>
                                                                    <li>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure want to delete?')" OnCommand="btnDelete_Command" CommandArgument='<%# QuaintPark.QuaintSecurityManager.Encrypt(Eval("BlogPostId").ToString()) %>'><i class="fa fa-trash text-red"></i>Delete</asp:LinkButton>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="box-footer" id="alertMessage" runat="server"></div>
                        </div>
                    </div>
                </div>
            </section>

            <asp:Timer ID="tmrAlertMessage" runat="server" Enabled="False" OnTick="tmrAlertMessage_Tick"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
