using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI.Modelos
{
    public class Categoria
    {
        // Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Constructor
        public Categoria() { }

        public Categoria(string nombre, string descripcion = "")
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        // ToString para mostrar en ComboBox
        public override string ToString()
        {
            return Nombre;
        }
    }
}
