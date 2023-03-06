using System.Runtime.CompilerServices;

namespace Model
{
    public class Region
    {
        private int idRegion;
        private string regionName;

        public int IdRegion { get => idRegion; set => idRegion = value; }
        public string RegionName { get => regionName; set => regionName = value; }

        public Region() { }

        public Region(int pidRegion, string pRegionName) 
        {
           IdRegion = pidRegion;
            RegionName = pRegionName;
        }
    }
}