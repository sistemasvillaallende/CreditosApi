using CreditosApi.Entities.AUDITORIA;
using CreditosApi.Entities.HELPERS;
using CreditosApi.Helpers;
using CreditosApi.Model;
using CreditosApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace CreditosApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CM_Credito_materialesController : ControllerBase
    {

        private ICM_Credito_materialesServices _CM_Credito_materialesService;
        private ICM_Ctasctes_credito_materialesServices _CM_CtasctesServices;


        public CM_Credito_materialesController(ICM_Credito_materialesServices CM_Credito_MaterialesServices
        , ICM_Ctasctes_credito_materialesServices CM_CtasctesServices)
        {
            _CM_Credito_materialesService = CM_Credito_MaterialesServices;
            _CM_CtasctesServices = CM_CtasctesServices;
        }

        [HttpGet]
        public IActionResult GetAllCreditos()
        {
            try
            {
                var lstCredito = _CM_Credito_materialesService.GetAllCreditos();


                if (lstCredito.Count == 0)
                {
                    return NotFound(new { message = $"No se ha encontrado creditos." });
                }
                return Ok(lstCredito);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al obtener todos los credito: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertNuevoCredito(Credito_materialesAuditoria obj)
        {
            try
            {
                _CM_Credito_materialesService.InsertNuevoCredito(obj);

                return Ok(new { message = "Se ha insertado nuevo credito." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al intentar insertar nuevo credito: " + ex.Message);
            }
        }


        [HttpPut]
        public IActionResult UpdateCredito(int legajo, int id_credito_materiales, Credito_materialesAuditoria obj)
        {
            try
            {
                var lstCtactes = _CM_CtasctesServices.GetListTodasDeudas(id_credito_materiales);

                if (lstCtactes.Any(cta => cta.pagado == 1))
                {

                    return BadRequest(new { message = "No se puede modificar credito por presentar almenos una cuota pagada" });
                }

                _CM_Credito_materialesService.UpdateCredito(legajo, id_credito_materiales, obj);

                return Ok(new { message = $"Se ha modificado el credito con id : {id_credito_materiales} ." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al intentar modificar nuevo credito: " + ex.Message);
            }
        }


        [HttpPut]
        public IActionResult BajaCredito(int legajo, int id_credito_materiales, Auditoria obj)
        {
            try
            {
                var lstCtactes = _CM_CtasctesServices.GetListTodasDeudas(id_credito_materiales);

                if (lstCtactes.Any(cta => cta.pagado == 1))
                {
                    return BadRequest(new { message = "No se puede dar de baja el  credito por presentar almenos una cuota pagada" });
                }

                _CM_Credito_materialesService.BajaCredito(legajo, id_credito_materiales, obj);

                return Ok(new { message = $"Se ha dado de baja correctamente el credito con legajo {legajo} ." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al intentar dar de baja credito: " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult AltaCredito(int id_credito_materiales, Auditoria obj)
        {
            try
            {
                _CM_Credito_materialesService.AltaCredito(id_credito_materiales, obj);

                return Ok(new { message = $"Se ha dado de alta correctamente el credito con ID {id_credito_materiales} ." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al intentar dar de alta credito: " + ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult EliminarCredito(int legajo, int id_credito_materiales, Auditoria obj)
        {
            try
            {
                var lstCtactes = _CM_CtasctesServices.GetListTodasDeudas(id_credito_materiales);

                if (lstCtactes.Any(cta => cta.pagado == 1))
                {
                    return BadRequest(new { message = "No se puede eliminar credito por presentar almenos una cuota pagada" });
                }

                _CM_Credito_materialesService.DeleteCredito(legajo, id_credito_materiales, obj);

                return Ok(new { message = $"Se ha eliminado correctamente el credito con legajo {legajo} ." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al eliminar credito: " + ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<PaginadorGenerico<Entities.CM_Credito_materiales>> GetCreditoMPaginado(
           string buscarPor = "0", string? strParametro = "", int pagina = 1, int registros_por_pagina = 10)
        {

            List<Entities.CM_Credito_materiales> _Creditos_Materiales;

            PaginadorGenerico<Entities.CM_Credito_materiales> _PaginadorCM;

            int _TotalRegistros;
            int _TotalPaginas;
            _TotalRegistros = _CM_Credito_materialesService.Count();


            _Creditos_Materiales = _CM_Credito_materialesService.GetCreditoMPaginado(buscarPor, strParametro, pagina, registros_por_pagina);

            if (_Creditos_Materiales != null && _Creditos_Materiales.Count() > 0)
            {

                _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);

                _PaginadorCM = new PaginadorGenerico<Entities.CM_Credito_materiales>()
                {
                    RegistrosPorPagina = registros_por_pagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    BusquedaPor = buscarPor,
                    Parametro = strParametro,
                    Resultado = _Creditos_Materiales
                };


                return _PaginadorCM;
            }
            else
                return null;
        }




        [HttpGet]
        public IActionResult GetCreditoById(int id_credito_materiales)
        {
            try
            {
                var credito = _CM_Credito_materialesService.GetCreditoById(id_credito_materiales);


                if (credito == null)
                {
                    return NotFound(new { message = $"No se ha encontrado el credito con id : {id_credito_materiales} ." });
                }
                return Ok(credito);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al obtener credito: " + ex.Message);
            }
        }

    }
}