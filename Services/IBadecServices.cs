using CreditosApi.Entities;


namespace CreditosApi.Services
{
    public interface IBadecServices
    {
        public List<BADEC> GetDatosByCuit(string cuit);
    }
}