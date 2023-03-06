using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CapacityType
    {
        Model.CapacityType model = new Model.CapacityType();

        public CapacityType() 
        {
            model.IdCapacityType = 0;
            model.NameCapacityType = string.Empty;
            model.QuantityUnits = 0;
        }

        public CapacityType(Model.CapacityType model)
        {
            this.model = model;
        }

        public bool Create(string cnn)
        {
            Database.CapacityType capacityType = new Database.CapacityType();
            return capacityType.Create(model, cnn);

        }

        public bool Update(string cnn)
        {
            Database.CapacityType capacityType = new Database.CapacityType();
            return capacityType.Update(model, cnn);
        }

        public bool Delete(string cnn)
        {
            Database.CapacityType capacityType = new Database.CapacityType();
            return capacityType.Delete(model, cnn);
        }

        public List<Model.CapacityType> GetcapacityTypes(string cnn, string where = "")
        {
            Database.CapacityType capacityType = new Database.CapacityType();
            return capacityType.Get(cnn, where);
        }

        public int countCapatyType(string cnn, int id)
        {
            Database.CapacityType capacityType = new Database.CapacityType();
            return capacityType.countCapatyType(cnn, id);
        }
    }
}
