using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Diagnostics;


namespace R_Rao_Asp_Proj1
{
    public partial class TechInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = "";
                LoadTechnician();
            }
        }

        //************ Procedure LoadTechnician() ****************//
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
                drpTechID.DataSource = dsData.Tables[0];
                drpTechID.DataTextField = "Techname";
                drpTechID.DataValueField = "TechnicianID";
                drpTechID.DataBind();

                dsData.Dispose();

            }

        }

        //********** DisplayTechnician()**************8//
        private void DisplayTechnician(String strTechID)
        {
            DataSet dsData;
            dsData = clsDatabase.GetTechnicianByID(strTechID);

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

                txtLName.Text = dsData.Tables[0].Rows[0]["LName"].ToString();
                txtFName.Text = dsData.Tables[0].Rows[0]["FName"].ToString();
                txtPhone.Text = dsData.Tables[0].Rows[0]["Phone"].ToString();
                txtHRate.Text = dsData.Tables[0].Rows[0]["HRate"].ToString();
                if (dsData.Tables[0].Rows[0]["MInit"] == DBNull.Value)
                {
                    txtMInit.Text = "";
                }
                else
                {
                    txtMInit.Text = dsData.Tables[0].Rows[0]["MInit"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["EMail"] == DBNull.Value)
                {
                    txtEMail.Text = "";
                }
                else
                {
                    txtEMail.Text = dsData.Tables[0].Rows[0]["EMail"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["Dept"] == DBNull.Value)
                {
                    txtDept.Text = "";
                }
                else
                {
                    txtDept.Text = dsData.Tables[0].Rows[0]["Dept"].ToString();
                }

                dsData.Dispose();
            }
        }



        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void drpTechID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTechnician(drpTechID.SelectedValue.ToString());
        }

        //******** InsertTechnician() *********//

        private void InsertTechnician()
        {
            Int32 intRetValue;
            lblError.Text = "";
            

            intRetValue = clsDatabase.InsertTechnician(txtLName.Text.Trim(), txtFName.Text.Trim(),
                txtMInit.Text.Trim(), txtEMail.Text.Trim(), txtDept.Text.Trim(), txtPhone.Text.Trim(), txtHRate.Text.Trim());
            if (intRetValue != 0)
            {
                lblError.Text = "New Technician inserted";
                Session.Contents["TechnicianID"] = drpTechID.Text;
            }
            else
            {
                lblError.Text = "Error inserting new Technician";
            }
        }

        //*********** ValidateFields() ******************//
        private Boolean ValidateFields()
        {
            Boolean blnOK = true;
            Int64 intPhone;
            String strMessage = "";
            lblError.Text = "";
            if (txtLName.Text.Trim().Length < 1)
            {
                blnOK = false;
                strMessage += "Last name is required";
            }
            if (txtFName.Text.Trim().Length < 1)
            {
                blnOK = false;
                strMessage += "First name is required";
            }
            if (txtMInit.Text.Trim().Length > 1)
            {
                blnOK = false;
                strMessage += "Middle Initial should be 1 character";

            }
            
            if(txtPhone.Text.Trim().Length < 10)
            {
                blnOK = false;
                strMessage += "Phone is required";
            }
            else if (!Int64.TryParse(txtPhone.Text, out intPhone))
            {
                blnOK = false;
                strMessage += "Phone number is numeric";
            }
            if (txtHRate.Text.Trim().Length < 1)
            {
                blnOK = false;
                strMessage += "Hourly Rate is required";
            }
            lblError.Text = strMessage;
            return blnOK;
        }

        protected void chkAddTech_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddTech.Checked)
            {
                drpTechID.Enabled = false;
                txtLName.Text = "";
                txtFName.Text = "";
                txtMInit.Text = "";
                txtEMail.Text = "";
                txtDept.Text = "";
                txtPhone.Text = "";
                txtHRate.Text = "";
                txtLName.Focus();
                btnCancel.Enabled = false;
                btnUpdate.Enabled = false;
            }
            else
            {
                drpTechID.Enabled = true;
                DisplayTechnician(drpTechID.SelectedValue.ToString());
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (Session.Contents["TechnicianID"] == null)
                {
                    InsertTechnician();
                }

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (Session.Contents["TechnicianID"] != null)
            {
                DisplayTechnician(Session.Contents["TechnicianID"].ToString());
            }
            else
            {
                drpTechID.Enabled = true;
                txtLName.Text = "";
                txtFName.Text = "";
                txtMInit.Text = "";
                txtEMail.Text = "";
                txtDept.Text = "";
                txtPhone.Text = "";
                txtHRate.Text = "";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {


            if (Session.Contents["TechnicianID"] == null)
            {
                DeleteTechnicians();
                LoadTechnician();
            }

        }

        private void DeleteTechnicians()
        {
            Int32 intRetValue = 0;

            intRetValue = clsDatabase.DeleteTechnician(drpTechID.SelectedValue.ToString());

            if (intRetValue == 0)
            {
                lblError.Text = "Technician Deleted";
            }
            else
            {
                lblError.Text = "Error deleting techinician";
            }
        }

        private void UpdateTechnician()
        {
            Int32 intRetValue;
            lblError.Text = "";
            

            intRetValue = clsDatabase.UpdateTechnician(drpTechID.SelectedValue.ToString(), txtLName.Text.Trim(), txtFName.Text.Trim(),
                txtMInit.Text.Trim(), txtEMail.Text.Trim(), txtDept.Text.Trim(), txtPhone.Text.Trim(), txtHRate.Text.Trim());
            if (intRetValue == 0)
            {
                lblError.Text = "Technician updated";
                
                Session.Contents["TechnicianID"] = drpTechID.Text;
            }
            else
            {
                lblError.Text = "Error updating Technician";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (Session.Contents["TechnicianID"] == null)
                {
                    UpdateTechnician();
                }

            }
        }
    }

}


