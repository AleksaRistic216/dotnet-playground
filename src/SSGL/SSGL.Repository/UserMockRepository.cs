using Bogus;
using Common.Contracts.Entities;
using Common.Contracts.Interfaces.IRepositories;

namespace SSGL.Repository
{
	public class UserMockRepository : IUserRepository
	{
		private static Faker<UserEntity> _usersFactory = new Faker<UserEntity>()
			.RuleFor(x => x.Id, (f, u) => f.IndexFaker)
			.RuleFor(x => x.Name, (f, u) => f.Name.FullName())
			.RuleFor(x => x.City, (f, u) => f.Address.City())
			.RuleFor(x => x.Country, (f, u) => f.Address.Country())
			.RuleFor(x => x.Email, (f, u) => f.Internet.Email())
			.RuleFor(x => x.Phone, (f, u) => f.Phone.PhoneNumber())
			.RuleFor(x => x.Address, (f, u) => f.Address.StreetAddress())
			.RuleFor(x => x.PostalCode, (f, u) => f.Address.ZipCode())
			.RuleFor(x => x.Age, (f, u) => f.Random.Int(18, 80));
		private static List<UserEntity> _users = _usersFactory.Generate(1000);

		public UserEntity Get(long id)
		{
			throw new NotImplementedException();
		}

		public UserEntity? GetOrDefault(long id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<UserEntity> GetMultiple() => _users.AsQueryable();

		public void Insert(UserEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Insert(IEnumerable<UserEntity> entities)
		{
			throw new NotImplementedException();
		}

		public void Update(UserEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Update(IEnumerable<UserEntity> entities)
		{
			throw new NotImplementedException();
		}

		public void UpdateOrInsert(UserEntity entity)
		{
			throw new NotImplementedException();
		}

		public void SoftDelete(long id)
		{
			throw new NotImplementedException();
		}

		public void HardDelete(long id)
		{
			throw new NotImplementedException();
		}

		public void SoftDelete(UserEntity entity)
		{
			throw new NotImplementedException();
		}

		public void HardDelete(UserEntity entity)
		{
			throw new NotImplementedException();
		}

		public void SoftDelete(IEnumerable<long> ids)
		{
			throw new NotImplementedException();
		}

		public void HardDelete(IEnumerable<long> ids)
		{
			throw new NotImplementedException();
		}

		public void SoftDelete(IEnumerable<UserEntity> entities)
		{
			throw new NotImplementedException();
		}

		public void HardDelete(IEnumerable<UserEntity> entities)
		{
			throw new NotImplementedException();
		}
	}
}
