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
    public partial class BlogPostCategoryList : System.Web.UI.Page
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
                BlogPostCategoryBLL blogPostCategoryBLL = new BlogPostCategoryBLL();
                DataTable dt = blogPostCategoryBLL.GetAll();
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
                    BlogPostCategoryBLL blogPostCategoryBLL = new BlogPostCategoryBLL();
                    DataTable dt = blogPostCategoryBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
                            BlogPostCategories blogPostCategory = new BlogPostCategories();
                            blogPostCategory.BlogPostCategoryId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BlogPostCategoryId"]));
                            blogPostCategory.BlogPostCategoryCode = Convert.ToString(dt.Rows[0]["BlogPostCategoryCode"]);
                            blogPostCategory.Name = Convert.ToString(dt.Rows[0]["Name"]);
                            blogPostCategory.Slag = Convert.ToString(dt.Rows[0]["Slag"]);
                            blogPostCategory.Description = Convert.ToString(dt.Rows[0]["Description"]);
                            blogPostCategory.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            blogPostCategory.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            blogPostCategory.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            blogPostCategory.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                            blogPostCategory.UpdatedDate = DateTime.Now;
                            blogPostCategory.UpdatedBy = UserInfo;
                            blogPostCategory.UpdatedFrom = StationInfo;

                            if (blogPostCategory.IsActive)
                            {
                                blogPostCategory.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                blogPostCategory.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (blogPostCategoryBLL.Update(blogPostCategory))
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
                    BlogPostCategoryBLL blogPostCategoryBLL = new BlogPostCategoryBLL();
                    BlogPostCategories blogPostCategory = new BlogPostCategories();
                    blogPostCategory.BlogPostCategoryId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (blogPostCategory.BlogPostCategoryId > 0)
                    {
                        if (blogPostCategoryBLL.Delete(blogPostCategory))
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