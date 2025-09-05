using CreditosApi.Entities;
using CreditosApi.Entities.AUDITORIA;


namespace CreditosApi.Services
{
  public interface ICM_UVAServices
  {
    public List<CM_UVA> GetValorUva();

    public void insertValorUVA( int valor_uva, Auditoria auditoria);


  }
}