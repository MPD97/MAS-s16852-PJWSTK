using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Koncowy_GUI.Models
{
    public class Component 
    {
        [Key]
        public string Identifier { get; set; }

        public int AvailableAmount { get; set; }


        [InverseProperty("Base")]
        public virtual ICollection<Replacement> Bases { get; set; }

        [InverseProperty("ReplacedBy")]
        public virtual ICollection<Replacement> ReplacedBys { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }

        public Component(string identifier) 
        {
            Identifier = identifier;
        }

        public bool Test()
        {
            throw new NotImplementedException();
        }
    }
}
