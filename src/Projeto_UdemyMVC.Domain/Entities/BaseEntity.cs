using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
