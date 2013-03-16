 public class Coordinate 
 {
        public string _description;
        public double _distanceTolerance;
        public double _latitude;
        public double _longitude;

       
        public Coordinate(double latitude, double longitude, string description, double distanceTolerance)
        {
            this._latitude = latitude;
            this._longitude = longitude;
            this._description = description;
            this._distanceTolerance = distanceTolerance;
            
        }
}




//Use this function for getting distance between two coordinates

private double CalculateDistanceBetweenTwoCoordinates(Coordinate coordinate1, Coordinate coordinate2)
        {
            double num = 3956.0871;
            double d = (coordinate1._latitude / 180.0) * 3.1415926535897931;
            double num3 = (coordinate1._longitude / 180.0) * 3.1415926535897931;
            double num4 = (coordinate2._latitude / 180.0) * 3.1415926535897931;
            double num5 = (coordinate2._longitude / 180.0) * 3.1415926535897931;
            double num6 = (num * 2.0) * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((d - num4) / 2.0), 2.0) + ((Math.Cos(d) * Math.Cos(num4)) * Math.Pow(Math.Sin((num3 - num5) / 2.0), 2.0))));
            return (num6 * 1.609344);
        }


//Function to get address from Google maps

  public  string GetAddress(string longitude, string latitude)
        {
            string str = longitude.ToString();
            string str2 = latitude.ToString();
            str = str.Replace(',', '.');
            str2 = str2.Replace(',', '.');


            XmlDocument doc = new XmlDocument();
            string address = "", tempadd = "";
            try
            {
             
                doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false");
                XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");

                tempadd = element.InnerText;
                if (element.InnerText == "ZERO_RESULTS")
                {
                    return ("");
                }
                else
                {
                    element = doc.SelectSingleNode("//GeocodeResponse/result/formatted_address");
                    tempadd = element.InnerText;
                    address = element.InnerText;
                    Thread.Sleep(200);

                    // XmlNodeList xnList = doc.SelectNodes("//GeocodeResponse/result/address_component");

                    //Console.ReadKey();
                    return address;
                }
            }
            catch (Exception ex)
            {
                string errormessage = "Logger update  to gateway failed in function-GetAddressfromGoogleMaps-" + ex.InnerException.Message;
                Logger.ErrorException(errormessage, ex);
                return ("");
            }
        }
