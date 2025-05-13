using Common.Contracts.Entities;
using Common.Contracts.Interfaces.IRepositories;
using LSCore.Repository;

namespace Common.Repository.Repositories;

public class UserRepository(CommonDbContext dbContext)
	: LSCoreRepositoryBase<UserEntity>(dbContext),
		IUserRepository { }
