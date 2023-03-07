using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class RegionType
    {
        Model.RegionType model = new Model.RegionType();
        
        public RegionType() 
        {
            model.IdRegion = 0;
            model.IdCapacityType = 0;
            model.Cost = 0;
        }

        public RegionType(Model.RegionType model)
        {
            this.model = model;
        }

       public bool Create(string cnn)
       {
           Database.RegionType region = new Database.RegionType();
           return region.Create(model, cnn);
       }

        public bool Update(string cnn)
        {
            Database.RegionType region = new Database.RegionType();
            return region.Update(model, cnn);
        }

        public bool Delete(string cnn)
        {
            Database.RegionType region = new Database.RegionType();
            return region.Delete(model, cnn);
        }

        public List<Model.RegionType> GetRegions(string cnn, string where = "")
        {
            Database.RegionType region = new Database.RegionType();
            return region.Get(cnn, where);
        }
    }
}
