using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Koncowy_GUI.Models
{
    public class Replacement
    {
        public string ReplacementId { get; set; }

        public string BaseId { get; set; }
        public string ReplacedById { get; set; }

        [ForeignKey("BaseId")]
        public Component Base { get; set; }

        [ForeignKey("ReplacedById")]
        public Component ReplacedBy { get; set; }
    }
}
