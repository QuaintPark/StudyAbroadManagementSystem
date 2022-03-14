using QuaintSAMS.Code.DAL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.BLL
{
    public class CourseBLL
    {
        public bool Save(Courses course)
        {
            try
            {
                CourseDAL courseDAL = new CourseDAL();

                if (IsNameExist(course))
                {
                    throw new Exception("Name already exist.");
                }
                else
                {
                    return courseDAL.Save(course);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsNameExist(Courses course)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Name"]).ToString() == course.Name);
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
                CourseDAL courseDAL = new CourseDAL();
                return courseDAL.GetAll();
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
                CourseDAL courseDAL = new CourseDAL();
                return courseDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Courses course)
        {
            try
            {
                CourseDAL courseDAL = new CourseDAL();
                return courseDAL.Update(course);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Courses course)
        {
            try
            {
                CourseDAL courseDAL = new CourseDAL();
                return courseDAL.Delete(course);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}