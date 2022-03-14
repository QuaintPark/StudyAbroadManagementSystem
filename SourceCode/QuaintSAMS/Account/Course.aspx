<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="QuaintSAMS.Account.Course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Course"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1>Course</h1>
                <ol class="breadcrumb">
                    <li>
                        <span id="workingBar" runat="server" visible="false" class="working-bar"><i class="fa fa-spinner fa-pulse fa-fw"></i>Working...</span>
                        <a runat="server" href="~/Account/CourseList.aspx" class="btn btn-default"><i class="fa fa-list-alt"></i>List</a>
                    </li>
                </ol>
            </section>

            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header with-border">
                                <i class="fa fa-certificate"></i>
                                <h3 class="box-title">
                                    <asp:Label ID="lblTitleStatus" runat="server" Text="Add"></asp:Label>
                                    Course</h3>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-primary btn-sm" data-widget="collapse" data-toggle="tooltip" title="Toggle">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body user-form">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtName">Name:<span>*</span></label>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Name" required="required"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtDescription">Description:</label>
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Description"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="fuAttachment">Attachment:</label>
                                        <asp:FileUpload ID="fuAttachment" runat="server" CssClass="form-control" accept=".jpg, .jpeg, .png, .gif, .pdf, .doc, .docx, .ppt, .pptx, .xls, .xlsx" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="fuAttachment" ErrorMessage="Allow: jpg, jpeg, png, gif, pdf, doc, docx, ppt, pptx, xls, xlsx files" CssClass="msgError" ValidationExpression="(.*\.([Gg][Ii][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([pP][nN][gG])|.*\.([pP][dD][fF])|.*\.([dD][oO][cC])|.*\.([dD][oD][cC][xX])|.*\.([pP][pP][tT])|.*\.([pP][pP][tT][xX])|.*\.([xX][lL][sS])|.*\.([xX][lL][sS][xX])$)"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="box-footer" id="alertMessage" runat="server"></div>
                            <div class="box-footer text-right">
                                <p class="pull-left conditions">* Mandatory field</p>
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default" OnClick="btnClear_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSaveAndContinue" runat="server" Text="Save & Continue" CssClass="btn btn-primary" OnClick="btnSaveAndContinue_Click" />
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
