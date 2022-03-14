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
    public partial class BlogPostList : System.Web.UI.Page
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
                BlogPostBLL blogPostBLL = new BlogPostBLL();
                DataTable dt = blogPostBLL.GetAll();
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
                    BlogPostBLL blogPostBLL = new BlogPostBLL();
                    DataTable dt = blogPostBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
                            BlogPosts blogPost = new BlogPosts();
                            blogPost.BlogPostId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BlogPostId"]));
                            blogPost.BlogPostCode = Convert.ToString(dt.Rows[0]["BlogPostCode"]);
                            blogPost.Title = Convert.ToString(dt.Rows[0]["Title"]);
                            blogPost.Slag = Convert.ToString(dt.Rows[0]["Slag"]);
                            blogPost.Description = Convert.ToString(dt.Rows[0]["Description"]);
                            blogPost.PublishedDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["PublishedDate"]));
                            blogPost.Attachment = Convert.ToString(dt.Rows[0]["Attachment"]);
                            blogPost.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            blogPost.BlogPostCategoryId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BlogPostCategoryId"]));
                            blogPost.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            blogPost.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            blogPost.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                            blogPost.UpdatedDate = DateTime.Now;
                            blogPost.UpdatedBy = UserInfo;
                            blogPost.UpdatedFrom = StationInfo;

                            if (blogPost.IsActive)
                            {
                                blogPost.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                blogPost.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (blogPostBLL.Update(blogPost))
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
                    BlogPostBLL blogPostBLL = new BlogPostBLL();
                    BlogPosts blogPost = new BlogPosts();
                    blogPost.BlogPostId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (blogPost.BlogPostId > 0)
                    {
                        if (blogPostBLL.Delete(blogPost))
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