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
using System.IO;

namespace QuaintSAMS.Account
{
    public partial class BlogPost : System.Web.UI.Page
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
                    Response.Redirect("~/Account/BlogPostList.aspx");
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
        private string ModelAttachment
        {
            set { ViewState["Attachment"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["Attachment"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        private string ModelSlag
        {
            set { ViewState["Slag"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["Slag"]);
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
                MultiEntryDisallow = false;
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);
                LoadBlogPostCategory();

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

        private void LoadBlogPostCategory()
        {
            try
            {
                BlogPostCategoryBLL blogPostCategoryBLL = new BlogPostCategoryBLL();
                DataTable dt = blogPostCategoryBLL.GetAll();
                ddlBlogPostCategory.DataSource = dt;
                ddlBlogPostCategory.DataTextField = "Name";
                ddlBlogPostCategory.DataValueField = "BlogPostCategoryId";
                ddlBlogPostCategory.DataBind();

                ddlBlogPostCategory.Items.Insert(0, "--- Please Select ---");
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
                BlogPostBLL blogPostBLL = new BlogPostBLL();
                DataTable dt = blogPostBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BlogPostId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["BlogPostCode"]);
                        txtTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                        this.ModelSlag = Convert.ToString(dt.Rows[0]["Slag"]);
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                        txtPublishedDate.Text = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["PublishedDate"])).ToString("MM/dd/yyyy");
                        this.ModelAttachment = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Attachment"]))) ? string.Empty : Convert.ToString(dt.Rows[0]["Attachment"]);
                        ddlBlogPostCategory.SelectedValue = Convert.ToString(dt.Rows[0]["BlogPostCategoryId"]);
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
                this.ModelCode = CodePrefix.BlogPost + "-" + lib.GetSixDigitNumber(1);
                BlogPostBLL blogPostBLL = new BlogPostBLL();
                DataTable dt = blogPostBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["BlogPostCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        this.ModelCode = CodePrefix.BlogPost + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtTitle.Text = string.Empty;
            ddlBlogPostCategory.SelectedIndex = 0;
            txtPublishedDate.Text = string.Empty;
            txtDescription.Text = string.Empty;

            txtTitle.Focus();
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
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    Alert(AlertType.Warning, "Enter title.");
                    txtTitle.Focus();
                }
                else if (ddlBlogPostCategory.SelectedIndex < 1)
                {
                    Alert(AlertType.Warning, "Select blog post category.");
                    ddlBlogPostCategory.Focus();
                }
                else if (string.IsNullOrEmpty(txtPublishedDate.Text))
                {
                    Alert(AlertType.Warning, "Select published date.");
                    txtPublishedDate.Focus();
                }
                else
                {
                    QuaintLibraryManager lib = new QuaintLibraryManager();
                    string title = Convert.ToString(txtTitle.Text);
                    string slag = lib.ConvertToSlug(title);
                    int blogPostCategoryId = Convert.ToInt32(ddlBlogPostCategory.SelectedValue);
                    DateTime publishedDate = Convert.ToDateTime(txtPublishedDate.Text);
                    string description = Convert.ToString(txtDescription.Text);
                    string attachment = string.Empty;
                    if (fuAttachment.HasFile)
                    {
                        attachment = UploadAttachment();
                    }
                    else
                    {
                        attachment = this.ModelAttachment;
                    }

                    BlogPostBLL blogPostBLL = new BlogPostBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = blogPostBLL.GetById(this.ModelId);
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

                        blogPost.Title = title.Trim();
                        blogPost.Slag = slag;
                        blogPost.Description = description;
                        blogPost.PublishedDate = publishedDate;
                        blogPost.Attachment = attachment;
                        blogPost.BlogPostCategoryId = blogPostCategoryId;

                        blogPost.UpdatedDate = DateTime.Now;
                        blogPost.UpdatedBy = this.UserInfo;
                        blogPost.UpdatedFrom = this.StationInfo;

                        if (blogPostBLL.Update(blogPost))
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
                        BlogPosts blogPost = new BlogPosts();
                        blogPost.BlogPostCode = this.ModelCode;
                        blogPost.Title = title;
                        blogPost.Slag = slag;
                        blogPost.BlogPostCategoryId = blogPostCategoryId;
                        blogPost.Attachment = attachment;
                        blogPost.PublishedDate = publishedDate;
                        blogPost.Description = description;
                        blogPost.IsActive = true;
                        blogPost.CreatedDate = DateTime.Now;
                        blogPost.CreatedBy = this.UserInfo;
                        blogPost.CreatedFrom = this.StationInfo;

                        if (blogPostBLL.Save(blogPost))
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

        private string UploadAttachment()
        {
            try
            {
                if (fuAttachment.HasFile)
                {
                    string filExtention = Path.GetExtension(fuAttachment.FileName).ToLower();
                    this.ModelAttachment = this.ModelCode + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + filExtention;

                    if (filExtention == ".jpg"
                        || filExtention == ".jpeg"
                        || filExtention == ".png"
                        || filExtention == ".gif"
                        || filExtention == ".pdf"
                        || filExtention == ".doc"
                        || filExtention == ".docx"
                        || filExtention == ".ppt"
                        || filExtention == ".pptx"
                        || filExtention == ".xls"
                        || filExtention == ".xlsx")
                    {
                        fuAttachment.SaveAs(Server.MapPath(FilePath.BlogPost + this.ModelAttachment));
                    }
                }

                return this.ModelAttachment;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            this.MultiEntryDisallow = false;
            SaveAndUpdate();
        }
    }
}