using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mishkasta.Common.Entities;

namespace Mishkasta.Repositories.EntityFrameworkCore.EntityConfigurations;

public abstract class LocalizedEntityConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : LocalizedEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Ignore(e => e.Locale);

        AlsoConfigure(builder);
    }


    protected abstract void AlsoConfigure(EntityTypeBuilder<TEntity> builder);
}