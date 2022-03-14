using QuaintPark;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.DAL
{
    public class CountryDAL
    {
        public bool Save(Countries country)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("CountryCode", country.CountryCode);
                db.AddParameters("Name", country.Name);
                db.AddParameters("CountryCodeAlpha2", country.CountryCodeAlpha2);
                db.AddParameters("CountryCodeAlpha3", country.CountryCodeAlpha3);
                db.AddParameters("Description", country.Description);
                db.AddParameters("IsActive", country.IsActive);
                db.AddParameters("CreatedDate", ((country.CreatedDate == null) ? country.CreatedDate : country.CreatedDate.Value));
                db.AddParameters("CreatedBy", country.CreatedBy);
                db.AddParameters("CreatedFrom", country.CreatedFrom);
                db.AddParameters("UpdatedDate", ((country.UpdatedDate == null) ? country.UpdatedDate : country.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", country.UpdatedBy);
                db.AddParameters("UpdatedFrom", country.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_Country", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Country", false);
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
                db.AddParameters("CountryId", id);
                DataTable dt = db.ExecuteDataTable("Get_Country_By_Id", true);
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

        public bool Update(Countries country)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("CountryId", country.CountryId);
                db.AddParameters("CountryCode", country.CountryCode);
                db.AddParameters("Name", country.Name);
                db.AddParameters("CountryCodeAlpha2", country.CountryCodeAlpha2);
                db.AddParameters("CountryCodeAlpha3", country.CountryCodeAlpha3);
                db.AddParameters("Description", country.Description);
                db.AddParameters("IsActive", country.IsActive);
                db.AddParameters("CreatedDate", ((country.CreatedDate == null) ? country.CreatedDate : country.CreatedDate.Value));
                db.AddParameters("CreatedBy", country.CreatedBy);
                db.AddParameters("CreatedFrom", country.CreatedFrom);
                db.AddParameters("UpdatedDate", ((country.UpdatedDate == null) ? country.UpdatedDate : country.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", country.UpdatedBy);
                db.AddParameters("UpdatedFrom", country.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_Country", true);

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

        public bool Delete(Countries country)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("CountryId", country.CountryId);
                int affectedRows = db.ExecuteNonQuery("Delete_Country", true);

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
