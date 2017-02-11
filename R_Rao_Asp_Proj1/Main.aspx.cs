using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace R_Rao_Asp_Proj1
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnManageTechs_Click(object sender, EventArgs e)
        {
            Response.Redirect("TechInfo.aspx");
        }

        protected void btnService_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceEvent.aspx");
        }

        protected void btnProblem_Click(object sender, EventArgs e)
        {
            Response.Redirect("Open Problems.aspx");
        }

        protected void btnReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportSelection.aspx");
        }
    }
}