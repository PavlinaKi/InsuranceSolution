namespace InsuranceSolution.Persistence.Configurations.Customers
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.CustomerId);
            builder.HasIndex(e => e.VatNumber);
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.LastName)
                 .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.VatNumber)
                .HasMaxLength(9);
            builder.Property(e => e.SocialSecurityNumber)
                .HasMaxLength(11);
            builder.Property(e => e.GovernmentID)
                .HasMaxLength(8);
            builder.Property(e => e.Profession)
                .HasMaxLength(50);
            builder.Property(e => e.Nationality)
                .HasMaxLength(50);
            builder.Property(e => e.TaxOffice)
              .HasMaxLength(50);
        }
    }
}
