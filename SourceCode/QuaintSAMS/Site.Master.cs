using QuaintPark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintSAMS
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuaintSessionManager session = new QuaintSessionManager();
                if (session.HasSession)
                {
                    areaAccess.Visible = false;
                    areaUserInfo.Visible = true;
                    lblUserName.Text = session.ActiveUserName;

                    string currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                    string redirectUrl = "~/Login.aspx?Ref=logout&Redirect=" + QuaintSecurityManager.EncryptUrl(currentUrl);
                    btnLogout.HRef = redirectUrl;
                }
                else
                {
                    areaAccess.Visible = true;
                    areaUserInfo.Visible = false;
                    lblUserName.Text = string.Empty;
                }
            }
        }
    }
}