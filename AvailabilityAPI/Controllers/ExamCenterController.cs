using AvailabilityAPI.Models;
using AvailabilityAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AvailabilityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamCenterController : ControllerBase
    {
        private readonly IExamCenterService _examCenterService;
        public ExamCenterController(IExamCenterService examCenterService)
        {
            _examCenterService = examCenterService;
        }

        [HttpGet]
        public async Task<IEnumerable<ExamCenterTable>> GetAllCenters()
        {
            return await _examCenterService.GetAllCenters();
        }

        [HttpGet("{centerId:int}")]
        public async Task<ExamCenterTable> GetCenterById(int centerId)
        {
            return await _examCenterService.GetExamCenterById(centerId);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExamCenter(ExamCenterTable center)
        {

            int id = await _examCenterService.AddExamCenter(center);
            return Ok(id);
        }




    }
}
