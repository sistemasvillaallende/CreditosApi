using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditosApi.Entities
{
    public class CM_Cate_deuda_credito_materiales : DALBase
    {
        public int cod_categoria { get; set; }
        public string des_categoria { get; set; }
        public int id_subrubro { get; set; }
        public int tipo_deuda { get; set; }

        public CM_Cate_deuda_credito_materiales()
        {
            cod_categoria = 0;
            des_categoria = string.Empty;
            id_subrubro = 0;
            tipo_deuda = 0;
        }

        private static List<CM_Cate_deuda_credito_materiales> mapeo(SqlDataReader dr)
        {
            List<CM_Cate_deuda_credito_materiales> lst = new List<CM_Cate_deuda_credito_materiales>();
            CM_Cate_deuda_credito_materiales obj;
            if (dr.HasRows)
            {
                int cod_categoria = dr.GetOrdinal("cod_categoria");
                int des_categoria = dr.GetOrdinal("des_categoria");
                int id_subrubro = dr.GetOrdinal("id_subrubro");
                int tipo_deuda = dr.GetOrdinal("tipo_deuda");
                while (dr.Read())
                {
                    obj = new CM_Cate_deuda_credito_materiales();
                    if (!dr.IsDBNull(cod_categoria)) { obj.cod_categoria = dr.GetInt32(cod_categoria); }
                    if (!dr.IsDBNull(des_categoria)) { obj.des_categoria = dr.GetString(des_categoria); }
                    if (!dr.IsDBNull(id_subrubro)) { obj.id_subrubro = dr.GetInt32(id_subrubro); }
                    if (!dr.IsDBNull(tipo_deuda)) { obj.tipo_deuda = dr.GetInt32(tipo_deuda); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CM_Cate_deuda_credito_materiales> read()
        {
            try
            {
                List<CM_Cate_deuda_credito_materiales> lst = new List<CM_Cate_deuda_credito_materiales>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Cm_cate_deuda_credito_materiales";
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

        public static CM_Cate_deuda_credito_materiales getByPk(
        int cod_categoria)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Cm_cate_deuda_credito_materiales WHERE");
                sql.AppendLine("cod_categoria = @cod_categoria");
                CM_Cate_deuda_credito_materiales obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_categoria", cod_categoria);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CM_Cate_deuda_credito_materiales> lst = mapeo(dr);
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

        public static int insert(CM_Cate_deuda_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Cm_cate_deuda_credito_materiales(");
                sql.AppendLine("cod_categoria");
                sql.AppendLine(", des_categoria");
                sql.AppendLine(", id_subrubro");
                sql.AppendLine(", tipo_deuda");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@cod_categoria");
                sql.AppendLine(", @des_categoria");
                sql.AppendLine(", @id_subrubro");
                sql.AppendLine(", @tipo_deuda");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_categoria", obj.cod_categoria);
                    cmd.Parameters.AddWithValue("@des_categoria", obj.des_categoria);
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

        public static void update(CM_Cate_deuda_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Cm_cate_deuda_credito_materiales SET");
                sql.AppendLine("des_categoria=@des_categoria");
                sql.AppendLine(", id_subrubro=@id_subrubro");
                sql.AppendLine(", tipo_deuda=@tipo_deuda");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_categoria=@cod_categoria");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_categoria", obj.cod_categoria);
                    cmd.Parameters.AddWithValue("@des_categoria", obj.des_categoria);
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

        public static void delete(CM_Cate_deuda_credito_materiales obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Cm_cate_deuda_credito_materiales ");
                sql.AppendLine("WHERE");
                sql.AppendLine("cod_categoria=@cod_categoria");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@cod_categoria", obj.cod_categoria);
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

