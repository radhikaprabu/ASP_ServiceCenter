using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace R_Rao_Asp_Proj1
{
    public partial class ServiceEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEvtDate.Text = DateTime.Now.ToShortDateString();
            lblError.Text = "";
            LoadClients();
        }

        public void LoadClients()
        {
            DataSet dsData;
            dsData = clsDatabase.GetClientList();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Clients";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Clients";
                dsData.Dispose();
            }
            else
            {
                drpClientID.DataSource = dsData.Tables[0];
                drpClientID.DataTextField = "ClientName";
                drpClientID.DataValueField = "ClientID";
                drpClientID.DataBind();

                dsData.Dispose();
            }
        }

        private Boolean ValidateFields()
        {
            Boolean blnOK = true;
            Int64 intPhone;
            String strMessage = "";
            lblError.Text = "";

            if (txtPhone.Text.Trim().Length < 10)
            {
                blnOK = false;
                strMessage += "Phone number should be 10 digits";
            }
            else if (!Int64.TryParse(txtPhone.Text, out intPhone))
            {
                blnOK = false;
                strMessage += "Phone number is numeric";
            }

            if (txtContact.Text.Trim().Length < 1)
            {
                blnOK = false;
                strMessage += "Contact Information is required";
            }

            lblError.Text = strMessage;
            return blnOK;
        }


        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Int32 intTicketID;
                lblError.Text = "";

                intTicketID = clsDatabase.InsertServiceEvent( Convert.ToInt32(drpClientID.SelectedValue.ToString()), Convert.ToDateTime(txtEvtDate.Text),
                    txtPhone.Text.Trim(), txtContact.Text.Trim());
                Session["NewTicketID"] = intTicketID;
                Response.Redirect("Problem.aspx");
            }
        }

        protected void drpClientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpClientID.SelectedValue.ToString();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtContact.Text = "";
            txtPhone.Text = "";
        }
    }
}