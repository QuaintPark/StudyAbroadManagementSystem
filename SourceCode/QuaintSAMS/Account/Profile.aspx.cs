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

namespace QuaintSAMS.Account
{
    public partial class Profile : System.Web.UI.Page
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



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuaintSessionManager session = new QuaintSessionManager();
                this.UserInfo = Convert.ToString(session.ActiveUserInformation);
                this.StationInfo = Convert.ToString(session.ActiveStationInformation);
                this.ModelId = Convert.ToInt32(session.ActiveUserId);
                txtPassword.Focus();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;

            txtPassword.Focus();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    Alert(AlertType.Warning, "Enter password.");
                    txtPassword.Focus();
                }
                else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    Alert(AlertType.Warning, "Enter confirm password.");
                    txtConfirmPassword.Focus();
                }
                else
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        Alert(AlertType.Warning, "Password does not match");
                        txtPassword.Focus();
                    }
                    else
                    {
                        string password = txtPassword.Text;
                        UserBLL userBLL = new UserBLL();
                        DataTable dt = userBLL.GetById(Convert.ToInt32(this.ModelId));
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Users user = new Users();
                                user.UserId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["UserId"]));
                                user.UserCode = Convert.ToString(dt.Rows[0]["UserCode"]);
                                user.FullName = Convert.ToString(dt.Rows[0]["FullName"]);
                                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                                user.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                                user.PasswordStamp = Convert.ToString(dt.Rows[0]["PasswordStamp"]);
                                user.UserType = Convert.ToString(dt.Rows[0]["UserType"]);
                                user.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                                user.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                                user.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                                user.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                                user.UpdatedDate = DateTime.Now;
                                user.UpdatedBy = UserInfo;
                                user.UpdatedFrom = StationInfo;

                                user.Password = password;

                                if (userBLL.Update(user))
                                {
                                    Alert(AlertType.Success, "Updated successfully.");
                                    ClearFields();
                                }
                                else
                                {
                                    Alert(AlertType.Error, "Failed to update.");
                                }
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