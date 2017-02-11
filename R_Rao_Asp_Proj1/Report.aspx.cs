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
    public partial class WebForm2 : System.Web.UI.Page
    {
        String strReport;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTitle.Text = Session.Contents["Title"].ToString();
            strReport = Session.Contents["Report"].ToString();
            LoadReports();
        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportSelection.aspx");
        }

        //***********************************************//
        //********LoadReports***********************//
        //***********************************************//
        private void LoadReports()
        {
            DataSet dsData;
            lblError.Text = "";
            dsData = clsDatabase.GetReport(strReport);
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Report";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Report";
                dsData.Dispose();
            }
            else
            {
                gvReport.DataSource = dsData.Tables[0];
                gvReport.DataBind();
                dsData.Dispose();
            }
            
        }

     
    }
}