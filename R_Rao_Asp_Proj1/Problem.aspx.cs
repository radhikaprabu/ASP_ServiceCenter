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
    public partial class Problem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Int32 intProblemNo;
            if (!IsPostBack)
            {
                
                
                txtTicketNo.Text = Session["NewTicketID"].ToString();
                lblerror.Text = "";
                intProblemNo = 1;
                txtProblemNo.Text = intProblemNo.ToString();
                LoadProduts();
                LoadTechnician();
            }
        }

        Int32 intProblemNo;
        
        //txtProblemNo.Text = intProblemNo.ToString();

        public void LoadProduts()
        {
            DataSet dsData;
            dsData = clsDatabase.GetProductList();
            if (dsData == null)
            {
                lblerror.Text = "Error retrieving Products";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblerror.Text = "Error retrieving Products";
                dsData.Dispose();
            }
            else
            {
                drpProdNo.DataSource = dsData.Tables[0];
                drpProdNo.DataTextField = "ProductDesc";
                drpProdNo.DataValueField = "ProductID";
                drpProdNo.DataBind();

                dsData.Dispose();
            }
        }

        private void LoadTechnician()
        {
            DataSet dsData;
            dsData = clsDatabase.GetTechnicianList();
            if (dsData == null)
            {
                lblerror.Text = "Error retrieving Technicians";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblerror.Text = "Error retrieving Technicians";
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                InsertProblem();
                txtProblem.Text = "";
                //lblerror.Text = "Problem Inserted";
                intProblemNo = Convert.ToInt32(txtProblemNo.Text);
                intProblemNo = intProblemNo + 1;
                txtProblemNo.Text = intProblemNo.ToString();

            }
        }

        //*********** ValidateFields() ******************//
        private Boolean ValidateFields()
        {
            Boolean blnOK = true;
            String strMessage = "";
            lblerror.Text = "";
            
            if (txtProblem.Text.Trim().Length < 1)
            {
                blnOK = false;
                strMessage += "Problem Description is required";
            }
            lblerror.Text = strMessage;
            return blnOK;
        }

        private void InsertProblem()
        {
            Int32 intRetValue;
            lblerror.Text = "";

            intRetValue = clsDatabase.InsertProblem(Convert.ToInt32(txtTicketNo.Text.Trim()),Convert.ToInt32(txtProblemNo.Text.Trim()),
                txtProblem.Text.Trim(), Convert.ToInt32(drpTechID.SelectedValue.ToString()), drpProdNo.SelectedValue.ToString());
            if (intRetValue == 0)
            {
                lblerror.Text = "New Problem Created";
            }
            else
            {
                lblerror.Text = "Problem Cannot be created";
            }
             
        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
       
    }
}