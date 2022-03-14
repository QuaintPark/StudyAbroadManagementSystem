<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="QuaintSAMS.Account.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Profile"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1>Profile</h1>
            </section>

            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header with-border">
                                <i class="fa fa-certificate"></i>
                                <h3 class="box-title">
                                    <asp:Label ID="lblTitleStatus" runat="server" Text="Change Password"></asp:Label>
                                    </h3>
                            </div>
                            <div class="box-body user-form">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtPassword">Password:<span>*</span></label>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" required="required"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtConfirmPassword">Confirm Password:<span>*</span></label>
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control"  placeholder="Password" TextMode="Password" required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="box-footer" id="alertMessage" runat="server"></div>
                            <div class="box-footer text-right">
                                <p class="pull-left conditions">* Mandatory field</p>
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default" OnClick="btnClear_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                            </div>
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
