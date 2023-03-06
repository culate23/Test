using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RegionType
    {
        private int idRegion;
        private int idCapacityType;
        private float cost;
        private string regionName;
        private string capacityName;

        public int IdRegion { get => idRegion; set => idRegion = value; }
        public int IdCapacityType { get => idCapacityType; set => idCapacityType = value; }
        public float Cost { get => cost; set => cost = value; }
        public string RegionName { get => regionName; set => regionName = value; }
        public string CapacityName { get => capacityName; set => capacityName = value; }

        public RegionType() { }

        public RegionType(int idRegion, int idCapacityType, float cost)
        {
            IdRegion = idRegion;
            IdCapacityType = idCapacityType;
            Cost = cost;
        }

        public RegionType(int idRegion, int idCapacityType, float cost, string regionName, string capacityName)
        {
            this.regionName = regionName;
            this.capacityName = capacityName;
            IdRegion = idRegion;
            IdCapacityType = idCapacityType;
            Cost = cost;
            RegionName = regionName;
            CapacityName = capacityName;
        }
    }
}
