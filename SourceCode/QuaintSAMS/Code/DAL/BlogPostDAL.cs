using QuaintPark;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.DAL
{
    public class BlogPostDAL
    {
        public bool Save(BlogPosts blogPost)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("BlogPostCode", blogPost.BlogPostCode);
                db.AddParameters("Title", blogPost.Title);
                db.AddParameters("Slag", blogPost.Slag);
                db.AddParameters("Description", blogPost.Description);
                db.AddParameters("PublishedDate", blogPost.PublishedDate);
                db.AddParameters("Attachment", blogPost.Attachment);
                db.AddParameters("IsActive", blogPost.IsActive);
                db.AddParameters("CreatedDate", ((blogPost.CreatedDate == null) ? blogPost.CreatedDate : blogPost.CreatedDate.Value));
                db.AddParameters("CreatedBy", blogPost.CreatedBy);
                db.AddParameters("CreatedFrom", blogPost.CreatedFrom);
                db.AddParameters("UpdatedDate", ((blogPost.UpdatedDate == null) ? blogPost.UpdatedDate : blogPost.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", blogPost.UpdatedBy);
                db.AddParameters("UpdatedFrom", blogPost.UpdatedFrom);
                db.AddParameters("BlogPostCategoryId", blogPost.BlogPostCategoryId);
                int affectedRows = db.ExecuteNonQuery("Insert_BlogPost", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_BlogPost", false);
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
                db.AddParameters("BlogPostId", id);
                DataTable dt = db.ExecuteDataTable("Get_BlogPost_By_Id", true);
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

        public bool Update(BlogPosts blogPost)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("BlogPostId", blogPost.BlogPostId);
                db.AddParameters("BlogPostCode", blogPost.BlogPostCode);
                db.AddParameters("Title", blogPost.Title);
                db.AddParameters("Slag", blogPost.Slag);
                db.AddParameters("Description", blogPost.Description);
                db.AddParameters("PublishedDate", blogPost.PublishedDate);
                db.AddParameters("Attachment", blogPost.Attachment);
                db.AddParameters("IsActive", blogPost.IsActive);
                db.AddParameters("CreatedDate", ((blogPost.CreatedDate == null) ? blogPost.CreatedDate : blogPost.CreatedDate.Value));
                db.AddParameters("CreatedBy", blogPost.CreatedBy);
                db.AddParameters("CreatedFrom", blogPost.CreatedFrom);
                db.AddParameters("UpdatedDate", ((blogPost.UpdatedDate == null) ? blogPost.UpdatedDate : blogPost.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", blogPost.UpdatedBy);
                db.AddParameters("UpdatedFrom", blogPost.UpdatedFrom);
                db.AddParameters("BlogPostCategoryId", blogPost.BlogPostCategoryId);
                int affectedRows = db.ExecuteNonQuery("Update_BlogPost", true);

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

        public bool Delete(BlogPosts blogPost)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("BlogPostId", blogPost.BlogPostId);
                int affectedRows = db.ExecuteNonQuery("Delete_BlogPost", true);

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