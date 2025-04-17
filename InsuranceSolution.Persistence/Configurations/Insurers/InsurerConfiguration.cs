namespace InsuranceSolution.Persistence.Configurations.Insurers
{
    internal class InsurerConfiguration : IEntityTypeConfiguration<Insurer>
    {
        public void Configure(EntityTypeBuilder<Insurer> builder)
        {
            builder.HasKey(e => e.InsurerId);
            builder.HasIndex(e => e.InsurerCode);
            builder.Property(e => e.InsurerName)
                .HasMaxLength(50);
            builder.Property(e => e.InsurerCode)
                .HasMaxLength(6);   
        }
    }
}
