using System.Collections.Generic;
using ASP.Models;
using ASP.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace ASP.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
       public PizzaController()
       {
           
       }
       [HttpGet]
       public ActionResult<List<Pizza>> GetAll() =>PizzaService.GetAll();


       [HttpGet("{id}")]
       public ActionResult<Pizza> GetActionResult(int id)
       {
           var pizza = PizzaService.Get(id);
           if(pizza == null )
           {
               return NotFound();
           }
           return pizza;
       }
       [HttpPost]
       public IActionResult Create(Pizza pizza)
       {
           PizzaService.Add(pizza);
           return CreatedAtAction(nameof(Create),new {id = pizza.Id},pizza);
       }

       [HttpPut("{id}")]
       public IActionResult Put(int id , Pizza pizza)
       {
          if (id != pizza.Id)
          {
              return BadRequest();
          }
          
          var existingPizza = PizzaService.Get(id);
          if(existingPizza is null)
          {
              return NotFound();
          }
          PizzaService.Update(pizza); 
          return NoContent();
       }

       [HttpDelete("{id}")]
       public IActionResult Delete(int id)
       {
           var pizza = PizzaService.Get(id);
           if(pizza is null)
           {
               return NotFound();
           }
           PizzaService.Delete(id);

           return NoContent();
       }

      
    }
}