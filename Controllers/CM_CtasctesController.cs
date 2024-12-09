
using CreditosApi.Entities.AUDITORIA;
using CreditosApi.Entities.HELPERS;
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



        [HttpGet]
        public ActionResult GetDetalleDeuda(int nro_transaccion)
        {
            var Ctasctes = _CM_CtasctesService.GetDeuda(nro_transaccion);

            return Ok(Ctasctes);
        }

        [HttpPost]
        public IActionResult InsertNuevaDeuda(Credito_CtasctesAuditoria obj)
        {
            try
            {
                _CM_CtasctesService.InsertNuevaDeuda(obj);

                return Ok(new { message = "Se ha insertado nueva deuda CtaCte." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al intentar deuda: " + ex.Message);
            }
        }


        [HttpDelete]
        public IActionResult EliminarDeuda(int tipo_transaccion, int nro_transaccion, Auditoria obj)
        {
            try
            {
                _CM_CtasctesService.DeleteDeudaCtaCte(tipo_transaccion, nro_transaccion, obj);
                return Ok(new { message = "Se ha eliminado correctamente la deuda {legajo} ." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al eliminar la deuda: " + ex.Message);
            }
        }



        [HttpGet]
        public ActionResult  getListDeudaCredito(int id_credito_materiales)
        {
            var Ctasctes = _CM_CtasctesService.getListDeudaCredito(id_credito_materiales);

            return Ok(Ctasctes);
        }

    }
}