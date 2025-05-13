using LSCore.Repository.Contracts;

namespace Common.Contracts.Entities;

public class UserEntity : LSCoreEntity
{
	public string Name { get; set; } = null!;
	public string City { get; set; } = null!;
	public string Country { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string Phone { get; set; } = null!;
	public string Address { get; set; } = null!;
	public string PostalCode { get; set; } = null!;
	public int Age { get; set; }
}
