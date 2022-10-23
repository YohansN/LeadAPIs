using System.ComponentModel.DataAnnotations;

namespace ZooCtrlApi.Models
{
    public class Filo
    {
        [Key]
        public int IdFilo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
