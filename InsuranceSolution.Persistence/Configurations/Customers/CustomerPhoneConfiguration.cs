namespace InsuranceSolution.Persistence.Configurations.Customers
{
    internal class CustomerPhoneConfiguration : IEntityTypeConfiguration<CustomerPhone>
    {
        public void Configure(EntityTypeBuilder<CustomerPhone> builder)
        {
            builder.HasKey(e => e.CustomerPhoneId);
            builder.Property(e => e.Telephone)
              .HasMaxLength(10);
        }
    }
}
