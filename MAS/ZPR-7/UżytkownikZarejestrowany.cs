using System;

namespace ZPR_7
{
    public class UżytkownikZarejestrowany : Osoba
    {
        public string Pseudonim { get; set; }
        public long Ranga { get; set; }

        public UżytkownikZarejestrowany() : base()
        {

        }

        public override void UstawAwatar()
        {
            throw new NotImplementedException();
        }
    }
}
