using System;

namespace ZPR_7
{
    public class Pracownik : Osoba
    {
        public string NumerIdentyfikacyjny { get; set; }
        public decimal Pansja { get; set; }

        public Pracownik() : base()
        {

        }

        public override void UstawAwatar()
        {
            throw new NotImplementedException();
        }
    }
}
