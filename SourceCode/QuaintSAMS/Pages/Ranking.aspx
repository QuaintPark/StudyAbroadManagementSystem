<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ranking.aspx.cs" Inherits="QuaintSAMS.Pages.Ranking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Ranking"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <div class="container content-page">
                <div class="row content-page-section">
                    <div class="col-md-4 col-md-offset-4">
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <table class="table table-responsive table-striped table-hover content-page-table">
                            <thead>
                                <tr>
                                    <th>Serial</th>
                                    <th>University Name</th>
                                    <th>Rank</th>
                                    <th>Country</th>
                                    <th>Description</th>
                                    <th>Link</th>
                                </tr>
                            </thead>

                            <tbody class="text-center">
                                <asp:Repeater ID="rptrList" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %></td>
                                            <td class="text-left"><%# Eval("UniversityName") %></td>
                                            <td><b><%# Eval("Rank") %></b></td>
                                            <td><%# Eval("CountryName") %></td>
                                            <td class="text-left"><%# Eval("Description") %></td>
                                            <td><a class="btn btn-link" href='<%# (Convert.ToString(Eval("Url")).StartsWith("http://") || Convert.ToString(Eval("Url")).StartsWith("https://")) ? Eval("Url") : string.Concat("http://", Eval("Url")) %>' target="_blank"><i class="fa fa-link"></i>Official Website</a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
