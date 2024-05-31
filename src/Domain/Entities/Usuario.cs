using System.ComponentModel.DataAnnotations;

namespace RegressivaAPI.Domain.Entities
{
    public class Usuario
    {
        public int id { get; set; }
        [Required]
        public string login { get; set; }
        [Required]
        public string senha { get; set; }
        public int status { get; set; }
    }
}
