using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditosApi.Entities
{
    public class Vecino_digital : DALBase
    {
        public string CUIT { get; set; }
        public string APELLIDO { get; set; }
        public string NOMBRE { get; set; }
        public string NRO_DOC { get; set; }
        public DateTime FECHA_NACIMIENTO { get; set; }
        public string DIRECCION { get; set; }
        public string LOCALIDAD { get; set; }
        public int COD_PROVINCIA { get; set; }
        public string DESC_PROVINCIA { get; set; }
        public string COD_POSTAL { get; set; }
        public string TELEFONO { get; set; }
        public string MAIL { get; set; }
        public string PASSWORD { get; set; }
        public string TIPODOCUMENTO { get; set; }
        public bool ACTIVO { get; set; }
        public bool CONFIRMADO { get; set; }
        public DateTime FECHA_ALTA { get; set; }
        public string SEXO { get; set; }
        public string MENSAF { get; set; }
        public int NIVEL_CIDI { get; set; }
        public int CEL_COD_AREA { get; set; }
        public int CEL_NUMERO { get; set; }
        public bool CEL_VALIDADO { get; set; }
        public int CEL_COD_VALIDACION { get; set; }
        public DateTime CEL_VIGENCIA_COD_VALIDACION { get; set; }

        public Vecino_digital()
        {
            CUIT = string.Empty;
            APELLIDO = string.Empty;
            NOMBRE = string.Empty;
            NRO_DOC = string.Empty;
            FECHA_NACIMIENTO = DateTime.Now;
            DIRECCION = string.Empty;
            LOCALIDAD = string.Empty;
            COD_PROVINCIA = 0;
            DESC_PROVINCIA = string.Empty;
            COD_POSTAL = string.Empty;
            TELEFONO = string.Empty;
            MAIL = string.Empty;
            PASSWORD = string.Empty;
            TIPODOCUMENTO = string.Empty;
            ACTIVO = false;
            CONFIRMADO = false;
            FECHA_ALTA = DateTime.Now;
            SEXO = string.Empty;
            MENSAF = string.Empty;
            NIVEL_CIDI = 0;
            CEL_COD_AREA = 0;
            CEL_NUMERO = 0;
            CEL_VALIDADO = false;
            CEL_COD_VALIDACION = 0;
            CEL_VIGENCIA_COD_VALIDACION = DateTime.Now;
        }

        private static List<Vecino_digital> mapeo(SqlDataReader dr)
        {
            List<Vecino_digital> lst = new List<Vecino_digital>();
            Vecino_digital obj;
            if (dr.HasRows)
            {
                int CUIT = dr.GetOrdinal("CUIT");
                int APELLIDO = dr.GetOrdinal("APELLIDO");
                int NOMBRE = dr.GetOrdinal("NOMBRE");
                int NRO_DOC = dr.GetOrdinal("NRO_DOC");
                int FECHA_NACIMIENTO = dr.GetOrdinal("FECHA_NACIMIENTO");
                int DIRECCION = dr.GetOrdinal("DIRECCION");
                int LOCALIDAD = dr.GetOrdinal("LOCALIDAD");
                int COD_PROVINCIA = dr.GetOrdinal("COD_PROVINCIA");
                int DESC_PROVINCIA = dr.GetOrdinal("DESC_PROVINCIA");
                int COD_POSTAL = dr.GetOrdinal("COD_POSTAL");
                int TELEFONO = dr.GetOrdinal("TELEFONO");
                int MAIL = dr.GetOrdinal("MAIL");
                int PASSWORD = dr.GetOrdinal("PASSWORD");
                int TIPODOCUMENTO = dr.GetOrdinal("TIPODOCUMENTO");
                int ACTIVO = dr.GetOrdinal("ACTIVO");
                int CONFIRMADO = dr.GetOrdinal("CONFIRMADO");
                int FECHA_ALTA = dr.GetOrdinal("FECHA_ALTA");
                int SEXO = dr.GetOrdinal("SEXO");
                int MENSAF = dr.GetOrdinal("MENSAF");
                int NIVEL_CIDI = dr.GetOrdinal("NIVEL_CIDI");
                int CEL_COD_AREA = dr.GetOrdinal("CEL_COD_AREA");
                int CEL_NUMERO = dr.GetOrdinal("CEL_NUMERO");
                int CEL_VALIDADO = dr.GetOrdinal("CEL_VALIDADO");
                int CEL_COD_VALIDACION = dr.GetOrdinal("CEL_COD_VALIDACION");
                int CEL_VIGENCIA_COD_VALIDACION = dr.GetOrdinal("CEL_VIGENCIA_COD_VALIDACION");
                while (dr.Read())
                {
                    obj = new Vecino_digital();
                    if (!dr.IsDBNull(CUIT)) { obj.CUIT = dr.GetString(CUIT); }
                    if (!dr.IsDBNull(APELLIDO)) { obj.APELLIDO = dr.GetString(APELLIDO); }
                    if (!dr.IsDBNull(NOMBRE)) { obj.NOMBRE = dr.GetString(NOMBRE); }
                    if (!dr.IsDBNull(NRO_DOC)) { obj.NRO_DOC = dr.GetString(NRO_DOC); }
                    if (!dr.IsDBNull(FECHA_NACIMIENTO)) { obj.FECHA_NACIMIENTO = dr.GetDateTime(FECHA_NACIMIENTO); }
                    if (!dr.IsDBNull(DIRECCION)) { obj.DIRECCION = dr.GetString(DIRECCION); }
                    if (!dr.IsDBNull(LOCALIDAD)) { obj.LOCALIDAD = dr.GetString(LOCALIDAD); }
                    if (!dr.IsDBNull(COD_PROVINCIA)) { obj.COD_PROVINCIA = dr.GetInt32(COD_PROVINCIA); }
                    if (!dr.IsDBNull(DESC_PROVINCIA)) { obj.DESC_PROVINCIA = dr.GetString(DESC_PROVINCIA); }
                    if (!dr.IsDBNull(COD_POSTAL)) { obj.COD_POSTAL = dr.GetString(COD_POSTAL); }
                    if (!dr.IsDBNull(TELEFONO)) { obj.TELEFONO = dr.GetString(TELEFONO); }
                    if (!dr.IsDBNull(MAIL)) { obj.MAIL = dr.GetString(MAIL); }
                    if (!dr.IsDBNull(PASSWORD)) { obj.PASSWORD = dr.GetString(PASSWORD); }
                    if (!dr.IsDBNull(TIPODOCUMENTO)) { obj.TIPODOCUMENTO = dr.GetString(TIPODOCUMENTO); }
                    if (!dr.IsDBNull(ACTIVO)) { obj.ACTIVO = dr.GetBoolean(ACTIVO); }
                    if (!dr.IsDBNull(CONFIRMADO)) { obj.CONFIRMADO = dr.GetBoolean(CONFIRMADO); }
                    if (!dr.IsDBNull(FECHA_ALTA)) { obj.FECHA_ALTA = dr.GetDateTime(FECHA_ALTA); }
                    if (!dr.IsDBNull(SEXO)) { obj.SEXO = dr.GetString(SEXO); }
                    if (!dr.IsDBNull(MENSAF)) { obj.MENSAF = dr.GetString(MENSAF); }
                    if (!dr.IsDBNull(NIVEL_CIDI)) { obj.NIVEL_CIDI = dr.GetInt32(NIVEL_CIDI); }
                    if (!dr.IsDBNull(CEL_COD_AREA)) { obj.CEL_COD_AREA = dr.GetInt32(CEL_COD_AREA); }
                    if (!dr.IsDBNull(CEL_NUMERO)) { obj.CEL_NUMERO = dr.GetInt32(CEL_NUMERO); }
                    if (!dr.IsDBNull(CEL_VALIDADO)) { obj.CEL_VALIDADO = dr.GetBoolean(CEL_VALIDADO); }
                    if (!dr.IsDBNull(CEL_COD_VALIDACION)) { obj.CEL_COD_VALIDACION = dr.GetInt32(CEL_COD_VALIDACION); }
                    if (!dr.IsDBNull(CEL_VIGENCIA_COD_VALIDACION)) { obj.CEL_VIGENCIA_COD_VALIDACION = dr.GetDateTime(CEL_VIGENCIA_COD_VALIDACION); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Vecino_digital> read()
        {
            try
            {
                List<Vecino_digital> lst = new List<Vecino_digital>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Vecino_digital";
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

        public static Vecino_digital getByPk(string CUIT)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Vecino_digital WHERE");
                sql.AppendLine("CUIT = @CUIT");
                Vecino_digital obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@CUIT", CUIT);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Vecino_digital> lst = mapeo(dr);
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

        public static int insert(Vecino_digital obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Vecino_digital(");
                sql.AppendLine("CUIT");
                sql.AppendLine(", APELLIDO");
                sql.AppendLine(", NOMBRE");
                sql.AppendLine(", NRO_DOC");
                sql.AppendLine(", FECHA_NACIMIENTO");
                sql.AppendLine(", DIRECCION");
                sql.AppendLine(", LOCALIDAD");
                sql.AppendLine(", COD_PROVINCIA");
                sql.AppendLine(", DESC_PROVINCIA");
                sql.AppendLine(", COD_POSTAL");
                sql.AppendLine(", TELEFONO");
                sql.AppendLine(", MAIL");
                sql.AppendLine(", PASSWORD");
                sql.AppendLine(", TIPODOCUMENTO");
                sql.AppendLine(", ACTIVO");
                sql.AppendLine(", CONFIRMADO");
                sql.AppendLine(", FECHA_ALTA");
                sql.AppendLine(", SEXO");
                sql.AppendLine(", MENSAF");
                sql.AppendLine(", NIVEL_CIDI");
                sql.AppendLine(", CEL_COD_AREA");
                sql.AppendLine(", CEL_NUMERO");
                sql.AppendLine(", CEL_VALIDADO");
                sql.AppendLine(", CEL_COD_VALIDACION");
                sql.AppendLine(", CEL_VIGENCIA_COD_VALIDACION");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@CUIT");
                sql.AppendLine(", @APELLIDO");
                sql.AppendLine(", @NOMBRE");
                sql.AppendLine(", @NRO_DOC");
                sql.AppendLine(", @FECHA_NACIMIENTO");
                sql.AppendLine(", @DIRECCION");
                sql.AppendLine(", @LOCALIDAD");
                sql.AppendLine(", @COD_PROVINCIA");
                sql.AppendLine(", @DESC_PROVINCIA");
                sql.AppendLine(", @COD_POSTAL");
                sql.AppendLine(", @TELEFONO");
                sql.AppendLine(", @MAIL");
                sql.AppendLine(", @PASSWORD");
                sql.AppendLine(", @TIPODOCUMENTO");
                sql.AppendLine(", @ACTIVO");
                sql.AppendLine(", @CONFIRMADO");
                sql.AppendLine(", @FECHA_ALTA");
                sql.AppendLine(", @SEXO");
                sql.AppendLine(", @MENSAF");
                sql.AppendLine(", @NIVEL_CIDI");
                sql.AppendLine(", @CEL_COD_AREA");
                sql.AppendLine(", @CEL_NUMERO");
                sql.AppendLine(", @CEL_VALIDADO");
                sql.AppendLine(", @CEL_COD_VALIDACION");
                sql.AppendLine(", @CEL_VIGENCIA_COD_VALIDACION");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@CUIT", obj.CUIT);
                    cmd.Parameters.AddWithValue("@APELLIDO", obj.APELLIDO);
                    cmd.Parameters.AddWithValue("@NOMBRE", obj.NOMBRE);
                    cmd.Parameters.AddWithValue("@NRO_DOC", obj.NRO_DOC);
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", obj.FECHA_NACIMIENTO);
                    cmd.Parameters.AddWithValue("@DIRECCION", obj.DIRECCION);
                    cmd.Parameters.AddWithValue("@LOCALIDAD", obj.LOCALIDAD);
                    cmd.Parameters.AddWithValue("@COD_PROVINCIA", obj.COD_PROVINCIA);
                    cmd.Parameters.AddWithValue("@DESC_PROVINCIA", obj.DESC_PROVINCIA);
                    cmd.Parameters.AddWithValue("@COD_POSTAL", obj.COD_POSTAL);
                    cmd.Parameters.AddWithValue("@TELEFONO", obj.TELEFONO);
                    cmd.Parameters.AddWithValue("@MAIL", obj.MAIL);
                    cmd.Parameters.AddWithValue("@PASSWORD", obj.PASSWORD);
                    cmd.Parameters.AddWithValue("@TIPODOCUMENTO", obj.TIPODOCUMENTO);
                    cmd.Parameters.AddWithValue("@ACTIVO", obj.ACTIVO);
                    cmd.Parameters.AddWithValue("@CONFIRMADO", obj.CONFIRMADO);
                    cmd.Parameters.AddWithValue("@FECHA_ALTA", obj.FECHA_ALTA);
                    cmd.Parameters.AddWithValue("@SEXO", obj.SEXO);
                    cmd.Parameters.AddWithValue("@MENSAF", obj.MENSAF);
                    cmd.Parameters.AddWithValue("@NIVEL_CIDI", obj.NIVEL_CIDI);
                    cmd.Parameters.AddWithValue("@CEL_COD_AREA", obj.CEL_COD_AREA);
                    cmd.Parameters.AddWithValue("@CEL_NUMERO", obj.CEL_NUMERO);
                    cmd.Parameters.AddWithValue("@CEL_VALIDADO", obj.CEL_VALIDADO);
                    cmd.Parameters.AddWithValue("@CEL_COD_VALIDACION", obj.CEL_COD_VALIDACION);
                    cmd.Parameters.AddWithValue("@CEL_VIGENCIA_COD_VALIDACION", obj.CEL_VIGENCIA_COD_VALIDACION);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Vecino_digital obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Vecino_digital SET");
                sql.AppendLine("APELLIDO=@APELLIDO");
                sql.AppendLine(", NOMBRE=@NOMBRE");
                sql.AppendLine(", NRO_DOC=@NRO_DOC");
                sql.AppendLine(", FECHA_NACIMIENTO=@FECHA_NACIMIENTO");
                sql.AppendLine(", DIRECCION=@DIRECCION");
                sql.AppendLine(", LOCALIDAD=@LOCALIDAD");
                sql.AppendLine(", COD_PROVINCIA=@COD_PROVINCIA");
                sql.AppendLine(", DESC_PROVINCIA=@DESC_PROVINCIA");
                sql.AppendLine(", COD_POSTAL=@COD_POSTAL");
                sql.AppendLine(", TELEFONO=@TELEFONO");
                sql.AppendLine(", MAIL=@MAIL");
                sql.AppendLine(", PASSWORD=@PASSWORD");
                sql.AppendLine(", TIPODOCUMENTO=@TIPODOCUMENTO");
                sql.AppendLine(", ACTIVO=@ACTIVO");
                sql.AppendLine(", CONFIRMADO=@CONFIRMADO");
                sql.AppendLine(", FECHA_ALTA=@FECHA_ALTA");
                sql.AppendLine(", SEXO=@SEXO");
                sql.AppendLine(", MENSAF=@MENSAF");
                sql.AppendLine(", NIVEL_CIDI=@NIVEL_CIDI");
                sql.AppendLine(", CEL_COD_AREA=@CEL_COD_AREA");
                sql.AppendLine(", CEL_NUMERO=@CEL_NUMERO");
                sql.AppendLine(", CEL_VALIDADO=@CEL_VALIDADO");
                sql.AppendLine(", CEL_COD_VALIDACION=@CEL_COD_VALIDACION");
                sql.AppendLine(", CEL_VIGENCIA_COD_VALIDACION=@CEL_VIGENCIA_COD_VALIDACION");
                sql.AppendLine("WHERE");
                sql.AppendLine("CUIT=@CUIT");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@CUIT", obj.CUIT);
                    cmd.Parameters.AddWithValue("@APELLIDO", obj.APELLIDO);
                    cmd.Parameters.AddWithValue("@NOMBRE", obj.NOMBRE);
                    cmd.Parameters.AddWithValue("@NRO_DOC", obj.NRO_DOC);
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", obj.FECHA_NACIMIENTO);
                    cmd.Parameters.AddWithValue("@DIRECCION", obj.DIRECCION);
                    cmd.Parameters.AddWithValue("@LOCALIDAD", obj.LOCALIDAD);
                    cmd.Parameters.AddWithValue("@COD_PROVINCIA", obj.COD_PROVINCIA);
                    cmd.Parameters.AddWithValue("@DESC_PROVINCIA", obj.DESC_PROVINCIA);
                    cmd.Parameters.AddWithValue("@COD_POSTAL", obj.COD_POSTAL);
                    cmd.Parameters.AddWithValue("@TELEFONO", obj.TELEFONO);
                    cmd.Parameters.AddWithValue("@MAIL", obj.MAIL);
                    cmd.Parameters.AddWithValue("@PASSWORD", obj.PASSWORD);
                    cmd.Parameters.AddWithValue("@TIPODOCUMENTO", obj.TIPODOCUMENTO);
                    cmd.Parameters.AddWithValue("@ACTIVO", obj.ACTIVO);
                    cmd.Parameters.AddWithValue("@CONFIRMADO", obj.CONFIRMADO);
                    cmd.Parameters.AddWithValue("@FECHA_ALTA", obj.FECHA_ALTA);
                    cmd.Parameters.AddWithValue("@SEXO", obj.SEXO);
                    cmd.Parameters.AddWithValue("@MENSAF", obj.MENSAF);
                    cmd.Parameters.AddWithValue("@NIVEL_CIDI", obj.NIVEL_CIDI);
                    cmd.Parameters.AddWithValue("@CEL_COD_AREA", obj.CEL_COD_AREA);
                    cmd.Parameters.AddWithValue("@CEL_NUMERO", obj.CEL_NUMERO);
                    cmd.Parameters.AddWithValue("@CEL_VALIDADO", obj.CEL_VALIDADO);
                    cmd.Parameters.AddWithValue("@CEL_COD_VALIDACION", obj.CEL_COD_VALIDACION);
                    cmd.Parameters.AddWithValue("@CEL_VIGENCIA_COD_VALIDACION", obj.CEL_VIGENCIA_COD_VALIDACION);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Vecino_digital obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Vecino_digital ");
                sql.AppendLine("WHERE");
                sql.AppendLine("CUIT=@CUIT");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@CUIT", obj.CUIT);
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

