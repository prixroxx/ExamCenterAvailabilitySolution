using AvailabilityAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvailabilityAPI.Services
{
    public interface IExamCenterService
    {
        Task<int> AddExamCenter(ExamCenterTable center);

        Task<IEnumerable<ExamCenterTable>> GetAllCenters();

        Task<ExamCenterTable> GetExamCenterById(int examCenterId);
    }
}