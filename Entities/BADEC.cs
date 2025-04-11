using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditosApi.Entities;
namespace CreditosApi.Entities
{
    public class BADEC : DALBase
    {
        public int nro_bad { get; set; }
        public bool interno { get; set; }
        public bool persona { get; set; }
        public bool contribuyente { get; set; }
        public string tipo_instit { get; set; }
        public string nombre { get; set; }
        public string tip_doc { get; set; }
        public string nro_doc { get; set; }
        public int cod_calle { get; set; }
        public int nro_dom { get; set; }
        public int cod_barrio { get; set; }
        public string cod_postal { get; set; }
        public string localidad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public int cod_nivel_vida { get; set; }
        public int cod_vip { get; set; }
        public int codigo_actividad { get; set; }
        public string telefono { get; set; }
        public string e_mail { get; set; }
        public int nro_contrib { get; set; }
        public string piso_dpto { get; set; }
        public string nombre_calle { get; set; }
        public string nombre_barrio { get; set; }
        public string titulo { get; set; }
        public string cuit { get; set; }
        public string sexo { get; set; }
        public DateTime fecha_alta { get; set; }
        public int id_tip_doc { get; set; }
        public string cod_postal_arg { get; set; }
        public string celular { get; set; }
        public string usuario { get; set; }
        public string subsistema { get; set; }
        public Int64 cuit_afip { get; set; }
        public bool ciudadano_digital { get; set; }
        public DateTime fecha_nacimiento { get; set; }

        public BADEC()
        {
            nro_bad = 0;
            interno = false;
            persona = false;
            contribuyente = false;
            tipo_instit = string.Empty;
            nombre = string.Empty;
            tip_doc = string.Empty;
            nro_doc = string.Empty;
            cod_calle = 0;
            nro_dom = 0;
            cod_barrio = 0;
            cod_postal = string.Empty;
            localidad = string.Empty;
            provincia = string.Empty;
            pais = string.Empty;
            cod_nivel_vida = 0;
            cod_vip = 0;
            codigo_actividad = 0;
            telefono = string.Empty;
            e_mail = string.Empty;
            nro_contrib = 0;
            piso_dpto = string.Empty;
            nombre_calle = string.Empty;
            nombre_barrio = string.Empty;
            titulo = string.Empty;
            cuit = string.Empty;
            sexo = string.Empty;
            fecha_alta = DateTime.Now;
            id_tip_doc = 0;
            cod_postal_arg = string.Empty;
            celular = string.Empty;
            usuario = string.Empty;
            subsistema = string.Empty;
            cuit_afip = 0;
            ciudadano_digital = false;
            fecha_nacimiento = DateTime.Now;
        }

