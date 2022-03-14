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
    public partial class LenderBankList : System.Web.UI.Page
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
                LenderBankBLL lenderBankBLL = new LenderBankBLL();
                DataTable dt = lenderBankBLL.GetAll();
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
                    LenderBankBLL lenderBankBLL = new LenderBankBLL();
                    DataTable dt = lenderBankBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
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

                            lenderBank.UpdatedDate = DateTime.Now;
                            lenderBank.UpdatedBy = UserInfo;
                            lenderBank.UpdatedFrom = StationInfo;

                            if (lenderBank.IsActive)
                            {
                                lenderBank.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                lenderBank.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (lenderBankBLL.Update(lenderBank))
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
                    LenderBankBLL lenderBankBLL = new LenderBankBLL();
                    LenderBanks lenderBank = new LenderBanks();
                    lenderBank.LenderBankId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (lenderBank.LenderBankId > 0)
                    {
                        if (lenderBankBLL.Delete(lenderBank))
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