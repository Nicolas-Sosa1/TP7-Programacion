using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP7_Grupo18_Programacion.Clases
{
    public class Conexion
    {
        string cadenaConexion = "Data Source=localhost\\sqlexpress;Initial Catalog = BDSucursales; Integrated Security = True";

        // Metodo establecer conexion
        public SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch
            {
                return null;
            }
        }

        public SqlDataAdapter ObtenerAdaptador(string consultaSql)
        {
            SqlDataAdapter sqlDataAdapter;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(consultaSql, ObtenerConexion());
                return sqlDataAdapter;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}