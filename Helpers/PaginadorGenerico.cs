namespace CreditosApi.Helpers
{
    public class PaginadorGenerico<T> where T : class
    {
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public string BusquedaPor { get; set; }
        public string Parametro { get; set; }
        public IEnumerable<T>? Resultado { get; set; }
        public PaginadorGenerico()
        {
            PaginaActual = 0;
            RegistrosPorPagina = 0;
            TotalRegistros = 0;
            TotalPaginas = 0;
            BusquedaPor = string.Empty;
            Parametro = string.Empty;
        }

    }
}
