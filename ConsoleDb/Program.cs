using System;
using System.Collections.Generic;
using System.Text;
using database;

namespace ConsoleDb
{
    class Program
    {
        private static void PrintICollection<T>(ICollection<T> coll)
        {
            foreach(var c in coll)
            {
                Console.Write(c.ToString() + " ");
            }
            Console.WriteLine("\n");
        }
        private static void PrintICollection<T>(ICollection<T> coll, Func<T, string> f)
        {
            var i = 0;
            foreach (var c in coll)
            {
                Console.Write( Convert.ToString(i+1)+ " " + f(c)+ " ");
                i++;
            }
            Console.WriteLine("\n");
        }
        private static string PrintStudent(StudenteDto utente)
        {
            var result = new StringBuilder("Nome Studente " + utente.NomeStudente);


            return result.ToString();
        }


        private static void TestDb()
        {
            var dao = new DaoStudente();
            var daoEsame = new DaoEsame();
            var studenti = dao.GetUtenti();
            var idStudenti = dao.GetIdStudenti();
           
            daoEsame.AddEsame(new Random().Next(idStudenti.Count), 27, new DateTime(2014, 3, 2));
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            PrintICollection(studenti);
            PrintICollection(studenti, PrintStudent);
            daoEsame.AddEsame(24, new DateTime(2020, 4, 12));
            daoEsame.AddEsame(28, DateTime.Now);
            var esamiSenzaStudenti = daoEsame.getEsamiSenzaStudenti();
            var esamiConStudenti = daoEsame.GetEsamiConStudente();

           // PrintICollection(esamiSenzaStudenti);
            PrintICollection(esamiConStudenti);
        }
        static void Main(string[] args)
        {
            try
            {
                TestDb();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eccezione catturata  del tipo " + ex.GetType() + " Messaggio eccezione : " + ex.Message);

            }
        }
    }
}
