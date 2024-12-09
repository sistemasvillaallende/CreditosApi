
using CreditosApi.Entities.AUDITORIA;
using CreditosApi.Entities.HELPERS;
using CreditosApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace CreditosApi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]

    public class CM_Cate_deudaController : ControllerBase
    {

        private ICM_Cate_deuda_creditoServices _CM_CateService;


        public CM_Cate_deudaController(ICM_Cate_deuda_creditoServices CM_CateService)
        {
            _CM_CateService = CM_CateService;
        }


        [HttpGet]
        public ActionResult  GetCategoriasDeuda()
        {
            var lst = _CM_CateService.GetCategoriaDeuda();

            return Ok(lst);
        }

    }
}