using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditosApi.Entities
{
    
    public class CM_Conceptos_credito_materiales : DALBase
    {
        public int cod_concepto { get; set; }
        public string des_concepto { get; set; }
        public bool suma { get; set; }
        public bool activo { get; set; }

        public CM_Conceptos_credito_materiales()
        {
            cod_concepto = 0;
            des_concepto = string.Empty;
            suma = false;
            activo = false;
        }

        private static List<CM_Conceptos_credito_materiales> mapeo(SqlDataReader dr)
        {
            List<CM_Conceptos_credito_materiales> lst = new List<CM_Conceptos_credito_materiales>();
            CM_Conceptos_credito_materiales obj;
            if (dr.HasRows)
            {
                int cod_concepto = dr.GetOrdinal("cod_concepto");
                int des_concepto = dr.GetOrdinal("des_concepto");
                int suma = dr.GetOrdinal("suma");
                int activo = dr.GetOrdinal("activo");
                while (dr.Read())
                {
                    obj = new CM_Conceptos_credito_materiales();
                    if (!dr.IsDBNull(cod_concepto)) { obj.cod_concepto = dr.GetInt32(cod_concepto); }
                    if (!dr.IsDBNull(des_concepto)) { obj.des_concepto = dr.GetString(des_concepto); }
                    if (!dr.IsDBNull(suma)) { obj.suma = dr.GetBoolean(suma); }
                    if (!dr.IsDBNull(activo)) { obj.activo = dr.GetBoolean(activo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CM_Conceptos_credito_materiales> read()
        {
            try
            {
                List<CM_Conceptos_credito_materiales> lst = new List<CM_Conceptos_credito_materiales>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Cm_conceptos_credito_materiales";
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

        public static CM_Conceptos_credito_materiales getByPk(
        int cod_concepto)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Cm_conceptos_credito_materiales WHERE");
                sql.AppendLine("cod_concepto = @cod_concepto");
                CM_Conceptos_credito_materiales obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto", cod_concepto);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CM_Conceptos_credito_materiales> lst = mapeo(dr);
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

        public static int insert(CM_Conceptos_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Cm_conceptos_credito_materiales(");
                sql.AppendLine("cod_concepto");
                sql.AppendLine(", des_concepto");
                sql.AppendLine(", suma");
                sql.AppendLine(", activo");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_concepto");
                sql.AppendLine(", @des_concepto");
                sql.AppendLine(", @suma");
                sql.AppendLine(", @activo");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto", obj.cod_concepto);
                    cmd.Parameters.AddWithValue("@des_concepto", obj.des_concepto);
                    cmd.Parameters.AddWithValue("@suma", obj.suma);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(CM_Conceptos_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Cm_conceptos_credito_materiales SET");
                sql.AppendLine("des_concepto=@des_concepto");
                sql.AppendLine(", suma=@suma");
                sql.AppendLine(", activo=@activo");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_concepto=@cod_concepto");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto", obj.cod_concepto);
                    cmd.Parameters.AddWithValue("@des_concepto", obj.des_concepto);
                    cmd.Parameters.AddWithValue("@suma", obj.suma);
                    cmd.Parameters.AddWithValue("@activo", obj.activo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(CM_Conceptos_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Cm_conceptos_credito_materiales ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_concepto=@cod_concepto");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_concepto", obj.cod_concepto);
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

