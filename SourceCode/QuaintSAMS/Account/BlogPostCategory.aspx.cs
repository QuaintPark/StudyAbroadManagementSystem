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
    public partial class BlogPostCategory : System.Web.UI.Page
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
                    Response.Redirect("~/Account/BlogPostCategoryList.aspx");
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

        private void Edit(int id)
        {
            try
            {
                BlogPostCategoryBLL blogPostCategoryBLL = new BlogPostCategoryBLL();
                DataTable dt = blogPostCategoryBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["BlogPostCategoryId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["BlogPostCategoryCode"]);
                        this.ModelSlag = Convert.ToString(dt.Rows[0]["Slag"]);
                        txtName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
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
                this.ModelCode = CodePrefix.BlogPostCategory + "-" + lib.GetSixDigitNumber(1);
                BlogPostCategoryBLL blogPostCategoryBLL = new BlogPostCategoryBLL();
                DataTable dt = blogPostCategoryBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["BlogPostCategoryCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        this.ModelCode = CodePrefix.BlogPostCategory + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;

            txtName.Focus();
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
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    Alert(AlertType.Warning, "Enter blog post category name.");
                    txtName.Focus();
                }
                else
                {
                    QuaintLibraryManager lib = new QuaintLibraryManager();
                    string name = Convert.ToString(txtName.Text);
                    string slug = lib.ConvertToSlug(name);
                    string description = Convert.ToString(txtDescription.Text);

                    BlogPostCategoryBLL blogPostCategoryBLL = new BlogPostCategoryBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = blogPostCategoryBLL.GetById(this.ModelId);
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

                        blogPostCategory.Name = name.Trim();
                        blogPostCategory.Slag = slug;
                        blogPostCategory.Description = description;

                        blogPostCategory.UpdatedDate = DateTime.Now;
                        blogPostCategory.UpdatedBy = this.UserInfo;
                        blogPostCategory.UpdatedFrom = this.StationInfo;

                        if (blogPostCategoryBLL.Update(blogPostCategory))
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
                        BlogPostCategories blogPostCategory = new BlogPostCategories();
                        blogPostCategory.BlogPostCategoryCode = this.ModelCode;
                        blogPostCategory.Name = name.Trim();
                        blogPostCategory.Slag = slug;
                        blogPostCategory.Description = description;
                        blogPostCategory.IsActive = true;
                        blogPostCategory.CreatedDate = DateTime.Now;
                        blogPostCategory.CreatedBy = this.UserInfo;
                        blogPostCategory.CreatedFrom = this.StationInfo;

                        if (blogPostCategoryBLL.Save(blogPostCategory))
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