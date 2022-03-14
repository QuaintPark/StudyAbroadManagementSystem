using QuaintSAMS.Code.DAL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.BLL
{
    public class RankingBLL
    {
        public bool Save(Rankings ranking)
        {
            try
            {
                RankingDAL rankingDAL = new RankingDAL();

                if (IsUniversityNameExist(ranking))
                {
                    throw new Exception("University name already exist.");
                }
                else
                {
                    return rankingDAL.Save(ranking);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsUniversityNameExist(Rankings ranking)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["UniversityName"]).ToString() == ranking.UniversityName);
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
                RankingDAL rankingDAL = new RankingDAL();
                return rankingDAL.GetAll();
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
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true && ((bool)x["IsCountryActive"]) == true).OrderBy(x => ((int)x["Rank"]));
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

        public DataTable GetByCountryId(int countryId)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true && ((int)x["CountryId"]) == countryId).OrderBy(x => ((int)x["Rank"]));
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
                RankingDAL rankingDAL = new RankingDAL();
                return rankingDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Rankings ranking)
        {
            try
            {
                RankingDAL rankingDAL = new RankingDAL();
                return rankingDAL.Update(ranking);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Rankings ranking)
        {
            try
            {
                RankingDAL rankingDAL = new RankingDAL();
                return rankingDAL.Delete(ranking);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}