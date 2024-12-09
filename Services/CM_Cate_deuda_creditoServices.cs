using CreditosApi.Entities;

namespace CreditosApi.Services
{
    public class CM_Cate_deuda_creditoServices : ICM_Cate_deuda_creditoServices
    {


        public List<CM_Cate_deuda_credito_materiales> GetCategoriaDeuda(){
            try
            {
                var lst = CM_Cate_deuda_credito_materiales.read();
                return lst;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }


    }
}