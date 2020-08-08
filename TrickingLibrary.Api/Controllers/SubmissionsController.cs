using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrickingLibrary.Data;
using TrickingLibrary.Models;

namespace TrickingLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionsController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public SubmissionsController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<Submission> All()
        {
            return _ctx.Submissions.ToList();
        }

        [HttpGet("{id}")]
        public Submission Get(int id)
        {
            return _ctx.Submissions.FirstOrDefault(x => x.Id.Equals(id));
        }

        [HttpPost]
        public async Task<Submission> Create([FromBody] Submission submission)
        {
            _ctx.Add(submission);
            await _ctx.SaveChangesAsync();
            return submission;
        }

        [HttpPut]
        public async Task<Submission> Update([FromBody] Submission submission)
        {
            if (submission.Id == 0) return null;

            _ctx.Add(submission);
            await _ctx.SaveChangesAsync();
            return submission;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var submission = _ctx.Submissions.FirstOrDefault(x => x.Id.Equals(id));

            if (submission == null) return NotFound();

            submission.Deleted = true;
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}