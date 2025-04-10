namespace InsuranceSolution.Persistence.Configurations.Policies
{
    internal class PolicyConfiguration: IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.HasKey(e => e.PolicyId);
            builder.HasIndex(e => e.PolicyNumber);
            builder.Property(e => e.PolicyNumber)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(e => e.RenewalNumber)
                .HasMaxLength(11);
            builder.Property(e => e.AddendumNumber)
                .HasMaxLength(11);
            builder.Property(e => e.Plates)
                .HasMaxLength(7);
        }
    }
}
