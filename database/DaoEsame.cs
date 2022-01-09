using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace database
{
   public class DaoEsame
    {
        public int AddEsame(int voto, DateTime data)
        {
            int idEsame = 0;
            using(var db = new MyContext())
            {
                var esame = new Esame() { DataEsame=data, VotoEsame=voto};
                db.Esami.Add(esame);
                db.SaveChanges();
                idEsame = esame.IdEsame;
            }
            return idEsame;
        }
        public int AddStudenteEsame(int idStudente, int voto, DateTime dataEsame )
        {
            int idEsame = 0;
            using (var db = new MyContext())
            {
                var esame = new Esame() { DataEsame = dataEsame, VotoEsame = voto, StudenteForeignKey=idStudente};
                db.Esami.Add(esame);
                db.SaveChanges();
                idEsame = esame.IdEsame;
            }
            return idEsame;
        }
    
        public ICollection<DtoEsameStudente> GetEsamiConStudente()
        {
            var esamiConStudenti = new List<DtoEsameStudente>();
            using(var db = new MyContext())
            {
                var query = db.Studenti.Join(db.Esami, s => s.IdStudente,(Esame a) => a.StudenteForeignKey, (s, x) => new {IdEsame=x.IdEsame });
            }


            return esamiConStudenti;

        }

        public ICollection<EsameDto> getEsamiSenzaStudenti()
        {
            var esamiSenzaStudenti = new List<EsameDto>();
            using (var db = new MyContext())
            {
                var query = db.Esami.Select(e => new { IdEsame = e.IdEsame, DataEsame=e.DataEsame, VotoEsame=e.VotoEsame });
                foreach(var q in query)
                {
                    var esameSenzaStudente = new EsameDto() {IdEsame=q.IdEsame, DataEsame=q.DataEsame, VotoEsame=q.VotoEsame };
                    esamiSenzaStudenti.Add(esameSenzaStudente);
                }

            }

                return esamiSenzaStudenti;
        }

    }
}
