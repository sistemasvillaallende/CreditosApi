namespace CreditosApi.Helpers
{
    public class GeneradorPeriodo
    {
    
        public static string GeneradorPeriodoXCuota(int i)
        {
            DateTime baseFecha = DateTime.Now.AddMonths(1);

            DateTime periodoFecha = baseFecha.AddMonths(i);

            return $"{periodoFecha:yyyy/MM}";
        }

    }
}
