using System;
using System.ComponentModel.DataAnnotations;

namespace Gerencial.WebApi.Models
{
    public class Intervencao
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        [MaxLength(60)]
        public string Solicitador { get; set; }
        public string Solicitacao { get; set; }
        public DateTime DtServico { get; set; }
    }
}