using MP03.Functional;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ZPR_7
{
    public abstract class Osoba : ObjectPlusPlus
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }
        public string Avatar { get; set; } //Scieżka do pliku

        public Osoba() : base()
        {

        }

        public abstract void UstawAwatar();
    }
}
