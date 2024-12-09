using System.Data;
using System.Data.SqlClient;
using CreditosApi.Entities;
using CreditosApi.Entities.LOGIN;
using CreditosApi.Helpers;

namespace Web_Api_Auto.Entities.LOGIN
{
    public class SeguridadDal : DALBase
    {
        #region Seguridad Nueva
        private static List<Usuario> mapeo(SqlDataReader dr)
        {
            List<Usuario> lst = new List<Usuario>();
            Usuario obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Usuario();
                    if (!dr.IsDBNull(0)) { obj.IdUsuario = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.User = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.Passwd = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.Nombre_completo = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.Celular = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.Email = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.Administrador = dr.GetBoolean(6); }
                    if (!dr.IsDBNull(7)) { obj.Tipo = dr.GetString(7); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Usuario> read()
        {
            string strSQL = @"SELECT cod_usuario, nombre, passwd, nombre_completo,
                                celular, email, administrador, tipo='tipo'
                             FROM USUARIOS_V2";
            try
            {
                List<Usuario> lst = new List<Usuario>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Usuario ReadUser(string user)
        {
            try
            {
                string strSQL = @"SELECT cod_usuario, nombre, passwd, nombre_completo,
                                  celular, email, administrador, tipo='tipo'
                                  FROM USUARIOS_V2 
                                  WHERE nombre = @user";
                Usuario obj = new();
                using SqlConnection con = GetConnection();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Usuario> lst = mapeo(dr);
                if (lst.Count != 0)
                    obj = lst[0];
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool ValidaUsuario(string user, string password)
        {
            string strSQL = "";
            bool resultado = false;
            string? md5Passwd = "";
            string? md5Passwd_ = "";
            bool mExiste = false;
            user = user.Replace("'", "").Replace(",", "").Replace("=", "");
            strSQL = @"SELECT * 
                       FROM USUARIOS_V2 WHERE nombre=@user";
            SqlConnection? cn = null;
            cn = GetConnection();
            SqlCommand? cmd = null;
            SqlDataReader? reader = null;
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@user", user);
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    mExiste = true;
                    reader.Read();
                    //nombreUsuario = Convert.IsDBNull(reader["nombres"]) ? "" : Convert.ToString(reader["nombres"]);
                    md5Passwd = Convert.IsDBNull(reader["passwd"]) ? "" : Convert.ToString(reader["passwd"]);
                    md5Passwd_ = MD5Encryption.EncryptMD5(password.Trim().ToUpper() + user.Trim().ToUpper());
                    if (md5Passwd == md5Passwd_)
                        resultado = true;
                    else
                        resultado = false;
                    reader.Close();
                }
                else
                {
                    //nombreUsuario = "";
                    mExiste = false;
                    resultado = false;
                }
                reader.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la Autenticación!!!.");
            }
            finally
            {
                cn.Close();
                cmd = null;
            }
        }
        public static bool ValidaPermiso(string user, string proceso)
        {
            string strSQL = @"SELECT * 
                              FROM PROCESOS_V2 a, PROCESOS_x_USUARIO_V2 b,
                              USUARIOS_V2 c WHERE 
                              c.nombre=@user AND
                              c.cod_usuario=b.cod_usuario AND 
                              b.cod_proceso=a.cod_proceso AND 
                              a.proceso=@proceso";
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    MD5Encryption objMD5 = new MD5Encryption();
                    SqlCommand? cmd = cn.CreateCommand();
                    IDataReader? reader = null;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@proceso", proceso);
                    cmd.Connection.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        strSQL = @"SELECT * 
                                    FROM USUARIOS_V2 
                                    WHERE
                                    administrador=1 AND
                                    nombre=@user";
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = strSQL;
                        cmd2.Parameters.AddWithValue("@user", user);
                        reader.Close();
                        reader = cmd2.ExecuteReader();
                        if (reader.Read())
                        {
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            reader.Close();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la Autorización de Permiso!!!.");
            }
        }
        public bool ValidaPermiso(string User, string Proceso, out int id_oficina)
        {
            string strSQL = "";
            strSQL = "SELECT * FROM PROCESOS_V2 a, PROCESOS_x_USUARIO_V2 b, ";
            strSQL += "USUARIOS_V2 c WHERE ";
            strSQL += "c.nombre='" + User + "' AND ";
            strSQL += "c.cod_usuario=b.cod_usuario AND ";
            strSQL += "b.cod_proceso=a.cod_proceso AND ";
            strSQL += "a.proceso='" + Proceso + "'";


            SqlConnection? cn = null;
            cn = GetConnection("SIIMVA");
            MD5Encryption objMD5 = new MD5Encryption();
            SqlCommand cmd = null;
            IDataReader reader = null;
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;

            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id_oficina = Convert.IsDBNull(reader["cod_oficina"]) ? 0 : Convert.ToInt16(reader["cod_oficina"]);
                    reader.Close();
                    return true;
                }
                else
                {
                    strSQL = "SELECT * FROM USUARIOS_V2 WHERE ";
                    strSQL += "administrador=1 AND ";
                    strSQL += "nombre='" + User + "'";
                    reader.Close();
                    cmd.CommandText = strSQL;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        id_oficina = Convert.IsDBNull(reader["cod_oficina"]) ? 0 : Convert.ToInt16(reader["cod_oficina"]);
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        id_oficina = 0;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la Autorización de Permiso!!!.");
            }
            finally { cn.Close(); }
        }
        public bool AutorizaOpcionesMenu(int id_opcion, string login)
        {
            bool autoriza = false;
            string strSQL = " ";
            strSQL += "SELECT  *    ";
            strSQL += "FROM SE_OPCIONES_X_USUARIO a ";
            strSQL += "join SE_USUARIO b on ";
            strSQL += "a.id_usuario=b.id_usuario ";
            strSQL += "WHERE b.login='" + login + "' ";
            strSQL += "AND a.id_opcion=" + id_opcion.ToString();

            SqlConnection cn = null;
            SqlCommand cmd = null;
            cn = GetConnection("SIIMVA");
            SqlDataReader reader = null;
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;
            cmd.Connection.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                autoriza = true;
            }
            cn.Close();
            return autoriza;
        }
        //public DataSet OpcionesMenu()
        //{

        //    string strSQL = " ";

        //    strSQL += "SELECT  *    ";
        //    strSQL += "FROM SE_OPCIONES ";
        //    DataSet ds = new DataSet();
        //    ds = DALBase.Pagination("Opciones", strSQL, 0, 0, "", "");

        //    return ds;
        //}

        //public string MenuFuncion(int id_opcion)
        //{
        //    string strSQL = " ";

        //    strSQL += "SELECT  *    ";
        //    strSQL += "FROM SE_OPCIONES ";
        //    strSQL += "WHERE id_opcion=" + id_opcion.ToString();
        //    DataSet ds = new DataSet();
        //    ds = DALBase.Pagination("Opciones", strSQL, 0, 0, "", "");
        //    string strFuncion = ds.Tables[0].Rows[0]["Funcion"].ToString();
        //    return strFuncion;
        //}
        #endregion
    }
}