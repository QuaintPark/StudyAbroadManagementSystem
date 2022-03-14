using QuaintPark;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.DAL
{
    public class CourseDAL
    {
        public bool Save(Courses course)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("CourseCode", course.CourseCode);
                db.AddParameters("Name", course.Name);
                db.AddParameters("Description", course.Description);
                db.AddParameters("Attachment", course.Attachment);
                db.AddParameters("IsActive", course.IsActive);
                db.AddParameters("CreatedDate", ((course.CreatedDate == null) ? course.CreatedDate : course.CreatedDate.Value));
                db.AddParameters("CreatedBy", course.CreatedBy);
                db.AddParameters("CreatedFrom", course.CreatedFrom);
                db.AddParameters("UpdatedDate", ((course.UpdatedDate == null) ? course.UpdatedDate : course.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", course.UpdatedBy);
                db.AddParameters("UpdatedFrom", course.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_Course", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Course", false);
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
                db.AddParameters("CourseId", id);
                DataTable dt = db.ExecuteDataTable("Get_Course_By_Id", true);
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

        public bool Update(Courses course)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("CourseId", course.CourseId);
                db.AddParameters("CourseCode", course.CourseCode);
                db.AddParameters("Name", course.Name);
                db.AddParameters("Description", course.Description);
                db.AddParameters("Attachment", course.Attachment);
                db.AddParameters("IsActive", course.IsActive);
                db.AddParameters("CreatedDate", ((course.CreatedDate == null) ? course.CreatedDate : course.CreatedDate.Value));
                db.AddParameters("CreatedBy", course.CreatedBy);
                db.AddParameters("CreatedFrom", course.CreatedFrom);
                db.AddParameters("UpdatedDate", ((course.UpdatedDate == null) ? course.UpdatedDate : course.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", course.UpdatedBy);
                db.AddParameters("UpdatedFrom", course.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_Course", true);

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

        public bool Delete(Courses course)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("CourseId", course.CourseId);
                int affectedRows = db.ExecuteNonQuery("Delete_Course", true);

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