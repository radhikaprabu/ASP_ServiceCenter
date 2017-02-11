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
    public partial class Open_Problems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = "";
                LoadOpenProblems();
            }
        }

        //***********************************************//
        //********LoadOpenProblems***********************//
        private void LoadOpenProblems()
        {
            DataSet dsData;

            lblError.Text = "";

            dsData = clsDatabase.GetOpenProblems();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Products";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Products";
                dsData.Dispose();
            }
            else
            {
                gvProblems.DataSource = dsData.Tables[0];
                gvProblems.DataBind();

                dsData.Dispose();
            }
        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void gvProblems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Boolean blnOK = false;
            Int32 intTicketID;
            Int32 intProblemNo;
            if (e.CommandName.Trim().ToUpper() == "SELECT")
            {
                
                    intTicketID = Convert.ToInt32(gvProblems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
                    intProblemNo = Convert.ToInt32(gvProblems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);

                
                    Session["TicketID"] = intTicketID;
                    Session["ProblemNo"] = intProblemNo;
                    Response.Redirect("Resolution.aspx");
                
            }
        }

        protected void gvProblems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}