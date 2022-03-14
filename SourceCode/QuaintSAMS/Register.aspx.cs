using QuaintPark;
using QuaintSAMS.Code.BLL;
using QuaintSAMS.Code.Global;
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
    public partial class Register : System.Web.UI.Page
    {
        // Message Box Method(s)
        private void Alert(AlertType alertType, string message)
        {
            alertMessage.InnerHtml = Core.AlertBox(alertType, message);
            tmrAlertMessage.Enabled = true;
            tmrAlertMessage.Interval = Core.AlertBoxInternal;
        }

        protected void tmrAlertMessage_Tick(object sender, EventArgs e)
        {
            if (tmrAlertMessage.Interval == Core.AlertBoxInternal)
            {
                alertMessage.InnerHtml = string.Empty;
                tmrAlertMessage.Enabled = false;
            }
        }


        // View State(s)
        private string UserInfo
        {
            set { ViewState["UserInfo"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["UserInfo"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        private string StationInfo
        {
            set { ViewState["StationInfo"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["StationInfo"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        public int ModelId
        {
            set { ViewState["Id"] = value; }
            get
            {
                try
                {
                    return Convert.ToInt32(Convert.ToString(ViewState["Id"]));
                }
                catch
                {
                    return 0;
                }
            }
        }
        private string ModelCode
        {
            set { ViewState["Code"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["Code"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }


        
        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //MultiEntryDisallow = false;
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);

                if (Request.QueryString["Id"] != null)
                {
                    this.ModelId = Convert.ToInt32(QuaintSecurityManager.DecryptUrl(Convert.ToString(Request.QueryString["Id"])));
                }
                else
                {
                    GenerateCode();
                }
            }
        }

        private void GenerateCode()
        {
            try
            {
                QuaintLibraryManager lib = new QuaintLibraryManager();
                ModelCode = CodePrefix.User + "-" + lib.GetSixDigitNumber(1);
                UserBLL userBLL = new UserBLL();
                DataTable dt = userBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["UserCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.User + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to load.");
            }
        }

        private void ClearFileds()
        {
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;

            txtFullName.Focus();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullName.Text))
                {
                    Alert(AlertType.Warning, "Enter full name.");
                    txtFullName.Focus();
                }
                else if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    Alert(AlertType.Warning, "Enter email.");
                    txtEmail.Focus();
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    Alert(AlertType.Warning, "Enter password.");
                    txtPassword.Focus();
                }
                else
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        Alert(AlertType.Warning, "Password does not match.");
                        txtConfirmPassword.Focus();
                    }
                    else
                    {
                        Alert(AlertType.Information, "Please, wait...");
                        QuaintLibraryManager lib = new QuaintLibraryManager();
                        string fullName = Convert.ToString(txtFullName.Text);
                        string email = Convert.ToString(txtEmail.Text);
                        string password = Convert.ToString(txtPassword.Text);
                        string userName = Convert.ToString(txtEmail.Text);

                        UserBLL userBLL = new UserBLL();
                        if (this.ModelId > 0)
                        {
                            DataTable dt = userBLL.GetById(this.ModelId);
                            Users user = new Users();
                            user.UserId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["UserId"]));
                            user.UserCode = Convert.ToString(dt.Rows[0]["UserCode"]);
                            user.FullName = Convert.ToString(dt.Rows[0]["FullName"]);
                            user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                            user.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                            user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                            user.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            user.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            user.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            user.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);
                            user.UserType = Convert.ToString(dt.Rows[0]["UserType"]);
                        }
                        else
                        {
                            Users user = new Users();
                            user.UserCode = this.ModelCode;
                            user.FullName = fullName;
                            user.Email = email;
                            user.UserName = email;
                            user.Password = password;
                            user.UserType = "MEMBER";
                            user.IsActive = true;
                            user.CreatedDate = DateTime.Now;
                            user.CreatedBy = this.UserInfo;
                            user.CreatedFrom = this.StationInfo;

                            if (userBLL.Save(user))
                            {
                                Alert(AlertType.Success, "Registration successful.");
                                ClearFileds();
                                GenerateCode();
                            }
                            else
                            {
                                Alert(AlertType.Error, "Failed to registration.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alert(AlertType.Error, ex.Message.ToString());
            }
        }
    }
}