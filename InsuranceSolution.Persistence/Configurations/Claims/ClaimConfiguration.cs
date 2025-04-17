namespace InsuranceSolution.Persistence.Configurations.Claims
{
    internal class ClaimConfiguration : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.HasKey(e => e.ClaimId);
        }
    }
}
