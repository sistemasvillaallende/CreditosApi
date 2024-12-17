using System.Data.SqlClient;
using System.Data;

namespace CreditosApi.Entities
{
    public class LstDeudaCredito : DALBase
    {
        public string periodo { get; set; }
        public decimal deudaOriginal { get; set; }
        public decimal importe { get; set; }
        public string fecha_vencimiento { get; set; }
        public string desCategoria { get; set; }
        public int pagado { get; set; }
        public int nro_transaccion { get; set; }
        public int categoria_deuda { get; set; }
        public int nro_cedulon_paypertic { get; set; }
        public decimal intereses { get; set; }
        public bool pago_parcial { get; set; }
        public decimal pago_a_cuenta { get; set; }
        public int nro_proc { get; set; }
        public LstDeudaCredito()
        {
            periodo = string.Empty;
            deudaOriginal = 0;
            importe = 0;
            fecha_vencimiento = string.Empty;
            desCategoria = string.Empty;
            pagado = 0;
            nro_transaccion = 0;
            categoria_deuda = 0;
            nro_cedulon_paypertic = 0;
            intereses = 0;
            pago_parcial = false;
            pago_a_cuenta = 0;
            nro_proc = 0;
        }
        public static List<LstDeudaCredito> getListDeudaCredito(int id_credito_materiales)
        {
            List<LstDeudaCredito> oLstCredito = new List<LstDeudaCredito>();
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = null;

            string sql = @"
                       SELECT C.periodo, C.monto_original, C.debe -
                            (SELECT SUM(haber) 
                             FROM CM_CTASCTES_CREDITO_MATERIALES C2 
                             WHERE
                                C2.nro_transaccion=C.nro_transaccion ) as debe,
                            C.vencimiento, b.des_categoria,
                            C.pagado, C.nro_transaccion, C.categoria_deuda, C.nro_cedulon_paypertic,
                            C.recargo,
                            C.pago_parcial, 
                            (SELECT SUM(haber) 
                             FROM CM_CTASCTES_CREDITO_MATERIALES C2 
                             WHERE
                                C2.nro_transaccion=C.nro_transaccion) as pago_a_cuenta, 
                            C.NRO_PROCURACION
                        FROM CM_CTASCTES_CREDITO_MATERIALES C
                        INNER JOIN CM_CATE_DEUDA_CREDITO_MATERIALES b on C.categoria_deuda = b.cod_categoria
                        WHERE
                            C.pagado = 0
                            AND C.tipo_transaccion = 1
                            AND C.nro_plan IS NULL
                            AND C.nro_procuracion IS NULL
                            AND C.id_credito_materiales = @id_credito_materiales";
                            // AND vencimiento <= GETDATE() ORDER BY C.periodo ASC";


            cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@id_credito_materiales", id_credito_materiales);
            try
            {
                cn = DALBase.GetConnection();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LstDeudaCredito oCredito = new LstDeudaCredito();
                    if (!dr.IsDBNull(dr.GetOrdinal("periodo")))
                    { oCredito.periodo = dr.GetString(dr.GetOrdinal("periodo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("monto_original")))
                    { oCredito.deudaOriginal = dr.GetDecimal(dr.GetOrdinal("monto_original")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("debe")))
                    { oCredito.importe = dr.GetDecimal(dr.GetOrdinal("debe")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("vencimiento")))
                    {   oCredito.fecha_vencimiento = dr.GetDateTime(
                        dr.GetOrdinal("vencimiento")).ToShortDateString();}
                    if (!dr.IsDBNull(dr.GetOrdinal("des_categoria")))
                    { oCredito.desCategoria = dr.GetString(dr.GetOrdinal("des_categoria")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pagado")))
                    { oCredito.pagado = 0; }//Convert.ToInt32(dr.GetSqlBinary(dr.GetOrdinal("pagado"))); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_transaccion")))
                    { oCredito.nro_transaccion = dr.GetInt32(dr.GetOrdinal("nro_transaccion")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("categoria_deuda")))
                    { oCredito.categoria_deuda = dr.GetInt32(dr.GetOrdinal("categoria_deuda")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("recargo")))
                    { oCredito.intereses = dr.GetDecimal(dr.GetOrdinal("recargo")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("nro_cedulon_paypertic")))
                    { oCredito.nro_cedulon_paypertic = dr.GetInt32(dr.GetOrdinal("nro_cedulon_paypertic")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pago_parcial")))
                    { oCredito.pago_parcial = dr.GetBoolean(dr.GetOrdinal("pago_parcial")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("pago_a_cuenta")))
                    { oCredito.pago_a_cuenta = dr.GetDecimal(dr.GetOrdinal("pago_a_cuenta")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NRO_PROCURACION")))
                    { oCredito.nro_proc = dr.GetInt32(dr.GetOrdinal("NRO_PROCURACION")); }

                    oLstCredito.Add(oCredito);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally { cn.Close(); }
            return oLstCredito;
        }
       
        
    }
}
