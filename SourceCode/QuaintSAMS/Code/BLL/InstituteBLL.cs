using QuaintSAMS.Code.DAL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.BLL
{
    public class InstituteBLL
    {
        public bool Save(Institutes institute)
        {
            try
            {
                InstituteDAL instituteDAL = new InstituteDAL();

                if (IsNameExist(institute))
                {
                    throw new Exception("Name already exist.");
                }
                else
                {
                    return instituteDAL.Save(institute);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsNameExist(Institutes institute)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Name"]).ToString() == institute.Name);
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
                InstituteDAL instituteDAL = new InstituteDAL();
                return instituteDAL.GetAll();
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

        public DataTable GetAllActiveTop(int item = 10)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true).OrderBy(x => x["SerialNumber"]).Take(item);
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

        public DataTable GetByCourseId(int courseId)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true && ((int)x["CourseId"]) == courseId);
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
                InstituteDAL instituteDAL = new InstituteDAL();
                return instituteDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Institutes institute)
        {
            try
            {
                InstituteDAL instituteDAL = new InstituteDAL();
                return instituteDAL.Update(institute);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Institutes institute)
        {
            try
            {
                InstituteDAL instituteDAL = new InstituteDAL();
                return instituteDAL.Delete(institute);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}