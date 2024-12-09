
using CreditosApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace CreditosApi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]

    public class BadecController : ControllerBase
    {
        private IBadecServices _badecService;

        public BadecController(IBadecServices badecService)
        {
            _badecService = badecService;
        }

        [HttpGet]
        public ActionResult  GetBadecByCuit(string cuit)
        {
            var lst = _badecService.GetDatosByCuit(cuit);

            return Ok(lst);
        }

    }
}