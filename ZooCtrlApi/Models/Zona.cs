using System.ComponentModel.DataAnnotations;

namespace ZooCtrlApi.Models
{
    public class Zona
    {
        [Key]
        public int IdZona { get; set; }
        public string Nome { get; set; }
        public int IdFilo { get; set; }
    }
}
