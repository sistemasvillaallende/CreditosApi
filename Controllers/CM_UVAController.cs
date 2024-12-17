
using CreditosApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace CreditosApi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]

    public class CM_UVAController : ControllerBase
    {
        private ICM_UVAServices _UVAService;

        public CM_UVAController(ICM_UVAServices UVAService)
        {
            _UVAService = UVAService;
        }

        [HttpGet]
        public ActionResult  GetValorUva()
        {
            var lst = _UVAService.GetValorUva();

            return Ok(lst);
        }

    }
}