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

        //los signos de (?) adelante de las variables elimina la advertencia de null 
        //le decimos al compilador que sabemos que pueden ser nula la respuesta y vamos a trabajar con esa "nullabilidad"
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
                Console.WriteLine("Libro agregado exitosamente.");
                resultado = true;
            }
            else
            {
                Console.WriteLine("Accion cancelada: El libro ya existe.");
            }
            return resultado;
        }

        public void listarLibros()
        {
            if (libros.Count() != 0)
            {
                Console.WriteLine("Los libros de la biblioteca son los siguientes:");
                foreach (var libro in libros)
                {
                    Console.WriteLine(libro);
                }
            }
            else
            {
                Console.WriteLine("La biblioteca no posee libros registrados.");
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
                Console.WriteLine("Libro eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Libro no encontrado: eliminación cancelada.");
            }
            return resultado;
        }

        public bool altaLector(string nombre, string dni)
        {
            foreach (var lector in lectores)
            {
                if (lector.GetDni() == dni)
                {
                    Console.WriteLine("Accion cancelada: El usuario ya existe.");
                    return false;
                }
            }
            lectores.Add(new Lector(nombre, dni));
            Console.WriteLine("Usuario agregado exitosamente.");
            return true;
        }

        public string PrestarLibro(string titulo, string dni)
        {
            Console.WriteLine(titulo);
            Console.WriteLine(dni);
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
