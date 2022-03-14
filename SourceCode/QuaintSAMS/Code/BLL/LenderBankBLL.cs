using QuaintSAMS.Code.DAL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.BLL
{
    public class LenderBankBLL
    {
        public bool Save(LenderBanks lenderBank)
        {
            try
            {
                LenderBankDAL lenderBankDAL = new LenderBankDAL();

                if (IsBankNameExist(lenderBank))
                {
                    throw new Exception("Bank name already exist.");
                }
                else
                {
                    return lenderBankDAL.Save(lenderBank);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsBankNameExist(LenderBanks lenderBank)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["BankName"]).ToString() == lenderBank.BankName);
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
                LenderBankDAL lenderBankDAL = new LenderBankDAL();
                return lenderBankDAL.GetAll();
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
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true && ((bool)x["IsCountryActive"]) == true);
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
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true && ((int)x["CountryId"]) == countryId);
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
                LenderBankDAL lenderBankDAL = new LenderBankDAL();
                return lenderBankDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(LenderBanks lenderBank)
        {
            try
            {
                LenderBankDAL lenderBankDAL = new LenderBankDAL();
                return lenderBankDAL.Update(lenderBank);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(LenderBanks lenderBank)
        {
            try
            {
                LenderBankDAL lenderBankDAL = new LenderBankDAL();
                return lenderBankDAL.Delete(lenderBank);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}