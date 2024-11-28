using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditosApi.Entities
{
    public class CM_Ctasctes_credito_materiales : DALBase
    {
        public int tipo_transaccion { get; set; }
        public int nro_transaccion { get; set; }
        public int nro_pago_parcial { get; set; }
        public DateTime fecha_trasaccion { get; set; }
        public int id_credito_materiales { get; set; }
        public string periodo { get; set; }
        public int id_uva { get; set; }
        public decimal monto_original { get; set; }
        public int nro_plan { get; set; }
        public bool pagado { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public int nro_procuracion { get; set; }
        public bool pago_parcial { get; set; }
        public DateTime vencimiento { get; set; }
        public int nro_cedulon { get; set; }
        public int categoria_deuda { get; set; }
        public decimal monto_pagado { get; set; }
        public decimal recargo { get; set; }
        public decimal honorarios { get; set; }
        public decimal iva_hons { get; set; }
        public Int16 tipo_deuda { get; set; }
        public string decreto { get; set; }
        public string observaciones { get; set; }
        public int nro_cedulon_paypertic { get; set; }
        public int deuda_activa { get; set; }

        public CM_Ctasctes_credito_materiales()
        {
            tipo_transaccion = 0;
            nro_transaccion = 0;
            nro_pago_parcial = 0;
            fecha_trasaccion = DateTime.Now;
            id_credito_materiales = 0;
            periodo = string.Empty;
            id_uva = 0;
            monto_original = 0;
            nro_plan = 0;
            pagado = false;
            debe = 0;
            haber = 0;
            nro_procuracion = 0;
            pago_parcial = false;
            vencimiento = DateTime.Now;
            nro_cedulon = 0;
            categoria_deuda = 0;
            monto_pagado = 0;
            recargo = 0;
            honorarios = 0;
            iva_hons = 0;
            tipo_deuda = 0;
            decreto = string.Empty;
            observaciones = string.Empty;
            nro_cedulon_paypertic = 0;
            deuda_activa = 0;
        }

        private static List<CM_Ctasctes_credito_materiales> mapeo(SqlDataReader dr)
        {
            List<CM_Ctasctes_credito_materiales> lst = new List<CM_Ctasctes_credito_materiales>();
            CM_Ctasctes_credito_materiales obj;
            if (dr.HasRows)
            {
                int tipo_transaccion = dr.GetOrdinal("tipo_transaccion");
                int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                int nro_pago_parcial = dr.GetOrdinal("nro_pago_parcial");
                int fecha_trasaccion = dr.GetOrdinal("fecha_trasaccion");
                int id_credito_materiales = dr.GetOrdinal("id_credito_materiales");
                int periodo = dr.GetOrdinal("periodo");
                int id_uva = dr.GetOrdinal("id_uva");
                int monto_original = dr.GetOrdinal("monto_original");
                int nro_plan = dr.GetOrdinal("nro_plan");
                int pagado = dr.GetOrdinal("pagado");
                int debe = dr.GetOrdinal("debe");
                int haber = dr.GetOrdinal("haber");
                int nro_procuracion = dr.GetOrdinal("nro_procuracion");
                int pago_parcial = dr.GetOrdinal("pago_parcial");
                int vencimiento = dr.GetOrdinal("vencimiento");
                int nro_cedulon = dr.GetOrdinal("nro_cedulon");
                int categoria_deuda = dr.GetOrdinal("categoria_deuda");
                int monto_pagado = dr.GetOrdinal("monto_pagado");
                int recargo = dr.GetOrdinal("recargo");
                int honorarios = dr.GetOrdinal("honorarios");
                int iva_hons = dr.GetOrdinal("iva_hons");
                int tipo_deuda = dr.GetOrdinal("tipo_deuda");
                int decreto = dr.GetOrdinal("decreto");
                int observaciones = dr.GetOrdinal("observaciones");
                int nro_cedulon_paypertic = dr.GetOrdinal("nro_cedulon_paypertic");
                int deuda_activa = dr.GetOrdinal("deuda_activa");
                while (dr.Read())
                {
                    obj = new CM_Ctasctes_credito_materiales();
                    if (!dr.IsDBNull(tipo_transaccion)) { obj.tipo_transaccion = dr.GetInt32(tipo_transaccion); }
                    if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                    if (!dr.IsDBNull(nro_pago_parcial)) { obj.nro_pago_parcial = dr.GetInt32(nro_pago_parcial); }
                    if (!dr.IsDBNull(fecha_trasaccion)) { obj.fecha_trasaccion = dr.GetDateTime(fecha_trasaccion); }
                    if (!dr.IsDBNull(id_credito_materiales)) { obj.id_credito_materiales = dr.GetInt32(id_credito_materiales); }
                    if (!dr.IsDBNull(periodo)) { obj.periodo = dr.GetString(periodo); }
                    if (!dr.IsDBNull(id_uva)) { obj.id_uva = dr.GetInt32(id_uva); }
                    if (!dr.IsDBNull(monto_original)) { obj.monto_original = dr.GetDecimal(monto_original); }
                    if (!dr.IsDBNull(nro_plan)) { obj.nro_plan = dr.GetInt32(nro_plan); }
                    if (!dr.IsDBNull(pagado)) { obj.pagado = dr.GetBoolean(pagado); }
                    if (!dr.IsDBNull(debe)) { obj.debe = dr.GetDecimal(debe); }
                    if (!dr.IsDBNull(haber)) { obj.haber = dr.GetDecimal(haber); }
                    if (!dr.IsDBNull(nro_procuracion)) { obj.nro_procuracion = dr.GetInt32(nro_procuracion); }
                    if (!dr.IsDBNull(pago_parcial)) { obj.pago_parcial = dr.GetBoolean(pago_parcial); }
                    if (!dr.IsDBNull(vencimiento)) { obj.vencimiento = dr.GetDateTime(vencimiento); }
                    if (!dr.IsDBNull(nro_cedulon)) { obj.nro_cedulon = dr.GetInt32(nro_cedulon); }
                    if (!dr.IsDBNull(categoria_deuda)) { obj.categoria_deuda = dr.GetInt32(categoria_deuda); }
                    if (!dr.IsDBNull(monto_pagado)) { obj.monto_pagado = dr.GetDecimal(monto_pagado); }
                    if (!dr.IsDBNull(recargo)) { obj.recargo = dr.GetDecimal(recargo); }
                    if (!dr.IsDBNull(honorarios)) { obj.honorarios = dr.GetDecimal(honorarios); }
                    if (!dr.IsDBNull(iva_hons)) { obj.iva_hons = dr.GetDecimal(iva_hons); }
                    if (!dr.IsDBNull(tipo_deuda)) { obj.tipo_deuda = dr.GetInt16(tipo_deuda); }
                    if (!dr.IsDBNull(decreto)) { obj.decreto = dr.GetString(decreto); }
                    if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    if (!dr.IsDBNull(nro_cedulon_paypertic)) { obj.nro_cedulon_paypertic = dr.GetInt32(nro_cedulon_paypertic); }
                    if (!dr.IsDBNull(deuda_activa)) { obj.deuda_activa = dr.GetInt32(deuda_activa); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CM_Ctasctes_credito_materiales> read()
        {
            try
            {
                List<CM_Ctasctes_credito_materiales> lst = new List<CM_Ctasctes_credito_materiales>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Cm_ctasctes_credito_materiales";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CM_Ctasctes_credito_materiales getByPk(
        int tipo_transaccion, int nro_transaccion, int nro_pago_parcial)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Cm_ctasctes_credito_materiales WHERE");
                sql.AppendLine("tipo_transaccion = @tipo_transaccion");
                sql.AppendLine("AND nro_transaccion = @nro_transaccion");
                sql.AppendLine("AND nro_pago_parcial = @nro_pago_parcial");
                CM_Ctasctes_credito_materiales obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", nro_pago_parcial);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CM_Ctasctes_credito_materiales> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(CM_Ctasctes_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Cm_ctasctes_credito_materiales(");
                sql.AppendLine("tipo_transaccion");
                sql.AppendLine(", nro_transaccion");
                sql.AppendLine(", nro_pago_parcial");
                sql.AppendLine(", fecha_trasaccion");
                sql.AppendLine(", id_credito_materiales");
                sql.AppendLine(", periodo");
                sql.AppendLine(", id_uva");
                sql.AppendLine(", monto_original");
                sql.AppendLine(", nro_plan");
                sql.AppendLine(", pagado");
                sql.AppendLine(", debe");
                sql.AppendLine(", haber");
                sql.AppendLine(", nro_procuracion");
                sql.AppendLine(", pago_parcial");
                sql.AppendLine(", vencimiento");
                sql.AppendLine(", nro_cedulon");
                sql.AppendLine(", categoria_deuda");
                sql.AppendLine(", monto_pagado");
                sql.AppendLine(", recargo");
                sql.AppendLine(", honorarios");
                sql.AppendLine(", iva_hons");
                sql.AppendLine(", tipo_deuda");
                sql.AppendLine(", decreto");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", nro_cedulon_paypertic");
                sql.AppendLine(", deuda_activa");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@tipo_transaccion");
                sql.AppendLine(", @nro_transaccion");
                sql.AppendLine(", @nro_pago_parcial");
                sql.AppendLine(", @fecha_trasaccion");
                sql.AppendLine(", @id_credito_materiales");
                sql.AppendLine(", @periodo");
                sql.AppendLine(", @id_uva");
                sql.AppendLine(", @monto_original");
                sql.AppendLine(", @nro_plan");
                sql.AppendLine(", @pagado");
                sql.AppendLine(", @debe");
                sql.AppendLine(", @haber");
                sql.AppendLine(", @nro_procuracion");
                sql.AppendLine(", @pago_parcial");
                sql.AppendLine(", @vencimiento");
                sql.AppendLine(", @nro_cedulon");
                sql.AppendLine(", @categoria_deuda");
                sql.AppendLine(", @monto_pagado");
                sql.AppendLine(", @recargo");
                sql.AppendLine(", @honorarios");
                sql.AppendLine(", @iva_hons");
                sql.AppendLine(", @tipo_deuda");
                sql.AppendLine(", @decreto");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @nro_cedulon_paypertic");
                sql.AppendLine(", @deuda_activa");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", obj.tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", obj.nro_pago_parcial);
                    cmd.Parameters.AddWithValue("@fecha_trasaccion", obj.fecha_trasaccion);
                    cmd.Parameters.AddWithValue("@id_credito_materiales", obj.id_credito_materiales);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@id_uva", obj.id_uva);
                    cmd.Parameters.AddWithValue("@monto_original", obj.monto_original);
                    cmd.Parameters.AddWithValue("@nro_plan", obj.nro_plan);
                    cmd.Parameters.AddWithValue("@pagado", obj.pagado);
                    cmd.Parameters.AddWithValue("@debe", obj.debe);
                    cmd.Parameters.AddWithValue("@haber", obj.haber);
                    cmd.Parameters.AddWithValue("@nro_procuracion", obj.nro_procuracion);
                    cmd.Parameters.AddWithValue("@pago_parcial", obj.pago_parcial);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@nro_cedulon", obj.nro_cedulon);
                    cmd.Parameters.AddWithValue("@categoria_deuda", obj.categoria_deuda);
                    cmd.Parameters.AddWithValue("@monto_pagado", obj.monto_pagado);
                    cmd.Parameters.AddWithValue("@recargo", obj.recargo);
                    cmd.Parameters.AddWithValue("@honorarios", obj.honorarios);
                    cmd.Parameters.AddWithValue("@iva_hons", obj.iva_hons);
                    cmd.Parameters.AddWithValue("@tipo_deuda", obj.tipo_deuda);
                    cmd.Parameters.AddWithValue("@decreto", obj.decreto);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@nro_cedulon_paypertic", obj.nro_cedulon_paypertic);
                    cmd.Parameters.AddWithValue("@deuda_activa", obj.deuda_activa);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(CM_Ctasctes_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Cm_ctasctes_credito_materiales SET");
                sql.AppendLine("fecha_trasaccion=@fecha_trasaccion");
                sql.AppendLine(", id_credito_materiales=@id_credito_materiales");
                sql.AppendLine(", periodo=@periodo");
                sql.AppendLine(", id_uva=@id_uva");
                sql.AppendLine(", monto_original=@monto_original");
                sql.AppendLine(", nro_plan=@nro_plan");
                sql.AppendLine(", pagado=@pagado");
                sql.AppendLine(", debe=@debe");
                sql.AppendLine(", haber=@haber");
                sql.AppendLine(", nro_procuracion=@nro_procuracion");
                sql.AppendLine(", pago_parcial=@pago_parcial");
                sql.AppendLine(", vencimiento=@vencimiento");
                sql.AppendLine(", nro_cedulon=@nro_cedulon");
                sql.AppendLine(", categoria_deuda=@categoria_deuda");
                sql.AppendLine(", monto_pagado=@monto_pagado");
                sql.AppendLine(", recargo=@recargo");
                sql.AppendLine(", honorarios=@honorarios");
                sql.AppendLine(", iva_hons=@iva_hons");
                sql.AppendLine(", tipo_deuda=@tipo_deuda");
                sql.AppendLine(", decreto=@decreto");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", nro_cedulon_paypertic=@nro_cedulon_paypertic");
                sql.AppendLine(", deuda_activa=@deuda_activa");
                sql.AppendLine("WHERE");
                sql.AppendLine("tipo_transaccion=@tipo_transaccion");
                sql.AppendLine("AND nro_transaccion=@nro_transaccion");
                sql.AppendLine("AND nro_pago_parcial=@nro_pago_parcial");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", obj.tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", obj.nro_pago_parcial);
                    cmd.Parameters.AddWithValue("@fecha_trasaccion", obj.fecha_trasaccion);
                    cmd.Parameters.AddWithValue("@id_credito_materiales", obj.id_credito_materiales);
                    cmd.Parameters.AddWithValue("@periodo", obj.periodo);
                    cmd.Parameters.AddWithValue("@id_uva", obj.id_uva);
                    cmd.Parameters.AddWithValue("@monto_original", obj.monto_original);
                    cmd.Parameters.AddWithValue("@nro_plan", obj.nro_plan);
                    cmd.Parameters.AddWithValue("@pagado", obj.pagado);
                    cmd.Parameters.AddWithValue("@debe", obj.debe);
                    cmd.Parameters.AddWithValue("@haber", obj.haber);
                    cmd.Parameters.AddWithValue("@nro_procuracion", obj.nro_procuracion);
                    cmd.Parameters.AddWithValue("@pago_parcial", obj.pago_parcial);
                    cmd.Parameters.AddWithValue("@vencimiento", obj.vencimiento);
                    cmd.Parameters.AddWithValue("@nro_cedulon", obj.nro_cedulon);
                    cmd.Parameters.AddWithValue("@categoria_deuda", obj.categoria_deuda);
                    cmd.Parameters.AddWithValue("@monto_pagado", obj.monto_pagado);
                    cmd.Parameters.AddWithValue("@recargo", obj.recargo);
                    cmd.Parameters.AddWithValue("@honorarios", obj.honorarios);
                    cmd.Parameters.AddWithValue("@iva_hons", obj.iva_hons);
                    cmd.Parameters.AddWithValue("@tipo_deuda", obj.tipo_deuda);
                    cmd.Parameters.AddWithValue("@decreto", obj.decreto);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@nro_cedulon_paypertic", obj.nro_cedulon_paypertic);
                    cmd.Parameters.AddWithValue("@deuda_activa", obj.deuda_activa);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(CM_Ctasctes_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Cm_ctasctes_credito_materiales ");
                sql.AppendLine("WHERE");
                sql.AppendLine("tipo_transaccion=@tipo_transaccion");
                sql.AppendLine("AND nro_transaccion=@nro_transaccion");
                sql.AppendLine("AND nro_pago_parcial=@nro_pago_parcial");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@tipo_transaccion", obj.tipo_transaccion);
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_pago_parcial", obj.nro_pago_parcial);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
