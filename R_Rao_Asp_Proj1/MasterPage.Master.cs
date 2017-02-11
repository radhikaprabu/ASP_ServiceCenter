using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace R_Rao_Asp_Proj1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ConfigurationManager.AppSettings["ApplicationName"] != null)
                {
                    lblMaster.Text = ConfigurationManager.AppSettings["ApplicationName"].ToString();
                }
                txtDate.Text = DateTime.Now.ToString();
            }
        }
    }
}