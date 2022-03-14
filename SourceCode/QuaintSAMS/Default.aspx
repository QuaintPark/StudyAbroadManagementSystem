<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuaintSAMS.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <!-- Slider 1 Area Start Here -->
            <div class="slider1-area overlay-default">
                <div class="bend niceties preview-1">
                    <div id="ensign-nivoslider-3" class="slides">
                        <img runat="server" src="~/Theme/img/slider/2-1.jpg" alt="slider" title="#slider-direction-1" />
                        <img runat="server" src="~/Theme/img/slider/2-2.jpg" alt="slider" title="#slider-direction-2" />
                        <img runat="server" src="~/Theme/img/slider/1-2.jpg" alt="slider" title="#slider-direction-3" />
                    </div>
                    <div id="slider-direction-1" class="t-cn slider-direction">
                        <div class="slider-content s-tb slide-1">
                            <div class="title-container s-tb-c">
                                <div class="title1">Best Education For UI Design</div>
                                <p>
                                    Emply dummy text of the printing and typesetting industry orem Ipsum has been the industry's standard
                                <br>
                                    dummy text ever sinceprinting and typesetting industry.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div id="slider-direction-2" class="t-cn slider-direction">
                        <div class="slider-content s-tb slide-2">
                            <div class="title-container s-tb-c">
                                <div class="title1">Best Education For HTML Template</div>
                                <p>
                                    Emply dummy text of the printing and typesetting industry orem Ipsum has been the industry's standard
                                <br>
                                    dummy text ever sinceprinting and typesetting industry.
                                </p>
                            </div>
                        </div>
                    </div>
                    <div id="slider-direction-3" class="t-cn slider-direction">
                        <div class="slider-content s-tb slide-3">
                            <div class="title-container s-tb-c">
                                <div class="title1">Best Education Into PHP</div>
                                <p>
                                    Emply dummy text of the printing and typesetting industry orem Ipsum has been the industry's standard
                                <br>
                                    dummy text ever sinceprinting and typesetting industry.
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Slider 1 Area End Here -->

            <!-- About 1 Area Start Here -->
            <div class="about1-area">
                <div class="container">
                    <h1 class="about-title wow fadeIn" data-wow-duration="1s" data-wow-delay=".2s">Welcome To Academics</h1>
                    <p class="about-sub-title wow fadeIn" data-wow-duration="1s" data-wow-delay=".2s">Tmply dummy text of the printing and typesetting industry. Lorem Ipsum has been theindustry's standard dummy text ever since the 1500s, when an unknown printer took.</p>
                    <div class="about-img-holder wow fadeIn" data-wow-duration="2s" data-wow-delay=".2s">
                        <img runat="server" src="~/Theme/img/about/1.jpg" alt="about" class="img-responsive" />
                    </div>
                </div>
            </div>
            <!-- About 1 Area End Here -->

            <!-- Top Institute Area Start Here -->
            <div class="courses1-area">
                <div class="container">
                    <h2 class="title-default-left">Top Institute </h2>
                </div>
                <div id="shadow-carousel" class="container">
                    <div class="rc-carousel" data-loop="true" data-items="4" data-margin="20" data-autoplay="false" data-autoplay-timeout="10000" data-smart-speed="2000" data-dots="false" data-nav="true" data-nav-speed="false" data-r-x-small="1" data-r-x-small-nav="true" data-r-x-small-dots="false" data-r-x-medium="2" data-r-x-medium-nav="true" data-r-x-medium-dots="false" data-r-small="2" data-r-small-nav="true" data-r-small-dots="false" data-r-medium="3" data-r-medium-nav="true" data-r-medium-dots="false" data-r-large="4" data-r-large-nav="true" data-r-large-dots="false">
                        
                        <asp:Repeater ID="rptrTopInstitute" runat="server">
                            <ItemTemplate>
                                <div class="courses-box1">
                                    <div class="single-item-wrapper">
                                        <div class="courses-img-wrapper hvr-bounce-to-bottom">
                                            <div class="col-md-12">
                                                <img class="img-responsive" runat="server" src='<%# (string.IsNullOrEmpty(Convert.ToString(Eval("Logo")))) ? string.Empty : QuaintSAMS.Code.Global.FilePath.Institute + Eval("Logo") %>' alt='<%# Eval("Name") %>' />
                                            </div>
                                            <a href='<%# (Convert.ToString(Eval("Url")).StartsWith("http://") || Convert.ToString(Eval("Url")).StartsWith("https://")) ? Eval("Url") : string.Concat("http://", Eval("Url")) %>' target="_blank"><i class="fa fa-link" aria-hidden="true"></i></a>
                                        </div>
                                        <div class="courses-content-wrapper">
                                            <h3 class="item-title"><a><%# Eval("CourseName") %></a></h3>
                                            <h2><%# Eval("Name") %></h2>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>
            <!-- Top Institute  Area End Here -->

            <!-- Video Area Start Here -->
            <div class="video-area overlay-video bg-common-style" style="background-image: url('Theme/img/banner/1.jpg');">
                <div class="container">
                    <div class="video-content">
                        <h2 class="video-title">Watch Campus Life Video Tour</h2>
                        <p class="video-sub-title">
                            Vmply dummy text of the printing and typesetting industryorem
                       
                            <br>
                            Ipsum industry's standard dum an unknowramble.
                        </p>
                        <a class="play-btn popup-youtube wow bounceInUp" data-wow-duration="2s" data-wow-delay=".1s" href="https://www.youtube.com/watch?v=LMbQsI1PKVw"><i class="fa fa-play" aria-hidden="true"></i></a>
                    </div>
                </div>
            </div>
            <!-- Video Area End Here -->

            <!-- Helps and Tips Area Start Here -->
            <div class="news-event-area">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12 event-inner-area">
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
                            <div class="col-md-12 event-btn-holder">
                                <a runat="server" href="~/Pages/Blog.aspx" class="view-all-primary-btn">View All</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Help and Tips Area End Here -->

            <!-- Counter Area Start Here -->
            <div class="counter-area bg-primary-deep" style="background-image: url('img/banner/4.jpg');">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 counter1-box wow fadeInUp" data-wow-duration=".5s" data-wow-delay=".40s">
                            <h2 class="title-bar-counter">
                                <asp:Label ID="lblTotalUniversity" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p>Total <br/>University</p>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 counter1-box wow fadeInUp" data-wow-duration=".5s" data-wow-delay=".40s">
                            <h2 class="title-bar-counter">
                                <asp:Label ID="lblTotalBank" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p>Bank List <br/>(Who Provides Loan)</p>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 counter1-box wow fadeInUp" data-wow-duration=".5s" data-wow-delay=".60s">
                            <h2 class="title-bar-counter">
                                <asp:Label ID="lblTotalCourse" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p>Total <br/>Course</p>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 counter1-box wow fadeInUp" data-wow-duration=".5s" data-wow-delay=".80s">
                            <h2 class="title-bar-counter">
                                <asp:Label ID="lblTotalBlogPost" runat="server" Text="0"></asp:Label>
                            </h2>
                            <p>News & Post</p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Counter Area End Here -->

            <!-- Students Say Area Start Here -->
            <div class="students-say-area">
                <h2 class="title-default-center">What Our Students Say</h2>
                <div class="container">
                    <div class="rc-carousel" data-loop="true" data-items="2" data-margin="30" data-autoplay="false" data-autoplay-timeout="10000" data-smart-speed="2000" data-dots="true" data-nav="false" data-nav-speed="false" data-r-x-small="1" data-r-x-small-nav="false" data-r-x-small-dots="true" data-r-x-medium="2" data-r-x-medium-nav="false" data-r-x-medium-dots="true" data-r-small="2" data-r-small-nav="false" data-r-small-dots="true" data-r-medium="2" data-r-medium-nav="false" data-r-medium-dots="true" data-r-large="2" data-r-large-nav="false" data-r-large-dots="true">
                        <div class="single-item">
                            <div class="single-item-wrapper">
                                <div class="profile-img-wrapper">
                                    <a href="#" class="profile-img">
                                        <img class="profile-img-responsive img-circle" runat="server" src="~/Theme/img/students/1.jpg" alt="Testimonial" /></a>
                                </div>
                                <div class="tlp-tm-content-wrapper">
                                    <h3 class="item-title"><a href="#">Rosy Janner</a></h3>
                                    <span class="item-designation">UI Designer</span>
                                    <ul class="rating-wrapper">
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                    </ul>
                                    <div class="item-content">Pellentesque tellus arcu, laoreet volutpavenenatis molestPellentesque commodo lorem lectus pretium vehicula.</div>
                                </div>
                            </div>
                        </div>
                        <div class="single-item">
                            <div class="single-item-wrapper">
                                <div class="profile-img-wrapper">
                                    <a href="#" class="profile-img">
                                        <img class="profile-img-responsive img-circle" runat="server" src="~/Theme/img/students/2.jpg" alt="Testimonial" /></a>
                                </div>
                                <div class="tlp-tm-content-wrapper">
                                    <h3 class="item-title"><a href="#">Dainel Dina</a></h3>
                                    <span class="item-designation">Manager</span>
                                    <ul class="rating-wrapper">
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                    </ul>
                                    <div class="item-content">Pellentesque tellus arcu, laoreet volutpavenenatis molestPellentesque commodo lorem lectus pretium vehicula.</div>
                                </div>
                            </div>
                        </div>
                        <div class="single-item">
                            <div class="single-item-wrapper">
                                <div class="profile-img-wrapper">
                                    <a href="#" class="profile-img">
                                        <img class="profile-img-responsive img-circle" runat="server" src="~/Theme/img/students/2.jpg" alt="Testimonial"></a>
                                </div>
                                <div class="tlp-tm-content-wrapper">
                                    <h3 class="item-title"><a href="#">Dainel Dina</a></h3>
                                    <span class="item-designation">Manager</span>
                                    <ul class="rating-wrapper">
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                    </ul>
                                    <div class="item-content">Pellentesque tellus arcu, laoreet volutpavenenatis molestPellentesque commodo lorem lectus pretium vehicula.</div>
                                </div>
                            </div>
                        </div>
                        <div class="single-item">
                            <div class="single-item-wrapper">
                                <div class="profile-img-wrapper">
                                    <a href="#" class="profile-img">
                                        <img class="profile-img-responsive img-circle" runat="server" src="~/Theme/img/students/1.jpg" alt="Testimonial" /></a>
                                </div>
                                <div class="tlp-tm-content-wrapper">
                                    <h3 class="item-title"><a href="#">Rosy Janner</a></h3>
                                    <span class="item-designation">UI Designer</span>
                                    <ul class="rating-wrapper">
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                    </ul>
                                    <div class="item-content">Pellentesque tellus arcu, laoreet volutpavenenatis molestPellentesque commodo lorem lectus pretium vehicula.</div>
                                </div>
                            </div>
                        </div>
                        <div class="single-item">
                            <div class="single-item-wrapper">
                                <div class="profile-img-wrapper">
                                    <a href="#" class="profile-img">
                                        <img class="profile-img-responsive img-circle" runat="server" src="~/Theme/img/students/2.jpg" alt="Testimonial" /></a>
                                </div>
                                <div class="tlp-tm-content-wrapper">
                                    <h3 class="item-title"><a href="#">Dainel Dina</a></h3>
                                    <span class="item-designation">Manager</span>
                                    <ul class="rating-wrapper">
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                        <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                    </ul>
                                    <div class="item-content">Pellentesque tellus arcu, laoreet volutpavenenatis molestPellentesque commodo lorem lectus pretium vehicula.</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Students Say Area End Here -->

            <!-- Students Join 1 Area Start Here -->
            <div class="students-join2-area">
                <div class="container">
                    <div class="students-join2-wrapper">
                        <div class="students-join2-left">
                            <div id="ri-grid" class="author-banner-bg ri-grid header text-center">
                                <ul class="ri-grid-list">
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                    <li><a class="img-avater"><img runat="server" src="~/Theme/img/avater-member.png" alt="" /></a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="students-join2-right">
                            <div>
                                <h2>Join <span>
                                    <asp:Label ID="lblTotalMember" runat="server" Text="Label"></asp:Label></span> Members.</h2>
                                <a runat="server" href="~/Register.aspx" class="join-now-primary-btn">Join Now</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Students Join 1 Area End Here -->

            <!-- Brand Area Start Here -->
            <div class="brand-area">
                <div class="container">
                    <div class="rc-carousel" data-loop="true" data-items="4" data-margin="30" data-autoplay="true" data-autoplay-timeout="5000" data-smart-speed="2000" data-dots="false" data-nav="false" data-nav-speed="false" data-r-x-small="2" data-r-x-small-nav="false" data-r-x-small-dots="false" data-r-x-medium="3" data-r-x-medium-nav="false" data-r-x-medium-dots="false" data-r-small="4" data-r-small-nav="false" data-r-small-dots="false" data-r-medium="4" data-r-medium-nav="false" data-r-medium-dots="false" data-r-large="4" data-r-large-nav="false" data-r-large-dots="false">
                        <div class="brand-area-box">
                            <a href="#">
                                <img runat="server" src="~/Theme/img/brand/1.jpg" alt="brand" /></a>
                        </div>
                        <div class="brand-area-box">
                            <a href="#">
                                <img runat="server" src="~/Theme/img/brand/2.jpg" alt="brand" /></a>
                        </div>
                        <div class="brand-area-box">
                            <a href="#">
                                <img runat="server" src="~/Theme/img/brand/3.jpg" alt="brand" /></a>
                        </div>
                        <div class="brand-area-box">
                            <a href="#">
                                <img runat="server" src="~/Theme/img/brand/4.jpg" alt="brand" /></a>
                        </div>
                        <div class="brand-area-box">
                            <a href="#">
                                <img runat="server" src="~/Theme/img/brand/1.jpg" alt="brand" /></a>
                        </div>
                        <div class="brand-area-box">
                            <a href="#">
                                <img runat="server" src="~/Theme/img/brand/2.jpg" alt="brand" /></a>
                        </div>
                        <div class="brand-area-box">
                            <a href="#">
                                <img runat="server" src="~/Theme/img/brand/3.jpg" alt="brand" /></a>
                        </div>
                        <div class="brand-area-box">
                            <a href="#">
                                <img runat="server" src="~/Theme/img/brand/4.jpg" alt="brand" /></a>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Brand Area End Here -->

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
