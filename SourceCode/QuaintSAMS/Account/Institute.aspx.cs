using QuaintPark;
using QuaintSAMS.Code.BLL;
using QuaintSAMS.Code.Global;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintSAMS.Account
{
    public partial class Institute : System.Web.UI.Page
    {
        // Message Box Method(s)
        private void Alert(AlertType alertType, string message)
        {
            alertMessage.InnerHtml = Core.AlertBox(alertType, message);
            tmrAlertMessage.Enabled = true;
            tmrAlertMessage.Interval = Core.AlertBoxInternal;
        }

        protected void tmrAlertMessage_Tick(object sender, EventArgs e)
        {
            if (tmrAlertMessage.Interval == Core.AlertBoxInternal)
            {
                alertMessage.InnerHtml = string.Empty;
                tmrAlertMessage.Enabled = false;

                if (this.MultiEntryDisallow)
                {
                    Response.Redirect("~/Account/InstituteList.aspx");
                }
            }
        }



        // View State(s)
        private string UserInfo
        {
            set { ViewState["UserInfo"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["UserInfo"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        private string StationInfo
        {
            set { ViewState["StationInfo"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["StationInfo"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        public int ModelId
        {
            set { ViewState["Id"] = value; }
            get
            {
                try
                {
                    return Convert.ToInt32(Convert.ToString(ViewState["Id"]));
                }
                catch
                {
                    return 0;
                }
            }
        }
        private string ModelCode
        {
            set { ViewState["Code"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["Code"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        private bool MultiEntryDisallow
        {
            set { ViewState["MultiEntryDisallow"] = value; }
            get
            {
                try
                {
                    return Convert.ToBoolean(Convert.ToString(ViewState["MultiEntryDisallow"]));
                }
                catch
                {
                    return false;
                }
            }
        }
        private string ModelLogo
        {
            set { ViewState["Logo"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["Logo"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiEntryDisallow = false;
                //QuaintSessionManager session = new QuaintSessionManager();
                //UserInfo = Convert.ToString(session.ActiveUserInformation);
                //StationInfo = Convert.ToString(session.ActiveStationInformation);
                LoadCourse();

                if (Request.QueryString["Id"] != null)
                {
                    this.ModelId = Convert.ToInt32(QuaintSecurityManager.DecryptUrl(Convert.ToString(Request.QueryString["Id"])));
                    Edit(this.ModelId);
                    lblTitleStatus.Text = "Update";
                    btnSave.Text = "Update";
                    btnSaveAndContinue.Text = "Update & Continue";
                    btnSaveAndContinue.Visible = false;
                }
                else
                {
                    GenerateCode();
                }
            }
        }

        private void LoadCourse()
        {
            try
            {
                CourseBLL courseBLL = new CourseBLL();
                DataTable dt = courseBLL.GetAllActive();
                ddlCourse.DataSource = dt;
                ddlCourse.DataTextField = "Name";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();

                ddlCourse.Items.Insert(0, "--- Please Select ---");
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void Edit(int id)
        {
            try
            {
                InstituteBLL instituteBLL = new InstituteBLL();
                DataTable dt = instituteBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["InstituteId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["InstituteCode"]);
                        txtName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                        imgLogo.Src = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Logo"]))) ? "~/Assets/images/avater-public.png" : FilePath.Institute + Convert.ToString(dt.Rows[0]["Logo"]);
                        this.ModelLogo = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Logo"]))) ? string.Empty : Convert.ToString(dt.Rows[0]["Logo"]);
                        txtUrl.Text = Convert.ToString(dt.Rows[0]["Url"]);
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                        txtSerialNumber.Text = Convert.ToString(dt.Rows[0]["SerialNumber"]);
                        ddlCourse.SelectedValue = Convert.ToString(dt.Rows[0]["CourseId"]);
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to edit.");
            }
        }

        private void GenerateCode()
        {
            try
            {
                QuaintLibraryManager lib = new QuaintLibraryManager();
                ModelCode = CodePrefix.Institute + "-" + lib.GetSixDigitNumber(1);
                InstituteBLL instituteBLL = new InstituteBLL();
                DataTable dt = instituteBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["InstituteCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Institute + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to load.");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Text = string.Empty;
            fuLogo.Attributes.Clear();
            imgLogo.Src = "~/Assets/images/avater-public.png";
            txtUrl.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtSerialNumber.Text = string.Empty;
            ddlCourse.SelectedIndex = 0;

            txtName.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.MultiEntryDisallow = true;
            SaveAndUpdate();
        }

        private void SaveAndUpdate()
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    Alert(AlertType.Warning, "Enter institute name.");
                    txtName.Focus();
                }
                else if (string.IsNullOrEmpty(txtSerialNumber.Text))
                {
                    Alert(AlertType.Warning, "Enter serial number");
                    txtSerialNumber.Focus();
                }
                else if (ddlCourse.SelectedIndex < 1)
                {
                    Alert(AlertType.Warning, "Select course.");
                    ddlCourse.Focus();
                }
                else
                {
                    string name = Convert.ToString(txtName.Text);
                    string url = Convert.ToString(txtUrl.Text);
                    string description = Convert.ToString(txtDescription.Text);
                    int serialNumber = Convert.ToInt32(txtSerialNumber.Text);
                    int courseId = Convert.ToInt32(ddlCourse.SelectedValue);
                    string logo = string.Empty;
                    if (fuLogo.HasFile)
                        logo = UploadLogo();
                    else
                        logo = this.ModelLogo;

                    InstituteBLL instituteBLL = new InstituteBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = instituteBLL.GetById(this.ModelId);
                        Institutes institute = new Institutes();
                        institute.InstituteId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["InstituteId"]));
                        institute.InstituteCode = Convert.ToString(dt.Rows[0]["InstituteCode"]);
                        institute.Name = Convert.ToString(dt.Rows[0]["Name"]);
                        institute.Logo = Convert.ToString(dt.Rows[0]["Logo"]);
                        institute.Url = Convert.ToString(dt.Rows[0]["Url"]);
                        institute.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        institute.SerialNumber = Convert.ToInt32(dt.Rows[0]["SerialNumber"]);
                        institute.Attachment = Convert.ToString(dt.Rows[0]["Attachment"]);
                        institute.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                        institute.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        institute.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        institute.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);
                        institute.CourseId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["CourseId"]));

                        institute.Name = name.Trim();
                        institute.Url = url;
                        institute.SerialNumber = serialNumber;
                        institute.CourseId = courseId;
                        institute.Logo = logo;

                        institute.UpdatedDate = DateTime.Now;
                        institute.UpdatedBy = this.UserInfo;
                        institute.UpdatedFrom = this.StationInfo;

                        if (instituteBLL.Update(institute))
                        {
                            this.MultiEntryDisallow = true;
                            Alert(AlertType.Success, "Updated successfully.");
                            ClearFields();
                        }
                        else
                        {
                            Alert(AlertType.Error, "Failed to update.");
                        }
                    }
                    else
                    {
                        Institutes institute = new Institutes();
                        institute.InstituteCode = this.ModelCode;
                        institute.Name = name;
                        institute.Logo = logo;
                        institute.Url = url;
                        institute.Description = description;
                        institute.SerialNumber = serialNumber;
                        institute.Attachment = string.Empty;
                        institute.CourseId = courseId;
                        institute.IsActive = true;
                        institute.CreatedDate = DateTime.Now;
                        institute.CreatedBy = this.UserInfo;
                        institute.CreatedFrom = this.StationInfo;

                        if (instituteBLL.Save(institute))
                        {
                            Alert(AlertType.Success, "Saved successfully.");
                            ClearFields();
                            GenerateCode();
                        }
                        else
                        {
                            Alert(AlertType.Error, "Failed to save.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alert(AlertType.Error, ex.Message.ToString());
            }
        }

        private string UploadLogo()
        {
            try
            {
                if (fuLogo.HasFile)
                {
                    string filExtention = Path.GetExtension(fuLogo.FileName).ToLower();
                    this.ModelLogo = this.ModelCode + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + filExtention;

                    if (filExtention == ".jpg" || filExtention == ".jpeg" || filExtention == ".png" || filExtention == ".gif")
                    {
                        fuLogo.SaveAs(Server.MapPath(FilePath.Institute + this.ModelLogo));
                    }
                }

                return this.ModelLogo;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            this.MultiEntryDisallow = false;
            SaveAndUpdate();
        }
    }
}