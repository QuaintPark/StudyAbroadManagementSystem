<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="Institute.aspx.cs" Inherits="QuaintSAMS.Account.Institute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Institute"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1>Institute</h1>
                <ol class="breadcrumb">
                    <li>
                        <span id="workingBar" runat="server" visible="false" class="working-bar"><i class="fa fa-spinner fa-pulse fa-fw"></i>Working...</span>
                        <a runat="server" href="~/Account/InstituteList.aspx" class="btn btn-default"><i class="fa fa-list-alt"></i>List</a>
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
                                    Institute</h3>
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
                                        <label for="txtUrl">Url:<span>*</span></label>
                                        <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control" placeholder="Url" required="required"></asp:TextBox>
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
                                        <label for="txtSerialNumber">Serial Number:<span>*</span></label>
                                        <asp:TextBox ID="txtSerialNumber" runat="server" CssClass="form-control" placeholder="Serial Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-4 pull-right text-center">
                                                <img id="imgLogo" runat="server" class="img-preview" src="~/Assets/images/avater-public.png" />
                                            </div>
                                            <div class="col-sm-8 section-pp">
                                                <label for="fuLogo">Logo:</label>
                                                <asp:FileUpload ID="fuLogo" runat="server" CssClass="form-control" onchange="PreviewImage(this);" accept=".jpg, .jpeg, .png, .gif" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fuLogo" ErrorMessage="Allow: jpg, jpeg, png, gif files" CssClass="msgError" ValidationExpression="(.*\.([Gg][Ii][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([pP][nN][gG])$)"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="ddlCourse">Course:<span>*</span></label>
                                        <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Select course" CssClass="msgError" InitialValue="--- Please Select ---"></asp:RequiredFieldValidator>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnSaveAndContinue" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
    <script type="text/javascript">
        // Preview Profile Photo
        function PreviewImage(input) {
            var isValidFile = CheckFile(input);
            if (isValidFile) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%= imgLogo.ClientID %>').prop('src', e.target.result).width(110).height(140);
                    };
                    reader.readAsDataURL(input.files[0]);
                    }
                }
                else {
                    $('#<%= imgLogo.ClientID %>').prop('src', '../Assets/images/avater-public.png').width(110).height(140);
            }
        }
    </script>
</asp:Content>
