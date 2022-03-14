using QuaintPark;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.DAL
{
    public class LenderBankDAL
    {
        public bool Save(LenderBanks lenderBank)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("LenderBankCode", lenderBank.LenderBankCode);
                db.AddParameters("BankName", lenderBank.BankName);
                db.AddParameters("Url", lenderBank.Url);
                db.AddParameters("Description", lenderBank.Description);
                db.AddParameters("IsActive", lenderBank.IsActive);
                db.AddParameters("CreatedDate", ((lenderBank.CreatedDate == null) ? lenderBank.CreatedDate : lenderBank.CreatedDate.Value));
                db.AddParameters("CreatedBy", lenderBank.CreatedBy);
                db.AddParameters("CreatedFrom", lenderBank.CreatedFrom);
                db.AddParameters("UpdatedDate", ((lenderBank.UpdatedDate == null) ? lenderBank.UpdatedDate : lenderBank.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", lenderBank.UpdatedBy);
                db.AddParameters("UpdatedFrom", lenderBank.UpdatedFrom);
                db.AddParameters("CountryId", lenderBank.CountryId);
                int affectedRows = db.ExecuteNonQuery("Insert_LenderBank", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_LenderBank", false);
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
                db.AddParameters("LenderBankId", id);
                DataTable dt = db.ExecuteDataTable("Get_LenderBank_By_Id", true);
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

        public bool Update(LenderBanks lenderBank)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("LenderBankId", lenderBank.LenderBankId);
                db.AddParameters("LenderBankCode", lenderBank.LenderBankCode);
                db.AddParameters("BankName", lenderBank.BankName);
                db.AddParameters("Url", lenderBank.Url);
                db.AddParameters("Description", lenderBank.Description);
                db.AddParameters("IsActive", lenderBank.IsActive);
                db.AddParameters("CreatedDate", ((lenderBank.CreatedDate == null) ? lenderBank.CreatedDate : lenderBank.CreatedDate.Value));
                db.AddParameters("CreatedBy", lenderBank.CreatedBy);
                db.AddParameters("CreatedFrom", lenderBank.CreatedFrom);
                db.AddParameters("UpdatedDate", ((lenderBank.UpdatedDate == null) ? lenderBank.UpdatedDate : lenderBank.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", lenderBank.UpdatedBy);
                db.AddParameters("UpdatedFrom", lenderBank.UpdatedFrom);
                db.AddParameters("CountryId", lenderBank.CountryId);
                int affectedRows = db.ExecuteNonQuery("Update_LenderBank", true);

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

        public bool Delete(LenderBanks lenderBank)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("LenderBankId", lenderBank.LenderBankId);
                int affectedRows = db.ExecuteNonQuery("Delete_LenderBank", true);

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