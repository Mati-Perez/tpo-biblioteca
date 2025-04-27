

using System;
using tp_biblioteca.entidades;

namespace Colecciones
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vamos a darle un recorrido por cada funcion y entidades de nuestro programa recuerde leer y apretar la tecla (enter) para pasar a la siguiente explicación");
            Console.WriteLine("El usuario comienza creando una nueva biblioteca.");
            Console.ReadLine();
            // Para ello instancia un objeto de la clase bilioteca.
            Biblioteca biblioteca = new Biblioteca();

            Console.WriteLine("\nContinua cargando libro en la biblioteca.");
            Console.ReadLine();
            // Utiliza la funcion cargarLibros carga libros en la bilioteca para testear.
            cargarLibros(10);
            Console.WriteLine("\nrealiza para testear el intento de carga de libros ya cargados\n");
            cargarLibros(2); // La segunda carga se realiza para testear el intento de carga de libros ya cargados.

            Console.WriteLine("\nLuego de la carga desea obtener una lista de los libros para realizar una verificacion de los cargado.");
            Console.ReadLine();
            // Utiliza el metodo listarLibros para obtener todos los libros cargados en la biblioteca.
            biblioteca.listarLibros();

            Console.WriteLine("\nObserva un error, el libro con título (Libro5) fue cargado erroneamente, procede a quitarlo del listado.");
            Console.ReadLine();
            // Utiliza el metodo eliminarLibro para eliminar el libro especificado.
            biblioteca.eliminarLibro("Libro5");

            Console.WriteLine("\nDespues de corregir el error, genera un nuevo listado con los libros");
            Console.ReadLine();
            biblioteca.listarLibros();

            Console.WriteLine("\nUna vez lista la carga de libros, continua con el alta de los lectores.");
            Console.ReadLine();
            // Utiliza el metodo altaLector para dicha tarea.
            biblioteca.altaLector("sebastian", "38909876");
            //Console.WriteLine(biblioteca.Lectores[0].GetDni()); // Saco esta parte para que la secuencia del usuario simulado tenga sentido.
            Console.WriteLine("Carga el 2do lector.");
            biblioteca.altaLector("Florencia", "19280552");
            Console.WriteLine("Carga el 3er lector.");
            biblioteca.altaLector("Guillermo", "32366768");
            Console.WriteLine("Carga el 4to lector.");
            biblioteca.altaLector("Matias", "25823660");
            Console.WriteLine("Carga el 5to lector.");
            
            Console.WriteLine("\nAl recibir el error del software se percata de que en la lista de lectores que tenia Florencia figuraba 2 veces.\n");
            biblioteca.altaLector("Florencia", "19280552"); // Se fuerza la carga de un usuario existente para probar la respuesta del sistema.

            Console.ReadLine();

            Console.WriteLine("\nUna vez lista la carga de lectores, continua con agregar los libros que fueron prestados a cada lector.");
            Console.ReadLine();
            // Utiliza el metodo PrestarLibro para dicha tarea.
            Console.WriteLine(biblioteca.PrestarLibro("Libro3", "38909876"));
            Console.WriteLine(biblioteca.PrestarLibro("Libro4", "38909876"));
            Console.WriteLine(biblioteca.PrestarLibro("Libro5", "38909876"));
            Console.WriteLine(biblioteca.PrestarLibro("Libro2", "19280552"));
            Console.WriteLine(biblioteca.PrestarLibro("Libro6", "38909876")); // Se fuerza el prestamo de un cuarto libro para probar la respuesta del sistema.

            Console.WriteLine("\nAl recibir el error del software se percata de la asignacion erronea del libro, y lo corrige asignandoselo al lector correcto.");
            Console.ReadLine();
            Console.WriteLine(biblioteca.PrestarLibro("Libro6", "32366768"));

            Console.WriteLine("\nUna vez terminado el registro de libros prestados, obtiene una lista actualizada de los libros.");
            Console.ReadLine();
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
