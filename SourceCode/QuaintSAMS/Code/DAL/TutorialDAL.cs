using QuaintPark;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.DAL
{
    public class TutorialDAL
    {
        public bool Save(Tutorials tutorial)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("TutorialCode", tutorial.TutorialCode);
                db.AddParameters("Title", tutorial.Title);
                db.AddParameters("Slug", tutorial.Slug);
                db.AddParameters("Description", tutorial.Description);
                db.AddParameters("Attachment", tutorial.Attachment);
                db.AddParameters("ExternalUrl", tutorial.ExternalUrl);
                db.AddParameters("IsActive", tutorial.IsActive);
                db.AddParameters("CreatedDate", ((tutorial.CreatedDate == null) ? tutorial.CreatedDate : tutorial.CreatedDate.Value));
                db.AddParameters("CreatedBy", tutorial.CreatedBy);
                db.AddParameters("CreatedFrom", tutorial.CreatedFrom);
                db.AddParameters("UpdatedDate", ((tutorial.UpdatedDate == null) ? tutorial.UpdatedDate : tutorial.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", tutorial.UpdatedBy);
                db.AddParameters("UpdatedFrom", tutorial.UpdatedFrom);
                db.AddParameters("PlayListId", tutorial.PlayListId);
                int affectedRows = db.ExecuteNonQuery("Insert_Tutorial", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Tutorial", false);
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
                db.AddParameters("TutorialId", id);
                DataTable dt = db.ExecuteDataTable("Get_Tutorial_By_Id", true);
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

        public bool Update(Tutorials tutorial)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("TutorialId", tutorial.TutorialId);
                db.AddParameters("TutorialCode", tutorial.TutorialCode);
                db.AddParameters("Title", tutorial.Title);
                db.AddParameters("Slug", tutorial.Slug);
                db.AddParameters("Description", tutorial.Description);
                db.AddParameters("Attachment", tutorial.Attachment);
                db.AddParameters("ExternalUrl", tutorial.ExternalUrl);
                db.AddParameters("IsActive", tutorial.IsActive);
                db.AddParameters("CreatedDate", ((tutorial.CreatedDate == null) ? tutorial.CreatedDate : tutorial.CreatedDate.Value));
                db.AddParameters("CreatedBy", tutorial.CreatedBy);
                db.AddParameters("CreatedFrom", tutorial.CreatedFrom);
                db.AddParameters("UpdatedDate", ((tutorial.UpdatedDate == null) ? tutorial.UpdatedDate : tutorial.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", tutorial.UpdatedBy);
                db.AddParameters("UpdatedFrom", tutorial.UpdatedFrom);
                db.AddParameters("PlayListId", tutorial.PlayListId);
                int affectedRows = db.ExecuteNonQuery("Update_Tutorial", true);

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

        public bool Delete(Tutorials tutorial)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("TutorialId", tutorial.TutorialId);
                int affectedRows = db.ExecuteNonQuery("Delete_Tutorial", true);

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