using QuaintSAMS.Code.DAL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.BLL
{
    public class BlogPostBLL
    {
        public bool Save(BlogPosts blogPost)
        {
            try
            {
                BlogPostDAL blogPostDAL = new BlogPostDAL();

                if (IsTitleExist(blogPost))
                {
                    throw new Exception("Title already exist.");
                }
                else
                {
                    return blogPostDAL.Save(blogPost);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsTitleExist(BlogPosts blogPost)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Title"]).ToString() == blogPost.Title);
                DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

                if (dt != null)
                    if (dt.Rows.Count > 0)
                        return true;
                    else
                        return false;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAll()
        {
            try
            {
                BlogPostDAL blogPostDAL = new BlogPostDAL();
                return blogPostDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetAllActive()
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true);
                DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

                if (dt != null)
                    if (dt.Rows.Count > 0)
                        return dt;
                    else
                        return null;
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetFromLastActive(int item)
        {
            try
            {
                if (item > 0)
                {
                    DataTable dtList = GetAll();
                    var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true).Take(item);
                    DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

                    if (dt != null)
                        if (dt.Rows.Count > 0)
                            return dt;
                        else
                            return null;
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetById(int id)
        {
            try
            {
                BlogPostDAL blogPostDAL = new BlogPostDAL();
                return blogPostDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetByBlogPostSlug(string slug)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true && ((string)x["Slag"]) == slug);
                DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

                if (dt != null)
                    if (dt.Rows.Count > 0)
                        return dt;
                    else
                        return null;
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetByBlogPostCategorySlug(string slug)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true && ((string)x["BlogPostCategorySlag"]) == slug);
                DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

                if (dt != null)
                    if (dt.Rows.Count > 0)
                        return dt;
                    else
                        return null;
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(BlogPosts blogPost)
        {
            try
            {
                BlogPostDAL blogPostDAL = new BlogPostDAL();
                return blogPostDAL.Update(blogPost);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(BlogPosts blogPost)
        {
            try
            {
                BlogPostDAL blogPostDAL = new BlogPostDAL();
                return blogPostDAL.Delete(blogPost);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}