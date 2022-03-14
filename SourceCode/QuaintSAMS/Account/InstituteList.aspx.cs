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
    public partial class InstituteList : System.Web.UI.Page
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
                InstituteBLL instituteBLL = new InstituteBLL();
                DataTable dt = instituteBLL.GetAll();
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
                    InstituteBLL instituteBLL = new InstituteBLL();
                    DataTable dt = instituteBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
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

                            institute.UpdatedDate = DateTime.Now;
                            institute.UpdatedBy = UserInfo;
                            institute.UpdatedFrom = StationInfo;

                            if (institute.IsActive)
                            {
                                institute.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                institute.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (instituteBLL.Update(institute))
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
                    InstituteBLL instituteBLL = new InstituteBLL();
                    Institutes institute = new Institutes();
                    institute.InstituteId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (institute.InstituteId > 0)
                    {
                        if (instituteBLL.Delete(institute))
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