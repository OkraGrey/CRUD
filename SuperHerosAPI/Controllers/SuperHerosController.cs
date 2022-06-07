using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHerosAPI.Data;

namespace SuperHerosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHerosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<SuperHero>> Get()
        {
            using (DataContext d = new DataContext())
            {
                List<SuperHero> heros = (from p in d.SuperHeroes
                                         orderby p.Id
                                         select p).ToList();
                if (heros.Count == 0)
                {
                    return NotFound("Empty List");
                }
                return Ok(heros);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            using (DataContext d = new DataContext())
            {
                var heros = (from p in d.SuperHeroes
                                         where (p.Id == id)
                                         select p).FirstOrDefault();
                if (heros== null)
                {
                    return NotFound();
                }
                return Ok(heros);
            }
        }
        [HttpPost]
        public async Task<ActionResult<SuperHero>> Post(SuperHero s)
        {
            using (DataContext d = new DataContext())
            {
                if (ModelState.IsValid)
                {
                    d.Add(s);
                    d.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<ActionResult<SuperHero>> Put(SuperHero hero)
        {
            using (DataContext d = new DataContext())
            {
                var heros = (from p in d.SuperHeroes
                             where (p.Id == hero.Id)
                             select p).FirstOrDefault();
                if (heros != null)
                {
                    heros.FirstName = hero.FirstName;
                    heros.LastName = hero.LastName;
                    d.SaveChanges();
                    return Ok(heros);

                }
                return NotFound("Invalid Search");

            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
            using (DataContext d = new DataContext())
            {
                var heros = (from p in d.SuperHeroes
                             where (p.Id == id)
                             select p).FirstOrDefault();
                if (heros != null)
                {
                    d.Remove(heros);
                    d.SaveChanges();
                    return Ok(heros);
                }
                return NotFound();

            }
        }
    }
}
