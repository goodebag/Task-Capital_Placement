using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Capital_Placement.Core.Entities;
using Task_Capital_Placement.Core.Models;
using Task_Capital_Placement.Data;

namespace Task_Capital_Placement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammeController : ControllerBase
    {
        private readonly IProgrammeRepository _programmeRepository;
        private readonly IUserRepository _userRepository;
        public ProgrammeController(IProgrammeRepository programmeRepository, IUserRepository userRepository)
        {
            _programmeRepository = programmeRepository;
            _userRepository = userRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Programme>>> GetAll()
        {
            var questions = await _programmeRepository.GetAllAsync();
            return Ok(questions);
        }
      

        [HttpGet("GetById/{programmeId}")]
        public async Task<ActionResult<Programme>> GetById(string programmeId)
        {
            var programme = await _programmeRepository.GetByIdAsync(programmeId);
            if (programme == null)
            {
                return NotFound();
            }
            return programme;
        }
        [HttpPost]
        public async Task<ActionResult<Programme>> Create(ProgrammeDto programme)
        {
          

            var created = await _programmeRepository.Create(programme);
            return CreatedAtAction(nameof(GetById), new { programmeId = created.Id }, created);
        }
        [HttpPut("{programmeId}")]
        public async Task<ActionResult<Programme>> Update(string programmeId, Programme programme)
        {
            var existingTask = await _programmeRepository.GetByIdAsync(programmeId);
            if (existingTask == null)
            {
                return NotFound();
            }

            programme.Id = existingTask.Id; // Preserve the original ID

            var updated = await _programmeRepository.UpdateAsync(programme);
            return Ok(updated);
        }
        [HttpPost("Candidate/Apply")]
        public async Task<ActionResult<Programme>> Apply(UserCreationDTO data)
        {
            var created = await _userRepository.CreateUser(data);
            return Ok(created);
        }
    }
}
