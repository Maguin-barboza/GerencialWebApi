using Microsoft.AspNetCore.Mvc;

using Gerencial.WebApi.Data;
using Gerencial.WebApi.Models;

namespace Gerencial.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController: ControllerBase
    {
		private readonly IRepository _repository;

		public ClienteController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_repository.GetAllClientes());
        }

        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            Cliente cliente = _repository.GetClienteById(Id);

            if(cliente is null)
                return BadRequest("Não foi possível encontrar cliente com id especificado.");
            
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            _repository.Add<Cliente>(cliente);

            if(_repository.SaveChanges())
                return Ok(cliente);
            
            return BadRequest("Erro ao incluir cliente.");
        }

        [HttpPut("{Id}")]
        public ActionResult Post(int Id, Cliente cliente)
        {
            Cliente clienteAux = _repository.GetClienteById(Id);
            
            if(clienteAux is null)
                return BadRequest("Id informado não foi encontrado.");

            _repository.Update<Cliente>(cliente);

            if(_repository.SaveChanges())
                return Ok(cliente);
            
            return BadRequest("Erro ao incluir cliente.");
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            Cliente clienteAux = _repository.GetClienteById(Id);
            
            if(clienteAux is null)
                return BadRequest("Id informado não foi encontrado.");

            _repository.Delete<Cliente>(clienteAux);

            if(_repository.SaveChanges())
                return Ok($"Cliente {clienteAux.Nome} excluído com sucesso.");
            
            return BadRequest("Não foi possível excluir o cliente.");
        }
    }
}