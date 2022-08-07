using Microsoft.EntityFrameworkCore;

namespace NetReactJs.Models
{
    public class DonationDBContext : DbContext
    {
        public DonationDBContext(DbContextOptions<DonationDBContext> options):base(options)
        {

        }

        public DbSet<DCandidate> Dcandidates { get; set; }
    }
}
