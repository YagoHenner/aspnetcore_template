using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegressivaAPI.Domain.Entities
{
    public class Evento
    {
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        public TimeSpan horario { get; set; }
        public TimeSpan ṕroducao { get; set; }
        public TimeSpan comercializacao { get; set; }
        public TimeSpan chamada { get; set; }
        public int blocos { get; set; }
        public DateTime created_at { get; set; }
        [ForeignKey("Usuario")]
        public int modified_by_user_id { get; set; }

        public Usuario Usuario { get; set; }
    }
}
