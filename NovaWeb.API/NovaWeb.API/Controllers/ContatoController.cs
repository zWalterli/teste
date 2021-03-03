using Microsoft.AspNetCore.Mvc;
using NovaWeb.API.Bussiness;
using NovaWeb.Model;
using System.Collections.Generic;

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
        [ProducesResponseType(200, Type = typeof(List<Contato>))]
        public IActionResult Get()
        {
            return Ok(_repositoryContato.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Contato))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            var contato = _repositoryContato.FindById(id);
            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Contato))]
        [ProducesResponseType(400)]
        public IActionResult Post(Contato model)
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
        public IActionResult Put(Contato model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(_repositoryContato.Update(model));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public IActionResult Delete(int id)
        {
            _repositoryContato.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}/telefone")]
        [ProducesResponseType(200, Type = typeof(List<Contato>))]
        [ProducesResponseType(404)]
        public IActionResult GetTelefonesDoContato(int id)
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
        public IActionResult DeleteTelefoneDoContato(int IdContato, int IdTelefone)
        {
            _repositoryTelefone.Delete(IdTelefone, IdContato);
            return NoContent();
        }

        [HttpDelete("{id}/telefone/")]
        [ProducesResponseType(204)]
        public IActionResult DeleteTelefoneDoContato(int IdContato)
        {
            _repositoryTelefone.DeleteTodosTelefonesDoContato(IdContato);
            return NoContent();
        }

        [HttpPost("{id}/telefone/")]
        [ProducesResponseType(200, Type = typeof(List<Contato>))]
        [ProducesResponseType(404)]
        public IActionResult PostTelefones(List<Telefone> model)
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
        public IActionResult PutTelefones(List<Telefone> model)
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
