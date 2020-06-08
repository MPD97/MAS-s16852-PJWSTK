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
        public Guid Identifier { get; set; }
        
        [InverseProperty("Base")]
        public virtual ICollection<Replacement> Base { get; set; }

        [InverseProperty("ReplacedBy")]
        public virtual ICollection<Replacement> ReplacedBy { get; set; }



        public Component(Guid identifier) 
        {
            Identifier = identifier;
        }

        public bool Test()
        {
            throw new NotImplementedException();
        }
    }
    public class Replacement
    {
        public Guid ReplacementId { get; set; }

        public Guid BaseId { get; set; }
        public Guid ReplacedById { get; set; }

        [ForeignKey("BaseId")]
        public Component Base { get; set; }

        [ForeignKey("ReplacedById")]
        public Component ReplacedBy { get; set; }
    }
}
