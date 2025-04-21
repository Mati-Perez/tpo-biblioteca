using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_biblioteca.entidades
{
    internal class Lector
    {
        private string nombre;
        private string dni;
        private List<Libro> librosPrestados;

        public Lector(string nombre, string dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.librosPrestados = [];
        }
    }
}
