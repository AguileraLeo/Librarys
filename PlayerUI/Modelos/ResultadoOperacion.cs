using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//sugerida por IA, aun no le veo utilidad real
namespace PlayerUI.Modelos
{
    public class ResultadoOperacion
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }
        public int IdGenerado { get; set; }

        // Constructores
        public ResultadoOperacion(bool exitoso, string mensaje)
        {
            Exitoso = exitoso;
            Mensaje = mensaje;
        }

        public ResultadoOperacion(bool exitoso, string mensaje, object datos)
        {
            Exitoso = exitoso;
            Mensaje = mensaje;
            Datos = datos;
        }

        public ResultadoOperacion(bool exitoso, string mensaje, int idGenerado)
        {
            Exitoso = exitoso;
            Mensaje = mensaje;
            IdGenerado = idGenerado;
        }

        // Métodos estáticos para respuestas comunes
        public static ResultadoOperacion Exito(string mensaje = "Operación exitosa")
        {
            return new ResultadoOperacion(true, mensaje);
        }

        public static ResultadoOperacion Error(string mensaje)
        {
            return new ResultadoOperacion(false, mensaje);
        }

        public static ResultadoOperacion ExitoConId(string mensaje, int id)
        {
            return new ResultadoOperacion(true, mensaje, id);
        }

        public static ResultadoOperacion ExitoConDatos(string mensaje, object datos)
        {
            return new ResultadoOperacion(true, mensaje, datos);
        }
    }
}
