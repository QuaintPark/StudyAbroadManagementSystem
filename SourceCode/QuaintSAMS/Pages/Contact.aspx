<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="QuaintSAMS.Pages.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="contact-us-page1-area">
        <div class="container">
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                    <div class="contact-us-info1">
                        <ul>
                            <li>
                                <i class="fa fa-phone" aria-hidden="true"></i>
                                <h3>Phone</h3>
                                <p>+8801676 744144</p>
                            </li>
                            <li>
                                <i class="fa fa-map-marker" aria-hidden="true"></i>
                                <h3>Address</h3>
                                <p>Dhaka, Bangladesh</p>
                            </li>
                            <li>
                                <i class="fa fa-envelope-o" aria-hidden="true"></i>
                                <h3>E-mail</h3>
                                <p>hsg@gmail.com</p>
                            </li>
                            <li>
                                <h3>Follow Us</h3>
                                <ul class="contact-social">
                                    <li><a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                                    <li><a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                                    <li><a href="#"><i class="fa fa-linkedin" aria-hidden="true"></i></a></li>
                                    <li><a href="#"><i class="fa fa-pinterest" aria-hidden="true"></i></a></li>
                                    <li><a href="#"><i class="fa fa-rss" aria-hidden="true"></i></a></li>
                                    <li><a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <h2 class="title-default-left title-bar-high">Contact With Us</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="contact-form1">
                            <div id="contact-form">
                                <fieldset>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group">
                                            <%--<input type="text" placeholder="Name*" class="form-control" name="name" id="form-name" data-error="Name field is required" required>--%>
                                            <asp:TextBox runat="server" id="nametxt" placeholder="Name*" class="form-control"></asp:TextBox>
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group">
                                            <%--<input type="email" placeholder="Email*" class="form-control" name="email" id="form-email" data-error="Email field is required" required>--%>
                                            <asp:TextBox runat="server" id="emailtxt" placeholder="Email*" class="form-control"></asp:TextBox>
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group">
                                            <%--<textarea placeholder="Message*" class="textarea form-control" name="message" id="form-message" rows="8" cols="20" data-error="Message field is required" required></textarea>--%>
                                            <asp:TextBox runat="server" id="messagetxt" TextMode="MultiLine" class="textarea form-control" rows="8" cols="20"></asp:TextBox>
                                            <div class="help-block with-errors"></div>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-6 col-sm-12">
                                        <div class="form-group margin-bottom-none">
                                            <%--<button type="submit" class="default-big-btn">Send Message</button>--%>
                                            <asp:Button runat="server" id="sendBtn" Text="Send Message" CssClass="default-big-btn" />
                                        </div>
                                    </div>
                                    <div class="col-lg-8 col-md-8 col-sm-6 col-sm-12">
                                        <div class='form-response'></div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <iframe runat="server" id="mapSection" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7496149.559281854!2d85.84647510143783!3d23.45219283693556!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x30adaaed80e18ba7%3A0xf2d28e0c4e1fc6b!2sBangladesh!5e0!3m2!1sen!2sbd!4v1516641930341" marginwidth="0" width="100%" scrolling="no" height="400" marginheight="0" style="border: 0" allowfullscreen="" frameborder="0"></iframe>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
