using Microsoft.AspNetCore.Mvc;

using Gerencial.WebApi.Data;
using Gerencial.WebApi.Models;

namespace Gerencial.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IntervencaoController: ControllerBase
    {
		private readonly IRepository _repository;

		public IntervencaoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_repository.GetAllIntervencoes());
        }

        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            Intervencao intervencao = _repository.GetIntervencaoById(Id);

            if(intervencao is null)
                return BadRequest("Não foi possível encontrar intervenção com id especificado.");
            
            return Ok(intervencao);
        }

        [HttpPost]
        public ActionResult Post(Intervencao intervencao)
        {
            _repository.Add<Intervencao>(intervencao);

            if(_repository.SaveChanges())
                return Ok(intervencao);
            
            return BadRequest("Erro ao incluir intervenção.");
        }

        [HttpPut("{Id}")]
        public ActionResult Post(int Id, Intervencao intervencao)
        {
            Intervencao IntervencaoAux = _repository.GetIntervencaoById(Id);
            
            if(IntervencaoAux is null)
                return BadRequest("Id informado não foi encontrado.");

            _repository.Update<Intervencao>(intervencao);

            if(_repository.SaveChanges())
                return Ok(intervencao);
            
            return BadRequest("Erro ao incluir intervenção.");
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            Intervencao intervencaoAux = _repository.GetIntervencaoById(Id);
            
            if(intervencaoAux is null)
                return BadRequest("Id informado não foi encontrado.");

            _repository.Delete<Intervencao>(intervencaoAux);

            if(_repository.SaveChanges())
                return Ok($"intervenção {intervencaoAux.Id} excluída com sucesso.");
            
            return BadRequest("Não foi possível excluir a intervenção.");
        }
    }
}