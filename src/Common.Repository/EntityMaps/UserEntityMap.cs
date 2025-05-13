using Common.Contracts.Entities;
using LSCore.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Repository.EntityMaps;

internal class UserEntityMap : LSCoreEntityMap<UserEntity>
{
	public override Action<EntityTypeBuilder<UserEntity>> Mapper { get; } =
		(builder) =>
		{
			builder.Property(x => x.Age).IsRequired();
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Address).IsRequired();
			builder.Property(x => x.Email).IsRequired();
			builder.Property(x => x.Phone).IsRequired();
			builder.Property(x => x.City).IsRequired();
			builder.Property(x => x.Country).IsRequired();
			builder.Property(x => x.PostalCode).IsRequired();
		};
}