        private static List<BADEC> mapeo2(SqlDataReader dr)
        {
            List<BADEC> lst = new List<BADEC>();
            BADEC obj;
            if (dr.HasRows)
            {
                int nro_bad = dr.GetOrdinal("nro_bad");
                int nombre = dr.GetOrdinal("nombre");
                int tip_doc = dr.GetOrdinal("tip_doc");
                int nro_doc = dr.GetOrdinal("nro_doc");
                int e_mail = dr.GetOrdinal("e_mail");
                while (dr.Read())
                {
                    obj = new BADEC();
                    if (!dr.IsDBNull(nro_bad)) { obj.nro_bad = dr.GetInt32(nro_bad); }
                    if (!dr.IsDBNull(nombre)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(tip_doc)) { obj.tip_doc = dr.GetString(tip_doc); }
                    if (!dr.IsDBNull(nro_doc)) { obj.nro_doc = dr.GetString(nro_doc); }
                    if (!dr.IsDBNull(e_mail)) { obj.e_mail = dr.GetString(e_mail); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        private static List<BADEC> mapeo3(SqlDataReader dr)
        {
            List<BADEC> lst = new List<BADEC>();
            BADEC obj;
            if (dr.HasRows)
            {
                int nro_bad = dr.GetOrdinal("nro_bad");
                int nombre = dr.GetOrdinal("nombre");
                int cod_calle = dr.GetOrdinal("cod_calle");
                int nombre_calle = dr.GetOrdinal("nombre_calle");
                int cod_barrio = dr.GetOrdinal("cod_barrio");
                int nombre_barrio = dr.GetOrdinal("nombre_barrio");
                int nro_dom = dr.GetOrdinal("nro_dom");
                int piso_dpto = dr.GetOrdinal("piso_dpto");
                int localidad = dr.GetOrdinal("localidad");
                int provincia = dr.GetOrdinal("provincia");
                int cuit = dr.GetOrdinal("cuit");
                int cod_postal = dr.GetOrdinal("cod_postal");
                int e_mail = dr.GetOrdinal("e_mail");
                int celular = dr.GetOrdinal("celular");
                int sexo = dr.GetOrdinal("sexo");


                while (dr.Read())
                {
                    obj = new BADEC();
                    if (!dr.IsDBNull(0)) { obj.nro_bad = dr.GetInt32(nro_bad); }
                    if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(nombre); }
                    if (!dr.IsDBNull(2)) { obj.cod_calle = dr.GetInt32(cod_calle); }
                    if (!dr.IsDBNull(3)) { obj.nombre_calle = dr.GetString(nombre_calle); }
                    if (!dr.IsDBNull(4)) { obj.cod_barrio = dr.GetInt32(cod_barrio); }
                    if (!dr.IsDBNull(5)) { obj.nombre_barrio = dr.GetString(nombre_barrio); }
                    if (!dr.IsDBNull(6)) { obj.nro_dom = dr.GetInt32(nro_dom); }
                    if (!dr.IsDBNull(7)) { obj.piso_dpto = dr.GetString(piso_dpto); }
                    if (!dr.IsDBNull(8)) { obj.localidad = dr.GetString(localidad); }
                    if (!dr.IsDBNull(9)) { obj.provincia = dr.GetString(provincia); }
                    if (!dr.IsDBNull(10)) { obj.cod_postal = dr.GetString(cod_postal); }
                    if (!dr.IsDBNull(11)) { obj.cuit = dr.GetString(cuit); }
                    if (!dr.IsDBNull(12)) { obj.e_mail = dr.GetString(e_mail); }
                    if (!dr.IsDBNull(13)) { obj.celular = dr.GetString(celular); }
                    if (!dr.IsDBNull(14)) { obj.sexo = dr.GetString(sexo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        private static List<BADEC> mapeo(SqlDataReader dr)
        {
            List<BADEC> lst = new List<BADEC>();
            BADEC obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new BADEC();
                    if (!dr.IsDBNull(0)) { obj.nro_bad = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.interno = dr.GetBoolean(1); }
                    if (!dr.IsDBNull(2)) { obj.persona = dr.GetBoolean(2); }
                    if (!dr.IsDBNull(3)) { obj.contribuyente = dr.GetBoolean(3); }
                    if (!dr.IsDBNull(4)) { obj.tipo_instit = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.nombre = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.tip_doc = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.nro_doc = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.cod_calle = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.nro_dom = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.cod_barrio = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.cod_postal = dr.GetString(11); }
                    if (!dr.IsDBNull(12)) { obj.localidad = dr.GetString(12); }
                    if (!dr.IsDBNull(13)) { obj.provincia = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.pais = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.cod_nivel_vida = dr.GetInt32(15); }
                    if (!dr.IsDBNull(16)) { obj.cod_vip = dr.GetInt32(16); }
                    if (!dr.IsDBNull(17)) { obj.codigo_actividad = dr.GetInt32(17); }
                    if (!dr.IsDBNull(18)) { obj.telefono = dr.GetString(18); }
                    if (!dr.IsDBNull(19)) { obj.e_mail = dr.GetString(19); }
                    if (!dr.IsDBNull(20)) { obj.nro_contrib = dr.GetInt32(20); }
                    if (!dr.IsDBNull(21)) { obj.piso_dpto = dr.GetString(21); }
                    if (!dr.IsDBNull(22)) { obj.nombre_calle = dr.GetString(22); }
                    if (!dr.IsDBNull(23)) { obj.nombre_barrio = dr.GetString(23); }
                    if (!dr.IsDBNull(24)) { obj.titulo = dr.GetString(24); }
                    if (!dr.IsDBNull(25)) { obj.cuit = dr.GetString(25); }
                    if (!dr.IsDBNull(26)) { obj.sexo = dr.GetString(26); }
                    if (!dr.IsDBNull(27)) { obj.fecha_alta = dr.GetDateTime(27); }
                    if (!dr.IsDBNull(28)) { obj.id_tip_doc = dr.GetInt32(28); }
                    if (!dr.IsDBNull(29)) { obj.cod_postal_arg = dr.GetString(29); }
                    if (!dr.IsDBNull(30)) { obj.celular = dr.GetString(30); }
                    if (!dr.IsDBNull(31)) { obj.usuario = dr.GetString(31); }
                    if (!dr.IsDBNull(32)) { obj.subsistema = dr.GetString(32); }
                    if (!dr.IsDBNull(33)) { obj.cuit_afip = dr.GetInt64(33); }
                    if (!dr.IsDBNull(34)) { obj.ciudadano_digital = dr.GetBoolean(34); }
                    if (!dr.IsDBNull(35)) { obj.fecha_nacimiento = dr.GetDateTime(35); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<BADEC> read2()
        {
            try
            {
                List<BADEC> lst = new List<BADEC>();
                BADEC obj;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT TOP 5000 nro_bad, nombre, tip_doc, nro_doc, e_mail FROM BADEC";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new BADEC();
                            if (!dr.IsDBNull(0)) { obj.nro_bad = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.nombre = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.tip_doc = dr.GetString(2); }
                            if (!dr.IsDBNull(3)) { obj.nro_doc = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.e_mail = dr.GetString(4); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<BADEC> read()
        {
            try
            {
                List<BADEC> lst = new List<BADEC>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT top 100 *FROM BADEC";
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

        public static BADEC getByPk(int NRO_BAD)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT TOP 100 * FROM BADEC WHERE");
                sql.AppendLine("NRO_BAD = @NRO_BAD");
                BADEC obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_BAD", NRO_BAD);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<BADEC> lst = mapeo(dr);
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

        public static List<BADEC> GetBadecByCuit(string cuit)
        {
            try
            {
                string sql =
                    @"SELECT TOP 100
                        0 AS NRO_BAD,
	                        APELLIDO + ', ' + NOMBRE AS NOMBRE, 
	                        0 AS COD_CALLE, 
	                        DIRECCION AS NOMBRE_CALLE,
	                        0 AS COD_BARRIO, 
	                        '' AS NOMBRE_BARRIO, 
	                        0 AS NRO_DOM,
	                        '' AS PISO_DPTO,
	                        Localidad, 
	                        DESC_PROVINCIA AS PROVINCIA, 
	                        COD_POSTAl,
	                        CUIT,
	                        MAIL AS E_MAIL,                        
	                        CONVERT(VARCHAR, CEL_COD_AREA) + ' - ' + CONVERT(VARCHAR, CEL_NUMERO) AS celular,
	                        sexo
                        FROM VECINO_DIGITAL  
                        WHERE CUIT LIKE @cuit";
                List<BADEC> lst = new List<BADEC>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@cuit", $"%{cuit}%"); 
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo3(dr);
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static BADEC getByPk2(int nro_bad)
        {
            try
            {
                string sql = string.Empty;
                sql = @" SELECT  NRO_BAD,NOMBRE,TIP_DOC,NRO_DOC,E_MAIL=ISNULL(E_MAIL,'') 
                        FROM BADEC  
                        WHERE nro_bad = @nro_bad";
                BADEC? obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_bad", nro_bad);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<BADEC> lst = mapeo2(dr);
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
        public static List<BADEC> GetBadecByNombre(string nombre)
        {
            try
            {
                string sql = string.Empty;
                sql = @"SELECT
                        NRO_BAD, NOMBRE, COD_CALLE, NOMBRE_CALLE,
                        COD_BARRIO, NOMBRE_BARRIO, NRO_DOM,
                        PISO_DPTO = ISNULL(PISO_DPTO, ''),
                        Localidad, PROVINCIA, COD_POSTAl=isnull(COD_POSTAl,0),
                        CUIT=ISNULL(CUIT,''),
                        E_MAIL = ISNULL(E_MAIL, ''),
                        celular,
                        sexo
                        FROM BADEC  
                        WHERE nombre like @nombre +'%' ";
                List<BADEC> lst = new List<BADEC>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo3(dr);
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int insert(BADEC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO BADEC(");
                sql.AppendLine("INTERNO");
                sql.AppendLine(", PERSONA");
                sql.AppendLine(", CONTRIBUYENTE");
                sql.AppendLine(", TIPO_INSTIT");
                sql.AppendLine(", NOMBRE");
                sql.AppendLine(", TIP_DOC");
                sql.AppendLine(", NRO_DOC");
                sql.AppendLine(", COD_CALLE");
                sql.AppendLine(", NRO_DOM");
                sql.AppendLine(", COD_BARRIO");
                sql.AppendLine(", COD_POSTAL");
                sql.AppendLine(", LOCALIDAD");
                sql.AppendLine(", PROVINCIA");
                sql.AppendLine(", PAIS");
                sql.AppendLine(", COD_NIVEL_VIDA");
                sql.AppendLine(", COD_VIP");
                sql.AppendLine(", CODIGO_ACTIVIDAD");
                sql.AppendLine(", TELEFONO");
                sql.AppendLine(", E_MAIL");
                sql.AppendLine(", NRO_CONTRIB");
                sql.AppendLine(", PISO_DPTO");
                sql.AppendLine(", NOMBRE_CALLE");
                sql.AppendLine(", NOMBRE_BARRIO");
                sql.AppendLine(", TITULO");
                sql.AppendLine(", CUIT");
                sql.AppendLine(", SEXO");
                sql.AppendLine(", FECHA_ALTA");
                sql.AppendLine(", ID_TIP_DOC");
                sql.AppendLine(", COD_POSTAL_ARG");
                sql.AppendLine(", CELULAR");
                sql.AppendLine(", USUARIO");
                sql.AppendLine(", SUBSISTEMA");
                sql.AppendLine(", CUIT_AFIP");
                sql.AppendLine(", CIUDADANO_DIGITAL");
                sql.AppendLine(", FECHA_NACIMIENTO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@INTERNO");
                sql.AppendLine(", @PERSONA");
                sql.AppendLine(", @CONTRIBUYENTE");
                sql.AppendLine(", @TIPO_INSTIT");
                sql.AppendLine(", @NOMBRE");
                sql.AppendLine(", @TIP_DOC");
                sql.AppendLine(", @NRO_DOC");
                sql.AppendLine(", @COD_CALLE");
                sql.AppendLine(", @NRO_DOM");
                sql.AppendLine(", @COD_BARRIO");
                sql.AppendLine(", @COD_POSTAL");
                sql.AppendLine(", @LOCALIDAD");
                sql.AppendLine(", @PROVINCIA");
                sql.AppendLine(", @PAIS");
                sql.AppendLine(", @COD_NIVEL_VIDA");
                sql.AppendLine(", @COD_VIP");
                sql.AppendLine(", @CODIGO_ACTIVIDAD");
                sql.AppendLine(", @TELEFONO");
                sql.AppendLine(", @E_MAIL");
                sql.AppendLine(", @NRO_CONTRIB");
                sql.AppendLine(", @PISO_DPTO");
                sql.AppendLine(", @NOMBRE_CALLE");
                sql.AppendLine(", @NOMBRE_BARRIO");
                sql.AppendLine(", @TITULO");
                sql.AppendLine(", @CUIT");
                sql.AppendLine(", @SEXO");
                sql.AppendLine(", @FECHA_ALTA");
                sql.AppendLine(", @ID_TIP_DOC");
                sql.AppendLine(", @COD_POSTAL_ARG");
                sql.AppendLine(", @CELULAR");
                sql.AppendLine(", @USUARIO");
                sql.AppendLine(", @SUBSISTEMA");
                sql.AppendLine(", @CUIT_AFIP");
                sql.AppendLine(", @CIUDADANO_DIGITAL");
                sql.AppendLine(", @FECHA_NACIMIENTO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@INTERNO", obj.interno);
                    cmd.Parameters.AddWithValue("@PERSONA", obj.persona);
                    cmd.Parameters.AddWithValue("@CONTRIBUYENTE", obj.contribuyente);
                    cmd.Parameters.AddWithValue("@TIPO_INSTIT", obj.tipo_instit);
                    cmd.Parameters.AddWithValue("@NOMBRE", obj.nombre);
                    cmd.Parameters.AddWithValue("@TIP_DOC", obj.tip_doc);
                    cmd.Parameters.AddWithValue("@NRO_DOC", obj.nro_doc);
                    cmd.Parameters.AddWithValue("@COD_CALLE", obj.cod_calle);
                    cmd.Parameters.AddWithValue("@NRO_DOM", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@COD_BARRIO", obj.cod_barrio);
                    cmd.Parameters.AddWithValue("@COD_POSTAL", obj.cod_postal);
                    cmd.Parameters.AddWithValue("@LOCALIDAD", obj.localidad);
                    cmd.Parameters.AddWithValue("@PROVINCIA", obj.provincia);
                    cmd.Parameters.AddWithValue("@PAIS", obj.pais);
                    cmd.Parameters.AddWithValue("@COD_NIVEL_VIDA", obj.cod_nivel_vida);
                    cmd.Parameters.AddWithValue("@COD_VIP", obj.cod_vip);
                    cmd.Parameters.AddWithValue("@CODIGO_ACTIVIDAD", obj.codigo_actividad);
                    cmd.Parameters.AddWithValue("@TELEFONO", obj.telefono);
                    cmd.Parameters.AddWithValue("@E_MAIL", obj.e_mail);
                    cmd.Parameters.AddWithValue("@NRO_CONTRIB", obj.nro_contrib);
                    cmd.Parameters.AddWithValue("@PISO_DPTO", obj.piso_dpto);
                    cmd.Parameters.AddWithValue("@NOMBRE_CALLE", obj.nombre_calle);
                    cmd.Parameters.AddWithValue("@NOMBRE_BARRIO", obj.nombre_barrio);
                    cmd.Parameters.AddWithValue("@TITULO", obj.titulo);
                    cmd.Parameters.AddWithValue("@CUIT", obj.cuit);
                    cmd.Parameters.AddWithValue("@SEXO", obj.sexo);
                    cmd.Parameters.AddWithValue("@FECHA_ALTA", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@ID_TIP_DOC", obj.id_tip_doc);
                    cmd.Parameters.AddWithValue("@COD_POSTAL_ARG", obj.cod_postal_arg);
                    cmd.Parameters.AddWithValue("@CELULAR", obj.celular);
                    cmd.Parameters.AddWithValue("@USUARIO", obj.usuario);
                    cmd.Parameters.AddWithValue("@SUBSISTEMA", obj.subsistema);
                    cmd.Parameters.AddWithValue("@CUIT_AFIP", obj.cuit_afip);
                    cmd.Parameters.AddWithValue("@CIUDADANO_DIGITAL", obj.ciudadano_digital);
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", obj.fecha_nacimiento);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(BADEC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  BADEC SET");
                sql.AppendLine("INTERNO=@INTERNO");
                sql.AppendLine(", PERSONA=@PERSONA");
                sql.AppendLine(", CONTRIBUYENTE=@CONTRIBUYENTE");
                sql.AppendLine(", TIPO_INSTIT=@TIPO_INSTIT");
                sql.AppendLine(", NOMBRE=@NOMBRE");
                sql.AppendLine(", TIP_DOC=@TIP_DOC");
                sql.AppendLine(", NRO_DOC=@NRO_DOC");
                sql.AppendLine(", COD_CALLE=@COD_CALLE");
                sql.AppendLine(", NRO_DOM=@NRO_DOM");
                sql.AppendLine(", COD_BARRIO=@COD_BARRIO");
                sql.AppendLine(", COD_POSTAL=@COD_POSTAL");
                sql.AppendLine(", LOCALIDAD=@LOCALIDAD");
                sql.AppendLine(", PROVINCIA=@PROVINCIA");
                sql.AppendLine(", PAIS=@PAIS");
                sql.AppendLine(", COD_NIVEL_VIDA=@COD_NIVEL_VIDA");
                sql.AppendLine(", COD_VIP=@COD_VIP");
                sql.AppendLine(", CODIGO_ACTIVIDAD=@CODIGO_ACTIVIDAD");
                sql.AppendLine(", TELEFONO=@TELEFONO");
                sql.AppendLine(", E_MAIL=@E_MAIL");
                sql.AppendLine(", NRO_CONTRIB=@NRO_CONTRIB");
                sql.AppendLine(", PISO_DPTO=@PISO_DPTO");
                sql.AppendLine(", NOMBRE_CALLE=@NOMBRE_CALLE");
                sql.AppendLine(", NOMBRE_BARRIO=@NOMBRE_BARRIO");
                sql.AppendLine(", TITULO=@TITULO");
                sql.AppendLine(", CUIT=@CUIT");
                sql.AppendLine(", SEXO=@SEXO");
                sql.AppendLine(", FECHA_ALTA=@FECHA_ALTA");
                sql.AppendLine(", ID_TIP_DOC=@ID_TIP_DOC");
                sql.AppendLine(", COD_POSTAL_ARG=@COD_POSTAL_ARG");
                sql.AppendLine(", CELULAR=@CELULAR");
                sql.AppendLine(", USUARIO=@USUARIO");
                sql.AppendLine(", SUBSISTEMA=@SUBSISTEMA");
                sql.AppendLine(", CUIT_AFIP=@CUIT_AFIP");
                sql.AppendLine(", CIUDADANO_DIGITAL=@CIUDADANO_DIGITAL");
                sql.AppendLine(", FECHA_NACIMIENTO=@FECHA_NACIMIENTO");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_BAD=@NRO_BAD");
                sql.AppendLine("AND FECHA_NACIMIENTO=@FECHA_NACIMIENTO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@INTERNO", obj.interno);
                    cmd.Parameters.AddWithValue("@PERSONA", obj.persona);
                    cmd.Parameters.AddWithValue("@CONTRIBUYENTE", obj.contribuyente);
                    cmd.Parameters.AddWithValue("@TIPO_INSTIT", obj.tipo_instit);
                    cmd.Parameters.AddWithValue("@NOMBRE", obj.nombre);
                    cmd.Parameters.AddWithValue("@TIP_DOC", obj.tip_doc);
                    cmd.Parameters.AddWithValue("@NRO_DOC", obj.nro_doc);
                    cmd.Parameters.AddWithValue("@COD_CALLE", obj.cod_calle);
                    cmd.Parameters.AddWithValue("@NRO_DOM", obj.nro_dom);
                    cmd.Parameters.AddWithValue("@COD_BARRIO", obj.cod_barrio);
                    cmd.Parameters.AddWithValue("@COD_POSTAL", obj.cod_postal);
                    cmd.Parameters.AddWithValue("@LOCALIDAD", obj.localidad);
                    cmd.Parameters.AddWithValue("@PROVINCIA", obj.provincia);
                    cmd.Parameters.AddWithValue("@PAIS", obj.pais);
                    cmd.Parameters.AddWithValue("@COD_NIVEL_VIDA", obj.cod_nivel_vida);
                    cmd.Parameters.AddWithValue("@COD_VIP", obj.cod_vip);
                    cmd.Parameters.AddWithValue("@CODIGO_ACTIVIDAD", obj.codigo_actividad);
                    cmd.Parameters.AddWithValue("@TELEFONO", obj.telefono);
                    cmd.Parameters.AddWithValue("@E_MAIL", obj.e_mail);
                    cmd.Parameters.AddWithValue("@NRO_CONTRIB", obj.nro_contrib);
                    cmd.Parameters.AddWithValue("@PISO_DPTO", obj.piso_dpto);
                    cmd.Parameters.AddWithValue("@NOMBRE_CALLE", obj.nombre_calle);
                    cmd.Parameters.AddWithValue("@NOMBRE_BARRIO", obj.nombre_barrio);
                    cmd.Parameters.AddWithValue("@TITULO", obj.titulo);
                    cmd.Parameters.AddWithValue("@CUIT", obj.cuit);
                    cmd.Parameters.AddWithValue("@SEXO", obj.sexo);
                    cmd.Parameters.AddWithValue("@FECHA_ALTA", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@ID_TIP_DOC", obj.id_tip_doc);
                    cmd.Parameters.AddWithValue("@COD_POSTAL_ARG", obj.cod_postal_arg);
                    cmd.Parameters.AddWithValue("@CELULAR", obj.celular);
                    cmd.Parameters.AddWithValue("@USUARIO", obj.usuario);
                    cmd.Parameters.AddWithValue("@SUBSISTEMA", obj.subsistema);
                    cmd.Parameters.AddWithValue("@CUIT_AFIP", obj.cuit_afip);
                    cmd.Parameters.AddWithValue("@CIUDADANO_DIGITAL", obj.ciudadano_digital);
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", obj.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("@NRO_BAD", obj.nro_bad);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update2(BADEC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  BADEC SET");
                sql.AppendLine(" NOMBRE=@NOMBRE");
                sql.AppendLine(", TIP_DOC=@TIP_DOC");
                sql.AppendLine(", NRO_DOC=@NRO_DOC");
                sql.AppendLine(", E_MAIL=@E_MAIL ");
                sql.AppendLine(" WHERE ");
                sql.AppendLine("NRO_BAD=@nro_bad");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NOMBRE", obj.nombre);
                    cmd.Parameters.AddWithValue("@TIP_DOC", obj.tip_doc);
                    cmd.Parameters.AddWithValue("@NRO_DOC", obj.nro_doc);
                    cmd.Parameters.AddWithValue("@E_MAIL", obj.e_mail);
                    cmd.Parameters.AddWithValue("@NRO_BAD", obj.nro_bad);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int nro_bad)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  BADEC ");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_BAD=@NRO_BAD");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@nro_bad", nro_bad);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

