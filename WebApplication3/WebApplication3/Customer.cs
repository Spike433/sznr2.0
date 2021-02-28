using System;


namespace WebApplication3
{
    public class Customer: IComparable
    {

        //?param1=20190614T041236&param2=car&api_key=M6N015C8W6ALJ

        private string parsedParam1;
        private string param1Temp;
                
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string api_key { get; set; }        
        public string ParsedParam1 { get => etParsedParam1(); set => parsedParam1 = value; }

        public string GetParam1Temp()
        {
            
            return param1Temp;
        }
        public void SetParam1Temp(string valu)
        {
            param1Temp = valu;
        }

        public string etParsedParam1()
        {
            String formatFromAndroid = "yyyyMMddTHHmmss";

            DateTime parsedLine = DateTime.ParseExact(param1, formatFromAndroid, null);
            
            return parsedLine.ToString(" HH:mm  dd.MM.yyyy.");
        }

        

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Customer other = obj as Customer;

            if (other != null)
            {
                String formatFromAndroid = "yyyyMMddTHHmmss";

                DateTime otherDateTime = DateTime.ParseExact(other.param1, formatFromAndroid, null);

                DateTime param1DateTime = DateTime.ParseExact(this.param1, formatFromAndroid, null);

                return param1DateTime.CompareTo(otherDateTime);

            }
            else
                throw new ArgumentException("Object is not a Customer");
        }



    }
}