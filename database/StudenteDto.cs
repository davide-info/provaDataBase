using System;
using System.Collections.Generic;
using System.Text;

namespace database
{
   public  class StudenteDto
    {
        public int IdStudente { get; set; }
        public string NomeStudente { get; set; }
        public override string ToString()
        {
            return "Idutente " + IdStudente + " nome " + NomeStudente;
        }
    }
}
