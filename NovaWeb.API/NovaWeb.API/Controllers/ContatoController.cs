using Microsoft.AspNetCore.Mvc;
using NovaWeb.API.Bussiness;
using NovaWeb.API.Model;

namespace NovaWeb.API.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoBusiness _repositoryContato;
        private readonly ITelefoneBusiness _repositoryTelefone;

        public ContatoController(IContatoBusiness repositoryContato, ITelefoneBusiness repositoryTelefone)
        {
            _repositoryContato = repositoryContato;
            _repositoryTelefone = repositoryTelefone;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositoryContato.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contato = _repositoryContato.FindById(id);
            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        [HttpGet("{id}/telefone")]
        public IActionResult GetTelefonesDoContato(int id)
        {
            var telefones = _repositoryTelefone.GetAllTelefonesByIdContato(id);
            if (telefones == null)
            {
                return NotFound();
            }
            return Ok(telefones);
        }

        [HttpPost]
        public IActionResult Post(Contato model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(_repositoryContato.Create(model));
        }

        [HttpPut]
        public IActionResult Put(Contato model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(_repositoryContato.Update(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositoryContato.Delete(id);
            return NoContent();
        }
    }
}
