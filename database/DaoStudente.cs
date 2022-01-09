using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace database
{
    public class DaoStudente
    {
        public DaoStudente()
        {
           // database.
        }
        public int InserisciUtente(string nome)
        {
           
            var id = 0;

            using (var db = new MyContext())
            {
                Studente u = new Studente() { Nome = nome };
                db.Studenti.Add(u);
                db.SaveChanges();
                id = u.IdStudente;
            }

            return id;
        }

        public void EliminaStudenti()
        {
            using (var db = new MyContext())
            {
                foreach (var utente in db.Studenti)
                {
                    db.Remove(utente);
                }
            }
        }

        
        public ICollection<StudenteDto> GetUtenti()
        {
            var studenti = new List<StudenteDto>();
            
            using (var db = new MyContext())
            {
                var query = from u in db.Studenti select u;
                foreach (var u in query)
                {
                    var studente = new StudenteDto() { NomeStudente = u.Nome, IdStudente=u.IdStudente};
                    studenti.Add(studente);
                }
               

            }
            return studenti;
         }
        public ICollection<int> GetIdStudenti()
        {
            var idStudenti = new List<int>();

            using(var db = new MyContext() ) {
                var query = db.Studenti.Select(s => s.IdStudente);
                foreach(var q in query)
                {
                    idStudenti.Add(q);
                }
            
            }
            return idStudenti;
        }
       

        public ICollection<DtoEsameStudente> GetEsameJoinStudente()
        {
            var esami = new List<DtoEsameStudente>();
            using (var db = new MyContext())
            {

               var query= db.Studenti.Join(db.Esami, e => e.IdStudente, s => s.StudenteForeignKey, (s,e) => new {NomeStudente=s.Nome, IdStudente=s.IdStudente, IdEsame= e.IdEsame, ForeignKeyStudente=e.StudenteForeignKey, DataEsame=e.DataEsame,VotoEsame=e.VotoEsame,}).ToList().Where(e=>e.IdStudente==e.ForeignKeyStudente);
               foreach (var q in query)
               {
                   var dto = new DtoEsameStudente(){IdEsame = q.IdEsame,DataEsame = q.DataEsame, NomeStudente = q.NomeStudente,VotoEsame = q.VotoEsame};
                   esami.Add(dto);
               }

            }

            

            return esami;
        }

    }
}
