
using CreditosApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace CreditosApi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]

    public class CM_CtasctesController : ControllerBase
    {

        private ICM_Ctasctes_credito_materialesServices _CM_CtasctesService;


        public CM_CtasctesController(ICM_Ctasctes_credito_materialesServices CM_CtasctesService)
        {
            _CM_CtasctesService = CM_CtasctesService;
        }





        // [HttpGet]
        // public ActionResult ListarCtacte()
        // {

        // }


        // [HttpPost]
        // public IActionResult Reliquidar_Deuda(string dominio, List<Ctasctes_automotores> lst)
        // {


        // }
        // [HttpPost]
        // public IActionResult Confirma_reliquidacion(CtasCtes_Con_Auditoria obj)
        // {

        // }

        [HttpGet]
        public ActionResult GetDetalleDeuda(int nro_transaccion, int nro_item)
        {
            var Ctasctes = _CM_CtasctesService.GetDeuda(nro_transaccion, nro_item);

            return Ok(Ctasctes);
        }




    }
}