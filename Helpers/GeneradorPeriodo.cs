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

        public static string GeneradorCuotaxCantidad(int i, int totalCuotas)
        {
            // Asegurar que ambas partes tengan 3 dígitos con ceros a la izquierda
            string nroCuota = (i + 1).ToString("D3");
            string total = totalCuotas.ToString("D3");

            return $"{nroCuota}/{total}";

            //Console.WriteLine(GeneradorPeriodoXCuota(0, 24));  // Salida: 001/024
            //Console.WriteLine(GeneradorPeriodoXCuota(5, 24));  // Salida: 006/024
            //Console.WriteLine(GeneradorPeriodoXCuota(23, 24)); // Salida: 024/024
        }

    }
}
