using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CapacityTypeController : Controller
    {
        private string cnn = "";

        public CapacityTypeController(IConfiguration configuration)
        {
            IConfiguration _configuration = configuration;

            cnn = configuration.GetConnectionString("cnn");
        }


        [HttpPost]
        public string Create([FromBody] Model.CapacityType pcapacityType)
        {
            Logic.CapacityType capacityType = new Logic.CapacityType(pcapacityType);
            return capacityType.Create(cnn) ? "Guardado con éxito" : "Error al guardado";
        }

        [HttpPut]
        public string Update([FromBody] Model.CapacityType pcapacityType)
        {
            Logic.CapacityType capacityType = new Logic.CapacityType(pcapacityType);
            return capacityType.Update(cnn) ? "Guardado con éxito" : "Error al guardado";
        }

        [HttpDelete]
        public string Delete([FromBody] Model.CapacityType pcapacityType)
        {
            Logic.CapacityType capacityType = new Logic.CapacityType(pcapacityType);
            return capacityType.Delete(cnn) ? "Eliminado con éxito" : "Error al eliminar";
        }

        [HttpGet]
        public List<Model.CapacityType> GetAll()
        {
            Logic.CapacityType capacityType = new Logic.CapacityType();
            return capacityType.GetcapacityTypes(cnn);
        }

        [HttpGet("{pIdCapacityType}")]
        public List<Model.CapacityType> GetOne(int pIdCapacityType)
        {
            Logic.CapacityType capacityType = new Logic.CapacityType();
            return capacityType.GetcapacityTypes(cnn, "Where idTipoCapacidad = " + pIdCapacityType.ToString());
        }
    }
}
