using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditosApi.Entities
{
    public class CM_Detalle_deuda_credito_materiales : DALBase
    {
        public int nro_transaccion { get; set; }
        public int nro_item { get; set; }
        public DateTime fecha_item { get; set; }
        public int cod_concepto_item { get; set; }
        public bool suma_item { get; set; }
        public decimal importe_item { get; set; }
        public bool activo_item { get; set; }
        public decimal importe_actual { get; set; }

        public CM_Detalle_deuda_credito_materiales()
        {
            nro_transaccion = 0;
            nro_item = 0;
            fecha_item = DateTime.Now;
            cod_concepto_item = 0;
            suma_item = false;
            importe_item = 0;
            activo_item = false;
            importe_actual = 0;
        }

        private static List<CM_Detalle_deuda_credito_materiales> mapeo(SqlDataReader dr)
        {
            List<CM_Detalle_deuda_credito_materiales> lst = new List<CM_Detalle_deuda_credito_materiales>();
            CM_Detalle_deuda_credito_materiales obj;
            if (dr.HasRows)
            {
                int nro_transaccion = dr.GetOrdinal("nro_transaccion");
                int nro_item = dr.GetOrdinal("nro_item");
                int fecha_item = dr.GetOrdinal("fecha_item");
                int cod_concepto_item = dr.GetOrdinal("cod_concepto_item");
                int suma_item = dr.GetOrdinal("suma_item");
                int importe_item = dr.GetOrdinal("importe_item");
                int activo_item = dr.GetOrdinal("activo_item");
                int importe_actual = dr.GetOrdinal("importe_actual");
                while (dr.Read())
                {
                    obj = new CM_Detalle_deuda_credito_materiales();
                    if (!dr.IsDBNull(nro_transaccion)) { obj.nro_transaccion = dr.GetInt32(nro_transaccion); }
                    if (!dr.IsDBNull(nro_item)) { obj.nro_item = dr.GetInt32(nro_item); }
                    if (!dr.IsDBNull(fecha_item)) { obj.fecha_item = dr.GetDateTime(fecha_item); }
                    if (!dr.IsDBNull(cod_concepto_item)) { obj.cod_concepto_item = dr.GetInt32(cod_concepto_item); }
                    if (!dr.IsDBNull(suma_item)) { obj.suma_item = dr.GetBoolean(suma_item); }
                    if (!dr.IsDBNull(importe_item)) { obj.importe_item = dr.GetDecimal(importe_item); }
                    if (!dr.IsDBNull(activo_item)) { obj.activo_item = dr.GetBoolean(activo_item); }
                    if (!dr.IsDBNull(importe_actual)) { obj.importe_actual = dr.GetDecimal(importe_actual); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CM_Detalle_deuda_credito_materiales> read()
        {
            try
            {
                List<CM_Detalle_deuda_credito_materiales> lst = new List<CM_Detalle_deuda_credito_materiales>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Cm_detalle_deuda_credito_materiales";
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

        public static CM_Detalle_deuda_credito_materiales getByPk(
        int nro_transaccion, int nro_item)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Cm_detalle_deuda_credito_materiales WHERE");
                sql.AppendLine("nro_transaccion = @nro_transaccion");
                sql.AppendLine("AND nro_item = @nro_item");
                CM_Detalle_deuda_credito_materiales obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_item", nro_item);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CM_Detalle_deuda_credito_materiales> lst = mapeo(dr);
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

        public static int insert(CM_Detalle_deuda_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Cm_detalle_deuda_credito_materiales(");
                sql.AppendLine("nro_transaccion");
                sql.AppendLine(", nro_item");
                sql.AppendLine(", fecha_item");
                sql.AppendLine(", cod_concepto_item");
                sql.AppendLine(", suma_item");
                sql.AppendLine(", importe_item");
                sql.AppendLine(", activo_item");
                sql.AppendLine(", importe_actual");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@nro_transaccion");
                sql.AppendLine(", @nro_item");
                sql.AppendLine(", @fecha_item");
                sql.AppendLine(", @cod_concepto_item");
                sql.AppendLine(", @suma_item");
                sql.AppendLine(", @importe_item");
                sql.AppendLine(", @activo_item");
                sql.AppendLine(", @importe_actual");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_item", obj.nro_item);
                    cmd.Parameters.AddWithValue("@fecha_item", obj.fecha_item);
                    cmd.Parameters.AddWithValue("@cod_concepto_item", obj.cod_concepto_item);
                    cmd.Parameters.AddWithValue("@suma_item", obj.suma_item);
                    cmd.Parameters.AddWithValue("@importe_item", obj.importe_item);
                    cmd.Parameters.AddWithValue("@activo_item", obj.activo_item);
                    cmd.Parameters.AddWithValue("@importe_actual", obj.importe_actual);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(CM_Detalle_deuda_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Cm_detalle_deuda_credito_materiales SET");
                sql.AppendLine("fecha_item=@fecha_item");
                sql.AppendLine(", cod_concepto_item=@cod_concepto_item");
                sql.AppendLine(", suma_item=@suma_item");
                sql.AppendLine(", importe_item=@importe_item");
                sql.AppendLine(", activo_item=@activo_item");
                sql.AppendLine(", importe_actual=@importe_actual");
                sql.AppendLine("WHERE");
                sql.AppendLine("nro_transaccion=@nro_transaccion");
                sql.AppendLine("AND nro_item=@nro_item");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_item", obj.nro_item);
                    cmd.Parameters.AddWithValue("@fecha_item", obj.fecha_item);
                    cmd.Parameters.AddWithValue("@cod_concepto_item", obj.cod_concepto_item);
                    cmd.Parameters.AddWithValue("@suma_item", obj.suma_item);
                    cmd.Parameters.AddWithValue("@importe_item", obj.importe_item);
                    cmd.Parameters.AddWithValue("@activo_item", obj.activo_item);
                    cmd.Parameters.AddWithValue("@importe_actual", obj.importe_actual);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(CM_Detalle_deuda_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Cm_detalle_deuda_credito_materiales ");
                sql.AppendLine("WHERE");
                sql.AppendLine("nro_transaccion=@nro_transaccion");
                sql.AppendLine("AND nro_item=@nro_item");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_transaccion", obj.nro_transaccion);
                    cmd.Parameters.AddWithValue("@nro_item", obj.nro_item);
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

