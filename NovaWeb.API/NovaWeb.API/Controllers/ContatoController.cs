using Microsoft.AspNetCore.Mvc;
using NovaWeb.API.Bussiness;
using NovaWeb.API.Model;

namespace NovaWeb.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoBusiness _repository;

        public ContatoController(IContatoBusiness repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.FindById(id));
        }

        [HttpPost]
        public IActionResult Post(Contato model)
        {
            return Ok(_repository.Create(model));
        }

        [HttpPut]
        public IActionResult Put(Contato model)
        {
            return Ok(_repository.Update(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
