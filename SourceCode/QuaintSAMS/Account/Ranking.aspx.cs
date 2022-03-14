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
    public partial class Ranking : System.Web.UI.Page
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
                    Response.Redirect("~/Account/RankingList.aspx");
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
                RankingBLL rankingBLL = new RankingBLL();
                DataTable dt = rankingBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["RankingId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["RankingCode"]);
                        txtUniversityName.Text = Convert.ToString(dt.Rows[0]["UniversityName"]);
                        txtRank.Text = Convert.ToString(dt.Rows[0]["Rank"]);
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
                this.ModelCode = CodePrefix.Ranking + "-" + lib.GetSixDigitNumber(1);
                RankingBLL rankingBLL = new RankingBLL();
                DataTable dt = rankingBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["RankingCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        this.ModelCode = CodePrefix.Ranking + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtUniversityName.Text = string.Empty;
            txtRank.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtDescription.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;

            txtUniversityName.Focus();
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
                if (string.IsNullOrEmpty(txtUniversityName.Text))
                {
                    Alert(AlertType.Warning, "Enter bank name.");
                    txtUniversityName.Focus();
                }
                else if (string.IsNullOrEmpty(txtRank.Text))
                {
                    Alert(AlertType.Warning, "Enter rank.");
                    txtRank.Focus();
                }
                else if (ddlCountry.SelectedIndex < 1)
                {
                    Alert(AlertType.Warning, "Select country");
                    ddlCountry.Focus();
                }
                else
                {
                    string universityName = Convert.ToString(txtUniversityName.Text);
                    int rank = Convert.ToInt32(Convert.ToString(txtRank.Text));
                    string url = Convert.ToString(txtUrl.Text);
                    string description = Convert.ToString(txtDescription.Text);
                    int countryId = Convert.ToInt32(Convert.ToString(ddlCountry.SelectedValue));

                    RankingBLL rankingBLL = new RankingBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = rankingBLL.GetById(this.ModelId);
                        Rankings ranking = new Rankings();
                        ranking.RankingId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["RankingId"]));
                        ranking.RankingCode = Convert.ToString(dt.Rows[0]["RankingCode"]);
                        ranking.UniversityName = Convert.ToString(dt.Rows[0]["UniversityName"]);
                        ranking.Rank = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Rank"]));
                        ranking.Url = Convert.ToString(dt.Rows[0]["Url"]);
                        ranking.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        ranking.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                        ranking.CountryId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["CountryId"]));
                        ranking.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        ranking.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        ranking.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                        ranking.UniversityName = universityName.Trim();
                        ranking.Rank = rank;
                        ranking.Url = url;
                        ranking.Description = description;
                        ranking.CountryId = countryId;

                        ranking.UpdatedDate = DateTime.Now;
                        ranking.UpdatedBy = this.UserInfo;
                        ranking.UpdatedFrom = this.StationInfo;

                        if (rankingBLL.Update(ranking))
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
                        Rankings ranking = new Rankings();
                        ranking.RankingCode = this.ModelCode;
                        ranking.UniversityName = universityName.Trim();
                        ranking.Rank = rank;
                        ranking.Url = url;
                        ranking.Description = description;
                        ranking.CountryId = countryId;
                        ranking.IsActive = true;
                        ranking.CreatedDate = DateTime.Now;
                        ranking.CreatedBy = this.UserInfo;
                        ranking.CreatedFrom = this.StationInfo;

                        if (rankingBLL.Save(ranking))
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