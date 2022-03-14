using QuaintSAMS.Code.BLL;
using QuaintSAMS.Code.Global;
using QuaintSAMS.Code.Model;
using QuaintPark;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace QuaintSAMS.Account
{
    public partial class Course : System.Web.UI.Page
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
                    Response.Redirect("~/Account/CourseList.aspx");
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
        private string ModelAttachment
        {
            set { ViewState["Attachment"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["Attachment"]);
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
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);

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

        private void Edit(int id)
        {
            try
            {
                CourseBLL courseBLL = new CourseBLL();
                DataTable dt = courseBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["CourseId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["CourseCode"]);
                        txtName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                        this.ModelAttachment = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Attachment"]))) ? string.Empty : Convert.ToString(dt.Rows[0]["Attachment"]);
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
                this.ModelCode = CodePrefix.Course + "-" + lib.GetSixDigitNumber(1);
                CourseBLL courseBLL = new CourseBLL();
                DataTable dt = courseBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["CourseCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        this.ModelCode = CodePrefix.Course + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtDescription.Text = string.Empty;

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
                    Alert(AlertType.Warning, "Enter course name.");
                    txtName.Focus();
                }
                else
                {
                    string name = Convert.ToString(txtName.Text);
                    string description = Convert.ToString(txtDescription.Text);
                    string attachment = string.Empty;
                    if (fuAttachment.HasFile)
                        attachment = UploadAttachment();
                    else
                        attachment = this.ModelAttachment;

                    CourseBLL courseBLL = new CourseBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = courseBLL.GetById(this.ModelId);
                        Courses course = new Courses();
                        course.CourseId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["CourseId"]));
                        course.CourseCode = Convert.ToString(dt.Rows[0]["CourseCode"]);
                        course.Name = Convert.ToString(dt.Rows[0]["Name"]);
                        course.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        course.Attachment = Convert.ToString(dt.Rows[0]["Attachment"]);
                        course.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                        course.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        course.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        course.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                        course.Name = name.Trim();
                        course.Description = description;
                        course.Attachment = attachment;

                        course.UpdatedDate = DateTime.Now;
                        course.UpdatedBy = this.UserInfo;
                        course.UpdatedFrom = this.StationInfo;

                        if (courseBLL.Update(course))
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
                        Courses course = new Courses();
                        course.CourseCode = this.ModelCode;
                        course.Name = name.Trim();
                        course.Description = description;
                        course.Attachment = attachment;
                        course.IsActive = true;
                        course.CreatedDate = DateTime.Now;
                        course.CreatedBy = this.UserInfo;
                        course.CreatedFrom = this.StationInfo;

                        if (courseBLL.Save(course))
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

        private string UploadAttachment()
        {
            try
            {
                if (fuAttachment.HasFile)
                {
                    string filExtention = Path.GetExtension(fuAttachment.FileName).ToLower();
                    this.ModelAttachment = this.ModelCode + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + filExtention;

                    if (filExtention == ".jpg" 
                        || filExtention == ".jpeg"
                        || filExtention == ".png"
                        || filExtention == ".gif"
                        || filExtention == ".pdf"
                        || filExtention == ".doc"
                        || filExtention == ".docx"
                        || filExtention == ".ppt"
                        || filExtention == ".pptx"
                        || filExtention == ".xls"
                        || filExtention == ".xlsx")
                    {
                        fuAttachment.SaveAs(Server.MapPath(FilePath.CourseMaterial + this.ModelAttachment));
                    }
                }

                return this.ModelAttachment;
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