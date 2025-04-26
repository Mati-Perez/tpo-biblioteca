using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_biblioteca.entidades
{
    internal class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores = new List<Lector>();

        public List<Lector> Lectores { get => lectores; }

        public Biblioteca()
        {
            this.libros = new List<Libro>();
        }

        private Libro? buscarLibro(string titulo)
        {
            Libro? libroBuscado = null;
            int i = 0;
            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo))
            {
                i++;
            }
            if (i != libros.Count)
            {
                libroBuscado = libros[i];
            }
            return libroBuscado;
        }

        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado = false;
            Libro? libro;
            libro = buscarLibro(titulo);
            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                libros.Add(libro);
                resultado = true;
            }
            return resultado;
        }

        public void listarLibros()
        {
            foreach (var libro in libros)
            {
                Console.WriteLine(libro);
            }
        }

        public bool eliminarLibro(string titulo)
        {
            bool resultado = false;
            Libro? libro;
            libro = buscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                resultado = true;
            }
            return resultado;
        }
        public bool altaLector(string nombre, string dni)
        {
            foreach (var lector in lectores)
            {
                if (lector.GetDni() == dni)
                {
                    return false;
                }
            }
            lectores.Add(new Lector(nombre, dni));
            return true;
        }

        public string PrestarLibro(string titulo, string dni)
        {
            Lector? lector = lectores.FirstOrDefault(l => l.GetDni() == dni);
            if (lector == null) return "LECTOR INEXISTENTE";

            if (!lector.PuedePrestar()) return "TOPE DE PRESTAMO ALCAZADO";

            Libro? libro = libros.FirstOrDefault(l => l.getTitulo() == titulo);
            if (libro == null) return "LIBRO INEXISTENTE";

            lector.AgregarPrestamo(libro);
            libros.Remove(libro);

            return "PRESTAMO EXITOSO";
        }
    }
}
