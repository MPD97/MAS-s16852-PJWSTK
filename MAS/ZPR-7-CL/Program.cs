using MP03.Functional;
using System;
using ZPR_7;

namespace ZPR_7_CL
{
    class Program
    {
        static void Main(string[] args)
        {
            Association<Przepis, Opinia>.CreateAssociation(1, 0, "posiada", "dotyczy");             // jeden przepis - wiele opinni
            var przpisOpinniaAssociation = Association<Przepis, Opinia>.GetAssociation();

            Association<Osoba, Opinia>.CreateAssociation(1, 0, "dodala", "napisana przez");         // jedna osoba - wiele opinni
            var osobaOpinniaAssociation = Association<Osoba, Opinia>.GetAssociation();

            Association<Przepis, Osoba>.CreateAssociation(0, 1, "stworzony przez", "stworzyla");    // wiele przepisów - jedna osoba
            var przepisOsobaAssociation = Association<Przepis, Osoba>.GetAssociation();

            Association<Osoba, Przepis>.CreateAssociation(0, 0, "ma ulubiony", "ulubiony przez");   // wiele osób - wiele przepisów
            var przepisOpinniaAssociation = Association<Przepis, Osoba>.GetAssociation();


        }
    }
}
