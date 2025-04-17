namespace InsuranceSolution.Persistence.Configurations.Insurers
{
    internal class InsurerPhoneConfiguration : IEntityTypeConfiguration<InsurerPhone>
    {
        public void Configure(EntityTypeBuilder<InsurerPhone> builder)
        {
            builder.HasKey(e => e.InsurerTelephoneId);
            builder.Property(e => e.Telephone)
                .HasMaxLength(10);
        }
    }
}
