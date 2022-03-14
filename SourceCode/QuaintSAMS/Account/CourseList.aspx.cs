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
    public partial class CourseList : System.Web.UI.Page
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
                CourseBLL courseBLL = new CourseBLL();
                DataTable dt = courseBLL.GetAll();
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
                    CourseBLL courseBLL = new CourseBLL();
                    DataTable dt = courseBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
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

                            course.UpdatedDate = DateTime.Now;
                            course.UpdatedBy = UserInfo;
                            course.UpdatedFrom = StationInfo;

                            if (course.IsActive)
                            {
                                course.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                course.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (courseBLL.Update(course))
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
                    CourseBLL courseBLL = new CourseBLL();
                    Courses course = new Courses();
                    course.CourseId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (course.CourseId > 0)
                    {
                        if (courseBLL.Delete(course))
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