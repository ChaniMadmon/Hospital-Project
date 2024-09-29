using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private static new List<Ward> wards = new List<Ward>
        {
            new Ward {Id = 1, Name = "כירורגיה" },
            new Ward {Id = 1, Name = "יולדות" },
        };

        // GET: api/<WardController>
        [HttpGet]
        public IEnumerable<Ward> Get()
        {
            return wards;
        }

        //// GET api/<WardController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<WardController>
        [HttpPost]
        public Ward Post([FromBody] Ward ward)
        {
            if(wards.Count == 0)
                ward.Id = 1;
            else
                ward.Id = wards.Last().Id + 1;
            wards.Add(ward);
            return ward;
        }

        // PUT api/<WardController>/5
        [HttpPut("{id}")]
        public Ward Put(int id, [FromBody] Ward ward)
        {
            int index = wards.FindIndex(w => w.Id == id);
            wards[index].Name = ward.Name;
            return wards[index];
        }

        // DELETE api/<WardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int index = wards.FindIndex(w => w.Id == id);
            wards.Remove(wards[index]);
        }
    }
}
