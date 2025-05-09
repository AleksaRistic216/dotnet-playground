using LDSSM.Contracts.Entities;
using LDSSM.Contracts.Interfaces.IRepositories;
using LSCore.Repository;
using LSCore.Repository.Contracts;

namespace LDSSM.Repository.Repositories;

public class UserRepository(LDSSMDbContext dbContext)
	: LSCoreRepositoryBase<UserEntity>(dbContext),
		IUserRepository { }
