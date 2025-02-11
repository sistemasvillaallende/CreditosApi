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
        public string nombre { get; set; }  
        public int legajo { get; set; }
        public string domicilio { get; set; }
        public DateTime? fecha_alta { get; set; }
        public bool baja { get; set; }
        public DateTime? fecha_baja { get; set; }
        public string cuit_solicitante { get; set; }
        public string garantes { get; set; }
        public decimal presupuesto { get; set; }
        public decimal presupuesto_uva { get; set; }
        public int cant_cuotas { get; set; }
        public decimal? valor_cuota_uva { get; set; }
        public int id_uva { get; set; }
        public int id_estado { get; set; }
        public string? per_ultimo { get; set; }
        public Int16 con_deuda { get; set; }
        public decimal? saldo_adeudado { get; set; }
        public DateTime? proximo_vencimiento { get; set; }
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }


        public CM_Credito_materiales()
        {
            id_credito_materiales = 0;
            legajo = 0;
            domicilio = string.Empty;
            fecha_alta = DateTime.Now;
            nombre = string.Empty;
            baja = false;
            fecha_baja = null;
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
            proximo_vencimiento = DateTime.Now.AddMonths(1);
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
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
                int circunscripcion = dr.GetOrdinal("circunscripcion");
                int seccion = dr.GetOrdinal("seccion");
                int manzana = dr.GetOrdinal("manzana");
                int parcela = dr.GetOrdinal("parcela");
                int p_h = dr.GetOrdinal("p_h");
                int nomnre = dr.GetString("")

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
                    if (!dr.IsDBNull(circunscripcion)) { obj.circunscripcion = dr.GetInt32(circunscripcion); }
                    if (!dr.IsDBNull(seccion)) { obj.seccion = dr.GetInt32(seccion); }
                    if (!dr.IsDBNull(manzana)) { obj.manzana = dr.GetInt32(manzana); }
                    if (!dr.IsDBNull(parcela)) { obj.parcela = dr.GetInt32(parcela); }
                    if (!dr.IsDBNull(p_h)) { obj.p_h = dr.GetInt32(p_h); }

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
                    cmd.CommandText = "SELECT * FROM CM_CREDITO_MATERIALES";
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
                //sql.AppendLine("AND legajo = @legajo");
                CM_Credito_materiales obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_credito_materiales", id_credito_materiales);
                    //cmd.Parameters.AddWithValue("@legajo", legajo);
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



        public static CM_Credito_materiales GetById(int id_credito_materiales)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Cm_credito_materiales WHERE");
                sql.AppendLine("id_credito_materiales = @id_credito_materiales");
                CM_Credito_materiales obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_credito_materiales", id_credito_materiales);
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

        public static int insert(Model.CreditosModel obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Cm_credito_materiales(");
                sql.AppendLine("legajo");
                sql.AppendLine(", domicilio");
                //sql.AppendLine(", fecha_alta");
                //sql.AppendLine(", baja");
                //sql.AppendLine(", fecha_baja");
                sql.AppendLine(", cuit_solicitante");
                sql.AppendLine(", garantes");
                sql.AppendLine(", presupuesto");
                //sql.AppendLine(", presupuesto_uva");
                sql.AppendLine(", cant_cuotas");
                //sql.AppendLine(", valor_cuota_uva");
                //sql.AppendLine(", id_uva");
                //sql.AppendLine(", id_estado");
                //sql.AppendLine(", per_ultimo");
                //sql.AppendLine(", con_deuda");
                //sql.AppendLine(", saldo_adeudado");
                //sql.AppendLine(", proximo_vencimiento");
                sql.AppendLine(", circunscripcion");
                sql.AppendLine(", seccion");
                sql.AppendLine(", manzana");
                sql.AppendLine(", parcela");
                sql.AppendLine(", p_h");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@legajo");
                sql.AppendLine(", @domicilio");
                //sql.AppendLine(", @fecha_alta");
                //sql.AppendLine(", @baja");
                //sql.AppendLine(", @fecha_baja");
                sql.AppendLine(", @cuit_solicitante");
                sql.AppendLine(", @garantes");
                sql.AppendLine(", @presupuesto");
                //sql.AppendLine(", @presupuesto_uva");
                //sql.AppendLine(", @cant_cuotas");
                //sql.AppendLine(", @valor_cuota_uva");
                //sql.AppendLine(", @id_uva");
                //sql.AppendLine(", @id_estado");
                //sql.AppendLine(", @per_ultimo");
                //sql.AppendLine(", @con_deuda");
                //sql.AppendLine(", @saldo_adeudado");
                //sql.AppendLine(", @proximo_vencimiento");
                sql.AppendLine(", @circunscripcion");
                sql.AppendLine(", @seccion");
                sql.AppendLine(", @manzana");
                sql.AppendLine(", @parcela");
                sql.AppendLine(", @p_h");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@domicilio", obj.domicilio);
                    //cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    //cmd.Parameters.AddWithValue("@baja", obj.baja);
                    //cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja);
                    cmd.Parameters.AddWithValue("@cuit_solicitante", obj.cuit_solicitante);
                    cmd.Parameters.AddWithValue("@garantes", obj.garantes);
                    cmd.Parameters.AddWithValue("@presupuesto", obj.presupuesto);
                    //cmd.Parameters.AddWithValue("@presupuesto_uva", obj.presupuesto_uva);
                    cmd.Parameters.AddWithValue("@cant_cuotas", obj.cant_cuotas);
                    //cmd.Parameters.AddWithValue("@valor_cuota_uva", obj.valor_cuota_uva);
                    //cmd.Parameters.AddWithValue("@id_uva", obj.id_uva);
                    //cmd.Parameters.AddWithValue("@id_estado", obj.id_estado);
                    //cmd.Parameters.AddWithValue("@per_ultimo", obj.per_ultimo);
                    //cmd.Parameters.AddWithValue("@con_deuda", obj.con_deuda);
                    //cmd.Parameters.AddWithValue("@saldo_adeudado", obj.saldo_adeudado);
                    //cmd.Parameters.AddWithValue("@proximo_vencimiento", obj.proximo_vencimiento);
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);

                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(CM_Credito_materiales obj, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                string sql = @"
            INSERT INTO cm_credito_materiales (
                legajo, domicilio, fecha_alta, baja, fecha_baja, cuit_solicitante, 
                garantes, presupuesto, presupuesto_uva, cant_cuotas, valor_cuota_uva, 
                id_uva, id_estado, per_ultimo, con_deuda, saldo_adeudado, proximo_vencimiento, circunscripcion, 
                seccion,manzana, parcela , p_h
            ) 
            VALUES (
                @legajo, @domicilio, @fecha_alta, @baja, @fecha_baja, @cuit_solicitante, 
                @garantes, @presupuesto, @presupuesto_uva, @cant_cuotas, @valor_cuota_uva, 
                @id_uva, @id_estado, @per_ultimo, @con_deuda, @saldo_adeudado, @proximo_vencimiento,
                @circunscripcion, @seccion, @manzana, @parcela, @p_h
            );
            SELECT SCOPE_IDENTITY();
        ";

                using (SqlCommand cmd = new SqlCommand(sql, con, trx))
                {
                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@domicilio", obj.domicilio);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@baja", obj.baja);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@cuit_solicitante", obj.cuit_solicitante ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@garantes", obj.garantes ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@presupuesto", obj.presupuesto);
                    cmd.Parameters.AddWithValue("@presupuesto_uva", obj.presupuesto_uva);
                    cmd.Parameters.AddWithValue("@cant_cuotas", obj.cant_cuotas);
                    cmd.Parameters.AddWithValue("@valor_cuota_uva", obj.valor_cuota_uva);
                    cmd.Parameters.AddWithValue("@id_uva", obj.id_uva);
                    cmd.Parameters.AddWithValue("@id_estado", obj.id_estado);
                    cmd.Parameters.AddWithValue("@per_ultimo", obj.per_ultimo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@con_deuda", obj.con_deuda);
                    cmd.Parameters.AddWithValue("@saldo_adeudado", obj.saldo_adeudado);
                    cmd.Parameters.AddWithValue("@proximo_vencimiento", obj.proximo_vencimiento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);

                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el registro en Cm_credito_materiales", ex);
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
                sql.AppendLine(", circunscripcion = @circunscripcion");
                sql.AppendLine(", seccion = @seccion");
                sql.AppendLine(", manzana = @manzana");
                sql.AppendLine(", parcela = @parcela");
                sql.AppendLine(", p_h = @p_h");
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
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(int legajo, int id_credito_materiales, CM_Credito_materiales obj, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Cm_credito_materiales SET");
                sql.AppendLine("  legajo = @legajo");
                sql.AppendLine(", domicilio = @domicilio");
                sql.AppendLine(", fecha_alta = @fecha_alta");
                sql.AppendLine(", baja = @baja");
                sql.AppendLine(", fecha_baja = @fecha_baja");
                sql.AppendLine(", cuit_solicitante = @cuit_solicitante");
                sql.AppendLine(", garantes = @garantes");
                sql.AppendLine(", presupuesto = @presupuesto");
                sql.AppendLine(", presupuesto_uva = @presupuesto_uva");
                sql.AppendLine(", cant_cuotas = @cant_cuotas");
                sql.AppendLine(", valor_cuota_uva = @valor_cuota_uva");
                sql.AppendLine(", id_uva = @id_uva");
                sql.AppendLine(", id_estado = @id_estado");
                sql.AppendLine(", per_ultimo = @per_ultimo");
                sql.AppendLine(", con_deuda = @con_deuda");
                sql.AppendLine(", saldo_adeudado = @saldo_adeudado");
                sql.AppendLine(", proximo_vencimiento = @proximo_vencimiento");
                sql.AppendLine(", circunscripcion = @circunscripcion");
                sql.AppendLine(", seccion = @seccion");
                sql.AppendLine(", manzana = @manzana");
                sql.AppendLine(", parcela = @parcela");
                sql.AppendLine(", p_h = @p_h");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_credito_materiales = @id_credito_materiales");
                //sql.AppendLine("AND legajo = @legajo");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con, trx))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@legajo", obj.legajo);
                    cmd.Parameters.AddWithValue("@domicilio", obj.domicilio);
                    cmd.Parameters.AddWithValue("@fecha_alta", obj.fecha_alta);
                    cmd.Parameters.AddWithValue("@baja", obj.baja);
                    cmd.Parameters.AddWithValue("@fecha_baja", obj.fecha_baja ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@cuit_solicitante", obj.cuit_solicitante);
                    cmd.Parameters.AddWithValue("@garantes", obj.garantes);
                    cmd.Parameters.AddWithValue("@presupuesto", obj.presupuesto);
                    cmd.Parameters.AddWithValue("@presupuesto_uva", obj.presupuesto_uva);
                    cmd.Parameters.AddWithValue("@cant_cuotas", obj.cant_cuotas);
                    cmd.Parameters.AddWithValue("@valor_cuota_uva", obj.valor_cuota_uva);
                    cmd.Parameters.AddWithValue("@id_uva", obj.id_uva);
                    cmd.Parameters.AddWithValue("@id_estado", obj.id_estado);
                    cmd.Parameters.AddWithValue("@per_ultimo", obj.per_ultimo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@con_deuda", obj.con_deuda);
                    cmd.Parameters.AddWithValue("@saldo_adeudado", obj.saldo_adeudado);
                    cmd.Parameters.AddWithValue("@proximo_vencimiento", obj.proximo_vencimiento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@circunscripcion", obj.circunscripcion);
                    cmd.Parameters.AddWithValue("@seccion", obj.seccion);
                    cmd.Parameters.AddWithValue("@manzana", obj.manzana);
                    cmd.Parameters.AddWithValue("@parcela", obj.parcela);
                    cmd.Parameters.AddWithValue("@p_h", obj.p_h);
                    cmd.Parameters.AddWithValue("@id_credito_materiales", id_credito_materiales);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar Cm_credito_materiales con legajo {obj.legajo}: {ex.Message}", ex);
            }
        }


        public static void Delete(int legajo, int id_credito_materiales, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Cm_credito_materiales ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_credito_materiales=@id_credito_materiales");
                //sql.AppendLine("AND legajo=@legajo");

                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@id_credito_materiales", id_credito_materiales);
                //cmd.Parameters.AddWithValue("@legajo", legajo);
                //cmd.Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void BajaCredito(int legajo, int id_credito_materiales, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Cm_credito_materiales");
                sql.AppendLine("SET baja = @baja,");
                sql.AppendLine("fecha_baja = @fecha_baja");
                sql.AppendLine("WHERE id_credito_materiales = @id_credito_materiales");
                //sql.AppendLine("AND legajo = @legajo");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con, trx))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@baja", 1);
                    cmd.Parameters.AddWithValue("@fecha_baja", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id_credito_materiales", id_credito_materiales);
                    //cmd.Parameters.AddWithValue("@legajo", legajo);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al dar de baja el crédito con ID {id_credito_materiales} y legajo {legajo}: {ex.Message}", ex);
            }
        }

        public static void AltaCredito( int id_credito_materiales, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Cm_credito_materiales");
                sql.AppendLine("SET baja = @baja,");
                sql.AppendLine("fecha_baja = @fecha_baja");
                sql.AppendLine("WHERE id_credito_materiales = @id_credito_materiales");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con, trx))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@baja", 0);
                    cmd.Parameters.AddWithValue("@fecha_alta", DateTime.Now);
                    cmd.Parameters.AddWithValue("@fecha_baja", DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_credito_materiales", id_credito_materiales);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al dar de baja el crédito con ID {id_credito_materiales}: {ex.Message}", ex);
            }
        }

        public static int Count()
        {
            try
            {
                int count = 0;
                string sql = @"SELECT count(*) 
                               FROM CM_CREDITO_MATERIALES (nolock)";

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<CM_Credito_materiales> GetCreditoMPaginado(string buscarPor, string? strParametro,
         int pagina, int registros_por_pagina)
        {
            try
            {
                List<CM_Credito_materiales> lst = new List<CM_Credito_materiales>();
                string sqlWhere = "";


                if (!string.IsNullOrEmpty(strParametro))
                {
                    switch (buscarPor)
                    {
                        case "legajo":
                            sqlWhere += @" WHERE legajo LIKE @parametro + '%' 
                               ";
                            break;
                        case "cuit":
                            sqlWhere += @" WHERE cuit_solicitante LIKE @parametro + '%'
                               ";
                            break;
                        default:
                            sqlWhere += @" WHERE legajo LIKE @parametro + '%' 
                               ";
                            break;
                    }
                }
                else
                {

                    sqlWhere += " WHERE 1=1";
                }

                string sql = $@"
            WITH CreditoMaterialesFiltrados AS (
                SELECT *,
                       COUNT(*) OVER () AS TotalRegistros
                FROM CM_CREDITO_MATERIALES (nolock)
                {sqlWhere}
            )
            SELECT *
            FROM CreditoMaterialesFiltrados
            ORDER BY legajo
            OFFSET CASE WHEN (SELECT MAX(TotalRegistros) FROM CreditoMaterialesFiltrados) > @CantidadElementosPagina 
                        THEN (@numeroPagina) * @CantidadElementosPagina ELSE 0 END ROWS
            FETCH NEXT CASE WHEN (SELECT MAX(TotalRegistros) FROM CreditoMaterialesFiltrados) > @CantidadElementosPagina 
                            THEN @CantidadElementosPagina ELSE (SELECT MAX(TotalRegistros) FROM CreditoMaterialesFiltrados) END ROWS ONLY;
        ";

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@numeroPagina", pagina);
                    cmd.Parameters.AddWithValue("@CantidadElementosPagina", registros_por_pagina);
                    cmd.Parameters.AddWithValue("@parametro", strParametro);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error al obtener credito materiales paginados", ex);
            }
        }




    }
}

