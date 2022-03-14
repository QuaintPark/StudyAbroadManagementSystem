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
    public partial class TutorialList : System.Web.UI.Page
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
                TutorialBLL tutorialBLL = new TutorialBLL();
                DataTable dt = tutorialBLL.GetAll();
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
                    TutorialBLL tutorialBLL = new TutorialBLL();
                    DataTable dt = tutorialBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
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

                            tutorial.UpdatedDate = DateTime.Now;
                            tutorial.UpdatedBy = UserInfo;
                            tutorial.UpdatedFrom = StationInfo;

                            if (tutorial.IsActive)
                            {
                                tutorial.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                tutorial.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (tutorialBLL.Update(tutorial))
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
                    TutorialBLL tutorialBLL = new TutorialBLL();
                    Tutorials tutorial = new Tutorials();
                    tutorial.TutorialId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (tutorial.TutorialId > 0)
                    {
                        if (tutorialBLL.Delete(tutorial))
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