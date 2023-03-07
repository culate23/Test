using Model;
using Database;

namespace Logic
{
    public class Region
    {
        Model.Region model = new Model.Region();
        public Region() 
        {
            model.IdRegion = 0;
            model.RegionName = string.Empty;
        }

        public Region(Model.Region pregion) 
        {
            this.model = pregion;
        }


        public bool Create(string cnn)
        {
            Database.Region region = new Database.Region();
            return region.Create(model, cnn);

        }

        public bool Update(string cnn)
        {
            Database.Region region = new Database.Region();
            return region.Update(model, cnn);
        }

        public bool Delete(string cnn) 
        {
            Database.Region region = new Database.Region();
            return region.Delete(model, cnn);
        }

        public List<Model.Region> GetRegions(string cnn, string where = "")
        {
            Database.Region region = new Database.Region();
            return region.Get(cnn, where);
        }

        public int countRegion(string cnn)
        {
            Database.Region region = new Database.Region();
            return region.countRegion(cnn);
        }

    }
}