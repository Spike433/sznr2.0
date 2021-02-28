using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Input : Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

                       
               
            
            }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
                    
            string text = start.SelectedValue + Environment.NewLine + stop.SelectedValue + Environment.NewLine + delay.SelectedValue + Environment.NewLine;
            File.WriteAllText(Server.MapPath("~/text.txt"), text);

            Response.Redirect("Default.aspx");


        }
    }
}