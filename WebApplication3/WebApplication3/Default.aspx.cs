using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWebAPI.Controller;


namespace WebApplication3
{
    public partial class _Default : Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            HelloController helloController = new HelloController();            

            string[] spl=readFile();
            HelloController.setWorkTime(spl);

                     Label1.Text = "<h4><br/> Radno vrijeme : " + spl[0] + " - " + spl[1] + "<br/> <br/>Trajanje : " + spl[2]+" min</h4>";
           
            //         helloController.Delay = int.Parse(cookie["Delay"]);


            //   Label1.Text = String.Format("Postavite radno vrijeme i trajanje: <a href=\"{0}\">{1}</a>", "https://szn.azurewebsites.net/Input", "ovdje") ;

            helloController.DeleteOld();
            List<Customer> customers = helloController.DobaviList();
            
            lv_Members.DataSource = customers;
            lv_Members.DataBind();
            


        }

        public string[] readFile()
        {
            string text = File.ReadAllText(Server.MapPath("~/text.txt"));
            string[] spl = text.Split('\n');

            return spl;

        }
    }
}