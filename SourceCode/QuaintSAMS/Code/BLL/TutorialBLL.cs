using QuaintSAMS.Code.DAL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.BLL
{
    public class TutorialBLL
    {
        public bool Save(Tutorials tutorial)
        {
            try
            {
                TutorialDAL tutorialDAL = new TutorialDAL();

                if (IsTitleExist(tutorial))
                {
                    throw new Exception("Title already exist.");
                }
                else
                {
                    return tutorialDAL.Save(tutorial);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsTitleExist(Tutorials tutorial)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Title"]).ToString() == tutorial.Title);
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
                TutorialDAL tutorialDAL = new TutorialDAL();
                return tutorialDAL.GetAll();
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

        public DataTable GetByPlayListId(int playListId)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true && ((int)x["PlayListId"]) == playListId);
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
                TutorialDAL tutorialDAL = new TutorialDAL();
                return tutorialDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Tutorials tutorial)
        {
            try
            {
                TutorialDAL tutorialDAL = new TutorialDAL();
                return tutorialDAL.Update(tutorial);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Tutorials tutorial)
        {
            try
            {
                TutorialDAL tutorialDAL = new TutorialDAL();
                return tutorialDAL.Delete(tutorial);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}