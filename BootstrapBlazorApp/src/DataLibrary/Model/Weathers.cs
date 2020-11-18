using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    public class Weathers
    {
        public string success { get; set; }
        public Records records { get; set; }
    }

    public class Records
    {
        public string datasetDescription { get; set; }
        public List<Location> location { get; set; }
    }

    public class Location
    {
        public string locationName { get; set; }
        public List<Weatherelement> weatherElement { get; set; }
    }

    public class Weatherelement
    {
        public string elementName { get; set; }
        public List<Time> time { get; set; }
    }

    public class Time
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Parameter parameter { get; set; }
    }

    public class Parameter
    {
        public string parameterName { get; set; }
        public string parameterValue { get; set; }
        public string parameterUnit { get; set; }
    }

}
