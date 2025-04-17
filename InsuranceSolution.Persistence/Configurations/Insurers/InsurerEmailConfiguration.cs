namespace InsuranceSolution.Persistence.Configurations.Insurers
{
    internal class InsurerEmailConfiguration : IEntityTypeConfiguration<InsurerEmail>
    {
        public void Configure(EntityTypeBuilder<InsurerEmail> builder)
        {
            builder.HasKey(e => e.InsurerEmailId);
            builder.Property(e => e.EmailAddress)
                .HasMaxLength(50);
        }
    }
}
