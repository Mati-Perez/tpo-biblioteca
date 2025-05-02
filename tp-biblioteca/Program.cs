
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

            Console.WriteLine("Elegir una de las siguientes opciones:");

            Console.WriteLine("  1. Manual.");
            Console.WriteLine("  2. Automatico.");
            string res = Console.ReadLine();

            if (res == "1")
            {
                program();
            }
            else
            {
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
                Console.ReadLine();
                biblioteca.altaLector("Florencia", "19280552"); // Se fuerza la carga de un usuario existente para probar la respuesta del sistema.


                Console.WriteLine("\nUna vez lista la carga de lectores, continua con agregar los libros que fueron prestados a cada lector.");
                Console.ReadLine();
                // Utiliza el metodo PrestarLibro para dicha tarea.
                Console.WriteLine(biblioteca.PrestarLibro("Libro3", "38909876") + " Dni:38909876");
                Console.WriteLine(biblioteca.PrestarLibro("Libro4", "38909876") + " Dni:38909876");
                Console.WriteLine(biblioteca.PrestarLibro("Libro6", "38909876") + " Dni:38909876");
                Console.WriteLine(biblioteca.PrestarLibro("Libro2", "19280552") + " Dni: 19280552");
                Console.WriteLine(biblioteca.PrestarLibro("Libro8", "38909876") + " Dni:38909876"); ;// Se fuerza el prestamo de un cuarto libro para probar la respuesta del sistema.

                Console.WriteLine("\nAl recibir el error del software se percata de la asignacion erronea del libro, y lo corrige asignandoselo al lector correcto.");
                Console.ReadLine();
                Console.WriteLine(biblioteca.PrestarLibro("Libro6", "32366768") + " Libro6");

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

        static void program(int seleccion = 0, int numeroLibros = 0, string nombreLector = "", string dni = "",
            string nombreLibro = "")
        {

            bool salir = true;
            Biblioteca biblioteca = new Biblioteca();

            while (salir)
            {
                Console.WriteLine("******************************************", "\n");
                Console.WriteLine("BIBLIOTECA - GRUPO 7\n");
                Console.WriteLine("Elegir una de las siguientes opciones:");
                Console.WriteLine("  1. salir.");
                Console.WriteLine("  2. Agregar libros.");
                Console.WriteLine("  3. Agregar lector.");
                Console.WriteLine("  4. Obtener lista de libros en biblioteca.");
                Console.WriteLine("  5. Prestar libro a lector.");
                Console.WriteLine("  6. Eliminar libros.\n");
                Console.WriteLine("******************************************", "\n");

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

                //if (seleccion == 0)
                //{
                    Console.WriteLine("Ingrese la en número de la opcion seleccionada:");
                    seleccion = int.Parse(Console.ReadLine());

                    switch (seleccion)
                    {
                        case 1:
                            salir = false;
                            break;
                        case 2:
                            Console.Write("Ingrese la cantidad de libros a agregar:");

                            if (numeroLibros == 0)
                            {
                                numeroLibros = int.Parse(Console.ReadLine());
                            }
                            else
                            {
                                Console.WriteLine("Número ingresado = " + numeroLibros);
                            }

                            Console.WriteLine("Agregando...");
                            cargarLibros(numeroLibros);
                            numeroLibros = 0;
                            break;
                         case 3:
                            Console.WriteLine("Ingrese los datos del Lector:");
                            if (nombreLector == "")
                            {
                                Console.WriteLine("Ingrese el nombre del Lector:");
                                nombreLector = Console.ReadLine();
                                Console.WriteLine("Ingrese el número de DNI del Lector:");
                                dni = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Ingrese el nombre del Lector:");
                                Console.WriteLine("Nombre ingresado: " + nombreLector);
                                Console.WriteLine("Ingrese el número de DNI del Lector:");
                                Console.WriteLine("DNI ingresado: " + dni);
                            }

                            Console.WriteLine("Agregando...");
                            biblioteca.altaLector(nombreLector, dni);
                            nombreLector = "";
                            dni = "";
                            break;
                         case 4:
                            Console.WriteLine("Los libros cargados en la biblioteca son los siguientes:");
                            biblioteca.listarLibros();
                            break;
                         case 5:
                            Console.WriteLine("Ingrese los datos del prestamo:");
                            if (nombreLibro == "")
                            {
                                Console.WriteLine("Ingrese el nombre del Libro:");
                                nombreLibro = Console.ReadLine();
                                Console.WriteLine("Ingrese el número de DNI del Lector:");
                                dni = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Ingrese el nombre del Libro:");
                                Console.WriteLine("Nombre ingresado: " + nombreLibro);
                                Console.WriteLine("Ingrese el número de DNI del Lector:");
                                Console.WriteLine("DNI ingresado: " + dni);
                            }

                            Console.WriteLine("Agregando...");
                            
                            Console.WriteLine(biblioteca.PrestarLibro(nombreLibro, dni));
                            break;
                         case 6:
                            Console.WriteLine("Ingrese el nombre del libro a eliminar: ");
                            if (nombreLibro == "")
                            {
                                nombreLibro = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Nombre de libro ingresado: " + nombreLibro);
                            }
                            Console.WriteLine("Eliminando...");
                            biblioteca.eliminarLibro(nombreLibro);
                            break;
                        default:
                            Console.WriteLine("Opción no válida, favor de ingresar una opción correcta.");
                                break;
                         }
                      Console.ReadKey();
                      Console.Clear();
                      seleccion = 0; 
                      numeroLibros = 0;
                      nombreLector = "";
                      dni = "";
                      nombreLibro = "";
            }
                    


                //}

         
           
            
        }
    }
}
