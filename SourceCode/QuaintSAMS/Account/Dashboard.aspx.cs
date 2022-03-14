using QuaintSAMS.Code.BLL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintSAMS.Account
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardInfo();
            }
        }

        private void LoadDashboardInfo()
        {
            try
            {
                //Total Member
                UserBLL userBLL = new UserBLL();
                DataTable dtUser = userBLL.GetAllActive();
                lblTotalMember.Text = (dtUser == null) ? "0" : Convert.ToString(Convert.ToInt32(dtUser.Rows.Count));

                //Total University
                //InstituteBLL instituteBLL = new InstituteBLL();
                //DataTable dtInstitute = instituteBLL.GetAllActive();
                RankingBLL rankingBLL = new RankingBLL();
                DataTable dtRanking = rankingBLL.GetAllActive();
                lblTotalUniversity.Text = (dtRanking == null) ? "0" : Convert.ToString(dtRanking.Rows.Count);

                //Total Course
                CourseBLL courseBLL = new CourseBLL();
                DataTable dtCourse = courseBLL.GetAllActive();
                lblTotalCourse.Text = (dtCourse == null) ? "0" : Convert.ToString(dtCourse.Rows.Count);

                //Total Bank
                LenderBankBLL lenderBankBLL = new LenderBankBLL();
                DataTable dtLenderBank = lenderBankBLL.GetAllActive();
                lblTotalBank.Text = (dtLenderBank == null) ? "0" : Convert.ToString(dtLenderBank.Rows.Count);

                //Total Blog Post
                BlogPostBLL blogPostBLL = new BlogPostBLL();
                DataTable dtBlogPost = blogPostBLL.GetAllActive();
                lblTotalBlogPost.Text = (dtBlogPost == null) ? "0" : Convert.ToString(dtBlogPost.Rows.Count);
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}