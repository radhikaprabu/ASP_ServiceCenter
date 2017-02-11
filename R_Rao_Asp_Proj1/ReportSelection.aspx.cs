using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace R_Rao_Asp_Proj1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void btnTechnician_Click(object sender, EventArgs e)
        {
            Session.Contents["Title"] = "Problems By Technician";
            Session.Contents["Report"] = "uspProblemsByTechnician";
            Response.Redirect("Report.aspx");
        }

        protected void btnClient_Click(object sender, EventArgs e)
        {
            Session.Contents["Title"] = "Problems By Client";
            Session.Contents["Report"] = "uspProblemsByClient";
            Response.Redirect("Report.aspx");
        }

        protected void btnInstitution_Click(object sender, EventArgs e)
        {
            Session.Contents["Title"] = "Problems By Institution";
            Session.Contents["Report"] = "uspProblemsByInstitution";
            Response.Redirect("Report.aspx");
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            Session.Contents["Title"] = "Problems By Product";
            Session.Contents["Report"] = "uspProblemsByProduct";
            Response.Redirect("Report.aspx");
        }
       
        
    }
}