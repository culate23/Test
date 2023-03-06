using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionTypeController : Controller
    {
        private string cnn = "";

        public RegionTypeController(IConfiguration configuration) 
        {
            IConfiguration _configuration = configuration;

            cnn = configuration.GetConnectionString("cnn");
        }

        [HttpPost]
        public string Create([FromBody] Model.RegionType regionType)
        {
            Logic.RegionType region = new Logic.RegionType(regionType);
            return region.Create(cnn) ? "Guardado con éxito" : "Error al guardado";
        }

        [HttpPut]
        public string Update([FromBody] Model.RegionType regionType)
        {
            Logic.RegionType region = new Logic.RegionType(regionType);
            return region.Update(cnn) ? "Guardado con éxito" : "Error al guardado";
        }

        [HttpDelete]
        public string Delete([FromBody] Model.RegionType regionType)
        {
            Logic.RegionType region = new Logic.RegionType(regionType);
            return region.Delete(cnn) ? "Eliminado con éxito" : "Error al eliminar";
        }

        [HttpGet]
        public List<Model.RegionType> GetAll()
        {
            Logic.RegionType region = new Logic.RegionType();
            return region.GetRegions(cnn);
        }

        [HttpGet("{idRegion}")]
        public List<Model.RegionType> GetOne(int idRegion)
        {
            Logic.RegionType region = new Logic.RegionType();
            return region.GetRegions(cnn, "Where rt.idRegion = " + idRegion);
        }
    }
}
