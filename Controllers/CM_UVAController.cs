
using CreditosApi.Entities.AUDITORIA;
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
        public ActionResult GetValorUva()
        {
            try
            {
                var lst = _UVAService.GetValorUva();
                return Ok(lst);

            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public IActionResult InsertValorUVA(int valor_uva, Auditoria auditoria)
        {
            try
            {
                if (valor_uva == 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "El valor del UVA es requerido.",
                        errorCode = "INVALID_DATA"
                    });
                }

                _UVAService.insertValorUVA(valor_uva, auditoria);

                return Ok(new
                {
                    success = true,
                    message = "Valor del UVA creado exitosamente.",
                });

            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error interno. Intente nuevamente más tarde.",
                    errorCode = "INTERNAL_ERROR",
                    details = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ? ex.Message : null
                });
            }
        }

    }
}