using System.Data.SqlClient;

namespace CreditosApi.Entities
{
    public class DALBase
    {
        public DALBase()
        {

        }

        private static string DBMain = @"Data Source=10.0.0.8; Initial Catalog=SIIMVA; 
                                  Persist Security Info=True; 
                                  User ID=general; 
                                  Min Pool Size=0;
                                  Max Pool Size=10024;
                                  Pooling=true;";
        public static SqlConnection GetConnection()
        {
            string connectionString;
            SqlConnection objCon;
            //    <add name="DBMain" />
            connectionString = DBMain;
            objCon = new SqlConnection(connectionString);
            return objCon;
        }


        public static SqlConnection GetConnection(string strDB)
        {
            try
            {
                return new SqlConnection("Data Source=10.0.0.23;Initial Catalog=" + strDB + ";User ID=general");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
