using QuaintPark;
using QuaintSAMS.Code.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintSAMS.Pages
{
    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBlogPostCategories();

                if (Request.QueryString["Slug"] != null)
                {
                    string slug = Convert.ToString(Request.QueryString["Slug"]);
                    LoadData(slug);

                    QuaintSessionManager session = new QuaintSessionManager();
                    if (session.HasSession)
                    {
                        attachmentDownload.Visible = true;
                        attachmentView.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("~/Pages/Blog.aspx");
                }
            }
        }

        private void LoadBlogPostCategories()
        {
            try
            {
                BlogPostCategoryBLL blogPostCategoryBLL = new BlogPostCategoryBLL();
                DataTable dt = blogPostCategoryBLL.GetAllActive();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        rptrBlogPostCategory.DataSource = dt;
                        rptrBlogPostCategory.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void LoadData(string slug)
        {
            try
            {
                BlogPostBLL blogPostBLL = new BlogPostBLL();
                DataTable dt = blogPostBLL.GetByBlogPostSlug(slug);

                txtTitle.InnerText = Convert.ToString(dt.Rows[0]["Title"]);
                txtPublishedDate.Text = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["PublishedDate"])).ToString("dd MMMM yyyy");
                txtBlogPostCategoryName.Text = Convert.ToString(dt.Rows[0]["BlogPostCategoryName"]);
                txtDescription.InnerHtml = Convert.ToString(dt.Rows[0]["Description"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Attachment"])))
                {
                    string currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                    string redirectUrl = "~/Login.aspx?Ref=member&Redirect=" + QuaintSecurityManager.EncryptUrl(currentUrl);
                    lnkLogin.NavigateUrl = redirectUrl;
                    txtAttachmentView.Text = Convert.ToString(dt.Rows[0]["Title"]);
                    
                    txtAttachment.Text = Convert.ToString(dt.Rows[0]["Title"]);
                    lnkDownload.CommandArgument = QuaintSAMS.Code.Global.FilePath.BlogPost + Convert.ToString(dt.Rows[0]["Attachment"]);

                    attachmentDownload.Visible = false;
                    attachmentView.Visible = true;
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            try
            {
                string filePath = (sender as LinkButton).CommandArgument;
                if (File.Exists(Server.MapPath(filePath)))
                {
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                //else
                //    Response.Write("<script>alert('Failed to download the content.')</script>");
            }
            catch (Exception)
            {

            }
        }
    }
}