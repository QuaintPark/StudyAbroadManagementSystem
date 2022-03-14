using QuaintPark;
using QuaintSAMS.Code.BLL;
using QuaintSAMS.Code.Global;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintSAMS.Account
{
    public partial class Tutorial : System.Web.UI.Page
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
                    Response.Redirect("~/Account/TutorialList.aspx");
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
                TutorialBLL tutorialBLL = new TutorialBLL();
                DataTable dt = tutorialBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["TutorialId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["TutorialCode"]);
                        txtTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                        txtExternalUrl.Text = Convert.ToString(dt.Rows[0]["ExternalUrl"]);
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
                this.ModelCode = CodePrefix.Tutorial + "-" + lib.GetSixDigitNumber(1);
                TutorialBLL tutorilBLL = new TutorialBLL();
                DataTable dt = tutorilBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["TutorialCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        this.ModelCode = CodePrefix.Tutorial + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtExternalUrl.Text = string.Empty;

            txtTitle.Focus();
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
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    Alert(AlertType.Warning, "Enter title.");
                    txtTitle.Focus();
                }
                else if (string.IsNullOrEmpty(txtExternalUrl.Text))
                {
                    Alert(AlertType.Warning, "Enter YouTube link.");
                    txtExternalUrl.Focus();
                }
                
                else
                {
                    QuaintLibraryManager lib = new QuaintLibraryManager();
                    string title = Convert.ToString(txtTitle.Text);
                    string slug = lib.ConvertToSlug(title);
                    string description = Convert.ToString(txtDescription.Text);
                    string externalUrl = Convert.ToString(txtExternalUrl.Text);
                    int playListId = 0;

                    TutorialBLL tutorialBLL = new TutorialBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = tutorialBLL.GetById(this.ModelId);
                        Tutorials tutorial = new Tutorials();
                        tutorial.TutorialId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["TutorialId"]));
                        tutorial.TutorialCode = Convert.ToString(dt.Rows[0]["TutorialCode"]);
                        tutorial.Title = Convert.ToString(dt.Rows[0]["Title"]);
                        tutorial.Slug = Convert.ToString(dt.Rows[0]["Slug"]);
                        tutorial.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        tutorial.ExternalUrl = Convert.ToString(dt.Rows[0]["ExternalUrl"]);
                        tutorial.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                        tutorial.PlayListId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["PlayListId"]));
                        tutorial.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        tutorial.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        tutorial.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                        tutorial.Title = title.Trim();
                        tutorial.Slug = slug;
                        tutorial.Description = description;
                        tutorial.ExternalUrl = externalUrl;
                        tutorial.PlayListId = playListId;

                        tutorial.UpdatedDate = DateTime.Now;
                        tutorial.UpdatedBy = this.UserInfo;
                        tutorial.UpdatedFrom = this.StationInfo;

                        if (tutorialBLL.Update(tutorial))
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
                        Tutorials tutorial = new Tutorials();
                        tutorial.TutorialCode = this.ModelCode;
                        tutorial.Title = title.Trim();
                        tutorial.Slug = slug;
                        tutorial.Description = description;
                        tutorial.ExternalUrl = externalUrl;
                        tutorial.IsActive = true;
                        tutorial.PlayListId = playListId;
                        tutorial.CreatedDate = DateTime.Now;
                        tutorial.CreatedBy = this.UserInfo;
                        tutorial.CreatedFrom = this.StationInfo;

                        if (tutorialBLL.Save(tutorial))
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

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            this.MultiEntryDisallow = false;
            SaveAndUpdate();
        }
    }
}