using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAlumnosPOO
{
    internal class Alumno
    {
        //atributos de clase
        private string nombre;
        private string email;
        private string celular;

        //constructor de clase
        public Alumno(string nom,string ema,string cel)
        {
            this.nombre = nom;
            this.email = ema;
            this.celular = cel;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Celular { get => celular; set => celular = value; }

        public void Mostrar()
        {
            Console.WriteLine($"Nombre : {this.nombre}");
            Console.WriteLine($"Email : {this.email}");
            Console.WriteLine($"Celular : {this.celular}");
        }

        public string ToCsv()
        {
            return $"{this.nombre},{this.email},{this.celular}";
        }

        public static Alumno FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            if(values.Length != 3)
            {
                throw new ArgumentException("El formato csv no es valido");
            }
            return new Alumno(values[0], values[1], values[2]);
        }
    }
}
