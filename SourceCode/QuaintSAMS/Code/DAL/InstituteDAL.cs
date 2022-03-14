using QuaintPark;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.DAL
{
    public class InstituteDAL
    {
        public bool Save(Institutes institute)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("InstituteCode", institute.InstituteCode);
                db.AddParameters("Name", institute.Name);
                db.AddParameters("Logo", institute.Logo);
                db.AddParameters("Url", institute.Url);
                db.AddParameters("Description", institute.Description);
                db.AddParameters("SerialNumber", institute.SerialNumber);
                db.AddParameters("Attachment", institute.Attachment);
                db.AddParameters("IsActive", institute.IsActive);
                db.AddParameters("CreatedDate", ((institute.CreatedDate == null) ? institute.CreatedDate : institute.CreatedDate.Value));
                db.AddParameters("CreatedBy", institute.CreatedBy);
                db.AddParameters("CreatedFrom", institute.CreatedFrom);
                db.AddParameters("UpdatedDate", ((institute.UpdatedDate == null) ? institute.UpdatedDate : institute.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", institute.UpdatedBy);
                db.AddParameters("UpdatedFrom", institute.UpdatedFrom);
                db.AddParameters("CourseId", institute.CourseId);
                int affectedRows = db.ExecuteNonQuery("Insert_Institute", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Institute", false);
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
                db.AddParameters("InstituteId", id);
                DataTable dt = db.ExecuteDataTable("Get_Institute_By_Id", true);
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

        public bool Update(Institutes institute)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("InstituteId", institute.InstituteId);
                db.AddParameters("InstituteCode", institute.InstituteCode);
                db.AddParameters("Name", institute.Name);
                db.AddParameters("Logo", institute.Logo);
                db.AddParameters("Url", institute.Url);
                db.AddParameters("Description", institute.Description);
                db.AddParameters("SerialNumber", institute.SerialNumber);
                db.AddParameters("Attachment", institute.Attachment);
                db.AddParameters("IsActive", institute.IsActive);
                db.AddParameters("CreatedDate", ((institute.CreatedDate == null) ? institute.CreatedDate : institute.CreatedDate.Value));
                db.AddParameters("CreatedBy", institute.CreatedBy);
                db.AddParameters("CreatedFrom", institute.CreatedFrom);
                db.AddParameters("UpdatedDate", ((institute.UpdatedDate == null) ? institute.UpdatedDate : institute.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", institute.UpdatedBy);
                db.AddParameters("UpdatedFrom", institute.UpdatedFrom);
                db.AddParameters("CourseId", institute.CourseId);
                int affectedRows = db.ExecuteNonQuery("Update_Institute", true);

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

        public bool Delete(Institutes institute)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("InstituteId", institute.InstituteId);
                int affectedRows = db.ExecuteNonQuery("Delete_Institute", true);

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