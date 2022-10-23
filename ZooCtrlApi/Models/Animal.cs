using System.ComponentModel.DataAnnotations;

namespace ZooCtrlApi.Models
{
    public class Animal
    {
        [Key]
        public int IdAnimal { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public int IdFilo { get; set; }
    }
}
