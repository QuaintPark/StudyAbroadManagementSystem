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
    public partial class LenderBank : System.Web.UI.Page
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
                    Response.Redirect("~/Account/LenderBankList.aspx");
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
                LoadCountry();

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

        private void LoadCountry()
        {
            try
            {
                CountryBLL countryBLL = new CountryBLL();
                DataTable dt = countryBLL.GetAllActive();
                ddlCountry.DataSource = dt;
                ddlCountry.DataTextField = "Name";
                ddlCountry.DataValueField = "CountryId";
                ddlCountry.DataBind();

                ddlCountry.Items.Insert(0, "--- Please Select ---");
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
                LenderBankBLL lenderBankBLL = new LenderBankBLL();
                DataTable dt = lenderBankBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LenderBankId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["LenderBankCode"]);
                        txtBankName.Text = Convert.ToString(dt.Rows[0]["BankName"]);
                        txtUrl.Text = Convert.ToString(dt.Rows[0]["Url"]);
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                        ddlCountry.SelectedValue = Convert.ToString(dt.Rows[0]["CountryId"]);
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
                this.ModelCode = CodePrefix.Bank + "-" + lib.GetSixDigitNumber(1);
                LenderBankBLL lenderBankBLL = new LenderBankBLL();
                DataTable dt = lenderBankBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["LenderBankCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        this.ModelCode = CodePrefix.Bank + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtBankName.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtDescription.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;

            txtBankName.Focus();
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
                if (string.IsNullOrEmpty(txtBankName.Text))
                {
                    Alert(AlertType.Warning, "Enter bank name.");
                    txtBankName.Focus();
                }
                else if (ddlCountry.SelectedIndex < 1)
                {
                    Alert(AlertType.Warning, "Select country");
                    ddlCountry.Focus();
                }
                else
                {
                    string bankName = Convert.ToString(txtBankName.Text);
                    string url = Convert.ToString(txtUrl.Text);
                    string description = Convert.ToString(txtDescription.Text);
                    int countryId = Convert.ToInt32(Convert.ToString(ddlCountry.SelectedValue));

                    LenderBankBLL lenderBankBLL = new LenderBankBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = lenderBankBLL.GetById(this.ModelId);
                        LenderBanks lenderBank = new LenderBanks();
                        lenderBank.LenderBankId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LenderBankId"]));
                        lenderBank.LenderBankCode = Convert.ToString(dt.Rows[0]["LenderBankCode"]);
                        lenderBank.BankName = Convert.ToString(dt.Rows[0]["BankName"]);
                        lenderBank.Url = Convert.ToString(dt.Rows[0]["Url"]);
                        lenderBank.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        lenderBank.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                        lenderBank.CountryId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["CountryId"]));
                        lenderBank.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        lenderBank.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        lenderBank.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                        lenderBank.BankName = bankName.Trim();
                        lenderBank.Url = url;
                        lenderBank.Description = description;
                        lenderBank.CountryId = countryId;

                        lenderBank.UpdatedDate = DateTime.Now;
                        lenderBank.UpdatedBy = this.UserInfo;
                        lenderBank.UpdatedFrom = this.StationInfo;

                        if (lenderBankBLL.Update(lenderBank))
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
                        LenderBanks lenderBank = new LenderBanks();
                        lenderBank.LenderBankCode = this.ModelCode;
                        lenderBank.BankName = bankName.Trim();
                        lenderBank.Url = url;
                        lenderBank.Description = description;
                        lenderBank.CountryId = countryId;
                        lenderBank.IsActive = true;
                        lenderBank.CreatedDate = DateTime.Now;
                        lenderBank.CreatedBy = this.UserInfo;
                        lenderBank.CreatedFrom = this.StationInfo;

                        if (lenderBankBLL.Save(lenderBank))
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