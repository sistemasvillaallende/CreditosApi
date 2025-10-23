using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditosApi.Entities
{
    public class CM_rubro_credito : DALBase
    {
        public int cod_rubro { get; set; }
        public string descripcion { get; set; }
        public string rubro { get; set; }
        public int id_subrubro { get; set; }
        public int tipo_deuda { get; set; }

        public CM_rubro_credito()
        {
            cod_rubro = 0;
            descripcion = String.Empty;
            rubro = String.Empty;
            id_subrubro = 0;
            tipo_deuda = 0;
        }

        private static List<CM_rubro_credito> mapeo(SqlDataReader dr)
        {
            List<CM_rubro_credito> lst = new List<CM_rubro_credito>();
            CM_rubro_credito obj;
            if (dr.HasRows)
            {
                int cod_rubro = dr.GetOrdinal("cod_rubro");
                int descripcion = dr.GetOrdinal("descripcion");
                int rubro = dr.GetOrdinal("rubro");
                int id_subrubro = dr.GetOrdinal("id_subrubro");
                int tipo_deuda = dr.GetOrdinal("tipo_deuda");
                while (dr.Read())
                {
                    obj = new CM_rubro_credito();
                    if (!dr.IsDBNull(cod_rubro)) { obj.cod_rubro = dr.GetInt32(cod_rubro); }
                    if (!dr.IsDBNull(descripcion)) { obj.descripcion = dr.GetString(descripcion); }
                    if (!dr.IsDBNull(rubro)) { obj.rubro = dr.GetString(rubro); }
                    if (!dr.IsDBNull(id_subrubro)) { obj.id_subrubro = dr.GetInt32(id_subrubro); }
                    if (!dr.IsDBNull(tipo_deuda)) { obj.tipo_deuda = dr.GetInt32(tipo_deuda); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CM_rubro_credito> read()
        {
            try
            {
                List<CM_rubro_credito> lst = new List<CM_rubro_credito>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Cm_rubro_credito";
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

        public static CM_rubro_credito getByPk(int cod_rubro)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Cm_rubro_credito WHERE");
                sql.AppendLine("cod_rubro = @cod_rubro");
                CM_rubro_credito obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", cod_rubro);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CM_rubro_credito> lst = mapeo(dr);
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

        public static int insert(CM_rubro_credito obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO CM_rubro_credito (");
                sql.AppendLine("    cod_rubro,");
                sql.AppendLine("    descripcion,");
                sql.AppendLine("    rubro,");
                sql.AppendLine("    id_subrubro,");
                sql.AppendLine("    tipo_deuda");
                sql.AppendLine(")");
                sql.AppendLine("VALUES (");
                sql.AppendLine("    @cod_rubro,");
                sql.AppendLine("    @descripcion,");
                sql.AppendLine("    @rubro,");
                sql.AppendLine("    @id_subrubro,");
                sql.AppendLine("    @tipo_deuda");
                sql.AppendLine(");");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@rubro", obj.rubro ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_subrubro", obj.id_subrubro);
                    cmd.Parameters.AddWithValue("@tipo_deuda", obj.tipo_deuda);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(CM_rubro_credito obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CM_rubro_credito SET");
                sql.AppendLine("    descripcion = @descripcion,");
                sql.AppendLine("    rubro = @rubro,");
                sql.AppendLine("    id_subrubro = @id_subrubro,");
                sql.AppendLine("    tipo_deuda = @tipo_deuda");
                sql.AppendLine("WHERE cod_rubro = @cod_rubro;");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@rubro", obj.rubro ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_subrubro", obj.id_subrubro);
                    cmd.Parameters.AddWithValue("@tipo_deuda", obj.tipo_deuda);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(CM_rubro_credito obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  CM_rubro_credito ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_rubro=@cod_rubro");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_rubro", obj.cod_rubro);
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

