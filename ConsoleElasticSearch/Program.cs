using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleElasticSearch
{
    class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {

            var isoCodeDictionary = new Dictionary<string, CountryIsoCode>();

            


            var geoLocations = new List<GeoLocation>();

            var countryIsoCodes = new List<CountryIsoCode>();
            List<CountryIsoCode> countryIsoCodes2;

            List<GeoLocation> geoLocations2;
            try
            {
                using (StreamReader readFile = new StreamReader(@"D:\longlat\Country_Dict_ISO_3166_Codes.csv"))
                {
                    string line;
                    string[] row;
                    int rowcount = 0;
                    //Country,  alpha2, alpha3, numeric, Latitude, Longitude
                    //Albania,  AL,     ALB,    8,       41,       20,

                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        isoCodeDictionary.Add(row[1],new CountryIsoCode {
                            Country = row[0],
                            AlphaTwoCode = row[1],
                            AlphaThreeCode = row[2],
                            Latitude = row[4],
                            Longitude = row[5]

                        });
                        Console.WriteLine(row[1]);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                //_log.ErrorFormat(
                _log.ErrorFormat("My {0} message: {1}", "pretty", ex);
            }


            try
            {
                using (Stream stream = File.Open("data_full_dict.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, countryIsoCodes);
                }
            }
            catch (IOException)
            {
            }

            try
            {
                using (Stream stream = File.Open("data_full_dict.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    countryIsoCodes2 = (List<CountryIsoCode>)bin.Deserialize(stream);
                   
                }
            }
            catch (IOException)
            {
            }
           

          

            Console.ReadKey();
            //using (StreamReader r = new StreamReader("data.json"))
            //{
            //    string json = r.ReadToEnd();
            //    dynamic array = JsonConvert.DeserializeObject(json);




            //    //var found = array.
            //    foreach (var item in array)
            //    {
            //        Console.WriteLine("{0} {1}", item.Name, item.Value);


            //        //geoLocations.Add(new GeoLocation
            //        //{
            //        //    IsoCode = item.Name,
            //        //    Longitude = item.Value
            //        //});
            //    }

            //}

        }
    }
}
