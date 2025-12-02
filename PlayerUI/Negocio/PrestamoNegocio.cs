using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PlayerUI.Datos;
using PlayerUI.Modelos;

namespace PlayerUI.Negocio
{
    public class PrestamoNegocio
    {
        private PrestamoDatos datosPrestamo = new PrestamoDatos();
        private LibroDatos datosLibro = new LibroDatos();
        private MultaDatos datosMulta = new MultaDatos();

        public List<Prestamo> ObtenerPorUsuario(int usuarioId, bool soloActivos = false)
        {
            try
            {
                DataTable dt = datosPrestamo.ObtenerPorUsuario(usuarioId, soloActivos);
                return ConvertirDataTableAPrestamos(dt);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener préstamos del usuario: {ex.Message}");
            }
        }

        // Obtener todos los préstamos (para admin)
        public List<Prestamo> ObtenerTodos(bool soloActivos = false)
        {
            try
            {
                // Usamos el método del DashboardNegocio o creamos uno en PrestamoDatos
                var dashboard = new DashboardNegocio();
                var prestamosData = dashboard.ObtenerTodosPrestamos(soloActivos);

                // Convertir a lista de Prestamo
                var prestamos = new List<Prestamo>();
                // Aquí convertirías los datos dinámicos a objetos Prestamo

                return prestamos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los préstamos: {ex.Message}");
            }
        }

        public bool Renovar(int prestamoId, int usuarioId, out string mensajeError)
        {
            mensajeError = string.Empty;

            try
            {
                if (TieneMultasPendientes(usuarioId))
                {
                    mensajeError = "No puede renovar préstamos con multas pendientes";
                    return false;
                }

                bool resultado = datosPrestamo.Renovar(prestamoId);

                if (resultado)
                {
                    mensajeError = "Préstamo renovado exitosamente por 7 días más";
                    return true;
                }
                else
                {
                    mensajeError = "Error al renovar el préstamo";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error inesperado: {ex.Message}";
                return false;
            }
        }

        public bool RealizarPrestamo(int usuarioId, int libroId, out string mensajeError)
        {
            mensajeError = string.Empty;

            try
            {
                if (!datosLibro.VerificarDisponibilidad(libroId))
                {
                    mensajeError = "El libro no está disponible";
                    return false;
                }

                if (TieneMultasPendientes(usuarioId))
                {
                    mensajeError = "Usuario tiene multas pendientes. Debe pagarlas primero.";
                    return false;
                }

                var prestamosActivos = ObtenerPorUsuario(usuarioId, true);
                if (prestamosActivos.Count >= 3)
                {
                    mensajeError = "Límite de préstamos alcanzado (máximo 3 libros a la vez)";
                    return false;
                }

                if (prestamosActivos.Any(p => p.LibroId == libroId))
                {
                    mensajeError = "Ya tiene este libro prestado";
                    return false;
                }

                bool resultado = datosLibro.RealizarPrestamo(usuarioId, libroId);

                if (resultado)
                {
                    mensajeError = "Préstamo realizado exitosamente. Fecha de devolución: " +
                                  DateTime.Now.AddDays(14).ToString("dd/MM/yyyy");
                    return true;
                }
                else
                {
                    mensajeError = "Error al realizar el préstamo";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error inesperado: {ex.Message}";
                return false;
            }
        }

        public bool DevolverLibro(int prestamoId, int usuarioId, out string mensajeError, out decimal multaGenerada)
        {
            mensajeError = string.Empty;
            multaGenerada = 0;

            try
            {
                var prestamos = ObtenerPorUsuario(usuarioId, true);
                var prestamo = prestamos.FirstOrDefault(p => p.Id == prestamoId);

                if (prestamo == null)
                {
                    mensajeError = "Préstamo no encontrado";
                    return false;
                }

                if (prestamo.DiasRetraso > 0)
                {
                    multaGenerada = prestamo.MultaCalculada;
                    mensajeError = $"Libro devuelto con {prestamo.DiasRetraso} días de retraso. Multa: ${multaGenerada}";
                }
                else
                {
                    mensajeError = "Libro devuelto a tiempo";
                }

                bool resultado = datosLibro.DevolverLibro(prestamoId);
                return resultado;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al devolver libro: {ex.Message}";
                return false;
            }
        }

        private bool TieneMultasPendientes(int usuarioId)
        {
            try
            {
                DataTable multas = datosMulta.ObtenerPorUsuario(usuarioId, true);
                return multas.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        private List<Prestamo> ConvertirDataTableAPrestamos(DataTable dt)
        {
            var prestamos = new List<Prestamo>();

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    var prestamo = new Prestamo
                    {
                        Id = Convert.ToInt32(row["id"]),
                        LibroTitulo = row["libro"].ToString(),
                        LibroAutor = row["autor"].ToString(),
                        FechaPrestamo = Convert.ToDateTime(row["fechaPrestamo"]),
                        FechaDevolucionEsperada = Convert.ToDateTime(row["fechaDevolucionEsperada"]),
                        Estado = row["estado"].ToString(),
                        MultasAcumulada = Convert.ToDecimal(row["multa"])
                    };

                    // Obtener LibroId si está disponible
                    if (dt.Columns.Contains("libroID"))
                    {
                        prestamo.LibroId = Convert.ToInt32(row["libroID"]);
                    }

                    if (row["fechaDevolucionReal"] != DBNull.Value)
                    {
                        prestamo.FechaDevolucionReal = Convert.ToDateTime(row["fechaDevolucionReal"]);
                    }

                    prestamos.Add(prestamo);
                }
                catch (Exception ex)
                {
                    // Registrar error pero continuar con otros préstamos
                    Console.WriteLine($"Error al convertir préstamo: {ex.Message}");
                }
            }

            return prestamos;
        }
    }
}