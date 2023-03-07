using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CapacityType
    {
        private int idCapacityType;
        private string nameCapacityType;
        private int quantityUnits;

        public int IdCapacityType { get => idCapacityType; set => idCapacityType = value; }
        public string NameCapacityType { get => nameCapacityType; set => nameCapacityType = value; }
        public int QuantityUnits { get => quantityUnits; set => quantityUnits = value; }

        public CapacityType() { }

        public CapacityType(int idCapacityType, string nameCapacityType, int quantityUnits)
        {
            IdCapacityType = idCapacityType;
            NameCapacityType = nameCapacityType;
            QuantityUnits = quantityUnits;
            IdCapacityType = idCapacityType;
            NameCapacityType = nameCapacityType;
            QuantityUnits = quantityUnits;
        }
    }
}
