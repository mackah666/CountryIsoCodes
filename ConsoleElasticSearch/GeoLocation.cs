using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleElasticSearch
{
    [Serializable]
    public class GeoLocation
    {
        public string IsoCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
