using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gerencial.WebApi.Models
{
	public class Cliente
	{
		public int Id { get; set; }
		[MaxLength(60)]
		public string Nome { get; set; }

		public IEnumerable<Intervencao> Intervencoes { get; set; }
	}
}