<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="QuaintSAMS.Pages.Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="news-event-area">
                <div class="container">
                    <div class="row">
                        <div class="col-md-9 event-inner-area">
                            <div class="col-md-12">
                                <h2 class="title-default-left page-title">Help &amp; Tips</h2>
                            </div>
                            <div class="col-md-12">
                                <ul class="event-wrapper">

                                    <asp:Repeater ID="rptrPost" runat="server">
                                        <ItemTemplate>
                                            <li class="wow bounceInUp" data-wow-duration="2s" data-wow-delay=".1s">
                                                <div class="event-calender-wrapper">
                                                    <div class="event-calender-holder">
                                                        <h3><%# Convert.ToDateTime(Eval("PublishedDate")).ToString("dd") %></h3>
                                                        <p><%# Convert.ToDateTime(Eval("PublishedDate")).ToString("MMM") %></p>
                                                        <span><%# Convert.ToDateTime(Eval("PublishedDate")).ToString("yyyy") %></span>
                                                    </div>
                                                </div>
                                                <div class="event-content-holder">
                                                    <h3><a runat="server" href='<%# string.Concat("~/Pages/Post.aspx?Slug=", Eval("Slag")) %>'><%# Eval("Title") %></a></h3>
                                                    <p><%# (Convert.ToString(Eval("Description")).Length > 200) ? Convert.ToString(Eval("Description")).Substring(0, 200).ToString() + "..." : Convert.ToString(Eval("Description")) %></p>
                                                    <ul>
                                                        <li><i class="fa fa-tags"></i><%# Eval("BlogPostCategoryName") %></li>
                                                    </ul>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </ul>
                            </div>
                            <%--<div class="col-md-12 event-btn-holder">
                                <a runat="server" href="~/Pages/HelpAndTips.aspx" class="view-all-primary-btn">View All</a>
                            </div>--%>
                        </div>
                        <div class="col-md-3">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
