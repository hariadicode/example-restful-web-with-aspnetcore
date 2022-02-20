using ExampleRestfulWeb.Api.Models;
using ExampleRestfulWeb.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleRestfulWeb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        { }

        /**
         * public ActionResult GetAll()
         */
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        /**
         * public ActionResult Get(int id)
         */
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        /**
         * public IActionResult Create(Pizza pizza)
         */
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }

        /**
         * public IActionResult Update(int id, Pizza pizza)
         */
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var pizzaExist = PizzaService.Get(id);

            if (pizzaExist is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        /**
         * public IActionResult Delete(int id)
         */
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizzaExist = PizzaService.Get(id);

            if (pizzaExist is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}
