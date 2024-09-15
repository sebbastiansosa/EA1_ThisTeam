using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA1_ThisTeam
{
    internal class Escuela
    {
        //Lista que almacena los cursos existentes en la escuela.
        private List<Curso> cursosExistentes;
        //Lista que almacena los profesores existentes en la escuela.
        private List<Profesor> profesoresExistentes;
        //Lista que almacena los alumnos inscritos en la escuela.
        private List<Alumno> alumnosInscritos;

        //Constructor que inicializa las listas.
        public Escuela ()
        {
            cursosExistentes = new List<Curso>();
            profesoresExistentes = new List<Profesor>();
            alumnosInscritos = new List<Alumno>();
        }

        //Método que crea un nuevo curso.
        public bool CrearCurso(string nombre, Profesor profesorEncargado)
        {
            Curso curso = new Curso(nombre);
            curso.ProfesorEncargado = profesorEncargado;
            profesorEncargado.AsignarCurso(curso);
            cursosExistentes.Add(curso);
            return true;
        }

        //Método que registra a un profesor en la escuela.
        public bool RegistrarProfesor(string nombre, string especialidad)
        {
            //Crear una instancia de la clase Profesor.
            Profesor profesor = new Profesor(nombre, especialidad);

            //Agregar el profesor a la lista de profesores existentes.
            profesoresExistentes.Add(profesor);
            return true;
        }

        //Método para inscribir a un alumno en la escuela.
        public bool InscribirAlumno(int id, string nombre, int edad)
        {
            //Crear una instancia de la clase Alumno.
            Alumno alumno = new Alumno(id, nombre, edad);

            //Agregar el alumno a la lista de alumnos inscritos.    
            alumnosInscritos.Add(alumno);
            return true;
        }

        //Método que asigna un alumno a un curso.
        public bool AsignarAlumnoACurso(int idAlumno, string nombreCurso)
        {
            //Busca al alumno en la lista de alumnos inscritos.
            Alumno alumno = alumnosInscritos.Find(a => a.ID == idAlumno);
            //Busca el curso en la lista de cursos existentes.
            Curso curso = cursosExistentes.Find(c => c.Nombre == nombreCurso);
            
            //Si el alumno y el curso existen, inscribir al alumno en el curso.
            if (alumno != null && curso != null)
            {
                alumno.InscribirCurso(curso);
                return true;
            }
            //Si no se encuentra al alumno o al curso, devolver falso.
            return false;
        }

        public bool AsignarProfesorACurso(string nombreProfesor, string nombreCurso)
        {
            //Buscar el profesor en la lista de profesores existentes.
            Profesor profesor = profesoresExistentes.Find(p => p.Nombre == nombreProfesor);
            //Buscar el curso en la lista de cursos existentes.
            Curso curso = cursosExistentes.Find(c => c.Nombre == nombreCurso);

            //Si el profesor y el curso existen, asignar el curso al profesor.
            if (profesor != null && curso != null)
            {
                curso.ProfesorEncargado = profesor;
                profesor.AsignarCurso(curso);
                return true;
            }
            //Si no se encuentra al profesor o al curso, devolver falso.
            return false;
        }

        //Método que muestra los cursos existentes en la escuela.
        public string VerCursos()
        {
            //Si no hay cursos, devolver un mensaje.
            if (cursosExistentes.Count == 0) return $"No hay cursos creados.\n";

            //Recorrer la lista de cursos existentes y mostrar los datos de cada uno.
            string resultado = "";
            foreach (Curso curso in cursosExistentes)
            {
                resultado += $"Curso: {curso.Nombre}\nProfesor: {curso.ProfesorEncargado.Nombre}\n";
            }
            return resultado;
        }

        //Método que muestra los alumnos inscritos en un curso.
        public string VerAlumnos(string nombreCurso)
        {
            //Buscar el curso en la lista de cursos existentes.
            Curso curso = cursosExistentes.Find(c => c.Nombre == nombreCurso);
            //Devolver un mensaje si no se encuentra el curso.
            if (curso == null) return $"No se encontró el curso {nombreCurso}";
            else
            {
                //Verificar si hay alumnos inscritos en el curso.
                if (alumnosInscritos.Count == 0) return $"No hay alumnos inscritos en {curso.Nombre}.\n";
                //Recorrer e imprimir la lista de alumnos inscritos en el curso.
                string resultado = "";
                foreach (Alumno alumno in alumnosInscritos)
                {
                    resultado += $"Curso: {curso.Nombre} \nID: {alumno.ID} \nNombre: {alumno.Nombre} \nEdad: {alumno.Edad}\n";
                }
                return resultado;
            }
        }
    }
}
