using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Logic;
using Model;
using Database;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private string cnn = "";
        public RegionController(IConfiguration configuration)
        {
            IConfiguration _configuration = configuration;

            cnn = configuration.GetConnectionString("cnn");
        }

        [HttpPost]
        public string Create([FromBody] Model.Region pregion)
        {
           Logic.Region region = new Logic.Region(pregion);

            return region.Create(cnn) ? "Guardado con éxito": "Error al guardado";
        }

        [HttpPut]
        public string Update([FromBody] Model.Region pregion)
        {
            Logic.Region region = new Logic.Region(pregion);

            return region.Update(cnn) ? "Guardado con éxito" : "Error al guardado";
        }

        [HttpDelete]
        public string Delete([FromBody] Model.Region pregion)
        {
            Logic.Region region = new Logic.Region(pregion);

            return region.Delete(cnn) ? "Eliminado con éxito" : "Error al eliminar";
        }

        [HttpGet]
        public List<Model.Region> GetAll()
        {
            Logic.Region region = new Logic.Region();

            return region.GetRegions(cnn);
        }

        [HttpGet("{pIdRegion}")]
        public List<Model.Region> GetOne(int pIdRegion)
        {
            Logic.Region region = new Logic.Region();

            return region.GetRegions(cnn, "Where idRegion = " + pIdRegion.ToString());
        }
    }
}
