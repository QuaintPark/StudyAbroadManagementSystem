using QuaintSAMS.Code.BLL;
using QuaintSAMS.Code.Global;
using QuaintSAMS.Code.Model;
using QuaintPark;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintSAMS.Pages
{
    public partial class Tutorial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTutorial();
            }
        }

        private void LoadTutorial()
        {
            try
            {
                TutorialBLL tutorialBLL = new TutorialBLL();
                DataTable dt = tutorialBLL.GetAllActive();
                rptrTutorial.DataSource = dt;
                rptrTutorial.DataBind();
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}