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
    public partial class Resolution : System.Web.UI.Page
    {
        Int32 intResloNo;
        Int32 intCheckCharge;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTicketNo.Text = Session["TicketID"].ToString();
            txtProblemNo.Text = Session["ProblemNo"].ToString();
            intResloNo = 1;
            lblError.Text = "";
            txtResolNo.Text = intResloNo.ToString();
            LoadTechnician();
        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Open Problems.aspx");
        }

        private void LoadTechnician()
        {
            DataSet dsData;
            dsData = clsDatabase.GetTechnicianList();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Technicians";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Technicians";
                dsData.Dispose();
            }
            else
            {
                drpTechnician.DataSource = dsData.Tables[0];
                drpTechnician.DataTextField = "Techname";
                drpTechnician.DataValueField = "TechnicianID";
                drpTechnician.DataBind();

                dsData.Dispose();

            }

        }

        private Boolean ValidateFields()
        {
            Boolean blnOK = true;
            Int64 intHours;
            Int64 intMileage;
            String strMessage = "";
            lblError.Text = "";

            if (txtResol.Text.Trim().Length < 1)
            {
                blnOK = false;
                strMessage += "Resolution Information is required";
            }
            if (txtHours.Text.Trim().Length < 1)
            {
                blnOK = false;
                strMessage += "No of Hours is required";
            }
            else if (!Int64.TryParse(txtHours.Text, out intHours))
            {
                blnOK = false;
                strMessage += "No. of hours is numeric";
            }
            
     
            if (chkIntNoCharge.Checked)
            {
                intCheckCharge = 0;
            }
            
            lblError.Text = strMessage;
            return blnOK;
        }

        private void InsertResolution()
        {
            Int32 intRetValue;
            lblError.Text = "";

            intRetValue = clsDatabase.InsertResolution(Convert.ToInt32(txtTicketNo.Text), Convert.ToInt32(txtProblemNo.Text), Convert.ToInt32(txtResolNo.Text),
                txtResol.Text, txtDtFixed.Text, txtDtOnsite.Text, Convert.ToInt32(drpTechnician.SelectedValue.ToString()),
                txtHours.Text, txtMileage.Text, txtCOstMil.Text,
                txtSupplies.Text, txtMisc.Text, intCheckCharge);
            if (intRetValue == 0)
            {
                lblError.Text = "New Resolution Created";
            }
            else
            {
                lblError.Text = "Resolution Cannot be created";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                InsertResolution();

                intResloNo = Convert.ToInt32(txtResolNo.Text);
                intResloNo = intResloNo + 1;
                txtResolNo.Text = intResloNo.ToString();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtResol.Text = "";
            txtHours.Text = "";
            txtSupplies.Text = "";
            txtDtFixed.Text = "";
            txtMileage.Text = "";
            txtMisc.Text = "";
            txtDtOnsite.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        protected void chkIntNoCharge_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}