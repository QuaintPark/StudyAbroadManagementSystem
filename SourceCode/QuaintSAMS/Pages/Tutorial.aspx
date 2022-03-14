<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutorial.aspx.cs" Inherits="QuaintSAMS.Pages.Tutorial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Tutorial"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <style>
        .pb-video-container {
            padding: 70px 0px;
            background: #bdc3c7;
            font-family: Lato;
        }

        .pb-video {
            border: 1px solid #e6e6e6;
            padding: 5px;
        }

            .pb-video:hover {
                background: #2c3e50;
            }

        /*.pb-video-frame {
            transition: width 2s, height 2s;
        }

            .pb-video-frame:hover {
                height: 300px;
            }*/

        .pb-row {
            margin-bottom: 10px;
        }
        .label-warning {
            background-color: #EFC939;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <div class="container-fluid pb-video-container">
                <div class="col-md-10 col-md-offset-1">
                    <div class="row pb-row">

                        <asp:Repeater ID="rptrTutorial" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3 pb-video">
                                    <iframe runat="server" src='<%# Eval("ExternalUrl") %>' class="pb-video-frame" width="100%" height="230" frameborder="0" allowfullscreen></iframe>
                                    <label class="form-control label-warning text-center"><%# Eval("Title") %></label>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                                                
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
