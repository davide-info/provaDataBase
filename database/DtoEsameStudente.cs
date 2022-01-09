using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace database
{
   public  class DtoEsameStudente
    {
        public int IdStudente { get; set; }
        public int IdEsame { get; set; }
        public string NomeStudente { get; set; }
        public int VotoEsame { get; set; }
        public DateTime DataEsame { get; set; }
        public override string ToString()
        {
            return " ( " + GetType().Name+ "  Id Studente = " + IdStudente + " Id  Esame = " + IdEsame +" Voto Esame " + VotoEsame + " Data Esame " + DataEsame + " ) ";
        }

    }
}
