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

namespace QuaintSAMS.Account
{
    public partial class Country : System.Web.UI.Page
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
                    Response.Redirect("~/Account/CountryList.aspx");
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
                CountryBLL countryBLL = new CountryBLL();
                DataTable dt = countryBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["CountryId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["CountryCode"]);
                        txtName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                        txtCountryCodeAlpha2.Text = Convert.ToString(dt.Rows[0]["CountryCodeAlpha2"]);
                        txtCountryCodeAlpha3.Text = Convert.ToString(dt.Rows[0]["CountryCodeAlpha3"]);
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
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
                this.ModelCode = CodePrefix.Country + "-" + lib.GetSixDigitNumber(1);
                CountryBLL countryBLL = new CountryBLL();
                DataTable dt = countryBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["CountryCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        this.ModelCode = CodePrefix.Country + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtCountryCodeAlpha2.Text = string.Empty;
            txtCountryCodeAlpha3.Text = string.Empty;
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
                    Alert(AlertType.Warning, "Enter country name.");
                    txtName.Focus();
                }
                else
                {
                    string name = Convert.ToString(txtName.Text);
                    string countryCodeAlpha2 = Convert.ToString(txtCountryCodeAlpha2.Text);
                    string countryCodeAlpha3 = Convert.ToString(txtCountryCodeAlpha3.Text);
                    string description = Convert.ToString(txtDescription.Text);

                    CountryBLL countryBLL = new CountryBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = countryBLL.GetById(this.ModelId);
                        Countries country = new Countries();
                        country.CountryId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["CountryId"]));
                        country.CountryCode = Convert.ToString(dt.Rows[0]["CountryCode"]);
                        country.Name = Convert.ToString(dt.Rows[0]["Name"]);
                        country.CountryCodeAlpha2 = Convert.ToString(dt.Rows[0]["CountryCodeAlpha2"]);
                        country.CountryCodeAlpha3 = Convert.ToString(dt.Rows[0]["CountryCodeAlpha3"]);
                        country.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        country.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                        country.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        country.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        country.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                        country.Name = name.Trim();
                        country.CountryCodeAlpha2 = countryCodeAlpha2;
                        country.CountryCodeAlpha3 = countryCodeAlpha3;
                        country.Description = description;

                        country.UpdatedDate = DateTime.Now;
                        country.UpdatedBy = this.UserInfo;
                        country.UpdatedFrom = this.StationInfo;

                        if (countryBLL.Update(country))
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
                        Countries country = new Countries();
                        country.CountryCode = this.ModelCode;
                        country.Name = name.Trim();
                        country.CountryCodeAlpha2 = countryCodeAlpha2;
                        country.CountryCodeAlpha3 = countryCodeAlpha3;
                        country.Description = description;
                        country.IsActive = true;
                        country.CreatedDate = DateTime.Now;
                        country.CreatedBy = this.UserInfo;
                        country.CreatedFrom = this.StationInfo;

                        if (countryBLL.Save(country))
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