using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBooru
{
    class SearchResult
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string locationType;
        public string LocationType
        {
            get { return locationType;}
            set { locationType = value;}
        }

        private string location;
        public string Location
        {
          get { return location; }
          set { location = value; }
        }
        
        private string type;
        public string Type
        {
          get { return type; }
          set { type = value; }
        }

        public SearchResult(string inName, string inLocationType, string inLocation, string inType)
        {
            name = inName;
            locationType = inLocationType;
            location = inLocation;
            type = inType;
        }

        public string ToString()
        {
            string outString = "Result " + name + ": Location type " + locationType + ", location " + location + ", content type " + type + ".";
            return outString;
        }
    }
}
