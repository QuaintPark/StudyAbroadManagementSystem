using QuaintPark;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.DAL
{
    public class BlogPostCategoryDAL
    {
        public bool Save(BlogPostCategories blogPostCategory)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("BlogPostCategoryCode", blogPostCategory.BlogPostCategoryCode);
                db.AddParameters("Name", blogPostCategory.Name);
                db.AddParameters("Slag", blogPostCategory.Slag);
                db.AddParameters("Description", blogPostCategory.Description);
                db.AddParameters("IsActive", blogPostCategory.IsActive);
                db.AddParameters("CreatedDate", ((blogPostCategory.CreatedDate == null) ? blogPostCategory.CreatedDate : blogPostCategory.CreatedDate.Value));
                db.AddParameters("CreatedBy", blogPostCategory.CreatedBy);
                db.AddParameters("CreatedFrom", blogPostCategory.CreatedFrom);
                db.AddParameters("UpdatedDate", ((blogPostCategory.UpdatedDate == null) ? blogPostCategory.UpdatedDate : blogPostCategory.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", blogPostCategory.UpdatedBy);
                db.AddParameters("UpdatedFrom", blogPostCategory.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_BlogPostCategory", true);

                if (affectedRows > 0)
                    flag = true;

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public DataTable GetAll()
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                DataTable dt = db.ExecuteDataTable("Get_All_BlogPostCategory", false);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public DataTable GetById(int id)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                db.AddParameters("BlogPostCategoryId", id);
                DataTable dt = db.ExecuteDataTable("Get_BlogPostCategory_By_Id", true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public bool Update(BlogPostCategories blogPostCategory)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("BlogPostCategoryId", blogPostCategory.BlogPostCategoryId);
                db.AddParameters("BlogPostCategoryCode", blogPostCategory.BlogPostCategoryCode);
                db.AddParameters("Name", blogPostCategory.Name);
                db.AddParameters("Slag", blogPostCategory.Slag);
                db.AddParameters("Description", blogPostCategory.Description);
                db.AddParameters("IsActive", blogPostCategory.IsActive);
                db.AddParameters("CreatedDate", ((blogPostCategory.CreatedDate == null) ? blogPostCategory.CreatedDate : blogPostCategory.CreatedDate.Value));
                db.AddParameters("CreatedBy", blogPostCategory.CreatedBy);
                db.AddParameters("CreatedFrom", blogPostCategory.CreatedFrom);
                db.AddParameters("UpdatedDate", ((blogPostCategory.UpdatedDate == null) ? blogPostCategory.UpdatedDate : blogPostCategory.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", blogPostCategory.UpdatedBy);
                db.AddParameters("UpdatedFrom", blogPostCategory.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_BlogPostCategory", true);

                if (affectedRows > 0)
                    flag = true;

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public bool Delete(BlogPostCategories blogPostCategory)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("BlogPostCategoryId", blogPostCategory.BlogPostCategoryId);
                int affectedRows = db.ExecuteNonQuery("Delete_BlogPostCategory", true);

                if (affectedRows > 0)
                    flag = true;

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }
    }
}