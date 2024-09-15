using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EA1_ThisTeam
{
    internal class InterfazUsuario
    {
        private Escuela escuela; 
        //Lista de opciones que se muestran en el menú.
        private List<Opcion> opciones;

        //Constructor de la clase InterfazUsuario.
        public InterfazUsuario()
        {
            //Inicializar la instancia de la escuela.
            escuela = new Escuela();
            //Inicializar la lista de opciones para el menú.
            opciones = new List<Opcion>();
            {
                opciones.Add(new Opcion("Crear curso", CrearCurso));
                opciones.Add(new Opcion("Registrar profesor", RegistrarProfesor));
                opciones.Add(new Opcion("Inscribir alumno", InscribirAlumno));
                opciones.Add(new Opcion("Asignar alumno a un curso", AsignarAlumnoACurso));
                opciones.Add(new Opcion("Asignar profesor a un curso", AsignarProfesorACurso));
                opciones.Add(new Opcion("Ver cursos existentes", MostrarCursos));
                opciones.Add(new Opcion("Ver alumnos inscritos en un curso", MostrarAlumnosEnCurso));
                opciones.Add(new Opcion("Salir", () => Environment.Exit(0)));
            }
        }

        //Método principal que inicia la interacción con el usuario.
        public void Iniciar()
        {
            while (true)
            {
                //Mostrar el menú de opciones.
                MostarMenu();
                //Ejecutar la opción seleccionada por el usuario.
                SeleccionarOpcion();
            }
        }

        //Método que muestra las opciones del menú en la consola.
        private void MostarMenu()
        {
            Console.WriteLine("Menú del Banco:\n");
            //Recorrer la lista de opciones.
            for (int i = 0; i < opciones.Count; i++)
            {
                //Mostrar cada opción con su número correspondiente.
                Console.WriteLine($"{i + 1}. {opciones[i].Message}");
            }
        }

        //Método que solicita al usuario seleccionar una opción del menú y ejecuta la acción correspondiente.
        private void SeleccionarOpcion()
        {
            Console.Write("\nSelecciona una opción: ");
            try
            {
                //Leer y ajustar la opción seleccionada.
                int numOpcion = Convert.ToInt32(Console.ReadLine()) - 1;

                if (numOpcion >= 0 && numOpcion < opciones.Count)
                {
                    //Ejecutar la acción de la opción seleccionada.
                    Console.Clear();
                    opciones[numOpcion].Action.Invoke();
                }
                else
                {
                    //Vuelve a solicitar la selección de opción si la opción no es válida.
                    Console.WriteLine("Opción no válida. Inténtalo nuevamente.\n");
                    MostarMenu();
                    SeleccionarOpcion();
                }
            }
            catch (Exception e)
            {
                //Volver a mostrar el menú y la solicitud de selección de opción en caso de error.
                Console.WriteLine("No has introducido un valor válido.");
                Console.WriteLine(e.Message);
                Console.WriteLine();
                MostarMenu();
                SeleccionarOpcion();
            }
        }

        //Método para crear un nuevo curso.
        public void CrearCurso()
        {
            try
            {
                //Solicita el nombre del curso al usuario.
                Console.WriteLine("Ingresar el nombre del curso: ");
                string nombreCurso = Console.ReadLine();
                Console.WriteLine();

                //Solicita el nombre del profesor encargado al usuario.
                Console.WriteLine("Ingresar el nombre del profesor encargado: ");
                string nombreProfesor = Console.ReadLine();
                Console.WriteLine();

                //Solicita la especialidad del profesor al usuario.
                Console.WriteLine("Ingresar la especialidad del profesor: ");
                string especialidad = Console.ReadLine();
                Console.WriteLine();

                //Crear una nueva instancia de Profesor con los datos ingresados.
                Profesor profesor = new Profesor(nombreProfesor, especialidad);
                escuela.CrearCurso(nombreCurso, profesor);

                //Mostrar un mensaje confirmando que el curso fue registrado exitosamente.
                Console.WriteLine($"Curso creado exitosamente.\n");
            }
            catch (Exception e)
            {
                //Mandar mensaje en caso de error.
                Console.WriteLine("Error.");
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }

        //Método para asignar un nuevo profesor en la escuela.
        public void RegistrarProfesor()
        {
            {
                try
                {
                    //Solicita el nombre del profesor al usuario.
                    Console.WriteLine("Ingresar el nombre del profesor: ");
                    string nombreProfesor = Console.ReadLine();
                    Console.WriteLine();

                    //Solicita la especialidad del profesor al usuario.
                    Console.WriteLine("Ingresar la especialidad del profesor: ");
                    string especialidad = Console.ReadLine();
                    Console.WriteLine();

                    //Llamar al método de la escuela para asignar al profesor.
                    escuela.RegistrarProfesor(nombreProfesor, especialidad);

                    //Mostrar un mensaje confirmando que el profesor fue registrado exitosamente.
                    Console.WriteLine($"Profesor registrado exitosamente.\n");
                }
                catch (Exception e)
                {
                    //Mandar mensaje en caso de error.
                    Console.WriteLine("Error.");
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
            }
        }

        //Método para inscribir a un nuevo alumno en la escuela.
        public void InscribirAlumno()
        {
            try
            {
                //Solicita el ID del alumno al usuario.
                Console.WriteLine("Ingresar el ID del alumno: ");
                int idAlumno = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Solicita el nombre del alumnoo al usuario.
                Console.WriteLine("Ingresar el nombre del alumno: ");
                string nombre = Console.ReadLine();
                Console.WriteLine();

                // Solicita la edad del alumno al usuario.
                Console.WriteLine("Ingresar la edad del alumno: ");
                int edad = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Llamar al método de la escuela para inscribir al alumno.
                escuela.InscribirAlumno(idAlumno, nombre, edad);

                //Mostrar un mensaje confirmando que el alumno fue inscrito exitosamente.
                Console.WriteLine($"Alumno inscrito exitosamente.\n");
            }
            catch (Exception e)
            {
                //Mandar mensaje en caso de error.
                Console.WriteLine("Error.");
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }

        //Método para asignar un alumno a un curso.
        public void AsignarAlumnoACurso()
        {
            try
            {
                //Solicita el ID del alumno al usuario.
                Console.WriteLine("Ingresar el ID del alumno: ");
                int idAlumno = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Solicita el nombre del curso al usuario.
                Console.WriteLine("Ingresar el nombre del curso: ");
                string nombreCurso = Console.ReadLine();
                Console.WriteLine();

                //Llamar al método de la escuela para asignar al alumno al curso.
                escuela.AsignarAlumnoACurso(idAlumno, nombreCurso);

                //Mostrar un mensaje confirmando que el alumno fue asignado al curso exitosamente.
                Console.WriteLine("Alumbo asignado al curso exitosamente.\n");
            }
            catch (Exception e)
            {
                //Mandar mensaje en caso de error.
                Console.WriteLine("Error.");
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }

        //Método para asignar un profesor a un curso.
        public void AsignarProfesorACurso()
        {
            try
            {
                //Solicita el nombre del profesor al usuario.
                Console.WriteLine("Ingresar el nombre del profesor: ");
                string nombreProfesor = Console.ReadLine();
                Console.WriteLine();

                //Solicita el nombre del curso al usuario.
                Console.WriteLine("Ingresar el nombre del curso: ");
                string nombreCurso = Console.ReadLine();
                Console.WriteLine();

                //Llamar al método de la escuela para asignar al profesor al curso.
                escuela.AsignarProfesorACurso(nombreProfesor, nombreCurso);

                //Mostrar un mensaje confirmando que el profesor fue asignado al curso exitosamente.
                Console.WriteLine("Profesor asignado al curso exitosamente.\n");
            }
            catch (Exception e)
            {
                //Mandar mensaje en caso de error.
                Console.WriteLine("Error.");
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }

        //Método para mostrar los cursos existentes en la escuela.
        public void MostrarCursos() { Console.WriteLine(escuela.VerCursos()); }

        //Método para mostrar los alumnos inscritos en un curso.
        public void MostrarAlumnosEnCurso()
        {
            try
            {
                //Solicita el nombre del curso al usuario.
                Console.WriteLine("Ingresar el nombre del curso: ");
                string nombreCurso = Console.ReadLine();
                Console.WriteLine();

                //Llamar al método de la escuela para mostrar los alumnos inscritos en el curso.
                Console.WriteLine(escuela.VerAlumnos(nombreCurso));
            }
            catch (Exception e)
            {
                //Mandar mensaje en caso de error.
                Console.WriteLine("Error.");
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }

    }
}

