using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class JaratKezelo
    {

        List<Jarat> osszesJarat = new List<Jarat>();
        

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova,
            DateTime indulas)
        {
            Jarat jarat = new Jarat();
            jarat.jaratSzam = jaratSzam;
            jarat.HonnanRepter = repterHonnan;
            jarat.HovaRepter = repterHova;
            jarat.Indulas = indulas;
            jarat.keses = 0;
            osszesJarat.Add(jarat);
        }

        public void KesesSzamit(string jaratSzam, int keses)
        {
            for (int i = 0; i < osszesJarat.Count; i++)
            {
                if(osszesJarat[i].jaratSzam == jaratSzam)
                {
                    osszesJarat[i].keses += keses;
                }
            }

            
        } 

        public DateTime MikorIndul(string jarat)
        {
            DateTime indul = DateTime.Now;
            for (int i = 0; i < osszesJarat.Count; i++)
            {
                if (osszesJarat[i].jaratSzam == jarat)
                {
                    indul = osszesJarat[i].Indulas;
                }
            }
            return indul;
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            List<string> repterek = new List<string>();

            return repterek;
        }
        public string getJaratSzam(string jaratSzam)
        {
            return Keres(jaratSzam).jaratSzam;
        }
       
        public string Uticel(string jaratSzam)
        {
            return Keres(jaratSzam).HovaRepter;
        }

        public DateTime getIndulas(string jaratSzam)
        {
            return Keres(jaratSzam).Indulas;
        }

        public int getKeses(string jaratSzam)
        {
            return Keres(jaratSzam).keses;
        }

        public int setKeses(string jaratSzam, int keses)
        {
            Keres(jaratSzam).keses = keses;

            return Keres(jaratSzam).keses;
        }

        public int duplikaKeres(string jaratSzam)
        {
            int db = 0;
            foreach (var j in osszesJarat)
            {
                if (j.jaratSzam.Equals(jaratSzam))
                {
                    db++;
                }
            }
            return db;
            throw new HibasJaratSzamException(jaratSzam);
        }

        Jarat Keres(string jaratSzam)
        {
            foreach (var j in osszesJarat)
            {
                if (j.jaratSzam.Equals(jaratSzam))
                {
                    return j;
                }
            }
            throw new HibasJaratSzamException(jaratSzam);
        }

    }
}
