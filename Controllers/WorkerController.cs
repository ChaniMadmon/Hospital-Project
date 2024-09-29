using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private static new List<Worker> workers = new List<Worker>
        {
            new Worker {Id = "111111", Name = "aaa", Role = "דוקטור" },
            new Worker {Id = "222222", Name = "bbb", Role = "אחות" },
        };

        // GET: api/<Worker>
        [HttpGet]
        public IEnumerable<Worker> Get()
        {
            return workers;
        }

        // GET api/<Worker>/5
        [HttpGet("{id}")]
        public Worker Get(string id)
        {
            return (Worker)workers.Where(w => w.Id.Equals(id));
        }

        // POST api/<Worker>
        [HttpPost]
        public Worker Post([FromBody] Worker worker)
        {
            workers.Add(worker);
            return worker;
        }

        // PUT api/<Worker>/5
        [HttpPut("{id}")]
        public Worker Put(string id, [FromBody] Worker worker)
        {
            int index = workers.FindIndex(w => w.Id.Equals(id));
            workers[index].Name = worker.Name;
            workers[index].Role = worker.Role;
            return workers[index];
        }

        // DELETE api/<Worker>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            int index = workers.FindIndex(w => w.Id.Equals(id));
            workers.Remove(workers[index]);
        }
    }
}
