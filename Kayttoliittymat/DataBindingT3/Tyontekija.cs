using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingT3
{
    public class Henkilo
    {
        public string SOTU { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public DateTime SyntymaAika { get; set; }
        private string kokonimi;
        public string Kokonimi
        {
            get { return kokonimi; }
        }
        public int Ika { get;}

        public Henkilo(string sotu)
        {
            SOTU = sotu;
        }
        public Henkilo(string sotu, string etunimi, string sukunimi)
        {
            SOTU = sotu;
            Etunimi = etunimi;
            Sukunimi = sukunimi;
            AsetaKokoNimi();
        }
        private void AsetaKokoNimi()
        {
            kokonimi = Sukunimi + " " + Etunimi;
        }

    }
    public abstract class Tyontekija : Henkilo
    {
        public string Nimike { get; set; } = "orja";
        public int TTNumero { get; set; }
        public DateTime AloitusPvm { get; set; }
        public float Palkka { get; set; } = 42;
        public Tyontekija(string sotu) : base(sotu)
        {

        }
        public Tyontekija(string sotu, string etunimi, string sukunimi, int tTNumero, string nimike, float palkka) : base(sotu, etunimi, sukunimi)
        {
            TTNumero = tTNumero;
            Nimike = nimike;
            Palkka = palkka;
        }
        public override string ToString()
        {
            return TTNumero + " = " + Kokonimi + ", " + Nimike;
        }
        public abstract float LaskePalkka();

    }
    public class Vakituinen : Tyontekija
    {
        public float KuukausiPalkka { get; set; }
        public Vakituinen(string sotu, string etunimi, string sukunimi, int tTNumero, string nimike, float palkka) : base(sotu, etunimi, sukunimi, tTNumero, nimike, palkka)
        {

        }
        public override float LaskePalkka()
        {
            return KuukausiPalkka;
        }

    }

    public class OsaAikainen: Tyontekija
    {
        public float TuntiPalkka { get; set; }
        public float TehdytTunnit { get; set; }
        public OsaAikainen(string sotu, string etunimi, string sukunimi, int tTNumero, string nimike, float palkka) : base(sotu, etunimi, sukunimi, tTNumero, nimike, palkka)
        {

        }
        public override float LaskePalkka()
        {
            return TuntiPalkka * TehdytTunnit;
        }

    }
}
