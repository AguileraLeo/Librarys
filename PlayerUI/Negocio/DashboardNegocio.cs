using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PlayerUI.Datos;
using PlayerUI.Modelos;

namespace PlayerUI.Negocio
{
    public class DashboardNegocio
    {
        private LibroDatos datosLibro = new LibroDatos();
        private UsuarioDatos datosUsuario = new UsuarioDatos();
        private MultaDatos datosMulta = new MultaDatos();
        private PrestamoDatos datosPrestamo = new PrestamoDatos();

        public EstadisticasDashboard ObtenerEstadisticasCompletas()
        {
            try
            {
                var estadisticas = new EstadisticasDashboard();

                DataTable dtStats = datosLibro.ObtenerEstadisticasDashboard();
                if (dtStats.Rows.Count > 0)
                {
                    DataRow row = dtStats.Rows[0];
                    estadisticas.TotalUsuarios = Convert.ToInt32(row["totalUsuarios"]);
                    estadisticas.TotalLibros = Convert.ToInt32(row["totalLibros"]);
                    estadisticas.PrestamosActivos = Convert.ToInt32(row["prestamosActivos"]);
                    estadisticas.TotalPrestamos = Convert.ToInt32(row["totalPrestamos"]);
                    estadisticas.MultasPendientes = Convert.ToDecimal(row["multasPendientes"]);
                    estadisticas.TasaDevolucionPorcentaje = Convert.ToDecimal(row["tasaDevolucionPorcentaje"]);
                }

                return estadisticas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener estadísticas del dashboard: {ex.Message}");
            }
        }

        public List<dynamic> ObtenerTopLibrosMasPrestados(int cantidad = 10)
        {
            try
            {
                DataTable dt = datosLibro.ObtenerTopLibrosMasPrestados(cantidad);
                var resultado = new List<dynamic>();
                int posicion = 1;

                foreach (DataRow row in dt.Rows)
                {
                    resultado.Add(new
                    {
                        Posicion = posicion++,
                        Titulo = TruncarTexto(row["titulo"].ToString(), 30),
                        Autor = TruncarTexto(row["autor"].ToString(), 20),
                        Categoria = row["categoria"].ToString(),
                        Prestamos = Convert.ToInt32(row["totalPrestamos"]),
                        Disponibilidad = $"{row["stockDisponible"]}/{row["stockTotal"]}"
                    });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener libros más prestados: {ex.Message}");
            }
        }

        public List<dynamic> ObtenerTopUsuariosMasActivos(int cantidad = 10)
        {
            try
            {
                // LLAMAR AL SP
                DataTable dt = ObtenerTopUsuariosMasActivosBD(cantidad);
                var resultado = new List<dynamic>();
                int posicion = 1;

                foreach (DataRow row in dt.Rows)
                {
                    resultado.Add(new
                    {
                        Posicion = posicion++,
                        Nombre = TruncarTexto(row["nombre"].ToString(), 25),
                        Email = row["email"].ToString(),
                        Prestamos = Convert.ToInt32(row["totalPrestamos"]),
                        Multas = Convert.ToDecimal(row["multasPendientes"]).ToString("C")
                    });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuarios más activos: {ex.Message}");
            }
        }

        public List<dynamic> ObtenerMultasPendientes()
        {
            try
            {
                DataTable multas = datosMulta.ObtenerTodas(true);
                var resultado = new List<dynamic>();

                foreach (DataRow row in multas.Rows)
                {
                    resultado.Add(new
                    {
                        Id = row["id"],
                        Usuario = TruncarTexto(row["usuario"].ToString(), 20),
                        Libro = TruncarTexto(row["libro"].ToString(), 25),
                        Monto = Convert.ToDecimal(row["monto"]).ToString("C"),
                        Estado = row["estado"].ToString()
                    });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener multas pendientes: {ex.Message}");
            }
        }

        public List<dynamic> ObtenerPrestamosPorCategoria()
        {
            try
            {
                DataTable dt = datosLibro.ObtenerPrestamosPorCategoria();
                var resultado = new List<dynamic>();

                foreach (DataRow row in dt.Rows)
                {
                    resultado.Add(new
                    {
                        Categoria = row["categoria"].ToString(),
                        Prestamos = Convert.ToInt32(row["totalPrestamos"]),
                        Porcentaje = Convert.ToDecimal(row["porcentaje"]).ToString("F1") + "%"
                    });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener préstamos por categoría: {ex.Message}");
            }
        }

        public List<dynamic> ObtenerTodosPrestamos(bool soloActivos = false)
        {
            try
            {
                // LLAMAR AL SP
                DataTable dt = ObtenerTodosPrestamosBD(soloActivos);
                var resultado = new List<dynamic>();

                foreach (DataRow row in dt.Rows)
                {
                    resultado.Add(new
                    {
                        Id = row["id"],
                        Usuario = TruncarTexto(row["usuario"].ToString(), 20),
                        Email = row["email"].ToString(),
                        Libro = TruncarTexto(row["libro"].ToString(), 25),
                        FechaPrestamo = Convert.ToDateTime(row["fechaPrestamo"]).ToString("dd/MM/yyyy"),
                        FechaDevolucion = Convert.ToDateTime(row["fechaDevolucionEsperada"]).ToString("dd/MM/yyyy"),
                        DiasRestantes = Convert.ToInt32(row["diasRestantes"]),
                        Estado = row["estado"].ToString(),
                        Multa = Convert.ToDecimal(row["multa"]).ToString("C")
                    });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los préstamos: {ex.Message}");
            }
        }

        // MÉTODOS PRIVADOS PARA LLAMAR A LOS SP
        private DataTable ObtenerTopUsuariosMasActivosBD(int cantidad)
        {
            try
            {
                using (var conexion = ConexionDB.ObtenerConexion())
                {
                    var comando = new System.Data.SqlClient.SqlCommand("sp_ObtenerTopUsuariosMasActivos", conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@cantidad", cantidad);

                    var adaptador = new System.Data.SqlClient.SqlDataAdapter(comando);
                    var tabla = new DataTable();
                    conexion.Open();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en BD para usuarios activos: {ex.Message}");
            }
        }

        private DataTable ObtenerTodosPrestamosBD(bool soloActivos)
        {
            try
            {
                using (var conexion = ConexionDB.ObtenerConexion())
                {
                    var comando = new System.Data.SqlClient.SqlCommand("sp_ObtenerTodosPrestamos", conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@soloActivos", soloActivos ? 1 : 0);

                    var adaptador = new System.Data.SqlClient.SqlDataAdapter(comando);
                    var tabla = new DataTable();
                    conexion.Open();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en BD para todos los préstamos: {ex.Message}");
            }
        }

        private string TruncarTexto(string texto, int maxLength)
        {
            if (string.IsNullOrEmpty(texto) || texto.Length <= maxLength)
                return texto;

            return texto.Substring(0, maxLength - 3) + "...";
        }
    }
}