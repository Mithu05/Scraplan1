using Microsoft.EntityFrameworkCore;
using Scraplan_dotnet.Entities;
using Scraplan_dotnet.Global.Enums;

namespace Scraplan_dotnet.Data
{
    public class ScrapDbContext : DbContext

    {
        public ScrapDbContext(DbContextOptions<ScrapDbContext> options) : base(options)
        { }

        public DbSet<Careers> Careers { get; set; }
        public DbSet<AlembicVersion> AlembicVersions { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Driver>Drivers { get; set;}
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<FileEntity> FileEntities { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet <IssueDetail> IssueDetails { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderLog> OrderLogs { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PhonepePayment> PhonepePayments { get; set; }
        public DbSet<PhonepeRefund> PhonepeRefunds { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<User>Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasPostgresEnum<RoleEnum>();
        }

    }
}
