using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repositories
{
    public class EstudianteRepository
    {
        private readonly SchoolContext _context= new SchoolContext();

        
        public async Task guardarEstudiante(Student student)
        {
                       
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
 
        }

        public static async Task agregarEstudiante()
        {
            Console.WriteLine("Metodo agregar estudiante");

            using (SchoolContext context = new SchoolContext())
            {
                Student std = new Student();
                std.Name = "Bill";
                context.Students.Add(std);
                await context.SaveChangesAsync();

                Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);
            }
        }

        public static async Task consultarEstudiantes()
        {
            Console.WriteLine("Metodo consultar estudiantes");
            using (SchoolContext context = new SchoolContext())
            {
                List<Student> listEstudiantes = await context.Students.ToListAsync();

                foreach (var item in listEstudiantes)
                {
                    Console.WriteLine("Codigo: " + item.StudentId + " Nombre: " + item.Name);
                }
            }
        }

        public static async Task consultarEstudiante()
        {
            Console.WriteLine("Metodo consultar estudiante por id");
            using (SchoolContext context = new SchoolContext())
            {
                Student std = await context.Students.FindAsync(11);
                Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);
            }
        }

        public static async Task modificarEstudiante()
        {
            Console.WriteLine("Metodo modificar estudiante");
            using (SchoolContext context = new SchoolContext())
            {
                Student std = await context.Students.FindAsync(3);

                std.Name = "Bill Gates";
                await context.SaveChangesAsync();
                Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);
            }
        }

        public static async Task eliminarEstudiante()
        {
            Console.WriteLine("Metodo eliminar estudiante");
            using (SchoolContext context = new SchoolContext())
            {
                Student std = await context.Students.FindAsync(2);
                context.Students.Remove(std);
                await context.SaveChangesAsync();
                Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);
            }
        }
    }
}
