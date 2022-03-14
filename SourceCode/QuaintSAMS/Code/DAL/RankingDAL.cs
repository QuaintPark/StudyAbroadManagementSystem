using QuaintPark;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.DAL
{
    public class RankingDAL
    {
        public bool Save(Rankings ranking)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("RankingCode", ranking.RankingCode);
                db.AddParameters("UniversityName", ranking.UniversityName);
                db.AddParameters("Rank", ranking.Rank);
                db.AddParameters("Url", ranking.Url);
                db.AddParameters("Description", ranking.Description);
                db.AddParameters("IsActive", ranking.IsActive);
                db.AddParameters("CreatedDate", ((ranking.CreatedDate == null) ? ranking.CreatedDate : ranking.CreatedDate.Value));
                db.AddParameters("CreatedBy", ranking.CreatedBy);
                db.AddParameters("CreatedFrom", ranking.CreatedFrom);
                db.AddParameters("UpdatedDate", ((ranking.UpdatedDate == null) ? ranking.UpdatedDate : ranking.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", ranking.UpdatedBy);
                db.AddParameters("UpdatedFrom", ranking.UpdatedFrom);
                db.AddParameters("CountryId", ranking.CountryId);
                int affectedRows = db.ExecuteNonQuery("Insert_Ranking", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Ranking", false);
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
                db.AddParameters("RankingId", id);
                DataTable dt = db.ExecuteDataTable("Get_Ranking_By_Id", true);
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

        public bool Update(Rankings ranking)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("RankingId", ranking.RankingId);
                db.AddParameters("RankingCode", ranking.RankingCode);
                db.AddParameters("UniversityName", ranking.UniversityName);
                db.AddParameters("Rank", ranking.Rank);
                db.AddParameters("Url", ranking.Url);
                db.AddParameters("Description", ranking.Description);
                db.AddParameters("IsActive", ranking.IsActive);
                db.AddParameters("CreatedDate", ((ranking.CreatedDate == null) ? ranking.CreatedDate : ranking.CreatedDate.Value));
                db.AddParameters("CreatedBy", ranking.CreatedBy);
                db.AddParameters("CreatedFrom", ranking.CreatedFrom);
                db.AddParameters("UpdatedDate", ((ranking.UpdatedDate == null) ? ranking.UpdatedDate : ranking.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", ranking.UpdatedBy);
                db.AddParameters("UpdatedFrom", ranking.UpdatedFrom);
                db.AddParameters("CountryId", ranking.CountryId);
                int affectedRows = db.ExecuteNonQuery("Update_Ranking", true);

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

        public bool Delete(Rankings ranking)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("RankingId", ranking.RankingId);
                int affectedRows = db.ExecuteNonQuery("Delete_Ranking", true);

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