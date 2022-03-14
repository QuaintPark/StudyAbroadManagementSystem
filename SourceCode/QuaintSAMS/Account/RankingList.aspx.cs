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
    public partial class RankingList : System.Web.UI.Page
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



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);

                LoadList();
            }
        }

        private void LoadList()
        {
            try
            {
                RankingBLL rankingBLL = new RankingBLL();
                DataTable dt = rankingBLL.GetAll();
                rptrList.DataSource = dt;
                rptrList.DataBind();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void btnActiveOrDeactive_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string id = Convert.ToString(e.CommandArgument);
                if (!string.IsNullOrEmpty(id))
                {
                    RankingBLL rankingBLL = new RankingBLL();
                    DataTable dt = rankingBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
                            Rankings ranking = new Rankings();
                            ranking.RankingId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["RankingId"]));
                            ranking.RankingCode = Convert.ToString(dt.Rows[0]["RankingCode"]);
                            ranking.UniversityName = Convert.ToString(dt.Rows[0]["UniversityName"]);
                            ranking.Rank = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Rank"]));
                            ranking.Url = Convert.ToString(dt.Rows[0]["Url"]);
                            ranking.Description = Convert.ToString(dt.Rows[0]["Description"]);
                            ranking.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            ranking.CountryId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["CountryId"]));
                            ranking.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            ranking.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            ranking.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                            ranking.UpdatedDate = DateTime.Now;
                            ranking.UpdatedBy = UserInfo;
                            ranking.UpdatedFrom = StationInfo;

                            if (ranking.IsActive)
                            {
                                ranking.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                ranking.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (rankingBLL.Update(ranking))
                            {
                                Alert(AlertType.Success, actionStatus + " successfully.");
                                LoadList();
                            }
                            else
                            {
                                Alert(AlertType.Error, "Failed to update.");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to process.");
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string id = Convert.ToString(e.CommandArgument);
                if (!string.IsNullOrEmpty(id))
                {
                    RankingBLL rankingBLL = new RankingBLL();
                    Rankings ranking = new Rankings();
                    ranking.RankingId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (ranking.RankingId > 0)
                    {
                        if (rankingBLL.Delete(ranking))
                        {
                            Alert(AlertType.Success, "Deleted successfully.");
                            LoadList();
                        }
                        else
                        {
                            Alert(AlertType.Error, "Failed to delete.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to delete.");
            }
        }
    }
}