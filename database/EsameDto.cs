using System;
using System.Collections.Generic;
using System.Text;

namespace database
{
   public class EsameDto
    {
        public int IdEsame { get; set; }
        public int VotoEsame { get; set; }
        public DateTime DataEsame { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is EsameDto)) return false;
            var esame = obj as EsameDto;
            return esame.IdEsame.Equals(IdEsame);
        }
        public override int GetHashCode()
        {
            return IdEsame.GetHashCode();
        }
        public override string ToString()
        {
            return "EsameDto ( idEsame = " + IdEsame + " Voto Esame " + VotoEsame + " Data Esame "+DataEsame+  " ) ";
        }
    }
}
