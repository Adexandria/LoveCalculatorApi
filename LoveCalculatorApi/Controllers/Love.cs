using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoveCalculatorApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoveCalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Love : Controller
    {
        private readonly ICalculator db;
        public Love(ICalculator db)
        {
            this.db = db;
        }
       [HttpGet]
        public IActionResult Index(string name,string crush)
        {
            var query = db.GetCalculator(name, crush);
            if (query != null)
            {
                return Ok(query);
            }
            else
            {
                return NotFound("Data not found");
            }
            }
        [HttpPost]
        public IActionResult Post(Calculator calculator)
        {
            if (ModelState.IsValid)
            {
                db.Add(calculator);
                db.Commit();
                return Ok(db.Calculation(calculator.Name, calculator.Name1));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
