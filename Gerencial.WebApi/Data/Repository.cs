using System.Collections.Generic;
using System.Linq;

using Gerencial.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerencial.WebApi.Data
{
	public class Repository : IRepository
	{
		private readonly GerencialContext _context;

		public Repository(GerencialContext context)
        {
            _context = context;
        }
		
        public void Add<T>(T Entity) where T : class
		{
			_context.Add(Entity);
		}

		public void Update<T>(T Entity) where T : class
		{
			_context.Update(Entity);
		}

		public void Delete<T>(T Entity)
		{
			_context.Remove(Entity);
		}
        
        public bool SaveChanges()
		{
			return (_context.SaveChanges() > 0);
		}

		public IEnumerable<Cliente> GetAllClientes()
		{
			IQueryable<Cliente> Query = _context.Tbl_Clientes;
            
            Query = Query.Include(c => c.Intervencoes).AsNoTracking().OrderBy(c => c.Nome);
            return Query;
		}
        
        public Cliente GetClienteById(int Id)
		{
			IQueryable<Cliente> Query = _context.Tbl_Clientes;
            Cliente cliente = Query.Include(c => c.Intervencoes)
                                   .AsNoTracking()
								   .FirstOrDefault(c => c.Id == Id);
            
            return cliente;
		}

		public IEnumerable<Intervencao> GetAllIntervencoes()
		{
			IQueryable<Intervencao> Query = _context.Tbl_Intervencoes;
            
            Query = Query.AsNoTracking().OrderBy(Int => Int.Id);
            return Query;
		}

		public Intervencao GetIntervencaoById(int Id)
		{
			IQueryable<Intervencao> Query = _context.Tbl_Intervencoes;
            
            return Query.AsNoTracking().FirstOrDefault(c => c.Id == Id);
		}

		public IEnumerable<Intervencao> GetIntervencoesByClienteId(int ClienteId)
		{
			IQueryable<Intervencao> Query = _context.Tbl_Intervencoes;
            return Query.AsNoTracking().Where(inter => inter.ClienteId == ClienteId);
		}
	}
}