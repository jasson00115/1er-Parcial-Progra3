using System;
using System.Data;
using System.Data.SqlClient;

namespace arbolsiempre.clases.BaseDatos
{
    class Conexion
    {

        
        public SqlConnection conexion;
        private String _conexion { get; }

        public Conexion()
        {

            _conexion = "Data Source=TST\\SQLEXPRESS;Initial Catalog=Arbol;Integrated Security=True";

        }


        public void cerrarConexionBD()
        {
            conexion.Close();
        }

        public void abrirConexion()
        {
            conexion = new SqlConnection(_conexion);
            conexion.Open();
        }

        
        /// <param name="sqll"></param>
        
        public DataTable consultaTablaDirecta(String sqll)
        {
            abrirConexion();
            SqlDataReader dr;
            SqlCommand comm = new SqlCommand(sqll, conexion);
            dr = comm.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(dr);
            cerrarConexionBD();
            return dataTable;
        }

       
        /// <param name="sqll"></param>
        public void EjecutaSQLDirecto(String sqll)
        {
            abrirConexion();
            try
            {

                SqlCommand comm = new SqlCommand(sqll, conexion);
                comm.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                cerrarConexionBD();
            }

        }

       
        /// <param name="sqll"></param>
        public void EjecutaSQLManual(String sqll)
        {
            // se abre y cierra la conexino manualmente
            SqlCommand comm = new SqlCommand(sqll, conexion);
            comm.ExecuteReader();
        }


    }
}
