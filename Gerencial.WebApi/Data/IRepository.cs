using System.Collections.Generic;

using Gerencial.WebApi.Models;

namespace Gerencial.WebApi.Data
{
    public interface IRepository
    {
        void Add<T>(T Entity) where T: class;
        void Update<T>(T Entity) where T: class;
        void Delete<T>(T Entity);
        bool SaveChanges();

        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(int Id);

        IEnumerable<Intervencao> GetAllIntervencoes();
        IEnumerable<Intervencao> GetIntervencoesByClienteId(int IdCliente);
        Intervencao GetIntervencaoById(int Id);
    }
}