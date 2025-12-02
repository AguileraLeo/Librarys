using System;
using System.Data;
using System.Data.SqlClient;

namespace PlayerUI.Datos
{
    /// Esta clase maneja TODA la comunicación con la base de datos GordontLibrary
    /// Es el "puente" entre la aplicación Windows Forms y SQL Server
    public class ConexionDB
    {
        private static string cadenaConexion = @"Server=LAPTOP-PDMTFTA9\SQLEXPRESS;Database=GordontLibrary;Trusted_Connection=True;TrustServerCertificate=True;";
        // MÉTODOS PRINCIPALES

        /// Obtiene una conexión a SQL Server
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            return conexion;
        }
        /// Ejecuta un Stored Procedure que retorna datos (SELECT)
        /// Ideal para llenar DataGridView, ComboBox, etc.
        public static DataTable EjecutarConsulta(string procedimiento, SqlParameter[] parametros)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(procedimiento, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }
                    conexion.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }

        /// Ejecuta un Stored Procedure que NO retorna datos (INSERT, UPDATE, DELETE)
        public static void EjecutarComando(string procedimiento, SqlParameter[] parametros = null)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(procedimiento, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros);
                }
                try
                {
                    conexion.Open();
                    int filasAfectadas= comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error al ejecutar el comando{procedimiento}: {ex.Message}");
                }
            }
        }
    }
}
