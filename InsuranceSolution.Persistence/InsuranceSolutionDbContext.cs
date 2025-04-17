using InsuranceSolution.Domain.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InsuranceSolution.Persistence
{
    public class InsuranceSolutionDbContext : DbContext
    {
        public InsuranceSolutionDbContext(DbContextOptions<InsuranceSolutionDbContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Claim> Claim { get; set; }
        public DbSet<Policy> Policy { get; set; }
        public DbSet<Insurer> Insurer { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var insurerId = Guid.Parse("86e6cbcb-a869-4438-8081-60d8771d1d13");
            //var customerId = Guid.Parse("c5198e12-e205-4c62-83b0-b84237063c8b");
            //var policyId = Guid.Parse("54ad9cc6-96a3-4214-8086-b6ab689ec36d");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InsuranceSolutionDbContext).Assembly);

            #region Customer     
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = Guid.Parse("c5198e12-e205-4c62-83b0-b84237063c8b"),
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateOnly(1985, 5, 20),
                VatNumber = "123456789",
                SocialSecurityNumber = "12345678989",
                GovernmentID = "AB123456",
                Profession = "Engineer",
                Nationality = "Greek",
                Gender = eGender.Male,
                TaxOffice = "Athens Center",
                InsurerId = Guid.Parse("86e6cbcb-a869-4438-8081-60d8771d1d13")
            });
            modelBuilder.Entity<CustomerAddress>().ToTable("Customer_Address");
            modelBuilder.Entity<CustomerAddress>().HasData(new CustomerAddress
            {
                CustomerAddressId = Guid.Parse("c5c6a7e3-20cb-444a-860b-9b9e3f22c77c"),
                Prefecture = "Attica",
                City = "Athens",
                Address = "Ermou 15",
                ZipCode = "10563",
                CustomerId = Guid.Parse("c5198e12-e205-4c62-83b0-b84237063c8b"),
                AddressType = eAddressType.Home
            });
            modelBuilder.Entity<CustomerEmail>().ToTable("Customer_Email");
            modelBuilder.Entity<CustomerEmail>().HasData(new CustomerEmail
            {
                CustomerEmailId = Guid.Parse("f197b8c2-1233-4146-99a5-f2cef9f7fa39"),
                EmailAddress = "john.doe@example.com",
                CustomerId = Guid.Parse("c5198e12-e205-4c62-83b0-b84237063c8b"),
                EmailType = eEmailType.Personal
            });
            modelBuilder.Entity<CustomerPhone>().ToTable("Customer_Phone");
            modelBuilder.Entity<CustomerPhone>().HasData(new CustomerPhone
            {
                CustomerPhoneId = Guid.Parse("f15e5e51-62d9-4d67-9b57-f11517132af3"),
                Telephone = "6981234567",
                PhoneType = ePhoneType.Personal,
                CustomerId = Guid.Parse("c5198e12-e205-4c62-83b0-b84237063c8b"),
            });
            #endregion

            #region Insurer
            modelBuilder.Entity<Insurer>().ToTable("Insurer");
            modelBuilder.Entity<Insurer>().HasData(new Insurer
            {
                InsurerId = Guid.Parse("86e6cbcb-a869-4438-8081-60d8771d1d13"),
                InsurerName = "SafeLife Insurance",
                InsurerCode = "SLI001"
            });
            modelBuilder.Entity<InsurerEmail>().ToTable("Insurer_Email");
            modelBuilder.Entity<InsurerEmail>().HasData(new InsurerEmail
            {
                InsurerEmailId = Guid.Parse("4866f931-c4f1-4651-89c4-f7bad696f0fa"),
                EmailAddress = "support@safelife.gr",
                InsurerId = Guid.Parse("86e6cbcb-a869-4438-8081-60d8771d1d13"),
            });
            modelBuilder.Entity<InsurerPhone>().ToTable("Insurer_Phone");
            modelBuilder.Entity<InsurerPhone>().HasData(new InsurerPhone
            {
                InsurerTelephoneId = Guid.Parse("1f906a63-baf2-4bab-af37-0b9967ba2974"),
                Telephone = "2101234567",
                InsurerId = Guid.Parse("86e6cbcb-a869-4438-8081-60d8771d1d13"),
                phoneCategory = ePhoneCategory.LandLine,
            });
            #endregion

            #region Policy
            modelBuilder.Entity<Policy>().ToTable("Policy");
            modelBuilder.Entity<Policy>().Property(p => p.NetPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Policy>().Property(p => p.GrossPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Policy>().HasData(new Policy
            {
                PolicyId = Guid.Parse("54ad9cc6-96a3-4214-8086-b6ab689ec36d"),
                PolicyNumber = "POL123456",
                RenewalNumber = "REN001",
                AddendumNumber = "ADD001",
                StartDate = new DateTime(2024, 1, 1).ToUniversalTime(),
                EndDate = new DateTime(2025, 1, 1).ToUniversalTime(),
                NetPrice = 500,
                GrossPrice = 600,
                IsCanceled = false,
                IsExpired = false,
                Plates = "ΙΝΖ1234",
                PolicySector = ePolicySector.Motor,
                CustomerId = Guid.Parse("c5198e12-e205-4c62-83b0-b84237063c8b"),
            });
            #endregion

            #region Claim
            modelBuilder.Entity<Claim>().ToTable("Claim");
            modelBuilder.Entity<Claim>().Property(p => p.CompensationAmount).HasPrecision(18, 2);
            modelBuilder.Entity<Claim>().HasData(new Claim
            {
                ClaimId = Guid.Parse("f53401de-f34f-4cc2-870b-f3feef2936e1"),
                AnnouncementDate = new DateTime(2025, 4, 5).ToUniversalTime(),
                AccidentDate = new DateTime(2025, 4, 4).ToUniversalTime(),
                ClaimStatus = "Open",
                CompensationDate = new DateTime(2025, 4, 9).ToUniversalTime(),
                CompensationAmount = 100,
                AccidentAddress = "Egnatias 100",
                AccidentRegion = "Thessaloniki",
                PolicyId = Guid.Parse("54ad9cc6-96a3-4214-8086-b6ab689ec36d")
            });
            #endregion

            #region Enums
            modelBuilder.Entity<Customer>().Property(e => e.Gender).HasConversion<int>();
            modelBuilder.Entity<CustomerAddress>().Property(e => e.AddressType).HasConversion<int>();
            modelBuilder.Entity<CustomerEmail>().Property(e => e.EmailType).HasConversion<int>();
            modelBuilder.Entity<CustomerPhone>().Property(e => e.PhoneCategory).HasConversion<int>();
            modelBuilder.Entity<CustomerPhone>().Property(e => e.PhoneType).HasConversion<int>();
            modelBuilder.Entity<Policy>().Property(e => e.PolicySector).HasConversion<int>();
            #endregion
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

