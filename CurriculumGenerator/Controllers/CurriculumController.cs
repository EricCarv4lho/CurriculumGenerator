using CurriculumGenerator.Entities;
using CurriculumGenerator.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumGenerator.Controllers
{
    [ApiController]
    [Route("api/curriculum")]
    public class CurriculumController : Controller
    {  
        private readonly CurriculumService _curriculumService;

        public CurriculumController(CurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }

        [HttpPost("generate")]
        public IActionResult GenerateCurriculum(Curriculum curriculum)
        {  
            var result = _curriculumService.GenerateCurriculum(curriculum);
            return File(result, "application/pdf", "curriculum.pdf");
        }
    }
}
