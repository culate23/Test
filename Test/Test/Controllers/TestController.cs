using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private string cnn = "";

        public TestController(IConfiguration configuration)
        {
            IConfiguration _configuration = configuration;

            cnn = configuration.GetConnectionString("cnn");
        }

        [HttpPost]
        public List<Model.Output> CalculaCosto(int Capacity, int hours)
        {
            int residuo = Capacity % 10;
            //string retorno = string.Empty;
            Logic.Test test = new Logic.Test();
            test.cnn = cnn;
            List<Model.Output> retorno;

            if (residuo == 0) 
            {
               retorno = test.calcularCosto(Capacity, hours);
            }
            else
            {
                retorno = new List<Model.Output>();
            }
            
            return retorno;
            
        }
    }
}
