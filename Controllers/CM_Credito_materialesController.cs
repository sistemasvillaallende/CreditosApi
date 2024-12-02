using CreditosApi.Helpers;
using CreditosApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace CreditosApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CM_Credito_materialesController : ControllerBase
    {

        private ICM_Credito_materialesServices _CM_Credito_materialesService;


        public CM_Credito_materialesController(ICM_Credito_materialesServices CM_Credito_MaterialesServices)
        {
            _CM_Credito_materialesService = CM_Credito_MaterialesServices;
        }


        [HttpGet]
        public IActionResult GetHola()
        {
            return Ok("hola");
        }

        [HttpGet]
        public ActionResult<PaginadorGenerico<Entities.CM_Credito_materiales>> GetCreditoMPaginado(
           string buscarPor = "0", string strParametro = "0", int pagina = 1, int registros_por_pagina = 10)
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





    }
}