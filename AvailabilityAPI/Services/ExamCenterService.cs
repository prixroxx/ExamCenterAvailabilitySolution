using AvailabilityAPI.Data;
using AvailabilityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvailabilityAPI.Services
{
    public class ExamCenterService : IExamCenterService
    {
        private readonly AvailabilityDbContext _context;

        public ExamCenterService(AvailabilityDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExamCenterTable>> GetAllCenters()
        {
            return await _context.ExamCenters.ToListAsync();
        }

        public async Task<ExamCenterTable> GetExamCenterById(int examCenterId)
        {
            var center = await _context.ExamCenters.FindAsync(examCenterId);
            return center;
        }

        public async Task<int> AddExamCenter(ExamCenterTable center)
        {
            try
            {
                await _context.ExamCenters.AddAsync(center);
                await _context.SaveChangesAsync();
                return center.Id;
            }
            catch (Exception ex)
            {
                return -9999;
            }
            
        }
    }
}
