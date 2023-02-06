using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mishkasta.Common.Entities;

namespace Mishkasta.Repositories.EntityFrameworkCore.EntityConfigurations;

public abstract class LocalizedEntityConfigurationBase : IEntityTypeConfiguration<LocalizedEntity>
{
    public void Configure(EntityTypeBuilder<LocalizedEntity> builder)
    {
        builder.Ignore(e => e.Locale);

        AlsoConfigure(builder);
    }


    protected abstract void AlsoConfigure(EntityTypeBuilder<LocalizedEntity> builder);
}