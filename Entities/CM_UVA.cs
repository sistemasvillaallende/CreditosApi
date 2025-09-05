using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditosApi.Entities
{
    public class CM_UVA : DALBase
    {
        public int id_uva { get; set; }
        public DateTime fecha_uva { get; set; }
        public decimal valor_uva { get; set; }

        public CM_UVA()
        {
            id_uva = 0;
            fecha_uva = DateTime.Now;
            valor_uva = 0;

        }

        private static List<CM_UVA> mapeo(SqlDataReader dr)
        {
            List<CM_UVA> lst = new List<CM_UVA>();
            CM_UVA obj;
            if (dr.HasRows)
            {
                int id_uva = dr.GetOrdinal("id_uva");
                int fecha_uva = dr.GetOrdinal("fecha_uva");
                int valor_uva = dr.GetOrdinal("valor_uva");

                while (dr.Read())
                {
                    obj = new CM_UVA();
                    if (!dr.IsDBNull(id_uva)) { obj.id_uva = dr.GetInt32(id_uva); }
                    if (!dr.IsDBNull(fecha_uva)) { obj.fecha_uva = dr.GetDateTime(fecha_uva); }
                    if (!dr.IsDBNull(valor_uva)) { obj.valor_uva = dr.GetDecimal(valor_uva); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CM_UVA> read()
        {
            try
            {
                List<CM_UVA> lst = new List<CM_UVA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM CM_UVAS";
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

        public static CM_UVA GetUltimaFila()
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT TOP 1 * FROM CM_UVAS ORDER BY id_uva DESC";
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CM_UVA> lst = mapeo(dr);
                    return lst.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ObtenerUltimoIdUVA(SqlConnection con, SqlTransaction trx)
        {
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(id_uva), 0) FROM CM_UVAS ", con, trx);
            return (int)cmd.ExecuteScalar();
        }



        public static void insertValorUVA(int id_uva, DateTime fecha_uva, int valor_uva,string usuario, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"
           INSERT INTO CM_UVAS (
               id_uva,
               fecha_uva,
               valor_uva,
               usuario
           ) VALUES (
               @id_uva,
               @fecha_uva,
               @valor_uva,
               @usuario
           )";

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                cmd.Parameters.AddWithValue("@id_uva", id_uva);
                cmd.Parameters.AddWithValue("@fecha_uva", fecha_uva );
                cmd.Parameters.AddWithValue("@valor_uva", valor_uva);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






    }
}

