using MP03.Functional;
using System;

namespace MP03
{
    public class License : ObjectPlusPlus
    {

        private string _boxNumber;
        private string _identificator;

        public string BoxNumber { 
            get
            {
                return _boxNumber;
            }
            set
            {
                if(_identificator != null)
                {
                    throw new Exception("Nie mozna ustanowic BoxNumber, gdy zostal nadany Identificator.");
                }
                else
                {
                    _boxNumber = value;
                }
            }
        }
        public string Identificator {
            get
            {
                return _identificator;
            }
            set
            {
                if (_boxNumber != null)
                {
                    throw new Exception("Nie mozna ustanowic Identificator, gdy zostal nadany BoxNumber.");
                }
                else
                {
                    _identificator = value;
                }
            }
        }


        public License() :base()
        {

        }
    }
} 
