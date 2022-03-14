using QuaintSAMS.Code.DAL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.BLL
{
    public class BlogPostCategoryBLL
    {
        public bool Save(BlogPostCategories blogPostCategory)
        {
            try
            {
                BlogPostCategoryDAL blogPostCategoryDAL = new BlogPostCategoryDAL();

                if (IsNameExist(blogPostCategory))
                {
                    throw new Exception("Name already exist.");
                }
                else
                {
                    return blogPostCategoryDAL.Save(blogPostCategory);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsNameExist(BlogPostCategories blogPostCategory)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Name"]).ToString() == blogPostCategory.Name);
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
                BlogPostCategoryDAL blogPostCategoryDAL = new BlogPostCategoryDAL();
                return blogPostCategoryDAL.GetAll();
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

        public DataTable GetById(int id)
        {
            try
            {
                BlogPostCategoryDAL blogPostCategoryDAL = new BlogPostCategoryDAL();
                return blogPostCategoryDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetBySlug(string slug)
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

        public bool Update(BlogPostCategories blogPostCategory)
        {
            try
            {
                BlogPostCategoryDAL blogPostCategoryDAL = new BlogPostCategoryDAL();
                return blogPostCategoryDAL.Update(blogPostCategory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(BlogPostCategories blogPostCategory)
        {
            try
            {
                BlogPostCategoryDAL blogPostCategoryDAL = new BlogPostCategoryDAL();
                return blogPostCategoryDAL.Delete(blogPostCategory);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}