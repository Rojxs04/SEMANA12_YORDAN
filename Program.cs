using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMANA_12YORDAN
{
    using System;

    class Libreria
    {
        // Arreglos paralelos: uno para nombres y otro para precios
        string[] nombres = new string[0];
        decimal[] precios = new decimal[0];

        // Método para registrar nuevos libros
        public void Registrar()
        {
            string nombre;
            string dato;
            decimal precio;
            int pos;

            Console.WriteLine("\n***REGISTRAR LIBRO***");
            Console.Write("Nombre del libro: ");
            nombre = Console.ReadLine();

            // Validación: no permitir nombre vacío
            if (nombre == "")
            {
                Console.WriteLine("Debes escribir un nombre.");
                return;
            }

            // Verifica que el libro no este repetido
            pos = Buscar(nombre);
            if (pos != -1)
            {
                Console.WriteLine("Ese libro ya está registrado.");
                return;
            }

            Console.Write("Agrega Precio: ");
            dato = Console.ReadLine();

            // Validar que el precio sea de caracter numerico
            if (!decimal.TryParse(dato, out precio))
            {
                Console.WriteLine("Debe ser un número válido.");
                return;
            }

            //establecemos un rango de precio
            if (precio < 0 || precio > 1000)
            {
                Console.WriteLine("Precio fuera de rango (0 - 1000).");
                return;
            }

            // Aumentar tamaño de los arreglos y agregar datos
            Array.Resize(ref nombres, nombres.Length + 1);
            Array.Resize(ref precios, precios.Length + 1);
            nombres[nombres.Length - 1] = nombre;
            precios[precios.Length - 1] = precio;

            Console.WriteLine("Libro guardado correctamente.");
        }

        // Muestra todos los libros guardados
        public void Mostrar()
        {
            Console.WriteLine("\n***LISTA DE LIBROS***");

            if (nombres.Length == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + nombres[i] + " - S/ " + precios[i]);
            }
        }

        // Modifica el nombre y el precio de un libro
        public void Modificar()
        {
            string buscar;
            string nombreNuevo;
            string datoNuevo;
            decimal precioNuevo;
            int pos;
            int repetido;

            Console.WriteLine("\n***MODIFICAR LIBRO***");
            Console.Write("Nombre del libro que deseas cambiar: ");
            buscar = Console.ReadLine();

            // Buscar libro por nombre
            pos = Buscar(buscar);
            if (pos == -1)
            {
                Console.WriteLine("No se encontró ese libro.");
                return;
            }

            Console.Write("Agrega nuevo nombre (deja en blanco si non quieres cambiar): ");
            nombreNuevo = Console.ReadLine();

            // Validar que el nuevo nombre no se haya repetido
            if (nombreNuevo != "")
            {
                repetido = Buscar(nombreNuevo);
                if (repetido != -1 && repetido != pos)
                {
                    Console.WriteLine("Ya existe un libro con ese nombre.");
                    return;
                }
                nombres[pos] = nombreNuevo;
            }

            Console.Write("Agrega nuevo precio (deja en blanco si no  cambias): ");
            datoNuevo = Console.ReadLine();

            // Validar y actualizar el nuevo precio
            if (datoNuevo != "")
            {
                if (!decimal.TryParse(datoNuevo, out precioNuevo))
                {
                    Console.WriteLine("Precio muy loco.");
                    return;
                }

                if (precioNuevo < 0 || precioNuevo > 1000)
                {
                    Console.WriteLine("Precio fuera del rango.");
                    return;
                }

                precios[pos] = precioNuevo;
            }

            Console.WriteLine("Libro modificado correctamente.");
        }

        // Eliminamos un libro del registro
        public void Eliminar()
        {
            string buscar;
            int pos;

            Console.WriteLine("\n***ELIMINAR LIBRO***");
            Console.Write("Nombre del libro que deseas eliminar: ");
            buscar = Console.ReadLine();

            // Buscar el libro por nombre especifico
            pos = Buscar(buscar);
            if (pos == -1)
            {
                Console.WriteLine("No se encontró ese libro.");
                return;
            }

            // Mover los elementos siguientes una posición hacia atrás
            for (int i = pos; i < nombres.Length - 1; i++)
            {
                nombres[i] = nombres[i + 1];
                precios[i] = precios[i + 1];
            }

            // Reducimos el tamaño de los arreglos
            Array.Resize(ref nombres, nombres.Length - 1);
            Array.Resize(ref precios, precios.Length - 1);

            Console.WriteLine("Libro eliminado correctamente.");
        }

        // Busca un libro por nombre y devuelve su posición
        int Buscar(string nombre)
        {
            for (int i = 0; i < nombres.Length; i++)
            {
                if (nombres[i].ToLower() == nombre.ToLower())
                    return i;
            }
            return -1;
        }
    }

    class Program
    {
        static void Main()
        {
            Libreria lib = new Libreria();
            string opcion;

            // Menú principal: se repite hasta que el usuario elija salir
            do
            {
                Console.WriteLine("\n***MENÚ PRINCIPAL***");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Mostrar libros");
                Console.WriteLine("3. Modificar libro");
                Console.WriteLine("4. Eliminar libro");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción: ");
                opcion = Console.ReadLine();

                // añadimos el menu de opciones
                if (opcion == "1")
                {
                    lib.Registrar();
                }
                else if (opcion == "2")
                {
                    lib.Mostrar();
                }
                else if (opcion == "3")
                {
                    lib.Modificar();
                }
                else if (opcion == "4")
                {
                    lib.Eliminar();
                }
                else if (opcion == "5")
                {
                    Console.WriteLine("Saliendo del programa...");
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                }

            } while (opcion != "5");
        }
    }
}

