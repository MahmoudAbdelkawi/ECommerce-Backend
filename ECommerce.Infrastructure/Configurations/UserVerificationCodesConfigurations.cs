using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerce.Infrastructure.Configurations
{
    public class UserVerificationCodesConfigurations : IEntityTypeConfiguration<UserVerificationCodes>
    {
        public void Configure(EntityTypeBuilder<UserVerificationCodes> builder)
        {
            //builder.Property(x => x.ExpirationDate)
            //    .HasDefaultValue(DateTime.Now.AddMinutes(5));

            builder.Property(x => x.CanChangePassword)
                .HasDefaultValue(false);
        }
    }
}
