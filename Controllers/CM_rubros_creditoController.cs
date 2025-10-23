
using CreditosApi.Entities.AUDITORIA;
using CreditosApi.Entities.HELPERS;
using CreditosApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace CreditosApi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]

    public class CM_rubros_creditoController : ControllerBase
    {

        private ICM_rubro_creditoService _CM_RubroService;


        public CM_rubros_creditoController(ICM_rubro_creditoService CM_RubroService)
        {
            _CM_RubroService = CM_RubroService;
        }


        [HttpGet]
        public ActionResult  GetRubros()
        {
            var lst = _CM_RubroService.GetRubros();

            return Ok(lst);
        }

    }
}