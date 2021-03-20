using Microsoft.AspNetCore.Mvc;
using NovaWeb.API.Bussiness;
using NovaWeb.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType(200, Type = typeof(List<Contato>))]
        public IActionResult Get(
            [FromQuery] string name,
            string sortDirection,
            int pageSize,
            int page)
        {
            return Ok(_repositoryContato.findWithPagedSearch(name, sortDirection, pageSize, page));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Contato))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            var contato = _repositoryContato.FindById(id);
            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }        
        
        [HttpGet("findContatoByName")]
        [ProducesResponseType(200, Type = typeof(Contato))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get([FromQuery] string firstName, [FromQuery]  string lastName)
        {
            var contato = _repositoryContato.FindByName( firstName, lastName);
            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Contato))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(Contato model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(_repositoryContato.Create(model));
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Contato))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(Contato model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(_repositoryContato.Update(model));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int id)
        {
            _repositoryContato.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}/telefone")]
        [ProducesResponseType(200, Type = typeof(List<Contato>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTelefonesDoContato(int id)
        {
            var telefones = _repositoryTelefone.GetAllTelefonesByIdContato(id);
            if (telefones == null)
            {
                return NotFound();
            }
            return Ok(telefones);
        }

        [HttpDelete("{idContato}/telefone/{IdTelefone}/")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTelefoneDoContato(int IdContato, int IdTelefone)
        {
            _repositoryTelefone.Delete(IdTelefone, IdContato);
            return NoContent();
        }

        [HttpDelete("{id}/telefone/")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTelefoneDoContato(int IdContato)
        {
            _repositoryTelefone.DeleteTodosTelefonesDoContato(IdContato);
            return NoContent();
        }

        [HttpPost("{id}/telefone/")]
        [ProducesResponseType(200, Type = typeof(List<Contato>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PostTelefones(List<Telefone> model)
        {
            int x = 0;
            foreach (var item in model)
            {
                if (item == null)
                {
                    return BadRequest();
                }
                var result = _repositoryTelefone.Create(item);
                model[x].TelefoneId = result.TelefoneId;
                x++;
            }
            return Ok(model);
        }
        
        [HttpPut("{id}/telefone/")]
        [ProducesResponseType(200, Type = typeof(List<Contato>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutTelefones(List<Telefone> model)
        {
            foreach (var item in model)
            {
                if (item == null)
                {
                    return BadRequest();
                }
                _repositoryTelefone.Update(item);
            }
            return Ok(model);
        }
    }
}
