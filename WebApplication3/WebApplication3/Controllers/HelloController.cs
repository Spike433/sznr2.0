using Itenso.TimePeriod;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebApplication3;



namespace HelloWebAPI.Controller
{

    public class HelloController : ApiController

    {
        //POST https://localhost:44346/api/hello?param1=20190614T041236&param2=car&api_key=M6N015C8W6ALJ

        //GET https://localhost:44346/api/hello?id=0

        private static List<Customer> customers = new List<Customer>();

        private static string[] workTimeString;

        public static void setWorkTime(string[] work)
        {
            workTimeString = work;
        }

        private int delay;      

        public List<Customer> DobaviList()
        {
            customers.Sort();

            return customers;
        }

        public HttpResponseMessage Get(int id)
        {
            if (id == 0)
            {
                customers = new List<Customer>();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage GetWork(int work)
        {
            if (work == 0)
            {
                WorkTime workTime = new WorkTime();
                workTime.start = workTimeString[0];
                workTime.stop  = workTimeString[1];
                workTime.delay = workTimeString[2];
                return Request.CreateResponse(HttpStatusCode.Created, workTime);

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public void DeleteOld()
        {
            bool[] deleteCustomers = new bool[customers.Count];

            int i = -1;

            String formatFromAndroid = "yyyyMMddTHHmmss";


            foreach (Customer customer1 in customers)
            {
                i++;

                string line = customer1.param1;


                DateTime parsedLine = DateTime.ParseExact(line, formatFromAndroid, null);

                if (parsedLine < DateTime.Now)
                {
                    deleteCustomers[i] = true;
                }

            }
            
            for (int j = 0; j < deleteCustomers.Length; j++)
            {
                if (deleteCustomers[j])
                {
                    customers.RemoveAt(j);
                }
            }
        }

        
        
        public HttpResponseMessage Post(string param1, string param2, string api_key)
        {
            Customer customer = new Customer();
            customer.param1 = param1;
            customer.param2 = param2;
            customer.api_key = api_key;
            delay=int.Parse(workTimeString[2]);


            if (customer.api_key == "M6N015C8W6ALJ")
            {

                String formatFromAndroid = "yyyyMMddTHHmmss";

                DateTime dateTime = DateTime.ParseExact(customer.param1, formatFromAndroid, null);

                DateTime dateTimeTemp = dateTime;
                
                dateTime = dateTime.Add(new TimeSpan(0, -delay, 0));
                customer.SetParam1Temp(dateTime.ToString(formatFromAndroid));

                ITimePeriod timePeriod = new TimeBlock(dateTimeTemp);

                TimePeriodCollection timePeriods = new TimePeriodCollection();

                
                foreach (Customer customer1 in customers)
                {

                    string line = customer1.GetParam1Temp();

                    DateTime parsedLine = DateTime.ParseExact(line, formatFromAndroid, null);
                                        
                    timePeriods.Add(new TimeBlock(parsedLine, Duration.Minutes(delay*2)));

                    if (timePeriods.Last().IntersectsWith(timePeriod))
                    {
                        List<CustSecret> custSecrets = new List<CustSecret>();

                        foreach(Customer customer2 in customers)
                        {
                            CustSecret custSecret = new CustSecret();
                            custSecret.param1 = customer2.param1;
                            custSecrets.Add(custSecret);
                        }

                        return Request.CreateResponse(HttpStatusCode.Created, custSecrets);

                    }


                }
                                           
                customers.Add(customer);
                return Request.CreateResponse(HttpStatusCode.OK);

            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        } 
        
    }


}