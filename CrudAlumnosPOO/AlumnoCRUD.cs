using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudAlumnosPOO;

namespace CrudAlumnosPOO
{
    internal class AlumnoCRUD
    {
        private List<Alumno> listaAlumnos = new List<Alumno>();
        private MensajeUI mensaje = new MensajeUI(50);
        private const string FilePath = "alumnos.csv";

        public AlumnoCRUD()
        {
            //Alumno alumnoMuestra = new Alumno("César Mayta", "cesar@gmail.com", "82372323");
            //listaAlumnos.Add(alumnoMuestra);
            this.CargarAlumnos();
        }

        public void MostrarAlumnos()
        {
            this.mensaje.mostrarTitulo("RELACIÓN DE ALUMNOS");
            foreach (var alumno in listaAlumnos)
            {
                Console.WriteLine(new string('*', 50));
                alumno.Mostrar();
            }
        }

        public void RegistrarAlumno()
        {
            this.mensaje.mostrarTitulo("REGISTRO DE NUEVO ALUMNO");
            Console.WriteLine("NOMBRE : ");
            string nombre = Console.ReadLine();
            Console.WriteLine("EMAIL : ");
            string email = Console.ReadLine();
            Console.WriteLine("CELULAR : ");
            string celular = Console.ReadLine();

            Alumno nuevoAlumno = new Alumno(nombre,email, celular);
            listaAlumnos.Add(nuevoAlumno);
            this.mensaje.mostrarMensaje("ALUMNO REGISTRADO CON EXITO!!!");
        }

        private Alumno buscarAlumno(string opcion)
        {
            Console.WriteLine($" {opcion} ALUMNO");
            Console.WriteLine($"INGRESE EL EMAIL DEL ALUMNO A {opcion}: ");
            string email = Console.ReadLine();

            Alumno alumno = listaAlumnos.Find(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return alumno;
        }

        public void ActualizarAlumno()
        {
            Alumno alumno = this.buscarAlumno("ACTUALIZAR");
            if(alumno != null)
            {
                Console.WriteLine("NUEVO NOMBRE : ");
                string nuevoNombre = Console.ReadLine();
                Console.WriteLine("NUEVO EMAIL : ");
                string nuevoEmail = Console.ReadLine();
                Console.WriteLine("NUEVO CELULAR : ");
                string nuevoCelular = Console.ReadLine();

                alumno.Nombre = nuevoNombre;
                alumno.Email = nuevoEmail;
                alumno.Celular = nuevoCelular;

                this.mensaje.mostrarMensaje("ALUMNO ACTUALIZADO CON EXITO!!!");
            }
            else
            {
                this.mensaje.mostrarMensaje("ALUMNO NO ENCONTRADO...");
            }
        }

        public void EliminarAlumno()
        {
            Alumno alumno = this.buscarAlumno("ELIMINAR");
            if (alumno != null)
            {
                listaAlumnos.Remove(alumno);
                this.mensaje.mostrarMensaje("ALUMNO ELIMINADO CON EXITO!!!");
            }
            else
            {
                this.mensaje.mostrarMensaje("NO SE ENCONTRO EL ALUMNO...");
            }
        }

        public void CargarAlumnos()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        listaAlumnos.Add(Alumno.FromCsv(line));
                    }
                }
            }
        }

        public void GuardarAlumnos()
        {
            using(StreamWriter sr = new StreamWriter(FilePath))
            {
                foreach(var alumno in listaAlumnos)
                {
                    sr.WriteLine(alumno.ToCsv());
                }
            }
        }
    }
}
