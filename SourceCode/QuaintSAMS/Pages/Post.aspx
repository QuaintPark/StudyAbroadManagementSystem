<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="QuaintSAMS.Pages.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">    
    <div class="event-details-page-area">
        <div class="container">
            <div class="row">
                <div class="col-lg-9 col-md-9 col-sm-8 col-xs-12">
                    <div class="event-details-inner">
                        <h2 class="title-default-left-bold-lowhight" runat="server" id="txtTitle"></h2>
                        <ul class="event-info-inline title-bar-sm-high">
                            <li><i class="fa fa-calendar" aria-hidden="true"></i>
                                <asp:Label ID="txtPublishedDate" runat="server"></asp:Label></li>
                            <li><i class="fa fa-tags" aria-hidden="true"></i>
                                <asp:Label ID="txtBlogPostCategoryName" runat="server"></asp:Label></li>
                        </ul>
                        <p runat="server" id="txtDescription"></p>
                    </div>
                    <div class="event-details-inner area-blog-post-attachment">
                        <div runat="server" id="attachmentDownload" visible="false">
                            <asp:LinkButton ID="lnkDownload" runat="server" OnClick="DownloadFile">
                                <i class="fa fa-download"></i>
                                <asp:Label ID="txtAttachment" runat="server" Text="Attachment"></asp:Label>
                            </asp:LinkButton> 
                        </div>
                        <div runat="server" id="attachmentView" visible="false">
                            <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx?Ref=member">
                                <i class="fa fa-download"></i>
                                <asp:Label ID="txtAttachmentView" runat="server" Text="Attachment"></asp:Label>
                            </asp:HyperLink>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                    <div class="sidebar-box">
                        <div class="sidebar-box-inner">
                            <h3 class="sidebar-title">Categories</h3>
                            <ul class="sidebar-categories">
                                <li><a runat="server" href="~/Pages/Blog.aspx">All</a></li>

                                <asp:Repeater ID="rptrBlogPostCategory" runat="server">
                                    <ItemTemplate>
                                        <li><a runat="server" href='<%# string.Concat("~/Pages/Blog.aspx?Slug=", Eval("Slag")) %>'><%# Eval("Name") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>        
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
