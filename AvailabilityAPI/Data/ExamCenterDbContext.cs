//using Microsoft.EntityFrameworkCore.Storage;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using AvailabilityAPI.Models;

//namespace AvailabilityAPI.Data
//{
//    public class ExamCenterDbContext : DbContext
//    {
//        public ExamCenterDbContext(DbContextOptions<ExamCenterDbContext> dbContextOptions) : base(dbContextOptions)
//        {
//            try
//            {
//                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
//                if (databaseCreator != null)
//                {
//                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
//                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();

//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }

//        public DbSet<ExamCenterTable> ExamCenters { get; set; }

//    }
//}
