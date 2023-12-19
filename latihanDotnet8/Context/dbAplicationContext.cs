using latihanDotnet8.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace latihanDotnet8.Context
{
    public class dbAplicationContext : DbContext
    {
        private readonly IConfiguration config;

        public dbAplicationContext(DbContextOptions<dbAplicationContext> options, IConfiguration _config) : base(options) {
            config = _config;
        }

        public DbSet<Pengguna> Pengguna { get; set; }
    }
}
