using System.Data.Entity;

namespace BanVe.Models
{
    public class ContextCS : DbContext
    {
        public ContextCS() : base("name=BanVeDb")
        {

        }
        public DbSet<AdminLogic> AdminLogics { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<AeroPlaneInfo> AeroPlaneInfos { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }
    }
}