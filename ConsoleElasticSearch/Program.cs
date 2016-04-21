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
            for (int i = 1; i < 100; i++)
            {
                _log.Info("console test log " + i);  
            }

            var geoLocations = new List<GeoLocation>();

            List<GeoLocation> geoLocations2;
            try
            {
                using (StreamReader readFile = new StreamReader(@"D:\longlat\isocodes.csv"))
                {
                    string line;
                    string[] row;
                    int rowcount = 0;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        geoLocations.Add( new GeoLocation {
                            IsoCode = row[0],
                            Latitude = row[1],
                            Longitude = row[2]
                        });

                        Console.WriteLine(string.Format("Processed row number => {0}", ++rowcount));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, geoLocations);
                }
            }
            catch (IOException)
            {
            }

            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    geoLocations2 = (List<GeoLocation>)bin.Deserialize(stream);


                    GeoLocation result = geoLocations2.Single(s => s.IsoCode == "GB");
                    //foreach (GeoLocation geolocation in geoLocations2)
                    //{
                    //    Console.WriteLine("{0}, {1}, {2}",
                    //        geolocation.IsoCode,
                    //        geolocation.Latitude,
                    //        geolocation.Longitude);
                    //}
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
