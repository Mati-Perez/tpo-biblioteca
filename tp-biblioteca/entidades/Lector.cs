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
            this.librosPrestados = new List<Libro>();
        }

        public string GetDni() => dni;
        public int CantidadPrestamos() => librosPrestados.Count;
        public bool PuedePrestar() => librosPrestados.Count < 3;
        public void AgregarPrestamo(Libro libro) => librosPrestados.Add(libro);
    }
}
