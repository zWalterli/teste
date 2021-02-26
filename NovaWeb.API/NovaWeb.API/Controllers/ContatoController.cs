using Microsoft.AspNetCore.Mvc;
using NovaWeb.API.Bussiness;
using NovaWeb.API.Model;

namespace NovaWeb.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return Ok(_repositoryContato.FindById(id));
        }

        [HttpGet("{id}/telefone")]
        public IActionResult GetTelefonesDoContato(int id)
        {
            return Ok(_repositoryTelefone.GetAllTelefonesByIdContato(id));
        }

        [HttpPost]
        public IActionResult Post(Contato model)
        {
            return Ok(_repositoryContato.Create(model));
        }

        [HttpPut]
        public IActionResult Put(Contato model)
        {
            return Ok(_repositoryContato.Update(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositoryContato.Delete(id);
            return Ok();
        }
    }
}
