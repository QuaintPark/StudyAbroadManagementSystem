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
    public partial class BankLoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCountry();
                LoadList(0);
            }
        }

        private void LoadCountry()
        {
            try
            {
                CountryBLL countryBLL = new CountryBLL();
                DataTable dt = countryBLL.GetAllActive();
                ddlCountry.DataSource = dt;
                ddlCountry.DataTextField = "Name";
                ddlCountry.DataValueField = "CountryId";
                ddlCountry.DataBind();

                ddlCountry.Items.Insert(0, "All over the World");
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void LoadList(int countryId)
        {
            try
            {
                LenderBankBLL lenderBankBLL = new LenderBankBLL();
                DataTable dt = new DataTable();

                if (countryId > 0)
                    dt = lenderBankBLL.GetByCountryId(countryId);
                else
                    dt = lenderBankBLL.GetAllActive();

                rptrList.DataSource = dt;
                rptrList.DataBind();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCountry.SelectedIndex == 0)
                {
                    LoadList(0);
                }
                else
                {
                    int countryId = Convert.ToInt32(Convert.ToString(ddlCountry.SelectedValue));
                    LoadList(countryId);
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}