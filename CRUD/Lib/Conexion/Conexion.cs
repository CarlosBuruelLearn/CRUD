using MySql.Data.MySqlClient;
using System.Data;

namespace CRUD.Lib.Conexion
{
    class Conexion
    {
        //Obtener consulta a la base de datos
        public DataTable getQuery(string sQuery)
        {
            try
            {
                MySqlDataAdapter mysqlDataAdapter = new MySqlDataAdapter(sQuery, mysqlConexion);
                DataSet dsDataSet = new DataSet();
                mysqlDataAdapter.Fill(dsDataSet, "consulta");
                return dsDataSet.Tables[0];
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public bool isChangeDataBase(MySqlCommand command)
        {
            try
            {
                command.Connection = mysqlConexion;
                mysqlConexion.Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                return false;
            }
            mysqlConexion.Close();
            return true;
        }

        //Obtener conexion de forma global
        public static Conexion obtenerConexion()
        {
            if (cConexion == null)
            {
                cConexion = new Conexion();
            }
            return cConexion;
        }

        private Conexion()
        {
            mysqlConexion = new MySqlConnection(sConexion);
        }

        //Datos base de conexion
        private string sConexion = "Database = db_cocina_economica; Data Source = Localhost; User Id = root; Password = root";

        //Instancia de conexion a la base de datos
        private MySqlConnection mysqlConexion;

        //Instancia global de conexion
        private static Conexion cConexion = null;
    }
}