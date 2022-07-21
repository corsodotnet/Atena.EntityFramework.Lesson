using Atena.EntityFramework.Lesson.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Atena.EntityFramework.Lesson
{
    internal class Program
    {
        static UniversityDbContext db = null;

        static void Main(string[] args)
        {

            using (db = new UniversityDbContext())
            {
                try
                {
                    Studente std = GetStudent(1006);

                    Console.WriteLine($"Name: {std.Name}"); 
                    Console.WriteLine($"Matricola: {std.Id}");
                    Console.WriteLine($"Email: {std.Email}");
                    Console.WriteLine($"Id del Corso: {std.CorsoId}");


                    DeleteStudent(std);

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
        static Studente GetStudent(int matricola)
        {
            using (db = new UniversityDbContext())
            {
                return db.Studentes.Where(s => s.Id == matricola).FirstOrDefault();
            }
        }
        static void  UpdateStudent(Studente Studente)
        {
            using (db = new UniversityDbContext())
            {
                try
                {
                    db.Update(Studente);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
               
            }
        }
        static void DeleteStudent(Studente Studente)
        {
            using (db = new UniversityDbContext())
            {
                try
                {
                    db.Remove(Studente);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }
    } 
}
