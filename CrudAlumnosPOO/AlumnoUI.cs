using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAlumnosPOO
{
    internal class AlumnoUI
    {
        const int ANCHO = 50;
        private AlumnoCRUD crud;
        private MensajeUI mensajeUI = new MensajeUI(50);

        public AlumnoUI()
        {
            crud = new AlumnoCRUD();
        }

        
        public void MostrarMenuPrincipal()
        {
            int opcion = 0;
            while (opcion != 5)
            {
                Console.Clear();
                this.mensajeUI.mostrarTitulo("CRUD DE ALUMNOS");
                Console.WriteLine(@"
                    [1] REGISTRAR ALUMNO
                    [2] MOSTRAR ALUMNOS
                    [3] ACTUALIZAR ALUMNO
                    [4] ELIMINAR ALUMNO
                    [5] SALIR
                ");
                this.mensajeUI.mostrarTitulo("INGRESE UNA OPCIÓN DEL MENU: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        crud.RegistrarAlumno();
                        break;
                    case 2:
                        crud.MostrarAlumnos();
                        Console.WriteLine("PRESIONE ENTER PARA CONTINUAR...");
                        Console.ReadKey();
                        break;
                    case 3:
                        crud.ActualizarAlumno();
                        break;
                    case 4:
                        crud.EliminarAlumno();
                        break;
                    case 5:
                        Console.WriteLine("SALIENDO DEL SISTEMA ... ");
                        crud.GuardarAlumnos();
                        break;
                    default:
                        this.mensajeUI.mostrarMensaje("OPCIÓN INVALIDA!!!");
                        break;
                }
            }
        }
    }
}
