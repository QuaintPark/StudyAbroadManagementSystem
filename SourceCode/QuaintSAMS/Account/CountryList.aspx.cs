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
    public partial class CountryList : System.Web.UI.Page
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



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);

                LoadList();
            }
        }

        private void LoadList()
        {
            try
            {
                CountryBLL countryBLL = new CountryBLL();
                DataTable dt = countryBLL.GetAll();
                rptrList.DataSource = dt;
                rptrList.DataBind();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void btnActiveOrDeactive_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string id = Convert.ToString(e.CommandArgument);
                if (!string.IsNullOrEmpty(id))
                {
                    CountryBLL countryBLL = new CountryBLL();
                    DataTable dt = countryBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
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

                            country.UpdatedDate = DateTime.Now;
                            country.UpdatedBy = UserInfo;
                            country.UpdatedFrom = StationInfo;

                            if (country.IsActive)
                            {
                                country.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                country.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (countryBLL.Update(country))
                            {
                                Alert(AlertType.Success, actionStatus + " successfully.");
                                LoadList();
                            }
                            else
                            {
                                Alert(AlertType.Error, "Failed to update.");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to process.");
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string id = Convert.ToString(e.CommandArgument);
                if (!string.IsNullOrEmpty(id))
                {
                    CountryBLL countryBLL = new CountryBLL();
                    Countries country = new Countries();
                    country.CountryId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (country.CountryId > 0)
                    {
                        if (countryBLL.Delete(country))
                        {
                            Alert(AlertType.Success, "Deleted successfully.");
                            LoadList();
                        }
                        else
                        {
                            Alert(AlertType.Error, "Failed to delete.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to delete.");
            }
        }
    }
}