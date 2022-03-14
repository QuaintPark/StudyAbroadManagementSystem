using QuaintSAMS.Code.DAL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.BLL
{
    public class CountryBLL
    {
        public bool Save(Countries country)
        {
            try
            {
                CountryDAL countryDAL = new CountryDAL();

                if (IsNameExist(country))
                {
                    throw new Exception("Name already exist.");
                }
                else
                {
                    return countryDAL.Save(country);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsNameExist(Countries country)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Name"]).ToString() == country.Name);
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
                CountryDAL countryDAL = new CountryDAL();
                return countryDAL.GetAll();
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
                CountryDAL countryDAL = new CountryDAL();
                return countryDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Countries country)
        {
            try
            {
                CountryDAL countryDAL = new CountryDAL();
                return countryDAL.Update(country);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Countries country)
        {
            try
            {
                CountryDAL countryDAL = new CountryDAL();
                return countryDAL.Delete(country);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}