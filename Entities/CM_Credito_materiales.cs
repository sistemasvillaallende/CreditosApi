using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditosApi.Entities
{
    public class CM_Credito_materiales : DALBase
    {
        public int id_credito_materiales { get; set; }
        public int legajo { get; set; }
        public string domicilio { get; set; }
        public DateTime fecha_alta { get; set; }
        public bool baja { get; set; }
        public DateTime fecha_baja { get; set; }
        public string cuit_solicitante { get; set; }
        public string garantes { get; set; }
        public decimal presupuesto { get; set; }
        public decimal presupuesto_uva { get; set; }
        public int cant_cuotas { get; set; }
        public decimal valor_cuota_uva { get; set; }
        public int id_uva { get; set; }
        public int id_estado { get; set; }
        public string per_ultimo { get; set; }
        public Int16 con_deuda { get; set; }
        public decimal saldo_adeudado { get; set; }
        public DateTime proximo_vencimiento { get; set; }

        public CM_Credito_materiales()
        {
            id_credito_materiales = 0;
            legajo = 0;
            domicilio = string.Empty;
            fecha_alta = DateTime.Now;
            baja = false;
            fecha_baja = DateTime.Now;
            cuit_solicitante = string.Empty;
            garantes = string.Empty;
            presupuesto = 0;
            presupuesto_uva = 0;
            cant_cuotas = 0;
            valor_cuota_uva = 0;
            id_uva = 0;
            id_estado = 0;
            per_ultimo = string.Empty;
            con_deuda = 0;
            saldo_adeudado = 0;
            proximo_vencimiento = DateTime.Now;
        }

        private static List<CM_Credito_materiales> mapeo(SqlDataReader dr)
        {
            List<CM_Credito_materiales> lst = new List<CM_Credito_materiales>();
            CM_Credito_materiales obj;
            if (dr.HasRows)
            {
                int id_credito_materiales = dr.GetOrdinal("id_credito_materiales");
                int legajo = dr.GetOrdinal("legajo");
                int domicilio = dr.GetOrdinal("domicilio");
                int fecha_alta = dr.GetOrdinal("fecha_alta");
                int baja = dr.GetOrdinal("baja");
                int fecha_baja = dr.GetOrdinal("fecha_baja");
                int cuit_solicitante = dr.GetOrdinal("cuit_solicitante");
                int garantes = dr.GetOrdinal("garantes");
                int presupuesto = dr.GetOrdinal("presupuesto");
                int presupuesto_uva = dr.GetOrdinal("presupuesto_uva");
                int cant_cuotas = dr.GetOrdinal("cant_cuotas");
                int valor_cuota_uva = dr.GetOrdinal("valor_cuota_uva");
                int id_uva = dr.GetOrdinal("id_uva");
                int id_estado = dr.GetOrdinal("id_estado");
                int per_ultimo = dr.GetOrdinal("per_ultimo");
                int con_deuda = dr.GetOrdinal("con_deuda");
                int saldo_adeudado = dr.GetOrdinal("saldo_adeudado");
                int proximo_vencimiento = dr.GetOrdinal("proximo_vencimiento");
                while (dr.Read())
                {
                    obj = new CM_Credito_materiales();
                    if (!dr.IsDBNull(id_credito_materiales)) { obj.id_credito_materiales = dr.GetInt32(id_credito_materiales); }
                    if (!dr.IsDBNull(legajo)) { obj.legajo = dr.GetInt32(legajo); }
                    if (!dr.IsDBNull(domicilio)) { obj.domicilio = dr.GetString(domicilio); }
                    if (!dr.IsDBNull(fecha_alta)) { obj.fecha_alta = dr.GetDateTime(fecha_alta); }
                    if (!dr.IsDBNull(baja)) { obj.baja = dr.GetBoolean(baja); }
                    if (!dr.IsDBNull(fecha_baja)) { obj.fecha_baja = dr.GetDateTime(fecha_baja); }
                    if (!dr.IsDBNull(cuit_solicitante)) { obj.cuit_solicitante = dr.GetString(cuit_solicitante); }
                    if (!dr.IsDBNull(garantes)) { obj.garantes = dr.GetString(garantes); }
                    if (!dr.IsDBNull(presupuesto)) { obj.presupuesto = dr.GetDecimal(presupuesto); }
                    if (!dr.IsDBNull(presupuesto_uva)) { obj.presupuesto_uva = dr.GetDecimal(presupuesto_uva); }
                    if (!dr.IsDBNull(cant_cuotas)) { obj.cant_cuotas = dr.GetInt32(cant_cuotas); }
                    if (!dr.IsDBNull(valor_cuota_uva)) { obj.valor_cuota_uva = dr.GetDecimal(valor_cuota_uva); }
                    if (!dr.IsDBNull(id_uva)) { obj.id_uva = dr.GetInt32(id_uva); }
                    if (!dr.IsDBNull(id_estado)) { obj.id_estado = dr.GetInt32(id_estado); }
                    if (!dr.IsDBNull(per_ultimo)) { obj.per_ultimo = dr.GetString(per_ultimo); }
                    if (!dr.IsDBNull(con_deuda)) { obj.con_deuda = dr.GetInt16(con_deuda); }
                    if (!dr.IsDBNull(saldo_adeudado)) { obj.saldo_adeudado = dr.GetDecimal(saldo_adeudado); }
                    if (!dr.IsDBNull(proximo_vencimiento)) { obj.proximo_vencimiento = dr.GetDateTime(proximo_vencimiento); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CM_Credito_materiales> read()
        {
            try
            {
                List<CM_Credito_materiales> lst = new List<CM_Credito_materiales>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Cm_credito_materiales";
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

        public static CM_Credito_materiales getByPk(
        int id_credito_materiales, int legajo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Cm_credito_materiales WHERE");
                sql.AppendLine("id_credito_materiales = @id_credito_materiales");
                sql.AppendLine("AND legajo = @legajo");
                CM_Credito_materiales obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_credito_materiales", id_credito_materiales);
                    cmd.Parameters.AddWithValue("@legajo", legajo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CM_Credito_materiales> lst = mapeo(dr);
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

        public static int insert(CM_Credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Cm_credito_materiales(");
                sql.AppendLine("legajo");
                sql.AppendLine(", domicilio");
                sql.AppendLine(", fecha_alta");
                sql.AppendLine(", baja");
                sql.AppendLine(", fecha_baja");
                sql.AppendLine(", cuit_solicitante");
                sql.AppendLine(", garantes");
                sql.AppendLine(", presupuesto");
                sql.AppendLine(", presupuesto_uva");
                sql.AppendLine(", cant_cuotas");
                sql.AppendLine(", valor_cuota_uva");
                sql.AppendLine(", id_uva");
                sql.AppendLine(", id_estado");
                sql.AppendLine(", per_ultimo");
                sql.AppendLine(", con_deuda");
                sql.AppendLine(", saldo_adeudado");
                sql.AppendLine(", proximo_vencimiento");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@legajo");
                sql.AppendLine(", @domicilio");
                sql.AppendLine(", @fecha_alta");
                sql.AppendLine(", @baja");
                sql.AppendLine(", @fecha_baja");
                sql.AppendLine(", @cuit_solicitante");
                sql.AppendLine(", @garantes");
                sql.AppendLine(", @presupuesto");
                sql.AppendLine(", @presupuesto_uva");
                sql.AppendLine(", @cant_cuotas");
                sql.AppendLine(", @valor_cuota_uva");
                sql.AppendLine(", @id_uva");
                sql.AppendLine(", @id_estado");
                sql.AppendLine(", @per_ultimo");
                sql.AppendLine(", @con_deuda");
                sql.AppendLine(", @saldo_adeudado");
                sql.AppendLine(", @proximo_vencimiento");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@domicilio", obj.domicilio);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@baja", obj.baja);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja);
                    cmd.Parameters.AddWithValue("@cuit_solicitante", obj.cuit_solicitante);
                    cmd.Parameters.AddWithValue("@garantes", obj.garantes);
                    cmd.Parameters.AddWithValue("@presupuesto", obj.presupuesto);
                    cmd.Parameters.AddWithValue("@presupuesto_uva", obj.presupuesto_uva);
                    cmd.Parameters.AddWithValue("@cant_cuotas", obj.cant_cuotas);
                    cmd.Parameters.AddWithValue("@valor_cuota_uva", obj.valor_cuota_uva);
                    cmd.Parameters.AddWithValue("@id_uva", obj.id_uva);
                    cmd.Parameters.AddWithValue("@id_estado", obj.id_estado);
                    cmd.Parameters.AddWithValue("@per_ultimo", obj.per_ultimo);
                    cmd.Parameters.AddWithValue("@con_deuda", obj.con_deuda);
                    cmd.Parameters.AddWithValue("@saldo_adeudado", obj.saldo_adeudado);
                    cmd.Parameters.AddWithValue("@proximo_vencimiento", obj.proximo_vencimiento);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(CM_Credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Cm_credito_materiales SET");
                sql.AppendLine("domicilio=@domicilio");
                sql.AppendLine(", fecha_alta=@fecha_alta");
                sql.AppendLine(", baja=@baja");
                sql.AppendLine(", fecha_baja=@fecha_baja");
                sql.AppendLine(", cuit_solicitante=@cuit_solicitante");
                sql.AppendLine(", garantes=@garantes");
                sql.AppendLine(", presupuesto=@presupuesto");
                sql.AppendLine(", presupuesto_uva=@presupuesto_uva");
                sql.AppendLine(", cant_cuotas=@cant_cuotas");
                sql.AppendLine(", valor_cuota_uva=@valor_cuota_uva");
                sql.AppendLine(", id_uva=@id_uva");
                sql.AppendLine(", id_estado=@id_estado");
                sql.AppendLine(", per_ultimo=@per_ultimo");
                sql.AppendLine(", con_deuda=@con_deuda");
                sql.AppendLine(", saldo_adeudado=@saldo_adeudado");
                sql.AppendLine(", proximo_vencimiento=@proximo_vencimiento");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_credito_materiales=@id_credito_materiales");
                sql.AppendLine("AND legajo=@legajo");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@domicilio", obj.domicilio);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@baja", obj.baja);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja);
                    cmd.Parameters.AddWithValue("@cuit_solicitante", obj.cuit_solicitante);
                    cmd.Parameters.AddWithValue("@garantes", obj.garantes);
                    cmd.Parameters.AddWithValue("@presupuesto", obj.presupuesto);
                    cmd.Parameters.AddWithValue("@presupuesto_uva", obj.presupuesto_uva);
                    cmd.Parameters.AddWithValue("@cant_cuotas", obj.cant_cuotas);
                    cmd.Parameters.AddWithValue("@valor_cuota_uva", obj.valor_cuota_uva);
                    cmd.Parameters.AddWithValue("@id_uva", obj.id_uva);
                    cmd.Parameters.AddWithValue("@id_estado", obj.id_estado);
                    cmd.Parameters.AddWithValue("@per_ultimo", obj.per_ultimo);
                    cmd.Parameters.AddWithValue("@con_deuda", obj.con_deuda);
                    cmd.Parameters.AddWithValue("@saldo_adeudado", obj.saldo_adeudado);
                    cmd.Parameters.AddWithValue("@proximo_vencimiento", obj.proximo_vencimiento);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(CM_Credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Cm_credito_materiales ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_credito_materiales=@id_credito_materiales");
                sql.AppendLine("AND legajo=@legajo");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_credito_materiales", obj.id_credito_materiales);
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
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
