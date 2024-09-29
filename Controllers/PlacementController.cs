using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacementController : ControllerBase
    {
        private static new List<Placement> placements = new List<Placement>
        {
            new Placement {IdWorker = "111111", Day = "ראשון", Morning = true, Evening = true, Night = false, Idward = 1 },
            new Placement {IdWorker = "111111", Day = "שלישי", Morning = true, Evening = false, Night = true, Idward = 1 },
            new Placement {IdWorker = "222222", Day = "ראשון", Morning = true, Evening = false, Night = false, Idward = 2 },
        };

        // GET: api/<PlacementController>
        [HttpGet]
        public IEnumerable<Placement> Get()
        {
            return placements;
        }

        // GET api/<PlacementController>/5
        [HttpGet("{id}")]
        public IEnumerable<Placement> Get(string idWorker)
        {
            return placements.FindAll(p => p.IdWorker.Equals(idWorker));
        }

        // POST api/<PlacementController>
        [HttpPost]
        public Placement Post([FromBody] Placement placement)
        {
            placements.Add(placement);
            return placement;
        }

        // PUT api/<PlacementController>/5
        [HttpPut("{id}")]
        public Placement Put(string idWorker, [FromBody] Placement placement)
        {
            int index = placements.FindIndex(p => p.IdWorker.Equals(idWorker));
            placements[index].Day = placement.Day;
            placements[index].Morning = placement.Morning;
            placements[index].Evening = placement.Evening;
            placements[index].Night = placement.Night;
            placements[index].Idward = placement.Idward;
            return placements[index];
        }

        // DELETE api/<PlacementController>/5
        [HttpDelete("{id}")]
        public void Delete(string idWorker)
        {
            int index = placements.FindIndex(w => w.IdWorker.Equals(idWorker));
            placements.Remove(placements[index]);
        }
    }
}
