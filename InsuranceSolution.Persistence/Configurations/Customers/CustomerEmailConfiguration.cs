namespace InsuranceSolution.Persistence.Configurations.Customers
{
    internal class CustomerEmailConfiguration : IEntityTypeConfiguration<CustomerEmail>
    {
        public void Configure(EntityTypeBuilder<CustomerEmail> builder)
        {
            builder.HasKey(e => e.CustomerEmailId);
            builder.Property(e => e.EmailAddress)
                .HasMaxLength(50);
        }
    }
}
