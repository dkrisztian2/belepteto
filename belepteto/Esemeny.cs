using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belepteto
{
    public class Esemeny
    {
        string kod, idopont;
        int esemenyKod;

        public Esemeny(string kod, string idopont, int esemenyKod)
        {
            this.kod = kod;
            this.idopont = idopont;
            this.esemenyKod = esemenyKod;
        }

        public string Kod { get => kod; }
        public string Idopont { get => idopont; }
        public int EsemenyKod { get => esemenyKod; }

        public TimeOnly IdpontTime{ get => TimeOnly.FromDateTime(Convert.ToDateTime(Idopont)); }
    }
}
