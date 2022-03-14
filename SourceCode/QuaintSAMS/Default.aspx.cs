using QuaintSAMS.Code.BLL;
using QuaintSAMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintSAMS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTopInstitutes();
                LoadCounter();
                LoadBlogPost();
            }
        }

        private void LoadTopInstitutes()
        {
            try
            {
                InstituteBLL instituteBLL = new InstituteBLL();
                DataTable dt = instituteBLL.GetAllActiveTop();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        rptrTopInstitute.DataSource = dt;
                        rptrTopInstitute.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void LoadCounter()
        {
            try
            {
                InstituteBLL instituteBLL = new InstituteBLL();
                DataTable dtInstitute = instituteBLL.GetAllActive();
                lblTotalUniversity.Text = Convert.ToString(dtInstitute.Rows.Count);

                LenderBankBLL lenderBankBLL = new LenderBankBLL();
                DataTable dtLenderBank = lenderBankBLL.GetAllActive();
                lblTotalBank.Text = Convert.ToString(dtLenderBank.Rows.Count);

                CourseBLL courseBLL = new CourseBLL();
                DataTable dtCourse = courseBLL.GetAllActive();
                lblTotalCourse.Text = Convert.ToString(dtCourse.Rows.Count);

                BlogPostBLL blogPostBLL = new BlogPostBLL();
                DataTable dtBlogPost = blogPostBLL.GetAllActive();
                lblTotalBlogPost.Text = Convert.ToString(dtBlogPost.Rows.Count);

                UserBLL userBLL = new UserBLL();
                DataTable dtUser = userBLL.GetAllActiveMember();
                lblTotalMember.Text = Convert.ToString(dtUser.Rows.Count);
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        private void LoadBlogPost()
        {
            try
            {
                BlogPostBLL blogPostBLL = new BlogPostBLL();
                DataTable dt = blogPostBLL.GetFromLastActive(2);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        rptrPost.DataSource = dt;
                        rptrPost.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}