using Microsoft.AspNetCore.Mvc;
using InternshipWebApiCounter.Domain;

namespace InternshipWebApiCounter.Controllers
{
    [ApiController]
    [Route("/api/counter")]
    public class CounterController : ControllerBase
    {
        private readonly CounterRepository counterRepository;
        public CounterController(CounterRepository counterRepository)
        {
            this.counterRepository = counterRepository;
        }

        [HttpGet("get-counter")]
        public IActionResult GetCounter()
        {
            var (didGetSucceed, counter) = counterRepository.GetCounterValue();

            if (!didGetSucceed)
                return NotFound();

            return Ok(counter);
        }

        [HttpPost("increase-counter")]
        public IActionResult IncreaseCounter()
        {
            var didIncreaseSucceed = counterRepository.IncreaseCounter();

            if (!didIncreaseSucceed)
                return Forbid();

            return Ok();
        }
    }
}
