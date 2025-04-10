using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belepteto
{
    public class EsemenyKezelo
    {
        List<Esemeny> lista;

        public EsemenyKezelo()
        {
            lista = new List<Esemeny>();
        }

        public List<Esemeny> Lista { get => lista; }

        public void LoadFromData(String path)
        {
            File.ReadAllLines(path).ToList().ForEach(x =>
            {
                var split = x.Split(' ');
                lista.Add(new Esemeny(split[0], split[1], int.Parse(split[2])));
            });
        }

        public List<Esemeny> GetEsemenyek(int esemenyFajta)
        {
            return Lista.Where(x => x.EsemenyKod == esemenyFajta).ToList();
        }

        public Esemeny Elso { get => GetEsemenyek(1).OrderBy(x => x.IdpontTime).First(); }
        public Esemeny Utolso { get => GetEsemenyek(2).OrderByDescending(x => x.IdpontTime).First(); }

        public int EbedelokSzama { get => GetEsemenyek(3).DistinctBy(x => x.Kod).Count(); }

        public int KolcsonzokSzama { get => GetEsemenyek(4).DistinctBy(x => x.Kod).Count(); }

        public List<Esemeny> KesokListaja(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            var list =  GetEsemenyek(1).Where(x => x.IdpontTime > TimeOnly.Parse("7:50") && x.IdpontTime <= TimeOnly.Parse("8:15")).ToList();
            list.ForEach(x =>
            {
                sw.WriteLine($"{x.Kod} {x.Idopont}");
            });
            sw.Close();
            return list;
        }

        public List<String> EbedelokKodjai()
        {
            var list = new List<String>();
            lista.ForEach(x => { 
                if(x.EsemenyKod == 3)
                {
                    list.Add(x.Kod);
                }
            });
            return list;
        }

        public List<String> Logok()
        {
            var list = new List<String>();
            GetEsemenyek(1).Where(x => x.IdpontTime >= TimeOnly.Parse("10:50") && x.IdpontTime <= TimeOnly.Parse("11:00")).ToList().ForEach(x =>
            {
                if (GetEsemenyek(1).Where(y => y.Kod == x.Kod).OrderBy(z => z.IdpontTime).First().IdpontTime < TimeOnly.Parse("10:50") && 
                    GetEsemenyek(2).Where(y => y.Kod == x.Kod).OrderBy(z => z.IdpontTime).First().IdpontTime < TimeOnly.Parse("10:50") == false) { 
                    list.Add(x.Kod);
                }
            });
            return list;
        }

        public string TartozkodasiIdo(string kod)
        {
            if(!lista.Exists(x => x.Kod == kod)){
                return "Ilyen azonosítójú tanuló aznap nem volt az iskolában.";
            }

            var belepes = GetEsemenyek(1).Where(x => x.Kod == kod).ToList().OrderBy(x => x.IdpontTime).First();
            var kilepes = GetEsemenyek(2).Where(x => x.Kod == kod).ToList().OrderByDescending(x => x.IdpontTime).First();
            TimeOnly idotartam = TimeOnly.Parse(Convert.ToString(kilepes.IdpontTime - belepes.IdpontTime));
            return ($"{idotartam.Hour} óra {idotartam.Minute} perc");
        }
    }
}
