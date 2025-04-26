

using tp_biblioteca.entidades;

namespace Colecciones
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            cargarLibros(10);
            cargarLibros(2);
            biblioteca.listarLibros();
            biblioteca.eliminarLibro("Libro5");
            biblioteca.listarLibros();

            Console.WriteLine(biblioteca.altaLector("sebastian", "38909876"));
            Console.WriteLine(biblioteca.Lectores[0].GetDni());
            Console.WriteLine(biblioteca.altaLector("sebastian", "38909876"));


            Console.WriteLine(biblioteca.PrestarLibro("Libro3", "38909876"));
            Console.WriteLine(biblioteca.PrestarLibro("Libro4", "38909876"));
            Console.WriteLine(biblioteca.PrestarLibro("Libro5", "38909876"));
            Console.WriteLine("Prueba del tope  " + biblioteca.PrestarLibro("Libro6", "38909876"));

            Console.WriteLine(biblioteca.PrestarLibro("libro2", "90897867"));
            Console.WriteLine(biblioteca.PrestarLibro("libro2", "38909876"));


            biblioteca.listarLibros();

            void cargarLibros(int cantidad)
            {
                bool pude;
                for (int i = 1; i <= cantidad; i++)
                {
                    pude = biblioteca.agregarLibro("Libro" + i, "Autor" + i, "Editorial" + i);
                    if (pude)
                    {
                        Console.WriteLine("Libro" + i + "agregado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("libro" + i + " Ya existe en la biblioteca");
                    }
                }
            }
        }
    }
}