using Microsoft.EntityFrameworkCore;
using UbsAPI.Models;

namespace UbsAPI.Data
{
    public class UbsDbContext : DbContext
    {
        public UbsDbContext
        (DbContextOptions<UbsDbContext> options) : base(options)
        { }

        public DbSet<MedicoModel> Medicos { get; set; }
    }
}
