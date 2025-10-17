using System.Data.SqlClient;
using CreditosApi.Entities;
using CreditosApi.Entities.AUDITORIA;

namespace CreditosApi.Services
{
  public class CM_UVAServices : ICM_UVAServices
  {


    private readonly ICM_Credito_materialesServices _creditoMateriales;

    public CM_UVAServices(ICM_Credito_materialesServices credito_MaterialesServices)
    {
      _creditoMateriales = credito_MaterialesServices;
    }


    public List<CM_UVA> GetValorUva()
    {
      try
      {
        return CM_UVA.read();
      }
      catch (System.Exception)
      {
        throw;
      }
    }


    public void insertValorUVA(int valor_uva, Auditoria auditoria)
    {
      try
      {
        using (SqlConnection con = DALBase.GetConnection())
        {
          con.Open();
          using (SqlTransaction trx = con.BeginTransaction())
          {
            try
            {
              string detalle = $"Usuario: {auditoria.usuario}  ";
              auditoria.identificacion = auditoria.usuario;
              auditoria.proceso = "AGREGAR VALOR UVA";
              auditoria.detalle = detalle;
              auditoria.observaciones = string.Format(" Fecha en la que se agrego el numero valor del UVA : {0} ", DateTime.Now);
              int maxId = CM_UVA.ObtenerUltimoIdUVA(con, trx);
              DateTime fechaUVA = DateTime.Now;
              CM_UVA.insertValorUVA(maxId + 1, fechaUVA, valor_uva, auditoria.usuario, con, trx);
              //ActualizarMontosCtaCte(valor_uva,con,trx);
              AuditoriaD.InsertAuditoria(auditoria, con, trx);
              trx.Commit();
            }
            catch (Exception)
            {
              trx.Rollback();
              throw;
            }
          }
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"Error de conexion al procesar valor UVA: {valor_uva}. Error: {ex.Message}", ex);
      }
    }

    // public void ActualizarMontosCtaCte(int valor_uva, SqlConnection con, SqlTransaction trx)
    // {
    //   try
    //   {
    //     //int idCredito = 154;
    //      List<CM_Credito_materiales> todosCreditos = _creditoMateriales.GetAllCreditos(con, trx);
    //     //List<CM_Credito_materiales> todosCreditos = _creditoMateriales.GetCreditoById(idCredito,con, trx);

    //     //  Por cada credito actualizar sus cuotas
    //     foreach (var credito in todosCreditos)
    //     {
    //       try
    //       {

    //         // Obtener las cuotas del credito con valor_cuota_uva
    //         List<CM_Ctasctes_credito_materiales> cuotasCredito =
    //             CM_Ctasctes_credito_materiales.GetCuotasByCredito(credito.id_credito_materiales, con, trx);

    //         //  Actualizar cada cuota no pagada
    //         foreach (var cuota in cuotasCredito)
    //         {
    //           // Solo actualizar cuotas no pagadas
    //           if (cuota.pagado is false)
    //           {
    //             // Calcular nuevo monto: valor_cuota_uva * valor_uva_actual
    //             decimal nuevoMonto = (decimal)credito.valor_cuota_uva * valor_uva;
    //             cuota.debe = (decimal)nuevoMonto;

    //             //CM_Ctasctes_credito_materiales.Update(cuota, con, trx);
    //             // Modficar solo campo debe
    //             CM_Ctasctes_credito_materiales.UpdateCampoDebe(nuevoMonto, cuota.tipo_transaccion, cuota.nro_transaccion, cuota.id_credito_materiales, con, trx);

    //           }
    //         }
    //       }
    //       catch (Exception)
    //       {
    //         throw;
    //       }
    //     }

    //   }
    //   catch (Exception)
    //   {
    //     throw;
    //   }
    // }

  }
}