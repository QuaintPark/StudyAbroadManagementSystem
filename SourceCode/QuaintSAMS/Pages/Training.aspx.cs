using QuaintSAMS.Code.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintSAMS.Pages
{
    public partial class Training : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourse();
                LoadList(0);
            }
        }

        private void LoadCourse()
        {
            try
            {
                CourseBLL courseBLL = new CourseBLL();
                DataTable dt = courseBLL.GetAllActive();
                ddlCourse.DataSource = dt;
                ddlCourse.DataTextField = "Name";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();

                ddlCourse.Items.Insert(0, "All Courses");
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void LoadList(int courseId)
        {
            try
            {
                InstituteBLL instituteBLL = new InstituteBLL();
                DataTable dt = new DataTable();

                if (courseId > 0)
                    dt = instituteBLL.GetByCourseId(courseId);
                else
                    dt = instituteBLL.GetAllActive();

                rptrList.DataSource = dt;
                rptrList.DataBind();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCourse.SelectedIndex == 0)
                {
                    LoadList(0);
                }
                else
                {
                    int courseId = Convert.ToInt32(Convert.ToString(ddlCourse.SelectedValue));
                    LoadList(courseId);
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}