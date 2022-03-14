using QuaintSAMS.Code.BLL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintSAMS.Pages
{
    public partial class Blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBlogPostCategories();

                if (Request.QueryString["Slug"] != null)
                {
                    LoadBlogPost(Convert.ToString(Request.QueryString["Slug"]));
                }
                else
                {
                    LoadBlogPost();
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

        private void LoadBlogPost()
        {
            try
            {
                BlogPostBLL blogPostBLL = new BlogPostBLL();
                DataTable dt = blogPostBLL.GetAllActive();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        rptrPost.DataSource = dt;
                        rptrPost.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void LoadBlogPost(string slug)
        {
            try
            {
                BlogPostBLL blogPostBLL = new BlogPostBLL();
                DataTable dt = blogPostBLL.GetByBlogPostCategorySlug(slug);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        rptrPost.DataSource = dt;
                        rptrPost.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}